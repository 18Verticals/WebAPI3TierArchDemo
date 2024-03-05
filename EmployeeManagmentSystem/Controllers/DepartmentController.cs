using BLL.Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        public IDepartmentService _service { get; }

        [HttpGet("GetDepartmentList")]
        public async Task<GetDepartmentList_Response> GetDepartmentList()
        {
            return await _service.GetDepartments();
        }

        [HttpGet("GetDepartment/{Id}")]
        public async Task<DefaultDepartment_Response> GetDepartmentById(int Id)
        {
            return await _service.GetDepartmentById(Id);
        }

        [HttpPost("AddDepartment/{Department}")]
        public async Task<AddUpdateDeleteDepartment_DTO> AddDepartment(string Department)
        {
            return await _service.AddDepartment(Department);
        }
        [HttpPost("UpdateDepartment")]
        public async Task<DefaultDepartment_Response> UpdateDepartment(UpdateDepartment_Request request)
        {
            return await _service.UpdateDepartment(request);
        }

        [HttpDelete("DeleteDepartment/{Id}")]
        public async Task<AddUpdateDeleteDepartment_DTO> DeleteDepartment(int Id)
        {
            return await _service.DeleteDepartment(Id);
        }
    }
}
