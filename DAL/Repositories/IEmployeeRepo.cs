using DAL.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IEmployeeRepo
    {
        Task<List<AppEmployee>> GetEmployeList(Sort_Parameters request);
        Task<EmployeeById_DTO> GetEmployeeById(int Id);
        Task<EmployeeById_DTO> AddEmployee(AddEmployee_Request request);
        Task<EmployeeById_DTO> UpdateEmployee(UpdateEmployee_Request request);

        Task<DeleteEmployee_DTO> DeleteEmployee(int Id);
    }
}
