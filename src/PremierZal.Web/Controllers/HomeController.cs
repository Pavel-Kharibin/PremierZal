using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremierZal.Common.Models;
using PremierZal.Service.Interfaces;
using ControllerBase = PremierZal.Web.Common.Bases.ControllerBase;

namespace PremierZal.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(IPrimierZalService service)
            : base(service)
        {
        }

        public async Task<IActionResult> Index()
        {
            var sessions = await Service.SessionsGetAllAsync();

            return View(sessions);
        }

        public IActionResult NewRow()
        {
            return PartialView("_Row", new Session {Begins = DateTime.Now});
        }
    }
}