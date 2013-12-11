using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IntranetGLM2013.Models;
using IntranetGLM2013.DAL;

namespace IntranetGLM2013.Controllers
{
    public class PersonController : ApiController
    {
        private GLMEEDContext db = new GLMEEDContext();

        // GET api/Person
        public IQueryable<Person> GetPeople()
        {
            return db.People;
        }

        // GET api/Person/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // GET api/Person?email=
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> GetPersonByMail(string email)
        {
            Person person = await db.People.FirstAsync(p=>p.Email.ToLower() == email.ToLower());
            if (person == null)
            {
                return null;
            }

            return Ok(person);
        }

        // PUT api/Person/5
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.ID)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Person
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = person.ID }, person);
        }

        // DELETE api/Person/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.ID == id) > 0;
        }
    }
}