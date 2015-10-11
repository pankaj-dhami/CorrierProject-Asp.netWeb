using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CourrierBO.Model;
using CourrierStorage;

namespace CourrierWeb.Areas.WEBAPI.Controllers
{
    public class Default1Controller : ApiController
    {
        private CourrierDataContext db = new CourrierDataContext();

        // GET api/Default1
        public IQueryable<UserModel> GetUsers()
        {
            return db.Users;
        }

        // GET api/Default1/5
        [ResponseType(typeof(UserModel))]
        public async Task<IHttpActionResult> GetUserModel(int id)
        {
            UserModel usermodel = await db.Users.FindAsync(id);
            if (usermodel == null)
            {
                return NotFound();
            }

            return Ok(usermodel);
        }

        // PUT api/Default1/5
        public async Task<IHttpActionResult> PutUserModel(int id, UserModel usermodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usermodel.Id)
            {
                return BadRequest();
            }

            db.Entry(usermodel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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

        // POST api/Default1
        [ResponseType(typeof(UserModel))]
        public async Task<IHttpActionResult> PostUserModel(UserModel usermodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(usermodel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usermodel.Id }, usermodel);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(UserModel))]
        public async Task<IHttpActionResult> DeleteUserModel(int id)
        {
            UserModel usermodel = await db.Users.FindAsync(id);
            if (usermodel == null)
            {
                return NotFound();
            }

            db.Users.Remove(usermodel);
            await db.SaveChangesAsync();

            return Ok(usermodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserModelExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}