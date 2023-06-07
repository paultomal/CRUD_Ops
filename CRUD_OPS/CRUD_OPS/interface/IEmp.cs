using CRUD_OPS.Models;

namespace CRUD_OPS
{
    public interface IEmp
    {
        List<TblEmployee>  getallEmploye();
        TblEmployee GetEmployeeByID(int ID);
        TblEmployee update(TblEmployee employee);
    }
}
