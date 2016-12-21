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
using SubmissionDojo.DAL;
using SubmissionDojo.Models;
using System.Threading.Tasks;

namespace SubmissionDojo.API
{
    public class WrestlingsController : ApiController
    {
        private DojoContext db = new DojoContext();

        // GET: api/Wrestlings
        public IQueryable<WrestlingDTO> GetWrestling()
        {
            var wrestling = from wr in db.Wrestling
                       select new WrestlingDTO()
                       {
                           ID = wr.ID,
                           Name = wr.Name,
                           Link = wr.Link,
                           Difficulty = wr.Difficulty,
                           Type = wr.Type
                       }; return wrestling;
        }

        // GET: api/Wrestlings/5
        [ResponseType(typeof(WrestlingDTO))]
        public async Task<IHttpActionResult> GetWrestling(int id)
        {
            Wrestling wr = await db.Wrestling.FindAsync(id);
            if (wr == null)
            {
                return NotFound();
            }

            WrestlingDTO wrestling = new WrestlingDTO
            {
                ID = wr.ID,
                Name = wr.Name,
                Link = wr.Link,
                Difficulty = wr.Difficulty,
                Type = wr.Type
            };

            return Ok(wrestling);
        }

        // PUT: api/Wrestlings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWrestling(int id, Wrestling wrestling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wrestling.ID)
            {
                return BadRequest();
            }

            db.Entry(wrestling).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WrestlingExists(id))
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

        // POST: api/Wrestlings
        [ResponseType(typeof(Wrestling))]
        public IHttpActionResult PostWrestling(Wrestling wrestling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wrestling.Add(wrestling);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wrestling.ID }, wrestling);
        }

        // DELETE: api/Wrestlings/5
        [ResponseType(typeof(Wrestling))]
        public IHttpActionResult DeleteWrestling(int id)
        {
            Wrestling wrestling = db.Wrestling.Find(id);
            if (wrestling == null)
            {
                return NotFound();
            }

            db.Wrestling.Remove(wrestling);
            db.SaveChanges();

            return Ok(wrestling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WrestlingExists(int id)
        {
            return db.Wrestling.Count(e => e.ID == id) > 0;
        }
    }
}