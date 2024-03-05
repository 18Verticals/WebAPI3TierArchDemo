using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IEmployeeService
    { 
        Task<EmployeeList_Response_DTO> GetEmployeList(Sort_Parameters request);
        Task<EmployeeById_DTO> GetEmployeeById(int Id);
        Task<EmployeeById_DTO> AddEmployee(AddEmployee_Request request);
        Task<EmployeeById_DTO> UpdateEmployee(UpdateEmployee_Request request);
        Task<DeleteEmployee_DTO> DeleteEmployee(int Id);

    }
}
