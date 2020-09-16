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
        Task<EmployeeListDTO> FindAll(PaginationFilter filter);

        Task<Employee> FindOne(int id);

        Task<EmployeeListDTO> FindByName(PaginationFilter filter, string name);

        void Modify(int id, Employee employee);

        void Add(Employee employee);

        Task Remove(int id);

        Task SaveChangeAsync();
    }
}
