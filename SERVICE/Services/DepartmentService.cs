using CORE.Models;
using REPO.IRepositories;
using SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SERVICE.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
            
        }

        public async Task DeleteAsync(Department department)
        {
             await _repository.DeleteAsync(department);

            
        }

        public Task<IEnumerable<Department>> GetAllAsync()
        {
            return _repository.GetAllAsync();
            
        }

        public async Task<Department> SearchPatientByDepId(int id)
        {
            return await _repository.SearchPatientByDepId(id);

        }

        public async Task<Department> GetIdAsync(int id)
        {
            return await _repository.GetIdAsync(id);
        }

        public async Task InsertAsync(Department dep)
        {
             await _repository.InsertAsync(dep);
            
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Department dep)
        {
            await _repository.UpdateAsync(dep);
        }
    }
}
