using CORE.Models;
using Microsoft.EntityFrameworkCore;
using REPO.DATA;
using REPO.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly MyDbContext _dbContext;
        public DepartmentRepository(MyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Department> SearchPatientByDepId(int id)
        {
            return await _dbContext.Departments.Include(x=>x.Patients).FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
