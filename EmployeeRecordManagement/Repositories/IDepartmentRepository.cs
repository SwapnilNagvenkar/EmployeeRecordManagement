using EmployeeRecordManagement.Models;
using EmployeeRecordManagement.ViewModels;

namespace EmployeeRecordManagement.Repositories
{
    public interface IDepartmentRepository
    {
        Task<DepartmentViewModel> GetByIdAsync(int id);

        Task<List<DepartmentViewModel>> GetAllAsync();

        Task AddAsync(DepartmentViewModel department);

        Task UpdateAsync(DepartmentViewModel department);

        Task DeleteAsync(int Id);
    }
}
