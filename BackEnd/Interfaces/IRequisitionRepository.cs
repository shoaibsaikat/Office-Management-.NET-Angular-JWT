using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

public interface IRequisitionRepository
{
    public Task<Boolean> Create(int user, string title, int inventory, int apporver, UInt32 amount, string? comment);
    public Task<IEnumerable<RequisitionResponseModel>> GetRequisitionListById(int userId);
    public Task<int> GetListCount();
    public Task<IEnumerable<RequisitionResponseModel>> GetAllRequisitionList(int? page);
    public Task<IEnumerable<RequisitionResponseModel>> GetPendingApprovalList(int userId);
    public Task<Boolean> ApproveRequisition(int id, int distributorId);
    public Task<IEnumerable<RequisitionResponseModel>> GetPendingDistributionList(int userId);
    public Task<Boolean> DistributeRequisition(int id);
}