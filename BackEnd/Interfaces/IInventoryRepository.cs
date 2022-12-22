using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

public interface IInventoryRepository
{
    public Task<IEnumerable<InventoryResponseModel>> GetAllList(int? page);
    public Task<int> GetListCount();
    public Task<InventoryResponseModel?> GetById(int id);
    public Task<Boolean> Update(int id, UInt32 amount);
    public Task<Boolean> Create(string name, UInt32 count, string unit, string? description);
}