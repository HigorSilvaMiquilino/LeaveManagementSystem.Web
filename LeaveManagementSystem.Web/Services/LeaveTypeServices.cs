using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LeaveManagementSystem.Web.Services;

public class LeaveTypeServices : ILeaveTypeServices
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public LeaveTypeServices(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypeAsync()
    {
        var data = await _context.LeaveTypes.ToListAsync();
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T?> GetLeaveTypeAsync<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

    }

    public async Task Edit(LeaveTypeEditVM leaveTypeEditVM)
    {
        var leaveType = _mapper.Map<LeaveType>(leaveTypeEditVM);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }


    public async Task Create(LeaveTypeCreateVM leaveTypeCreateVM)
    {
        var dataModel = new LeaveType
        {
            Name = leaveTypeCreateVM.Name,
            NumberOfDays = leaveTypeCreateVM.NumberOfDays
        };


        _context.Add(dataModel);
        await _context.SaveChangesAsync();
    }




    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowercaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(m => m.Name.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEditVM)
    {
        var lowercaseName = leaveTypeEditVM.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(m => m.Name.ToLower().Equals(lowercaseName)
        && m.Id != leaveTypeEditVM.Id);
    }
}
