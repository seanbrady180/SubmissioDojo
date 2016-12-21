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
    public class JudoesController : ApiController
    {
        private DojoContext db = new DojoContext();

        // GET: api/Judoes
        public IQueryable<JudoDTO> GetJudo()
        {
            var judo = from j in db.JiuJitsu
                           select new JudoDTO()
                           {
                               ID = j.ID,
                               Name = j.Name,
                               Link = j.Link,
                               Difficulty = j.Difficulty,
                               Type = j.Type
                           }; return judo;
        }

        // GET: api/Judoes/5
        [ResponseType(typeof(JudoDTO))]
        public async Task<IHttpActionResult> GetJudo(int id)
        {
            Judo j = await db.Judo.FindAsync(id);
            if (j == null)
            {
                return NotFound();
            }

            JudoDTO judo = new JudoDTO
            {
                ID = j.ID,
                Name = j.Name,
                Link = j.Link,
                Difficulty = j.Difficulty,
                Type = j.Type
            };

            return Ok(judo);
        }

        // PUT: api/Judoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJudo(int id, Judo judo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != judo.ID)
            {
                return BadRequest();
            }

            db.Entry(judo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JudoExists(id))
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

        // POST: api/Judoes
        [ResponseType(typeof(Judo))]
        public IHttpActionResult PostJudo(Judo judo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Judo.Add(judo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = judo.ID }, judo);
        }

        // DELETE: api/Judoes/5
        [ResponseType(typeof(Judo))]
        public IHttpActionResult DeleteJudo(int id)
        {
            Judo judo = db.Judo.Find(id);
            if (judo == null)
            {
                return NotFound();
            }

            db.Judo.Remove(judo);
            db.SaveChanges();

            return Ok(judo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JudoExists(int id)
        {
            return db.Judo.Count(e => e.ID == id) > 0;
        }
    }
}