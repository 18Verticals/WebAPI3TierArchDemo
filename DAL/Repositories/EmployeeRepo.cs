using DAL.Data;
using DAL.Entities;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public DataContext _context { get; }
        public EmployeeRepo(DataContext context)
        {
            _context = context;
        }


        public async Task<EmployeeById_DTO> GetEmployeeById(int Id)
        {
            EmployeeById_DTO response = new EmployeeById_DTO();
            try
            {
                AppEmployee employee = await _context.Employees.FindAsync(Id);
                if (employee != null)
                {
                    response.Id = employee.Id;
                    response.Updatedy = employee.Updatedy;
                    response.UpdatedDate = employee.UpdatedDate;
                    response.Updatedy = employee.Updatedy;
                    response.Address = employee.Address;
                    response.DepartmentId = employee.DepartmentId;
                    response.Designation = employee.Designation;
                    response.Age = employee.Age;
                    response.Name = employee.Name;
                    response.CreatedBy = employee.CreatedBy;
                    response.CreatedDate = employee.CreatedDate;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "Employee doesn't exist";
                    response.IsInformation = true;
                }
                return response;
            }
            catch (Exception err)
            {
                response.IsError = true;
                response.Message = err.Message;
                return response;
            }

        }
        public async Task<List<AppEmployee>> GetEmployeList(Sort_Parameters request)
        {
            try
            {
                request.SearchKeyword = request.SearchKeyword.ToLower();
                //var resp = await (from emp in _context.Employees orderby emp.Name ascending select emp).ToListAsync();
                List<AppEmployee> employees = new List<AppEmployee>();
                if (request.SortDir == "asc")
                {
                    employees = await _context.Employees.OrderBy(e=> EF.Property<object>(e!,request.OrderBy))
                        .Where(emp => emp.Name.ToLower().Contains(request.SearchKeyword) 
                        || emp.Age.ToString().Contains(request.SearchKeyword)
                        || emp.Address.ToLower().Contains(request.SearchKeyword)
                        || emp.CreatedDate.ToString().Contains(request.SearchKeyword)
                        || emp.UpdatedDate.ToString().Contains(request.SearchKeyword)
                        || emp.Designation.ToLower().Contains(request.SearchKeyword)).ToListAsync();
                }
                else
                {
                    employees = await _context.Employees.OrderByDescending(e=> EF.Property<object>(e!,request.OrderBy))
                        .Where(emp => emp.Name.ToLower().Contains(request.SearchKeyword)
                        || emp.Age.ToString().Contains(request.SearchKeyword)
                        || emp.Address.ToLower().Contains(request.SearchKeyword)
                        || emp.CreatedDate.ToString().Contains(request.SearchKeyword)
                        || emp.UpdatedDate.ToString().Contains(request.SearchKeyword)
                        || emp.Designation.ToLower().Contains(request.SearchKeyword)).ToListAsync();
                }
                return employees;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<EmployeeById_DTO> AddEmployee(AddEmployee_Request request)
        {
            EmployeeById_DTO employee = new EmployeeById_DTO();
            try
            {
                if (request.Age < 18)
                {
                    return new EmployeeById_DTO
                    {
                        IsError = true,
                        Message = "Age must be gretter then 18"
                    };  
                }
                AppEmployee emp = new AppEmployee
                {
                    Name = request.Name,
                    Address = request.Address,
                    Age = request.Age,
                    DepartmentId = request.DepartmentId,
                    Designation = request.Designation,
                    CreatedBy = request.LoginUserId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null
                };

                await _context.Employees.AddAsync(emp);
                await _context.SaveChangesAsync();
                employee.Designation = emp.Designation;
                employee.Name = emp.Name;
                employee.Address = emp.Address;
                employee.DepartmentId = emp.DepartmentId;
                employee.CreatedDate = emp.CreatedDate;
                employee.CreatedBy = emp.CreatedBy;
                employee.Updatedy = emp.Updatedy;
                employee.UpdatedDate = emp.UpdatedDate;
                employee.Message = "Employee added sucessfully";
                employee.IsSuccess = true;
                return employee;

            }
            catch (Exception err)
            {
                employee.IsError = true;
                employee.Message = err.Message;
                return employee;
            }
        }

        public async Task<EmployeeById_DTO> UpdateEmployee(UpdateEmployee_Request request)
        {
            AppEmployee employee = await _context.Employees.FindAsync(request.Id);
            try
            {
                if (employee != null)
                {
                    employee.Age = request.Age;
                    employee.Updatedy = request.LoginUserId;
                    employee.UpdatedDate = DateTime.Now;
                    employee.Name = request.Name;
                    employee.Address = request.Address;
                    employee.DepartmentId = request.DepartmentId;
                    employee.Designation = request.Designation;
                    await _context.SaveChangesAsync();
                    return new EmployeeById_DTO
                    {
                        Id = employee.Id,
                        CreatedBy = employee.CreatedBy,
                        Age = employee.Age,
                        CreatedDate = employee.CreatedDate,
                        Address = employee.Address,
                        DepartmentId = employee.DepartmentId,
                        Designation = employee.Designation,
                        Name = employee.Name,
                        UpdatedDate = employee.UpdatedDate,
                        Updatedy = employee.Updatedy,
                        Message = "Employee has been updated sucessfully.",
                        IsSuccess = true
                    };
                }
                else
                {
                    return new EmployeeById_DTO
                    {
                        Message = "Employee doesn't exist.",
                        IsInformation = true
                    };
                }
            }
            catch (Exception err)
            {
                return new EmployeeById_DTO
                {
                    Message = err.Message,
                    IsError = true
                };
            }
        }

        public async Task<DeleteEmployee_DTO> DeleteEmployee(int Id)
        {
            try
            {

                AppEmployee employee = await _context.Employees.FindAsync(Id);
                if (employee == null)
                {
                    return new DeleteEmployee_DTO
                    {
                        IsInformation = true,
                        Message = "Employee doesn't exist.",
                    };
                }
                else
                {
                     _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    return new DeleteEmployee_DTO
                    {
                        Id = Id,
                        IsSuccess = true,
                        Message = "Employee has been deleted",
                    };
                }
            }
            catch (Exception err)
            {
                return new DeleteEmployee_DTO
                {
                    IsError = true,
                    Message = err.Message,
                };
            }
               
        }
}
}
