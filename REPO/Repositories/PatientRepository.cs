using CORE.Models;
using REPO.DATA;
using REPO.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace REPO.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly MyDbContext _dbContext;
        public PatientRepository(MyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Patient>> GetPatientByDepIdAsync(int id)
        {
            return await _dbContext.Patients.Where(x => x.DepartmentId == id).ToListAsync();
        }
    }
}
