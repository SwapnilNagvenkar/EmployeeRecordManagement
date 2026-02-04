using EmployeeRecordManagement;
using EmployeeRecordManagement.Data;
using EmployeeRecordManagement.Models;
using EmployeeRecordManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(EmployeeViewModel employee)
        {
            var newEmployee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                Email = employee.Email,
                Address = employee.Address,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId,
            };
            await _appDbContext.Employees.AddAsync(newEmployee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var employee = await _appDbContext.Employees.FindAsync(Id);
            if (employee != null)
            {
                _appDbContext.Employees.Remove(employee);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public IQueryable<EmployeeViewModel> GetAllAsync()
        {
            var employees = _appDbContext.Employees
            .Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                IsActive = e.IsActive,
                DepartmentId = e.DepartmentId
            });

            return employees;
        }
        //public async Task<List<EmployeeViewModel>> GetAllAsync()
        //{
        //    List<Employee> employees = await _appDbContext.Employees.ToListAsync();
        //    List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

        //    foreach (var employee in employees)
        //    {
        //        var employeeViewModel = new EmployeeViewModel
        //        {
        //            EmployeeId = employee.EmployeeId,
        //            FirstName = employee.FirstName,
        //            LastName = employee.LastName,
        //            DateOfBirth = employee.DateOfBirth,
        //            Gender = employee.Gender,
        //            Email = employee.Email,
        //            PhoneNumber = employee.PhoneNumber,
        //            Address = employee.Address,
        //            IsActive = employee.IsActive
        //        };

        //        employeeViewModels.Add(employeeViewModel);
        //    }

        //    return employeeViewModels;
        //}

        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId
            };
            return employeeViewModel;
        }

        public async Task UpdateAsync(EmployeeViewModel employeeUpdated)
        {
            var employee = await _appDbContext.Employees.FindAsync(employeeUpdated.EmployeeId);

            if (employee != null) // Add this safety check
            {
                employee.FirstName = employeeUpdated.FirstName;
                employee.LastName = employeeUpdated.LastName;
                employee.Email = employeeUpdated.Email;
                employee.DateOfBirth = employeeUpdated.DateOfBirth;
                employee.PhoneNumber = employeeUpdated.PhoneNumber;
                employee.Address = employeeUpdated.Address;
                employee.DepartmentId = employeeUpdated.DepartmentId;
                employee.IsActive = employeeUpdated.IsActive;
                _appDbContext.Employees.Update(employee);
                await _appDbContext.SaveChangesAsync();
            }
        }


        public async Task<List<Department>> GetAllDepartments()
        {
            return await _appDbContext.Departments.ToListAsync();
        }
    }
}
