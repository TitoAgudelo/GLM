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
    public class LunchItemController : ApiController
    {
        private GLMEEDContext db = new GLMEEDContext();

        // GET api/LunchItem
        public IQueryable<LunchItem> GetLunchItems()
        {
            return db.LunchItems;
        }

        // GET api/LunchItem/5
        [ResponseType(typeof(LunchItem))]
        public async Task<IHttpActionResult> GetLunchItem(int id)
        {
            LunchItem lunchitem = await db.LunchItems.FindAsync(id);
            if (lunchitem == null)
            {
                return NotFound();
            }

            return Ok(lunchitem);
        }

        // PUT api/LunchItem/5
        public async Task<IHttpActionResult> PutLunchItem(int id, LunchItem lunchitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lunchitem.ID)
            {
                return BadRequest();
            }

            db.Entry(lunchitem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LunchItemExists(id))
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

        // POST api/LunchItem
        [ResponseType(typeof(LunchItem))]
        public async Task<IHttpActionResult> PostLunchItem(LunchItem lunchitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LunchItems.Add(lunchitem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lunchitem.ID }, lunchitem);
        }

        // DELETE api/LunchItem/5
        [ResponseType(typeof(LunchItem))]
        public async Task<IHttpActionResult> DeleteLunchItem(int id)
        {
            LunchItem lunchitem = await db.LunchItems.FindAsync(id);
            if (lunchitem == null)
            {
                return NotFound();
            }

            db.LunchItems.Remove(lunchitem);
            await db.SaveChangesAsync();

            return Ok(lunchitem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LunchItemExists(int id)
        {
            return db.LunchItems.Count(e => e.ID == id) > 0;
        }
    }
}