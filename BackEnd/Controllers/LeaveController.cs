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
}