using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class EmployeeRepository : Repository, IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllWithPositionAndDepartment()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesByNameWithPositionAndDepartment()
        {
            throw new NotImplementedException();
        }
    }
}
