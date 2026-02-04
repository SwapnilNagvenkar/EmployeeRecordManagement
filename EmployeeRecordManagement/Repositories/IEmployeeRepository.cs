using EmployeeRecordManagement.Models;
using EmployeeRecordManagement.ViewModels;

namespace EmployeeRecordManagement.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeViewModel> GetByIdAsync(int id);

        //Task<List<EmployeeViewModel>> GetAllAsync();
        IQueryable<EmployeeViewModel> GetAllAsync();

        Task AddAsync(EmployeeViewModel employee);

        Task UpdateAsync(EmployeeViewModel employee);

        Task DeleteAsync(int Id);

        Task<List<Department>> GetAllDepartments();
    }
}
