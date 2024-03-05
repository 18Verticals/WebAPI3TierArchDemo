using Azure.Core;
using DAL.Repositories;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public IEmployeeRepo _employeeRepo { get; }

        public async Task<EmployeeById_DTO> GetEmployeeById(int Id)
        {
            return await _employeeRepo.GetEmployeeById(Id);
        }

        public async Task<EmployeeList_Response_DTO> GetEmployeList(Sort_Parameters request)
        {
            EmployeeList_Response_DTO response = new EmployeeList_Response_DTO();
            List<EmployeeList_DTO> employees = new List<EmployeeList_DTO>();
            try
            {
                var empoyeeListRes = await _employeeRepo.GetEmployeList(request);
                foreach (var item in empoyeeListRes)
                {
                    EmployeeList_DTO employee = new EmployeeList_DTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DepartmentId = item.DepartmentId,
                        Address = item.Address,
                        Age = item.Age,
                        Designation = item.Designation,
                        CreatedBy = item.CreatedBy,
                        CreatedDate = item.CreatedDate,
                        UpdatedDate = item.UpdatedDate,
                        Updatedy = item.Updatedy
                    };
                    employees.Add(employee);
                }
                response.Employees = employees;
                if (employees.Count > 0)    
                {
                    response.Message = "Success!";
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "No employees to show";
                    response.IsInformation = true;
                }
                return response;
            }
            catch (Exception err)
            {
                response.Message = err.Message;
                response.IsError = true;
                return response;
            }
        }

        public async Task<EmployeeById_DTO> AddEmployee(AddEmployee_Request request)
        {
            var resp = await _employeeRepo.AddEmployee(request);
            return resp;
        }

        public async Task<EmployeeById_DTO> UpdateEmployee(UpdateEmployee_Request request)
        {
            var resp = await _employeeRepo.UpdateEmployee(request);
            return resp;
        }
        public async Task<DeleteEmployee_DTO> DeleteEmployee(int Id)
        {
            var resp = await _employeeRepo.DeleteEmployee(Id);
            return resp;
        }
    }
}
