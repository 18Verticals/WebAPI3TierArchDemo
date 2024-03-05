using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    #region     =======================Request Payloads============================
    public class AddEmployee_Request
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public string? Designation { get; set; }
        public int LoginUserId { get; set; }
    }

    public class UpdateEmployee_Request
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public string? Designation { get; set; }
        public int LoginUserId { get; set; }
    }
    #endregion
    public class EmployeeList_Response_DTO:CommonMessages_DTO
    {
        public List<EmployeeList_DTO> Employees { get; set; }
    }
    public class EmployeeList_DTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public string? Designation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int Updatedy { get; set; }
    }
    public class EmployeeById_DTO:CommonMessages_DTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public string? Designation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int Updatedy { get; set; }
    }

    public class DeleteEmployee_DTO : CommonMessages_DTO
    {
        public int Id { get; set; }
    }
}
