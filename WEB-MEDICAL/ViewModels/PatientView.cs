using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WEB_MEDICAL.ViewModels
{
    public class PatientView
    {
        [Required]
        [Display(Name ="Patient Name")]
        public string PatientName { get; set; }
        [Required]
        public string PatientDescription { get; set; }
        
        public DateTime AdmitDate { get; set; }
        public int DepartmentId { get; set; }
        public List<SelectListItem> ? DepartmentsList { get; set; }

        public string Department {  get; set; }
    }
}
