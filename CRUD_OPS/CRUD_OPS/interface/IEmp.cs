using CRUD_OPS.Models;
using CRUD_OPS.DTO;

namespace CRUD_OPS
{
    public interface IEmp
    {
        List<TblEmployee>  getallEmploye();
        TblEmployee GetEmployeeByID(int ID);
        TblEmployee update(TblEmployee employee);
        List<TblEmployee> getAbsenceEmp();
        List<AttendenceReort> getReport(string month,string year);
    }
}
