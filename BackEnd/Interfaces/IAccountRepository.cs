using _NET_Office_Management_BackEnd.ResponseModels;

public interface IAccountRepository
{
    public Task<Boolean> RegisterUser(string? username, string? password, bool isSuperUser = false);
    public Task<Boolean> ValidatePassword(int id, string password);
    public Task<string> Login(string? username, string? password);
    public Task<AccountResponseModel> GetResponseUserById(int id);
    public Task<Boolean> SetPassword(int id, string password);
    public Task<Boolean> UpdateUserInfo(int id, string firstName, string lastName, string email);
    public Task<IEnumerable<AccountResponseModel>> GetAllResponseUser();
    public Task<Boolean> SetManager(int id, int mangerId);
}