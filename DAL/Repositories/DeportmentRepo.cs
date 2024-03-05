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
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DataContext _context;
        public DepartmentRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<AddUpdateDeleteDepartment_DTO> AddDepartment(string department)
        {
            try
            {
                var existingDepartment = await (from dep in _context.Departments
                                                          where dep.Name == department
                                                          select new AppDepartment
                                                          { Id = dep.Id,
                                                          }).ToListAsync();

                if (existingDepartment.Count > 0)
                {
                    throw new Exception("Department already exist.");
                }
                else
                {
                    AppDepartment departmentToSave = new AppDepartment { Name = department };
                    await _context.Departments.AddAsync(departmentToSave);
                    await _context.SaveChangesAsync();
                    return new AddUpdateDeleteDepartment_DTO
                    {
                        IsSuccess = true,
                        Message = "Department has been added sucessfully."
                    };
                }

            }
            catch (Exception err)
            {

                return new AddUpdateDeleteDepartment_DTO
                {
                    IsError = true,
                    Message = err.Message
                };
            }

        }

        public async Task<AddUpdateDeleteDepartment_DTO> DeleteDepartment(int Id)
        {
            try
            {
                AppDepartment existingDepartment = await _context.Departments.FindAsync(Id);
                if (existingDepartment == null)
                {
                    throw new Exception("Department doesn't exist.");
                }
                else
                {
                    _context.Departments.Remove(existingDepartment);
                    await _context.SaveChangesAsync();
                    return new AddUpdateDeleteDepartment_DTO
                    {
                        Message = "Department has been deleted sucessfully",
                        IsSuccess = true
                    };
                }
            }
            catch (Exception err)
            {
                return new AddUpdateDeleteDepartment_DTO
                {
                    IsError = true,
                    Message = err.Message
                };
            }
        }

        public async Task<DefaultDepartment_Response> GetDepartmentById(int Id)
        {
            try
            {
                AppDepartment existingDepartment = await _context.Departments.FindAsync(Id);
                if (existingDepartment == null)
                {
                    throw new Exception("Department doesn't exist.");
                }
                else
                {
                    return new DefaultDepartment_Response
                    {
                        Id = existingDepartment.Id,
                        Name = existingDepartment.Name,
                        IsSuccess = true,
                        Message = "Sucess;"
                    };
                }
            }
            catch (Exception err)
            {
                return new DefaultDepartment_Response
                {
                    IsError = true,
                    Message = err.Message,
                };
            }
        }

        public async Task<GetDepartmentList_Response> GetDepartments()
        {
            try
            {
                GetDepartmentList_Response response = new GetDepartmentList_Response();
                response.Departments = new List<Departments_DTO>();
                List<AppDepartment> departmentList = await _context.Departments.ToListAsync();
                if (departmentList.Count == 0)
                {
                    return new GetDepartmentList_Response
                    {
                        IsInformation = true,
                        Message = "No departmets to show"
                    };
                }
                foreach (var item in departmentList)
                {
                    Departments_DTO department = new Departments_DTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                    };
                    response.Departments.Add(department);
                }
                response.IsSuccess = true;
                return response;
            }
            catch (Exception err)
            {
                return new GetDepartmentList_Response
                {
                    IsError = true,
                    Message = err.Message
                };
            }

        }

        public async Task<DefaultDepartment_Response> UpdateDepartment(UpdateDepartment_Request request)
        {
            try
            {
                AppDepartment existingDepartment = await _context.Departments.FindAsync(request.Id);
                if (existingDepartment == null)
                {
                    throw new Exception("Department doesn't exist.");
                }
                else
                {
                    existingDepartment.Name = request.Name;
                    await _context.SaveChangesAsync();
                    return new DefaultDepartment_Response
                    {
                        Id = existingDepartment.Id,
                        Name = existingDepartment.Name,
                        IsSuccess = true,
                        Message = "Department has been updated sucessfully."
                    };
                }
            }
            catch (Exception err)
            {
                return new DefaultDepartment_Response
                {
                    IsError = true,
                    Message = err.Message
                };
            }
        }
    }
}
