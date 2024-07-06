using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SERVICE.IServices;
using WEB_MEDICAL.ViewModels;

namespace WEB_MEDICAL.Controllers
{
    public class DepartmentController : Controller
    {
        public readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            
        }
        //change korlam

        public async Task<IActionResult> Index()
        {
            var obj =await _departmentService.GetAllAsync();
            return View(obj);

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentView depview)
        {
            Department obj= new Department();
            
            obj.DepName = depview.DepName;
           await _departmentService.InsertAsync(obj);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ShowPatient()
        {
            var obj = new PatientView();
            obj.DepartmentsList = _departmentService.GetAllAsync().Result.Select(x=> new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.DepName
            }).ToList();
            return View(obj);   

        }

        [HttpPost]
        public async Task<IActionResult> PatientResult(PatientView patientView)
        {
            var obj = await _departmentService.SearchPatientByDepId(patientView.DepartmentId);
          
            return View(obj.Patients);
        }

    }
}
