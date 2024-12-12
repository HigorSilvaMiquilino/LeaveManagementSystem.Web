using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {

        private readonly ILeaveTypeServices _leaveTypeServices;

        public LeaveTypesController(ILeaveTypeServices leaveTypeServices)
        {
            this._leaveTypeServices = leaveTypeServices;

        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewData = await _leaveTypeServices.GetAllLeaveTypeAsync();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeServices.GetLeaveTypeAsync<LeaveTypeReadOnlyVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreateVM)
        {

            if (await _leaveTypeServices.CheckIfLeaveTypeNameExists(leaveTypeCreateVM.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreateVM.Name), "This leave type already exists in the data base");
            };

            if (ModelState.IsValid)
            {
                await _leaveTypeServices.Create(leaveTypeCreateVM);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreateVM);
        }



        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeServices.GetLeaveTypeAsync<LeaveTypeEditVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEditVM)
        {
            if (id != leaveTypeEditVM.Id)
            {
                return NotFound();
            }

            if (await _leaveTypeServices.CheckIfLeaveTypeNameExistsForEdit(leaveTypeEditVM))
            {
                ModelState.AddModelError(nameof(leaveTypeEditVM.Name), "This leave type already exists in the data base");
            };


            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypeServices.Edit(leaveTypeEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypeServices.LeaveTypeExists(leaveTypeEditVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEditVM);
        }


        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeServices.GetLeaveTypeAsync<LeaveTypeReadOnlyVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
