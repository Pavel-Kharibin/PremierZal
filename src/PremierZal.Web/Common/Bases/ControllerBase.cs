using Microsoft.AspNetCore.Mvc;
using PremierZal.Service.Interfaces;

namespace PremierZal.Web.Common.Bases
{
    public abstract class ControllerBase : Controller
    {
        protected ControllerBase(IPrimierZalService servive)
        {
            Service = servive;
        }

        protected IPrimierZalService Service { get; }
    }
}