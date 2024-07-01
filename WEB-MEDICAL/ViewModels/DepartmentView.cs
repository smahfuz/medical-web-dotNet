using System.ComponentModel.DataAnnotations;

namespace WEB_MEDICAL.ViewModels
{
    public class DepartmentView
    {

       
        [Required]
        public string DepName { get; set; }
    }
}
