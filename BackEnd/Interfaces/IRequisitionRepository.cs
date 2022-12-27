using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

public interface IRequisitionRepository
{
    public Task<Boolean> Create(int user, string title, int inventory, int apporver, UInt32 amount, string? comment);
    public Task<int> GetListCountById(int userId);
    public Task<IEnumerable<RequisitionResponseModel>> GetRequisitionListById(int userId, int? page);
    public Task<int> GetListCount();
    public Task<IEnumerable<RequisitionResponseModel>> GetAllRequisitionList(int? page);
    public Task<int> GetPendingApprovalListCount(int approverId);
    public Task<IEnumerable<RequisitionResponseModel>> GetPendingApprovalList(int userId, int? page);
    public Task<Boolean> ApproveRequisition(int id, int distributorId);
    public Task<int> GetPendingDistributionListCount(int distributorId);
    public Task<IEnumerable<RequisitionResponseModel>> GetPendingDistributionList(int userId, int? page);
    public Task<Boolean> DistributeRequisition(int id);
}