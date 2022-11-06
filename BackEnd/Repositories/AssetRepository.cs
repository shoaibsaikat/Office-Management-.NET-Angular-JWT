using Microsoft.EntityFrameworkCore;
using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

namespace _NET_Office_Management_BackEnd.Repositories;

class AssetRepository : IAssetRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IDictionary<int, string> _STATUS_CHOICE = new Dictionary<int, string>()
    {
        {0, "Working"},
        {1, "Repairing"},
        {2, "Busted"},
    };
    private readonly IDictionary<int, string> _TYPE_CHOICE = new Dictionary<int, string>()
    {
        {0, "Others"},
        {1, "Desktop"},
        {2, "Laptop"},
        {3, "Printer"},
    };

    public AssetRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    IDictionary<int, string> IAssetRepository.GetStatus()
    {
        return _STATUS_CHOICE;
    }

    IDictionary<int, string> IAssetRepository.GetType()
    {
        return _TYPE_CHOICE;
    }

    async Task<IEnumerable<AssetResponseModel>> IAssetRepository.GetAllList()
    {
        var assetList = new List<AssetResponseModel>();
        // eager loading
        // without eager loading we'll get null in item.User.FirstName
        var list = await _context.Assets.Include(u => u.User).ToListAsync();
        foreach (var item in list)
        {
            assetList.Add(new AssetResponseModel
            {
                id = item.Id,
                name = item.Name,
                type = item.Type,
                model = item.Model,
                status = item.Status,
                serial = item.Serial,
                warranty = item.Warranty,
                description = item.Description,
                purchase_date = item.PurchaseDate.ToShortDateString(),
                user_first_name = item.User.FirstName != null ? item.User.FirstName : String.Empty,
                user_last_name = item.User.LastName != null ? item.User.LastName : String.Empty,
                user = item.UserId,
                next_user = item.NextUserId,
            });
        }
        return assetList;
    }

    async Task<IEnumerable<AssetResponseModel>> IAssetRepository.GetMyList(int id)
    {
        var assetList = new List<AssetResponseModel>();
        // eager loading
        // without eager loading we'll get null in item.User.FirstName
        var list = await _context.Assets.Include(u => u.User).Where(i => i.UserId == id).ToListAsync();
        foreach (var item in list)
        {
            assetList.Add(new AssetResponseModel
            {
                id = item.Id,
                name = item.Name,
                type = item.Type,
                model = item.Model,
                status = item.Status,
                serial = item.Serial,
                warranty = item.Warranty,
                description = item.Description,
                purchase_date = item.PurchaseDate.ToShortDateString(),
                user = item.UserId,
                next_user = item.NextUserId,
            });
        }
        return assetList;
    }

    async Task<IEnumerable<AssetResponseModel>> IAssetRepository.GetMyPendingList(int id)
    {
        var assetList = new List<AssetResponseModel>();
        // eager loading
        // without eager loading we'll get null in item.User.FirstName
        var list = await _context.Assets.Include(u => u.User).Where(i => i.NextUserId == id).ToListAsync();
        foreach (var item in list)
        {
            assetList.Add(new AssetResponseModel
            {
                id = item.Id,
                name = item.Name,
                type = item.Type,
                model = item.Model,
                status = item.Status,
                serial = item.Serial,
                warranty = item.Warranty,
                description = item.Description,
                purchase_date = item.PurchaseDate.ToShortDateString(),
                user = item.UserId,
                next_user = item.NextUserId,
            });
        }
        return assetList;
    }

    async Task<AssetResponseModel?> IAssetRepository.GetById(int id)
    {
        var item = await _context.Assets.FirstOrDefaultAsync(i => i.Id == id);
        if (item != null)
        {
            return new AssetResponseModel
            {
                id = item.Id,
                name = item.Name,
                type = item.Type,
                model = item.Model,
                status = item.Status,
                serial = item.Serial,
                warranty = item.Warranty,
                description = item.Description,
                purchase_date = item.PurchaseDate.ToShortDateString(),
            };
        }
        return null;
    }

    async Task<Boolean> IAssetRepository.Update(int id, string name, ushort status, ulong warranty, string description)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(i => i.Id == id);
        if (asset == null)
        {
            return false;
        }

        asset.Name = name;
        asset.Warranty = warranty;
        asset.Status = status;
        asset.Description = description;
        await _context.SaveChangesAsync();
        return true;
    }

    async Task<Boolean> IAssetRepository.Create(int id, string name, string model, string serial, DateTime purchaseDate, ushort type, ushort status, ulong warranty, string description)
    {
        var asset = new Asset()
        {
            Name = name,
            Model = model,
            Serial = serial,
            PurchaseDate = purchaseDate,
            Type = type,
            Status = status,
            Warranty = warranty,
            Description = description,
            UserId = id
        };
        await _context.Assets.AddAsync(asset);

        var history = new AssetHistory()
        {
            AssetId = asset.Id,
            FromUserId = id,
            ToUserId = id,
            CreationDate = DateTime.UtcNow,
        };
        await _context.AssetHistories.AddAsync(history);
        
        await _context.SaveChangesAsync();
        return true;
    }

    async Task<Boolean> IAssetRepository.Assign(int id, int userId)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(i => i.Id == id);
        if (asset != null && asset.NextUserId == null)
        {
            asset.NextUserId = userId;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    async Task<Boolean> IAssetRepository.Accept(int id)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(i => i.Id == id);
        if (asset != null && asset.NextUserId != null)
        {
            var history = new AssetHistory()
            {
                AssetId = id,
                FromUserId = asset.UserId,
                ToUserId = asset.NextUserId.Value,
                CreationDate = DateTime.UtcNow,
            };
            await _context.AssetHistories.AddAsync(history);

            asset.UserId = asset.NextUserId.Value;
            asset.NextUserId = null;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    async Task<Boolean> IAssetRepository.Decline(int id)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(i => i.Id == id);
        if (asset != null)
        {
            asset.NextUserId = null;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}