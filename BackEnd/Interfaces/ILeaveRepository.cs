using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

public interface ILeaveRepository
{
    public Task<Boolean> Create(AccountResponseModel user, string title, DateTime start, DateTime end, UInt32 days, string comment);
    public Task<IEnumerable<LeaveResponseModel>> GetLeaveListById(int userId);
    public Task<IEnumerable<LeaveResponseModel>> GetPendingApprovalList(int approverId);
    public Task<bool> ApproveLeave(int id);
}