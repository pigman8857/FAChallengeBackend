using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Filter;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeListDTO> FindAll(PaginationFilter filter);

        Task<Employee> FindOne(int id);

        Task<EmployeeListDTO> FindByName(PaginationFilter filter, string name);

        Task Modify(int id, Employee employee);
    }
}
