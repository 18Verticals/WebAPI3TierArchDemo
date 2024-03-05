using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AddUpdateDeleteDepartment_DTO: CommonMessages_DTO
    {
    }
    public class AddDepartment_Request
    {
        public string Name { get; set; }
    }

    public class UpdateDepartment_Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DefaultDepartment_Response:CommonMessages_DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Departments_DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class GetDepartmentList_Response : CommonMessages_DTO
    {
        public List<Departments_DTO> Departments { get; set; }
    }
}
