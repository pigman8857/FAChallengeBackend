using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DTOs
{
    public class EmployeeListDTO
    {
        public IEnumerable<EmployeeResult> EmployeeList { get; set; }
        public int ActualTotalAmount { get; set; }
    }
}
