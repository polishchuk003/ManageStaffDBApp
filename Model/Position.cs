using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStaffDBApp.Model
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int MaxNumber { get; set; }
        public List<Employee> EmployeesList { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


        [NotMapped]
        public Department PositionDepartment
        {
            get
            {
                return DataWorker.GetDepartmentById(DepartmentId);
            }

        }


        [NotMapped]
        public List<Employee> PositionEmployees
        {
            get
            {
                return DataWorker.GetAllEmployeeByPositionId(Id);
            }
        }

    }
}
