using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Filter;

namespace WebAPI.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeListDTO> FindAll(PaginationFilter filter);
    }
}
