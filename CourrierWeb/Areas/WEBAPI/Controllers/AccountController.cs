using CourrierBO.Model;
using CourrierStorage.Repositories;
using CourrierWeb.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CourrierWeb.Areas.WEBAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        IAuthRepository repository;

        public AccountController(IAuthRepository repository)
        {
            this.repository = repository;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel result = await repository.RegisterUserAsync(userModel);

            return Ok();
        }

        [Authorize]
        [Route("GetAllUser")]
        public IHttpActionResult GetAllUser()
        {
            var users = repository.GetAllUser();
            return Ok(users);
        }


    }
}
