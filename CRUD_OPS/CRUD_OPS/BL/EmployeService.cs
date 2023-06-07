using CRUD_OPS.DTO;
using CRUD_OPS.Models;
using System.Security.Claims;

namespace CRUD_OPS.BL
{
    public class EmployeService: IEmp 
    {
        EmployeeServicesContext employeeServicesContext;
        public EmployeService(EmployeeServicesContext employeeServicesContext) {
            this.employeeServicesContext = employeeServicesContext;
        }

        public List<TblEmployee> getAbsenceEmp()
        {   List<TblEmployee> epdata = new List<TblEmployee>();
            var data = employeeServicesContext.TblEmployeeAttendances.Where(e=>e.IsAbsent>0).ToList();
            var data3 = data.DistinctBy(e=>e.EmployeeId).ToList();
            foreach ( var item in data3 )
            {
                var data1 = employeeServicesContext.TblEmployees.Where(e=>e.EmployeeId == item.EmployeeId).SingleOrDefault();
                epdata.Add(data1);
            }
            
            return epdata;
        }

        public List<TblEmployee> getallEmploye()
        {
            return employeeServicesContext.TblEmployees.OrderByDescending(e => e.EmployeeSalary).ToList();
        }

        public TblEmployee GetEmployeeByID(int ID)
        {
            var data = employeeServicesContext.TblEmployees.Find(ID);
            return data;
        }

        public List<AttendenceReort> getReport(string month, string year)
        {
            List<AttendenceReort> reportList = new List<AttendenceReort>();
            
            var attendenceList = employeeServicesContext.TblEmployeeAttendances.Where(e=>e.AttendanceDate.Year.ToString()== year && e.AttendanceDate.Month.ToString()== month).ToList();
            var emplist = employeeServicesContext.TblEmployees.ToList();
            foreach( var item in emplist ) {
                var report = new AttendenceReort();
                var empattendenceList = attendenceList.Where(e=>e.EmployeeId == item.EmployeeId).ToList();
                report.TotalPresent = 0;
                report.TotalOffday = 0;
                report.TotalAbsence = 0;
                
                foreach( var item2 in empattendenceList)
                {
                    report.EmployeName = item.EmployeeName;
                    report.Month = month;
                    report.TotalPresent = report.TotalPresent + item2.IsPresent;
                    report.TotalAbsence = report.TotalAbsence + item2.IsAbsent;
                    report.TotalOffday = report.TotalOffday + item2.IsOffday;
                }
                reportList.Add(report);

            }
            return reportList;
        }

        public TblEmployee update(TblEmployee employee)
        {
            var empdata = employeeServicesContext.TblEmployees.Where(e=>e.EmployeeCode == employee.EmployeeCode).ToList();
  
                if(empdata.Count == 0)
               {
                    employeeServicesContext.TblEmployees.Update(employee);
                    employeeServicesContext.SaveChanges();
                    return employee;
               }
               else
               {
                   return null;
               }
            
        }
    }
}
