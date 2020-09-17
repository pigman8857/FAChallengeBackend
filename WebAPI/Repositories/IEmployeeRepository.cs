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
        Task<EmployeeListDTO> GetAllWithPositionAndDepartment(int pageNumber, int pageSize);
        Task<EmployeeListDTO> GetEmployeesByNameWithPositionAndDepartment(int pageNumber, int pageSize, string name);


    }
}
