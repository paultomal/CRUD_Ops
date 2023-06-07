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
            if(employee == null) { 
                
            }
            return employee;
        }
    }
}
