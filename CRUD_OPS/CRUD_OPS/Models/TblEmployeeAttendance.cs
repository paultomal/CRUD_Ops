using System;
using System.Collections.Generic;

namespace CRUD_OPS.Models
{
    public partial class TblEmployeeAttendance
    {
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int IsPresent { get; set; }
        public int IsAbsent { get; set; }
        public int IsOffday { get; set; }

        public virtual TblEmployee Employee { get; set; } = null!;
    }
}
