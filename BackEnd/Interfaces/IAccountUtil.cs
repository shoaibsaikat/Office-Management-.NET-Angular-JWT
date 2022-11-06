using _NET_Office_Management_BackEnd.ResponseModels;

public interface IAccountUtil
{
    public int? AuthorizeRequest(HttpRequest request);
    public Task<AccountResponseModel?> AuthorizeUser(HttpRequest request);
    public Task<IEnumerable<AccountResponseModel>> GetAllResponseUser();
}