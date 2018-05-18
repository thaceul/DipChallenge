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
    public class ShippingsController : ApiController
    {
        private DipChallengeModel db = new DipChallengeModel();

        // GET: api/Shippings
        public IQueryable<Shipping> GetShipping()
        {
            return db.Shipping;
        }

        // GET: api/Shippings/5
        [ResponseType(typeof(Shipping))]
        public IHttpActionResult GetShipping(string id)
        {
            Shipping shipping = db.Shipping.Find(id);
            if (shipping == null)
            {
                return NotFound();
            }

            return Ok(shipping);
        }

        // PUT: api/Shippings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShipping(string id, Shipping shipping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipping.ShipMode)
            {
                return BadRequest();
            }

            db.Entry(shipping).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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

        // POST: api/Shippings
        [ResponseType(typeof(Shipping))]
        public IHttpActionResult PostShipping(Shipping shipping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shipping.Add(shipping);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ShippingExists(shipping.ShipMode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shipping.ShipMode }, shipping);
        }

        // DELETE: api/Shippings/5
        [ResponseType(typeof(Shipping))]
        public IHttpActionResult DeleteShipping(string id)
        {
            Shipping shipping = db.Shipping.Find(id);
            if (shipping == null)
            {
                return NotFound();
            }

            db.Shipping.Remove(shipping);
            db.SaveChanges();

            return Ok(shipping);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShippingExists(string id)
        {
            return db.Shipping.Count(e => e.ShipMode == id) > 0;
        }
    }
}