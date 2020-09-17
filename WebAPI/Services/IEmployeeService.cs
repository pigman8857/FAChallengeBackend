using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        Task<EmployeeListDTO> FindAll(int pageNumber , int pageSize);

        Task<Employee> FindOne(int id);

        Task<EmployeeListDTO> FindByName(int pageNumber, int pageSize, string name);

        Task Modify(int id, Employee employee);

        Task Add(Employee employee);

        Task Remove(Employee employee);

        Task Commit();

        bool HasEmployee(int id);
    }
}
