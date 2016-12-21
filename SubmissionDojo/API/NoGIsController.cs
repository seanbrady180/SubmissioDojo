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
    public class NoGIsController : ApiController
    {
        private DojoContext db = new DojoContext();

        // GET: api/NoGIs
        public IQueryable<NoGIDTO> GetNoGi()
        {
            var nogi = from ng in db.NoGi
                       select new NoGIDTO()
                       {
                           ID = ng.ID,
                           Name = ng.Name,
                           Link = ng.Link,
                           Difficulty = ng.Difficulty,
                           Type = ng.Type
                       }; return nogi;
        }

        // GET: api/NoGIs/5
        [ResponseType(typeof(NoGIDTO))]
        public async Task<IHttpActionResult> GetNoGI(int id)
        {
            NoGI ng = await db.NoGi.FindAsync(id);
            if (ng == null)
            {
                return NotFound();
            }

            NoGIDTO noGI = new NoGIDTO
            {
                ID = ng.ID,
                Name = ng.Name,
                Link = ng.Link,
                Difficulty = ng.Difficulty,
                Type = ng.Type
            };

            return Ok(noGI);
        }

        // PUT: api/NoGIs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNoGI(int id, NoGI noGI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noGI.ID)
            {
                return BadRequest();
            }

            db.Entry(noGI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoGIExists(id))
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

        // POST: api/NoGIs
        [ResponseType(typeof(NoGI))]
        public IHttpActionResult PostNoGI(NoGI noGI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NoGi.Add(noGI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = noGI.ID }, noGI);
        }

        // DELETE: api/NoGIs/5
        [ResponseType(typeof(NoGI))]
        public IHttpActionResult DeleteNoGI(int id)
        {
            NoGI noGI = db.NoGi.Find(id);
            if (noGI == null)
            {
                return NotFound();
            }

            db.NoGi.Remove(noGI);
            db.SaveChanges();

            return Ok(noGI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoGIExists(int id)
        {
            return db.NoGi.Count(e => e.ID == id) > 0;
        }
    }
}