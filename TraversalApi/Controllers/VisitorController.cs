using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;
using TraversalApi.DAL.Context;
using TraversalApi.DAL.Entities;

namespace TraversalApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new ApiContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }

        }
        [HttpPost]
        public IActionResult AddVisitor(Visitor visitor)
        {
            using(var context = new ApiContext()) 
            {
                context.Visitors.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using(var context = new ApiContext())
            {
                var values=context.Visitors.Find(id);
                if(values==null)
                {
                    return NotFound();
                }else
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id) 
        {
            using (var context=new ApiContext())
            {
                var value=context.Visitors.Find(id);
                if(value !=  null)
                {
                    context.Visitors.Remove(value);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPut]
        public  IActionResult UpdateVisitor(Visitor visitor)
        {
            using(var context=new ApiContext())
            {
                var value = context.Visitors.Find(visitor.Id);
                if(value != null) 
                {
                    value.Name= visitor.Name;
                    value.Surname= visitor.Surname;
                    value.City= visitor.City;
                    value.Country = visitor.Country;
                    value.Mail=visitor.Mail;
                    context.Visitors.Update(value);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
