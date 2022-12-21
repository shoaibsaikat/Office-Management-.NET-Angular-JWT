using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

public interface IRequisitionRepository
{
    public Task<Boolean> Create(int user, string title, int inventory, int apporver, UInt32 amount, string? comment);
    public Task<IEnumerable<RequisitionResponseModel>> GetRequisitionListById(int userId);
    public Task<IEnumerable<RequisitionResponseModel>> GetAllRequisitionList();
}