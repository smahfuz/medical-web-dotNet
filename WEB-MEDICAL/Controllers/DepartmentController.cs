using CORE.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
