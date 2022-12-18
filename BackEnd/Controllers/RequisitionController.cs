using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace _NET_Office_Management_BackEnd.Controllers;

[ApiController]
public class RequisitionController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IInventoryRepository _inventory_repo;
    private readonly IRequisitionRepository _requisition_repo;
    private readonly IAccountUtil _account_util;

    public RequisitionController(ILogger<InventoryController> logger, IAccountUtil accountUtil, IInventoryRepository inventoryRepo, IRequisitionRepository requisitionRepo)
    {
        _logger = logger;
        _account_util = accountUtil;
        _requisition_repo = requisitionRepo;
        _inventory_repo = inventoryRepo;
    }

    [HttpGet, HttpPost]
    [Route("api/inventory/requisition/create")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<IActionResult> Create()
    {
        var userId = _account_util.AuthorizeRequest(Request);
        if (userId == null)
        {
            return Unauthorized();
        }

        if (Request.Method == "GET")
        {
            var inventoryList = (List<ResponseModels.InventoryResponseModel>)await _inventory_repo.GetAllList();
            return Ok(new
            {
                approver_list = await _account_util.GetAllResponseUser(),
                inventory_list = inventoryList,
            });
        }
        else if (Request.Method == "POST")
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var bodyJson = JObject.Parse(body);
                var title = bodyJson.GetValue("title")?.ToString();
                var amount = Convert.ToUInt32(bodyJson.GetValue("amount")?.ToString());
                var inventory = Convert.ToInt32(bodyJson.GetValue("inventory")?.ToString());
                var approver = Convert.ToInt32(bodyJson.GetValue("approver")?.ToString());
                var comment = bodyJson.GetValue("comment")?.ToString();

                if (!String.IsNullOrEmpty(title) && amount > 0 && inventory > 0 && approver > 0)
                {
                    await _requisition_repo.Create(userId.Value, title, inventory, approver, amount, comment);
                    return Ok("Requisition created");
                }
            }
        }

        return NotFound();
    }

    [HttpGet]
    [Route("api/inventory/requisition/my_list")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<IActionResult> GetMyList()
    {
        var userId = _account_util.AuthorizeRequest(Request);
        if (userId == null)
        {
            return Unauthorized();
        }
        if (Request.Method == "GET")
        {
            var list = (List<ResponseModels.RequisitionResponseModel>)await _requisition_repo.GetRequisitionListById(userId.Value);
            return Ok(new
            {
                requisition_list = list
            });
        }
        return NotFound();
    }
}
