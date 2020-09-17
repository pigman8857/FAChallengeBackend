using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Models;

using Microsoft.EntityFrameworkCore;
using WebAPI.Filter;

namespace WebAPI.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public CompanyDataContext CompanyDataContext
        {
            get { return _context as CompanyDataContext; }
        }
        public EmployeeRepository(CompanyDataContext context) : base(context) { }
        
        public async Task Add(Employee entity)
        {
            await CompanyDataContext.Employees.AddAsync(entity);
        }

        public async Task<IEnumerable<Employee>> Find(Expression<Func<Employee, bool>> predicate)
        {
            return await CompanyDataContext.Employees.Where(predicate).ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await CompanyDataContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await CompanyDataContext.Employees.ToListAsync();
        }

        public async Task<EmployeeListDTO> GetAllWithPositionAndDepartment(int pageNumber, int pageSize)
        {
           
            var query = CompanyDataContext.Employees
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
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalCount = results.First().TotalCount;
            var people = results.Select(r => r.Employee).ToArray();

            return new EmployeeListDTO { ActualTotalAmount = totalCount, EmployeeList = people };

        }

        public async Task<EmployeeListDTO> GetEmployeesByNameWithPositionAndDepartment(int pageNumber, int pageSize,string name)
        {
            var query = CompanyDataContext.Employees
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
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
            var totalCount = results.First().TotalCount;
            var people = results.Select(r => r.Employee).ToArray();

            return new EmployeeListDTO { ActualTotalAmount = totalCount, EmployeeList = people };
        }

        public async Task<Employee> GetOneWithPositionAndDepartment(int id)
        {
            var employee = await CompanyDataContext.Employees
                                   .Where(employee => employee.EmployeeId == id)
                                   .Include(Employee => Employee.Position)
                                   .Include(Employee => Employee.Department)
                                   .SingleAsync();

            return employee;
        }
    }
}
