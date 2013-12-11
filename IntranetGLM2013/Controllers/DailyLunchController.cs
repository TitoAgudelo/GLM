using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IntranetGLM2013.Models;
using IntranetGLM2013.DAL;

namespace IntranetGLM2013.Controllers
{
    public class DailyLunchController : ApiController
    {
        private GLMEEDContext db = new GLMEEDContext();

        // GET api/DailyLunch
        public IQueryable<DailyLunch> GetDailyLunches()
        {
            return db.DailyLunches;
        }

        // GET api/DailyLunch?date=yyyy-mm-dd
        [ResponseType(typeof(DailyLunch))]
        public IQueryable<DailyLunch> GetDailyLunches(String date)
        {
            DateTime dayOfLunch = DateTime.Today.Date;
            try
            {
                dayOfLunch = Convert.ToDateTime(date).Date;
            }
            catch (Exception)
            {
                dayOfLunch = DateTime.Today.Date;
                throw;
            }
            return db.DailyLunches.Where(i => i.LunchDate == dayOfLunch);
        }

        // GET api/DailyLunch/5
        [ResponseType(typeof(DailyLunch))]
        public async Task<IHttpActionResult> GetDailyLunch(int id)
        {
            DailyLunch dailylunch = await db.DailyLunches.FindAsync(id);
            if (dailylunch == null)
            {
                return NotFound();
            }
            return Ok(dailylunch);
        }

        // PUT api/DailyLunch/5
        public async Task<IHttpActionResult> PutDailyLunch(int id, DailyLunch dailylunch)
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
                await db.SaveChangesAsync();
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

        // POST api/DailyLunch
        [ResponseType(typeof(DailyLunch))]
        public async Task<IHttpActionResult> PostDailyLunch(DailyLunch dailylunch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DailyLunches.Add(dailylunch);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dailylunch.ID }, dailylunch);
        }

        // DELETE api/DailyLunch/5
        [ResponseType(typeof(DailyLunch))]
        public async Task<IHttpActionResult> DeleteDailyLunch(int id)
        {
            DailyLunch dailylunch = await db.DailyLunches.FindAsync(id);
            if (dailylunch == null)
            {
                return NotFound();
            }

            db.DailyLunches.Remove(dailylunch);
            await db.SaveChangesAsync();

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


        // GET api/DailyLunch?GetDays=
        public List<WorkingDay> GetDays(string GetDays)
        {
            var Style = "none";
            var NameFunc = "dailyLunch";
            DateTime today = DateTime.Today;
            DateTime currDay = DateTime.Today;
            List<WorkingDay> days = new List<WorkingDay>();
            if (!string.IsNullOrEmpty(GetDays))
                try
                {
                    currDay = Convert.ToDateTime(GetDays);
                }
                catch (Exception)
                {
                    currDay = DateTime.Today;
                    //throw;
                }

            int j = (int)currDay.DayOfWeek;

            if (j == 0)
            {
                currDay = currDay.AddDays(1);
                j = 1;
            }
            else if (j == 6)
            {
                currDay = currDay.AddDays(2);
                j = 1;
            }


            // Domingo = 0, L=1, M=2, Mc=3, J=4, V=5, S=6
            WorkingDay curr = new WorkingDay();
            curr.WeekDay = "Anterior";
            curr.Day = currDay.AddDays(1 - j - 7).Date;
            curr.NameFunc = "listDays";
            curr.Style = "special";
            curr.isToday = false;
            curr.ShortDate = currDay.AddDays(1 - j - 7).Date.ToShortDateString();
            days.Add(curr);
            for (int i = 1 - j; i < 6 - j; i++)
            {
                curr = new WorkingDay();
                curr.WeekDay = currDay.AddDays(i).DayOfWeek.ToString();
                curr.Day = currDay.AddDays(i).Date;
                curr.NameFunc = NameFunc;
                curr.isToday = today.Date == curr.Day.Date;
                curr.Style = curr.isToday ? "activeDay" : Style;
                curr.isToday = today.Date == curr.Day.Date;
                curr.ShortDate = currDay.AddDays(i).Date.ToShortDateString();
                days.Add(curr);
            }
            curr = new WorkingDay();
            curr.WeekDay = "Siguiente";
            curr.Day = currDay.AddDays(1 - j + 7).Date;
            curr.NameFunc = "listDays";
            curr.Style = "special";
            curr.isToday = false;
            curr.ShortDate = currDay.AddDays(1 - j + 7).Date.ToShortDateString();
            days.Add(curr);

            return days;
        }

    }
}