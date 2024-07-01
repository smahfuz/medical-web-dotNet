using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface IPatientService
    {
        Task InsertAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetIdAsync(int id);
    }
}
