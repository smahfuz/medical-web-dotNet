using CORE.Models;
using REPO.IRepositories;
using SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
            
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllAsync()
        {
            return _repository.GetAllAsync();
            
        }

        public Task<Department> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Department dep)
        {
             await _repository.InsertAsync(dep);
            
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Department dep)
        {
            throw new NotImplementedException();
        }
    }
}
