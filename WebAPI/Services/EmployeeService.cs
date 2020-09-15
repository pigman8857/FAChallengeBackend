using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyDataContext _context;
        public EmployeeService(CompanyDataContext context) {
            _context = context;
        }
    }
}
