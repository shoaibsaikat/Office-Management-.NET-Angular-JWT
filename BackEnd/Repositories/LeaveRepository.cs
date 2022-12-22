using Microsoft.EntityFrameworkCore;
using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.ResponseModels;

namespace _NET_Office_Management_BackEnd.Repositories;

class LeaveRepository : ILeaveRepository
{
    private readonly ApplicationDbContext _context;

    public LeaveRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}