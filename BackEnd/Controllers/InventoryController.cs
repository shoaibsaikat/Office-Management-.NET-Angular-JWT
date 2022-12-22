using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace _NET_Office_Management_BackEnd.Controllers;

[ApiController]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IInventoryRepository _inventory_repo;
    private readonly IAccountUtil _account_util;

    public InventoryController(ILogger<InventoryController> logger, IAccountUtil accountUtil, IInventoryRepository repo)
    {
        _logger = logger;
        _account_util = accountUtil;
        _inventory_repo = repo;
    }

    [Route("api/inventory/inventory_list")]
    [HttpGet]
    public async Task<IActionResult> GetChartList()
    {
        return Ok(await _inventory_repo.GetAllList(null));
    }

    [Route("api/inventory/{page:int?}")]
    [HttpGet]
    public async Task<IActionResult> GetAllList(int? page)
    {
        var user = await _account_util.AuthorizeUser(Request);
        if (user == null || !(user.can_distribute_inventory || user.can_approve_inventory))
        {
            return Unauthorized();
        }

        var list = (List<ResponseModels.InventoryResponseModel>)await _inventory_repo.GetAllList(page);
        var count = await _inventory_repo.GetListCount();
        return Ok(new
        {
            count = count,
            inventory_list = list,
        });
    }

    [Route("api/inventory/quick_edit")]
    [HttpPost]
    public async Task<IActionResult> QuickUpdate()
    {
        var user = await _account_util.AuthorizeUser(Request);
        if (user == null || !(user.can_distribute_inventory || user.can_approve_inventory))
        {
            return Unauthorized();
        }

        using (var reader = new StreamReader(Request.Body))
        {
            var body = await reader.ReadToEndAsync();
            var bodyJson = JObject.Parse(body);
            var pk = Convert.ToInt32(bodyJson.GetValue("pk")?.ToString());
            var amount = Convert.ToUInt32(bodyJson.GetValue("amount")?.ToString());
            if (await _inventory_repo.Update(pk, amount))
            {
                return Ok("Inventory updated");
            }
            return NotFound("Asset assign failed");
        }
    }

    [HttpGet, HttpPost]
    [Route("api/inventory/edit/{id:int}")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<IActionResult> Update(int id)
    {
        var user = await _account_util.AuthorizeUser(Request);
        if (user == null || !(user.can_distribute_inventory || user.can_approve_inventory))
        {
            return Unauthorized();
        }

        if (Request.Method == "GET")
        {
            var item = await _inventory_repo.GetById(id);
            if (item != null)
            {
                return Ok(new
                {
                    description = item.description
                });
            }
            return NotFound("Inventory not found");
        }
        else if (Request.Method == "POST")
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var bodyJson = JObject.Parse(body);
                var amount = Convert.ToUInt32(bodyJson.GetValue("count")?.ToString());
                var description = bodyJson.GetValue("description")?.ToString();
                if (await _inventory_repo.Update(id, amount))
                {
                    return Ok("Inventory updated");
                }
                return NotFound("Inventory assign failed");
            }
        }
        return NotFound();
    }

    [HttpPost]
    [Route("api/inventory/create")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<IActionResult> Create()
    {
        var userId = _account_util.AuthorizeRequest(Request);
        if (userId == null)
        {
            return Unauthorized();
        }

        using (var reader = new StreamReader(Request.Body))
        {
            var body = await reader.ReadToEndAsync();
            var bodyJson = JObject.Parse(body);
            var name = bodyJson.GetValue("name")?.ToString();
            var count = Convert.ToUInt32(bodyJson.GetValue("count")?.ToString());
            var unit = bodyJson.GetValue("unit")?.ToString();
            var description = bodyJson.GetValue("description")?.ToString();

            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(unit))
            {
                await _inventory_repo.Create(name, count, unit, description);
                return Ok("Asset created");
            }
        }
        return NotFound();
    }
}
