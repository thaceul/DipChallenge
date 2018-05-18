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
    public class SegmentsController : ApiController
    {
        private DipChallengeModel db = new DipChallengeModel();

        // GET: api/Segments
        public IQueryable<Segment> GetSegment()
        {
            return db.Segment;
        }

        // GET: api/Segments/5
        [ResponseType(typeof(Segment))]
        public IHttpActionResult GetSegment(int id)
        {
            Segment segment = db.Segment.Find(id);
            if (segment == null)
            {
                return NotFound();
            }

            return Ok(segment);
        }

        // PUT: api/Segments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSegment(int id, Segment segment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != segment.SegID)
            {
                return BadRequest();
            }

            db.Entry(segment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegmentExists(id))
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

        // POST: api/Segments
        [ResponseType(typeof(Segment))]
        public IHttpActionResult PostSegment(Segment segment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Segment.Add(segment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SegmentExists(segment.SegID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = segment.SegID }, segment);
        }

        // DELETE: api/Segments/5
        [ResponseType(typeof(Segment))]
        public IHttpActionResult DeleteSegment(int id)
        {
            Segment segment = db.Segment.Find(id);
            if (segment == null)
            {
                return NotFound();
            }

            db.Segment.Remove(segment);
            db.SaveChanges();

            return Ok(segment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SegmentExists(int id)
        {
            return db.Segment.Count(e => e.SegID == id) > 0;
        }
    }
}