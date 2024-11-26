using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services
{
    public interface ILeaveTypeServices
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEditVM);
        Task Create(LeaveTypeCreateVM leaveTypeCreateVM);
        Task Edit(LeaveTypeEditVM leaveTypeEditVM);
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypeAsync();
        Task<T?> GetLeaveTypeAsync<T>(int id) where T : class;
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}