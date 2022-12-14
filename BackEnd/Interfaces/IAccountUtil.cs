using _NET_Office_Management_BackEnd.ResponseModels;

public interface IAccountUtil
{
    public int? AuthorizeRequest(HttpRequest request);
    public Task<AccountResponseModel?> AuthorizeUser(HttpRequest request);
    public Task<IEnumerable<AccountResponseModel>> GetAllUser();
    public Task<IEnumerable<AccountResponseModel>> GetAllRequisitionApprover();
    public Task<IEnumerable<AccountResponseModel>> GetAllRequisitionDistributor();
    public Task<IEnumerable<AccountResponseModel>> GetAllManager();
}