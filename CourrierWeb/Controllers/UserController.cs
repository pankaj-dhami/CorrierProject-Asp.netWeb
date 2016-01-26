using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AYDS.Storage;

namespace CourrierWeb.Controllers
{
    //Get: Get result, PUT: Update, POST: New Entry, DELETE: Delete entry
    public class UserController : ApiController
    {
        private AtYourDoorStepEntities db = new AtYourDoorStepEntities();
        private AYDSDAL dal = new AYDSDAL();

        #region Default Methods
        // GET: api/User
        public IQueryable<tblAYDSUserInformation> GettblAYDSUserInformations()
        {
            return db.tblAYDSUserInformations;
        }       

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAYDSUserInformation(int id, tblAYDSUserInformation tblAYDSUserInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAYDSUserInformation.Id)
            {
                return BadRequest();
            }

            db.Entry(tblAYDSUserInformation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAYDSUserInformationExists(id))
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

        // POST: api/User
        [ResponseType(typeof(tblAYDSUserInformation))]
        public IHttpActionResult PosttblAYDSUserInformation(tblAYDSUserInformation tblAYDSUserInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblAYDSUserInformations.Add(tblAYDSUserInformation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblAYDSUserInformation.Id }, tblAYDSUserInformation);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(tblAYDSUserInformation))]
        public IHttpActionResult DeletetblAYDSUserInformation(int id)
        {
            tblAYDSUserInformation tblAYDSUserInformation = db.tblAYDSUserInformations.Find(id);
            if (tblAYDSUserInformation == null)
            {
                return NotFound();
            }

            db.tblAYDSUserInformations.Remove(tblAYDSUserInformation);
            db.SaveChanges();

            return Ok(tblAYDSUserInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAYDSUserInformationExists(int id)
        {
            return db.tblAYDSUserInformations.Count(e => e.Id == id) > 0;
        } 
        #endregion

        #region Login
        /// <summary>
        /// GET: api/User/rahul,abcd
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IHttpActionResult GetUserInformation(string userName, string password)
        {
            tblAYDSUserInformation tblAYDSUserInformation = dal.ValidateUser(userName,password);
            if (tblAYDSUserInformation == null)
            {
                return NotFound();
            }

            return Ok(tblAYDSUserInformation);
        }
        #endregion

        #region Register
        // POST: api/User
        [ResponseType(typeof(tblAYDSUserInformation))]
        public IHttpActionResult PostUserInformation(tblAYDSUserInformation tblAYDSUserInformation)
        {
            tblAYDSUserInformation userDetails = new tblAYDSUserInformation();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userDetails = dal.RegisterUser(tblAYDSUserInformation);

            return CreatedAtRoute("DefaultApi", new { id = userDetails.Id }, userDetails);
        }
        #endregion

        #region Profile
         // GET: api/User/5
        [ResponseType(typeof(tblAYDSUserInformation))]
        public IHttpActionResult GetUserProfile(int id)
        {
            tblAYDSUserInformation tblAYDSUserInformation = dal.GetUserProfile(id);
            if (tblAYDSUserInformation == null)
            {
                return NotFound();
            }

            return Ok(tblAYDSUserInformation);
        }

        [ResponseType(typeof(tblAYDSUserInformation))]
        public IHttpActionResult PostUpdateUserDetails(tblAYDSUserInformation tblAYDSUserInformation)
        {
            tblAYDSUserInformation userDetails = new tblAYDSUserInformation();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userDetails = dal.UpdateUserDetails(tblAYDSUserInformation);

            return CreatedAtRoute("DefaultApi", new { id = userDetails.Id }, userDetails);
        }
        #endregion
    }
}