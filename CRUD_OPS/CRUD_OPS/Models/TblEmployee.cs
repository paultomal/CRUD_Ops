using System;
using System.Collections.Generic;

namespace CRUD_OPS.Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblEmployeeAttendances = new HashSet<TblEmployeeAttendance>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmployeeCode { get; set; } = null!;
        public int EmployeeSalary { get; set; }
        
        public virtual ICollection<TblEmployeeAttendance> TblEmployeeAttendances { get; set; }
    }
}
