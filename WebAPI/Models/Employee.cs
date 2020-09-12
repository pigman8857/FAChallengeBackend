using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public int Salary { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position Position
        {
            get; set;
        }

    }
}
