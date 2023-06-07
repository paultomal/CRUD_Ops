using System;
using System.Collections.Generic;

namespace CRUD_OPS.Models
{
    public partial class TblEmployee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmployeeCode { get; set; } = null!;
        public int EmployeeSalary { get; set; }

        public virtual TblEmployeeAttendance? TblEmployeeAttendance { get; set; }
    }
}
