using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface IDepartmentService
    {
        Task InsertAsync(Department dep);
        Task UpdateAsync(Department dep);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetIdAsync(int id);
    }
}
