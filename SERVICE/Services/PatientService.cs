using CORE.Models;
using REPO.DATA;
using REPO.IRepositories;
using SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;


        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }



        public async Task DeleteAsync(Patient patient)
        {
            await _patientRepository.DeleteAsync(patient);
        }

        public Task<IEnumerable<Patient>> GetAllAsync()
        {
            return _patientRepository.GetAllAsync();
        }

        public Task<Patient> GetIdAsync(int id)
        {
            return _patientRepository.GetIdAsync(id);

        }

      

       

        public async Task InsertAsync(Patient patient)
        {
            await _patientRepository.InsertAsync(patient);


        }


        public async Task SaveChangesAsync()
        {
            await _patientRepository.SaveChangesAsync();

        }

        public async Task UpdateAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }

        Task<List<Patient>> IPatientService.GetPatientByDepIdAsync(int id)
        {
            return _patientRepository.GetPatientByDepIdAsync(id);
        }
    }

      
}
