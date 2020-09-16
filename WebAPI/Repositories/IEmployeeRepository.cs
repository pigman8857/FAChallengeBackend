using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IEmployeeRepository : IRepository
    {
        IEnumerable<Employee> GetAllWithPositionAndDepartment();
        IEnumerable<Employee> GetEmployeesByNameWithPositionAndDepartment();


    }
}
