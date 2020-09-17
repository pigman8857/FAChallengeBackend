using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Filter;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyDataContext _context;
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeService(CompanyDataContext context, IEmployeeRepository employeeRepo) {
            _context = context;
            _employeeRepo = employeeRepo;
        }

        public async Task Add(Employee employee)
        {
           await _employeeRepo.Add(employee);
        }

        public async Task<EmployeeListDTO> FindAll(int pageNumber, int pageSize) {

           return  await _employeeRepo.GetAllWithPositionAndDepartment(pageNumber, pageSize);
        }

        public async Task<EmployeeListDTO> FindByName(int pageNumber, int pageSize, string name)
        {
            return await _employeeRepo.GetEmployeesByNameWithPositionAndDepartment(pageNumber, pageSize,name);
        }



        public async Task<Employee> FindOne(int id)
        {
            return await _employeeRepo.GetOneWithPositionAndDepartment(id);
        }

        public async Task Modify(int id, Employee employee)
        {
           var entry = await _employeeRepo.Get(id);
            if (entry != null)
            {
                _employeeRepo.Modify(entry);
                await Commit();
                return;
            }

            throw new DbUpdateConcurrencyException($"No entry to update");
        }

        public async Task Remove(Employee employee)
        {
            _employeeRepo.Remove(employee);
            await Commit();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public bool HasEmployee(int id) {
            return _context.Employees.Any(e => e.EmployeeId == id);

        }
    }
}
