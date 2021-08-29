using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Entitytwotable.Models;

namespace Entitytwotable.Controllers
{
    public class Employee1Controller : ApiController
    {
        private skillicebergEntities1 db = new skillicebergEntities1();
        [HttpGet]
        [Route("api/GetEmployee1")]
    
        public IQueryable<Employee1> GetEmployee1()
        {
            return db.Employee1;
        }
        
        [Route("api/Employee1/5")]
        [ResponseType(typeof(Employee1))]
        public IHttpActionResult GetEmployee1(long id)
        {
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return NotFound();
            }

            return Ok(employee1);
        }
         
       
        [HttpPut]
        [Route("api/Employee1")]

        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee1(long id, Employee1 employee1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee1.ID)
            {
                return BadRequest();
            }

            db.Entry(employee1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("updated");
        }

       
        [HttpPost]
        [Route("api/Employee1/post")]
        [ResponseType(typeof(Employee1))]
        public IHttpActionResult PostEmployee1(Employee1 employee1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee1.Add(employee1);
            db.SaveChanges();
            return Ok("success");

        }

       
        [HttpDelete]
        [Route("api/Employee1/delete")]
        [ResponseType(typeof(Employee1))]
        public IHttpActionResult DeleteEmployee1(long id)
        {
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return NotFound();
            }

            db.Employee1.Remove(employee1);
            db.SaveChanges();

            return Ok("delete");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee1Exists(long id)
        {
            return db.Employee1.Count(e => e.ID == id) > 0;
        }
    }
}