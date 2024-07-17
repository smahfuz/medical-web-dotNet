using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientDescription { get; set; }
        public DateTime AdmitDate { get; set; }
    
        [ForeignKey("DeaprtmentId")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}

