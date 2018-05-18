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
    public class RegionsController : ApiController
    {
        private DipChallengeModel db = new DipChallengeModel();

        // GET: api/Regions
        public IQueryable<Region> GetRegion()
        {
            return db.Region;
        }

        // GET: api/Regions/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult GetRegion(string id)
        {
            Region region = db.Region.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // PUT: api/Regions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegion(string id, Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != region.Region1)
            {
                return BadRequest();
            }

            db.Entry(region).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // POST: api/Regions
        [ResponseType(typeof(Region))]
        public IHttpActionResult PostRegion(Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Region.Add(region);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RegionExists(region.Region1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = region.Region1 }, region);
        }

        // DELETE: api/Regions/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult DeleteRegion(string id)
        {
            Region region = db.Region.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            db.Region.Remove(region);
            db.SaveChanges();

            return Ok(region);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegionExists(string id)
        {
            return db.Region.Count(e => e.Region1 == id) > 0;
        }
    }
}