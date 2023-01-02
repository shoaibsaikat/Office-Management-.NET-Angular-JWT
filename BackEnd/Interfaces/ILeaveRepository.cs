using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

public interface ILeaveRepository
{
    public Task<bool> Create(AccountResponseModel user, string title, DateTime start, DateTime end, UInt32 days, string comment);
    public Task<int> GetListCountById(int userId);
    public Task<IEnumerable<LeaveResponseModel>> GetLeaveListById(int userId, int? page);
    public Task<int> GetPendingApprovalListCount(int approverId);
    public Task<IEnumerable<LeaveResponseModel>> GetPendingApprovalList(int approverId, int? page);
    public Task<bool> ApproveLeave(int id);
    public Task<bool> DenyLeave(int id);
    public Task<IEnumerable<LeaveSummaryResponseModel>> GetLeaveSummary(int year);
}