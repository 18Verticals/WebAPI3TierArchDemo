using DAL.Repositories;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepo _repo;
        public DepartmentService(IDepartmentRepo repo)
        {
            _repo = repo;
        }

        public async Task<AddUpdateDeleteDepartment_DTO> AddDepartment(string department)
        {
           return await _repo.AddDepartment(department);
        }

        public async Task<AddUpdateDeleteDepartment_DTO> DeleteDepartment(int Id)
        {
            return await _repo.DeleteDepartment(Id);

        }

        public async Task<DefaultDepartment_Response> GetDepartmentById(int Id)
        {
            return await _repo.GetDepartmentById(Id);
        }

        public async Task<GetDepartmentList_Response> GetDepartments()
        {
            return await _repo.GetDepartments();
        }

        public async Task<DefaultDepartment_Response> UpdateDepartment(UpdateDepartment_Request request)
        {
            return await _repo.UpdateDepartment(request);

        }
    }
}
