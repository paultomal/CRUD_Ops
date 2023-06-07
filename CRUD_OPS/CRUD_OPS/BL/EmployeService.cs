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

        public List<TblEmployee> getallEmploye()
        {
            return employeeServicesContext.TblEmployees.OrderByDescending(e => e.EmployeeSalary).ToList();
        }

        public TblEmployee GetEmployeeByID(int ID)
        {
            var data = employeeServicesContext.TblEmployees.Find(ID);
            return data;
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
