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
using IntranetGLM2013.Models;
using IntranetGLM2013.DAL;

namespace IntranetGLM2013.Controllers
{
    public class WeekLunchController : ApiController
    {
        private GLMEEDContext db = new GLMEEDContext();

        // GET api/WeekLunch
        public IQueryable<DailyLunch> GetDailyLunches()
        {
            return db.DailyLunches;
        }

        // GET api/WeekLunch/5
        [ResponseType(typeof(DailyLunch))]
        public IHttpActionResult GetDailyLunch(int id)
        {
            DailyLunch dailylunch = db.DailyLunches.Find(id);
            if (dailylunch == null)
            {
                return NotFound();
            }

            return Ok(dailylunch);
        }

        public List<DailyLunch> GetWeekLunch(string date)
        {
            List<DailyLunch> list = new List<DailyLunch>();
            List<WorkingDay> week = WorkingDay.GetDays(date);
            week.RemoveAt(0);
            week.RemoveAt(5);

            foreach(WorkingDay day in week)
            {
                list.AddRange(db.DailyLunches.Where(i => i.LunchDate == day.Day));
            }

            foreach (DailyLunch d in list)
            {
                LunchItem curr = new LunchItem();
                d.LunchItem = db.LunchItems.Find(d.LunchItemId);
            }


            return list;
        }

        // PUT api/WeekLunch/5
        public IHttpActionResult PutDailyLunch(int id, DailyLunch dailylunch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dailylunch.ID)
            {
                return BadRequest();
            }

            db.Entry(dailylunch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyLunchExists(id))
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

        // POST api/WeekLunch
        [ResponseType(typeof(DailyLunch))]
        public IHttpActionResult PostDailyLunch(DailyLunch dailylunch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DailyLunches.Add(dailylunch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dailylunch.ID }, dailylunch);
        }

        // DELETE api/WeekLunch/5
        [ResponseType(typeof(DailyLunch))]
        public IHttpActionResult DeleteDailyLunch(int id)
        {
            DailyLunch dailylunch = db.DailyLunches.Find(id);
            if (dailylunch == null)
            {
                return NotFound();
            }

            db.DailyLunches.Remove(dailylunch);
            db.SaveChanges();

            return Ok(dailylunch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DailyLunchExists(int id)
        {
            return db.DailyLunches.Count(e => e.ID == id) > 0;
        }
    }
}