using _NET_Office_Management_BackEnd.ResponseModels;

namespace _NET_Office_Management_BackEnd.Utils;

class AccountUtil : IAccountUtil
{
    private readonly IAccountRepository _account_repo;
    private readonly ITokenUtil _tokenUtil;

    public AccountUtil(ITokenUtil token, IAccountRepository repo)
    {
        _tokenUtil = token;
        _account_repo = repo;
    }

    int? IAccountUtil.AuthorizeRequest(HttpRequest request)
    {
        var token = request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        // string headers = String.Empty;
        // foreach (var header in request.Headers)
        //     headers += header + Environment.NewLine;
        // Console.WriteLine("DEBUG: Got request: " + request.Headers["Authorization"].FirstOrDefault());

        return _tokenUtil.ValidateToken(token);
    }

    async Task<AccountResponseModel?> IAccountUtil.AuthorizeUser(HttpRequest request)
    {
        var userId = _tokenUtil.ValidateToken(request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());
        if (userId != null)
        {
            return await _account_repo.GetUserById(userId.Value);
        }
        return null;
    }

    async Task<IEnumerable<AccountResponseModel>> IAccountUtil.GetAllRequisitionApprover()
    {
        return await _account_repo.GetAllRequisitionApprover();
    }

    async Task<IEnumerable<AccountResponseModel>> IAccountUtil.GetAllRequisitionDistributor()
    {
        return await _account_repo.GetAllRequisitionDistributor();
    }

    async Task<IEnumerable<AccountResponseModel>> IAccountUtil.GetAllManager()
    {
        return await _account_repo.GetAllManager();
    }

    async Task<IEnumerable<AccountResponseModel>> IAccountUtil.GetAllUser()
    {
        return await _account_repo.GetAllUser();
    }

}