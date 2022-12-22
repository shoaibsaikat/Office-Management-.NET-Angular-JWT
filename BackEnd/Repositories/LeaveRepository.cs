using Microsoft.EntityFrameworkCore;
using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

namespace _NET_Office_Management_BackEnd.Repositories;

class LeaveRepository : ILeaveRepository
{
    private readonly ApplicationDbContext _context;

    public LeaveRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    async Task<Boolean> ILeaveRepository.Create(AccountResponseModel user, string title, DateTime start, DateTime end, UInt32 days, string comment)
    {
        if (user.manager_id != null)
        {
            var leave = new Leave()
            {
                Title = title,
                UserId = user.id,
                ApproverId = user.manager_id.Value,
                StartDate = start,
                EndDate = end,
                DayCount = days,
                Comment = comment,
            };
            await _context.Leaves.AddAsync(leave);
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }

    async Task<IEnumerable<LeaveResponseModel>> ILeaveRepository.GetLeaveListById(int userId)
    {
        var list = await _context.Leaves
                            .Include(i => i.User)
                            .Where(i => i.UserId == userId)
                            .ToListAsync();
        // .Include() is a lazy loading, foreign tables are not by default included in query, rather they has to be explicitly loaded
        var responseList = new List<LeaveResponseModel>();
        foreach (var item in list)
        {
            var model = new LeaveResponseModel
            {
                id = item.Id,
                title = item.Title,
                start_date = item.StartDate,
                end_date = item.EndDate,
                day_count = item.DayCount,
                user = item.UserId,
                user_first_name = item.User.FirstName,
                user_last_name = item.User.LastName,
                approver = item.ApproverId,
                approved = item.Approved,
                comment = item.Comment,
                creation_date = item.CreationDate,
                approve_date = item.ApproveDate
            };
            responseList.Add(model);
        }
        return responseList;
    }
}