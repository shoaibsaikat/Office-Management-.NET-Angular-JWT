using Microsoft.EntityFrameworkCore;
using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

namespace _NET_Office_Management_BackEnd.Repositories;

class InventoryRepository : IInventoryRepository
{
    private readonly ApplicationDbContext _context;

    public InventoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    async Task<IEnumerable<InventoryResponseModel>> IInventoryRepository.GetAllList()
    {
        var list = await _context.Inventories.ToListAsync();
        var responseList = new List<InventoryResponseModel>();
        foreach (var item in list)
        {
            var model = new InventoryResponseModel {
                id = item.Id,
                name = item.Name,
                count = item.Count,
                unit = item.Unit
            };
            responseList.Add(model);
        }
        return responseList;
    }

    async Task<InventoryResponseModel?> IInventoryRepository.GetById(int id)
    {
        var item = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == id);
        if (item != null)
        {
            return new InventoryResponseModel
            {
                id = item.Id,
                name = item.Name,
                count = item.Count,
                unit = item.Unit,
                description = item.Description == null ? String.Empty : item.Description,
            };
        }
        return null;
    }

    async Task<Boolean> IInventoryRepository.Update(int id, UInt32 amount)
    {
        var item = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == id);
        if (item != null)
        {
            item.Count = amount;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    async Task<Boolean> IInventoryRepository.Create(string name, UInt32 count, string unit, string? description)
    {
        var inventory = new Inventory()
        {
            Name = name,
            Count = count,
            Unit = unit,
            Description = description
        };
        await _context.Inventories.AddAsync(inventory);        
        await _context.SaveChangesAsync();
        return true;
    }
}