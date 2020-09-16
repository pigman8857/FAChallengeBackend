using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Filter;
using WebAPI.Models;
using WebAPI.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyDataContext _context;
        private IEmployeeService _employeeService;
        public EmployeesController(CompanyDataContext context, IEmployeeService employeeService )
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: api/Employees?pageNumber=1&pageSize=2
        [HttpGet]
        public async Task<ActionResult<EmployeeListDTO>> GetEmployees([FromQuery] PaginationFilter filter)
        {
            try
            {
                return await _employeeService.FindAll(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.FindOne(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return employee;
            }
            catch (Exception e) {
                throw e;
            }
        }

        // GET: api/Employees/name/{name}?pageNumber=1&pageSize=2
        [HttpGet("name/{name}")]
        public async Task<ActionResult<EmployeeListDTO>> GetEmployee([FromQuery] PaginationFilter filter,string name)
        {
            try
            {
                var employeeDto = await _employeeService.FindByName(filter, name);

                return employeeDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
