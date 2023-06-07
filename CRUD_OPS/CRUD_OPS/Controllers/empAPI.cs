using CRUD_OPS.BL;
using CRUD_OPS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_OPS.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class empAPI : ControllerBase
    {
        private readonly IEmp emp;
        public empAPI(IEmp emp)
        {
            this.emp = emp;
        }
        [Route("api/emplist")]
        [HttpGet]
        public IActionResult GetEmp()
        {
            var data = emp.getallEmploye();
            
            return Ok(data);
        }
        [Route("api/updateemp")]
        [HttpPost]
        public IActionResult GetEmp(TblEmployee em)
        {
            var data = emp.update(em);
            
            return Ok(data);
        }
       /* [HttpGet]
        [Route("api/emplist/{id}")]
        public IActionResult GetEmps(int id)
        {
            var data = emp.getallEmploye();
            
            return Ok(data);
        }*/
    }
}
