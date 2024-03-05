using BLL.Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpPost("GetEmployeeList")]
        public async Task<EmployeeList_Response_DTO> GetEmployeeList(Sort_Parameters request) {
            EmployeeList_Response_DTO response = await _employeeService.GetEmployeList(request);
            return response;
        }

        [HttpGet("{id}")]

        public async Task<EmployeeById_DTO> GetEmployeeById(int id)
        {
            return await _employeeService.GetEmployeeById(id);
        }
        [HttpPost("AddEmployee")]
        public async Task<EmployeeById_DTO> AddEmployee(AddEmployee_Request request)
        {
            EmployeeById_DTO resp = await _employeeService.AddEmployee(request);
            return resp;
        }

        [HttpPost("UpdateEmployee")]
        public async Task<EmployeeById_DTO> UpdateEmployee(UpdateEmployee_Request request)
        {
            EmployeeById_DTO resp = await _employeeService.UpdateEmployee(request);
            return resp;
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<DeleteEmployee_DTO> DeleteEmployee(int id)
        {
            DeleteEmployee_DTO resp = await _employeeService.DeleteEmployee(id);
            return resp;
        }
    }
}
