using EmployeeRecordManagement.Models;
using EmployeeRecordManagement.Repositories;
using EmployeeRecordManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRecordManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            //Fetch DB data
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }

        //GET: Department/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //POST: Department/Add
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model); //return ToString form with validation errors
            }
            await _departmentRepository.AddAsync(model);
            return RedirectToAction("Index", "Department");
        }

        //GET: /Department/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return View(department);
        }

        //POST: /Department/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel department)
        {

            if (ModelState.IsValid)
            {
                //Update the database with modified details
                await _departmentRepository.UpdateAsync(department);

                // Redirect to List all department page
                return RedirectToAction("Index", "Department");
            }

            // If the model is not valid, return the view with the validation errors
            return View(department);
        }

        //GET: /Department/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //Delete the data from database
            await _departmentRepository.DeleteAsync(id);

            // Redirect to List all department page
            return RedirectToAction("Index", "Department");
        }
    }
}
