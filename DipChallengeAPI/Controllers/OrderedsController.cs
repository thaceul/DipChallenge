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
using DipChallengeAPI.Models;

namespace DipChallengeAPI.Controllers
{
    public class OrderedsController : ApiController
    {
        private DipChallengeModel db = new DipChallengeModel();

        // GET: api/Ordereds
        public IQueryable<Ordered> GetOrdered()
        {
            return db.Ordered;
        }

        // GET: api/Ordereds/5
        [ResponseType(typeof(Ordered))]
        public IHttpActionResult GetOrdered(DateTime id)
        {
            Ordered ordered = db.Ordered.Find(id);
            if (ordered == null)
            {
                return NotFound();
            }

            return Ok(ordered);
        }

        // PUT: api/Ordereds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrdered(DateTime id, Ordered ordered)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordered.OrderDate)
            {
                return BadRequest();
            }

            db.Entry(ordered).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderedExists(id))
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

        // POST: api/Ordereds
        [ResponseType(typeof(Ordered))]
        public IHttpActionResult PostOrdered(Ordered ordered)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ordered.Add(ordered);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderedExists(ordered.OrderDate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ordered.OrderDate }, ordered);
        }

        // DELETE: api/Ordereds/5
        [ResponseType(typeof(Ordered))]
        public IHttpActionResult DeleteOrdered(DateTime id)
        {
            Ordered ordered = db.Ordered.Find(id);
            if (ordered == null)
            {
                return NotFound();
            }

            db.Ordered.Remove(ordered);
            db.SaveChanges();

            return Ok(ordered);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderedExists(DateTime id)
        {
            return db.Ordered.Count(e => e.OrderDate == id) > 0;
        }
    }
}