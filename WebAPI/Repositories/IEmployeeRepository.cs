using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetOneWithPositionAndDepartment(int id);
        Task<EmployeeListDTO> GetAllWithPositionAndDepartment();
        Task<EmployeeListDTO> GetEmployeesByNameWithPositionAndDepartment();


    }
}
