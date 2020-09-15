using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Filter;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyDataContext _context;
        public EmployeeService(CompanyDataContext context) {
            _context = context;
        }

        public async Task<EmployeeListDTO> FindAll(PaginationFilter filter) {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var query = _context.Employees
                .Include(Employee => Employee.Position)
                .Include(Employee => Employee.Department);
            var results = await query.Select(e => new {
                Employee = new EmployeeResult
                {
                    Name = e.Name,
                    EmployeeId = e.EmployeeId,
                    Department = e.Department,
                    Position = e.Position,
                    Salary = e.Salary
                },
                TotalCount = query.Count()
            })
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalCount = results.First().TotalCount;
            var people = results.Select(r => r.Employee).ToArray();

            return new EmployeeListDTO { ActualTotalAmount = totalCount, EmployeeList = people };
        }

        public async Task<EmployeeListDTO> FindByName(PaginationFilter filter, string name)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var query = _context.Employees
                .Where(employee => employee.Name.Contains(name))
                .Include(Employee => Employee.Position)
                .Include(Employee => Employee.Department)
                .Include(Employee => Employee.Position.ParentPosition);

            var results = await query.Select(e => new {
                Employee = new EmployeeResult
                {
                    Name = e.Name,
                    EmployeeId = e.EmployeeId,
                    Department = e.Department,
                    Position = e.Position,
                    Salary = e.Salary
                },
                TotalCount = query.Count()
            })
                            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                            .Take(validFilter.PageSize)
                            .ToListAsync();
            var totalCount = results.First().TotalCount;
            var people = results.Select(r => r.Employee).ToArray();

            return new EmployeeListDTO { ActualTotalAmount = totalCount, EmployeeList = people };
        }

        public async Task<Employee> FindOne(int id)
        {
            var employee = await _context.Employees
                    .Where(employee => employee.EmployeeId == id)
                    .Include(Employee => Employee.Position)
                    .Include(Employee => Employee.Department)
                    .SingleAsync();

            return employee;
        }
    }
}
