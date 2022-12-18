using Microsoft.EntityFrameworkCore;
using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

namespace _NET_Office_Management_BackEnd.Repositories;

class RequisitionRepository : IRequisitionRepository
{
    private readonly ApplicationDbContext _context;

    public RequisitionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    async Task<Boolean> IRequisitionRepository.Create(int user, string title, int inventory, int apporver, UInt32 amount, string? comment)
    {
        var requisition = new Requisition()
        {
            Title = title,
            Amount = amount,
            Comment = comment,
            RequestDate = DateTime.UtcNow,
            UserId = user,
            ApproverId = apporver,
            InventoryId = inventory
        };
        await _context.Requisitions.AddAsync(requisition);
        await _context.SaveChangesAsync();
        return true;
    }

    async Task<IEnumerable<RequisitionResponseModel>> IRequisitionRepository.GetRequisitionListById(int userId)
    {
        var list = await _context.Requisitions
                            .Include(i => i.User)
                            .Include(i => i.Inventory)
                            .Include(i => i.Approver)
                            .Include(i => i.Distributor)
                            .Where(i => i.UserId == userId)
                            .ToListAsync();
        // .Include() is a lazy loading, foreign tables are not by default included in query, rather they has to be explicitly loaded
        var responseList = new List<RequisitionResponseModel>();
        foreach (var item in list)
        {
            var model = new RequisitionResponseModel {
                id = item.Id,
                item_name = item.Inventory.Name,
                title = item.Title,
                date = item.RequestDate,
                amount = item.Amount,
                total = item.Inventory.Count,
                unit = item.Inventory.Unit,
                user_id = item.UserId,
                user_name = item.User.FirstName + " " + item.User.LastName,
                approver_id = item.ApproverId,
                approver_name = item.Approver.FirstName + " " + item.Approver.LastName,
                distributor_id = item.DistributorId,
                distributor_name = item.Distributor?.FirstName + " " + item.Distributor?.LastName,
                approved = item.Approved,
                distributed = item.Distributed,
                comment = item.Comment
            };
            responseList.Add(model);
        }
        return responseList;
    }
}