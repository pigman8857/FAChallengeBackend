using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DTOs
{
    public class EmployeeResult
    {
      
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public  Department Department { get; set; }

        public Position Position
        {
            get; set;
        }
    }
}
