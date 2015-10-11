using CourrierBO;
using CourrierStorage;
using CourrierStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CourrierWeb.Controllers
{
    public class HomeController : Controller
    {
        IAuthRepository repository;
        public HomeController(IAuthRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ActionResult> Index()
        {
            repository.GetAllUser();
           // await repository.RegisterUserAsync("pankaj", "dhami11");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}