using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace _NET_Office_Management_BackEnd.Controllers;

[ApiController]
public class LeaveController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly ILeaveRepository _leave_repo;
    private readonly IAccountUtil _account_util;

    public LeaveController(ILogger<InventoryController> logger, IAccountUtil accountUtil, ILeaveRepository leaveRepo)
    {
        _logger = logger;
        _account_util = accountUtil;
        _leave_repo = leaveRepo;
    }

    [HttpGet, HttpPost]
    [Route("api/leave/create")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<IActionResult> Create()
    {
        var user = await _account_util.AuthorizeUser(Request);
        if (user == null)
        {
            return Unauthorized();
        }

        if (Request.Method == "GET")
        {
            if (user.manager_id == null)
            {
                return NotFound(new
                {
                    detail = "Add manager first"
                });
            }
            return Ok();
        }
        // else if (Request.Method == "POST")
        // {
        //     using (var reader = new StreamReader(Request.Body))
        //     {
        //         var body = await reader.ReadToEndAsync();
        //         var bodyJson = JObject.Parse(body);
        //         var title = bodyJson.GetValue("title")?.ToString();
        //         var amount = Convert.ToUInt32(bodyJson.GetValue("amount")?.ToString());
        //         var inventory = Convert.ToInt32(bodyJson.GetValue("inventory")?.ToString());
        //         var approver = Convert.ToInt32(bodyJson.GetValue("approver")?.ToString());
        //         var comment = bodyJson.GetValue("comment")?.ToString();

        //         if (!String.IsNullOrEmpty(title) && amount > 0 && inventory > 0 && approver > 0)
        //         {
        //             await _requisition_repo.Create(user.id, title, inventory, approver, amount, comment);
        //             return Ok("Requisition created");
        //         }
        //     }
        // }

        return NotFound();
    }
}