using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SERVICE.IServices;
using WEB_MEDICAL.ViewModels;

namespace WEB_MEDICAL.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IDepartmentService _departmentService;

        public PatientController(IPatientService patient, IDepartmentService departmentService)
        {
            _patientService = patient;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var ob = await _patientService.GetAllAsync();
            return View(ob);
        }

        
        public async Task<IActionResult> Create()
        {
            var obj1= new PatientView();
            obj1.DepartmentsList = _departmentService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.DepName
            }).ToList();

            return View(obj1);

        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientView pat)
        {
            if (ModelState.IsValid)
            {
                var obj = new Patient();
                obj.PatientName = pat.PatientName;
                obj.AdmitDate = pat.AdmitDate;
                obj.PatientDescription = pat.PatientDescription;
                obj.DepartmentId = pat.DepartmentId;

                await _patientService.InsertAsync(obj);
                return RedirectToAction("Index");

            }
            else
            {
                return View(null);
            }

        }

       public async Task<IActionResult> DepartmentPatient()
        {
            var obj1 = new DepartmentPatientView();
            obj1.Departments = _departmentService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.DepName
            }).ToList();

            return View(obj1);
        }
        [Produces("application/json")]  
        public async Task<IActionResult> GetPatient(int did)
        {
            var pat =await _patientService.GetPatientByDepIdAsync(did);
            return Json(pat);
        }




        public async Task<IActionResult> Delete(int id)
        {
           
            var obj= await _patientService.GetIdAsync(id);
            await _patientService.DeleteAsync(obj);
            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> GetPatientPar(int id)
        {
            Patient pat = await _patientService.GetIdAsync(id);
            Department dept = await _departmentService.GetIdAsync(pat.DepartmentId);

            //pat.Department = dept.DepName;
            var patv = new PatientView();
            patv.AdmitDate = pat.AdmitDate;
            patv.PatientDescription = pat.PatientDescription;
            patv.PatientName = pat.PatientName;
            patv.Department = dept.DepName;
            if (patv != null)
            {
                return PartialView("_PatientView", patv);
            }
            else
            {
                return null;
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var obj = await _patientService.GetIdAsync(id);
        //    return View(obj);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit1(Patient pat)
        //{
        //    //var obj = await _patientService.GetIdAsync(id);
        //    await _patientService.UpdateAsync(pat);
        //    return RedirectToAction("Index");
        //}

    }
}
