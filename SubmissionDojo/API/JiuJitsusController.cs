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
    public class JiuJitsusController : ApiController
    {
        private DojoContext db = new DojoContext();

        // GET: api/JiuJitsus
        public IQueryable<JiuJitsuDTO> GetJiuJitsu()
        {
            var jiujitsu = from j in db.JiuJitsu
                           select new JiuJitsuDTO() {
                               ID = j.ID,
                               Name = j.Name,
                               Link = j.Link,
                               Difficulty = j.Difficulty,
                               Type = j.Type
                           }; return jiujitsu;
        }

        // GET: api/JiuJitsus/5
        [ResponseType(typeof(JiuJitsuDTO))]
        public async Task<IHttpActionResult> GetJiuJitsu(int id)
        {
            JiuJitsu j = await  db.JiuJitsu.FindAsync(id);
            if (j == null)
            {
                return NotFound();
            }
            JiuJitsuDTO jiuJitsu = new JiuJitsuDTO
            {
                ID = j.ID,
                Name = j.Name,
                Link = j.Link,
                Difficulty = j.Difficulty,
                Type = j.Type
            };

            return Ok(jiuJitsu);
        }

        // PUT: api/JiuJitsus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJiuJitsu(int id, JiuJitsu jiuJitsu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jiuJitsu.ID)
            {
                return BadRequest();
            }

            db.Entry(jiuJitsu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JiuJitsuExists(id))
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

        // POST: api/JiuJitsus
        [ResponseType(typeof(JiuJitsu))]
        public IHttpActionResult PostJiuJitsu(JiuJitsu jiuJitsu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JiuJitsu.Add(jiuJitsu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jiuJitsu.ID }, jiuJitsu);
        }

        // DELETE: api/JiuJitsus/5
        [ResponseType(typeof(JiuJitsu))]
        public IHttpActionResult DeleteJiuJitsu(int id)
        {
            JiuJitsu jiuJitsu = db.JiuJitsu.Find(id);
            if (jiuJitsu == null)
            {
                return NotFound();
            }

            db.JiuJitsu.Remove(jiuJitsu);
            db.SaveChanges();

            return Ok(jiuJitsu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JiuJitsuExists(int id)
        {
            return db.JiuJitsu.Count(e => e.ID == id) > 0;
        }
    }
}