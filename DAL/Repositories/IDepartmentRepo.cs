using DAL.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IDepartmentRepo
    {
        Task<GetDepartmentList_Response> GetDepartments();
        Task<DefaultDepartment_Response> GetDepartmentById(int Id);
        Task<AddUpdateDeleteDepartment_DTO> AddDepartment(string department);
        Task<DefaultDepartment_Response> UpdateDepartment(UpdateDepartment_Request request);
        Task<AddUpdateDeleteDepartment_DTO> DeleteDepartment(int Id);
    }
}
