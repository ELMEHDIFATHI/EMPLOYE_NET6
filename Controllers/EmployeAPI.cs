using Crud_NET.Models;
using Crud_NET.Servcies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_NET.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeAPI : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employes>> GetAll() => EmployesServices.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Employes> Get(int id)
        {
            var emp = EmployesServices.Get(id);
            if (emp == null)
                return NotFound();
            return emp;

        }

        [HttpPost]
        public ActionResult Create(Employes emp)
        {
            EmployesServices.Add(emp);
            return CreatedAtAction(nameof(Create), new { id = emp.ID }, emp);
        }

        [HttpPut("{id}")]

        public ActionResult Update(int id,Employes emp)
        {
            if (id != emp.ID)
                return BadRequest();

            var exsist = EmployesServices.Get(id);
            if (exsist is null)
                return NotFound();
            EmployesServices.update(emp);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            var emp = EmployesServices.Get(id);
            if (emp is null)
                return NotFound();
            EmployesServices.Delete(id);
            return NoContent();
        }

    }
}
