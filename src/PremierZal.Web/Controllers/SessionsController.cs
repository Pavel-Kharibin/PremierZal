using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremierZal.Data.Models;
using PremierZal.Service.Interfaces;
using ControllerBase = PremierZal.Web.Common.Bases.ControllerBase;

namespace PremierZal.Web.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        public SessionsController(IPrimierZalService servive) : base(servive)
        {
        }

        public async Task<IEnumerable<Session>> Get()
        {
            var sessions = await Service.SessionsGetAllAsync();

            return sessions;
        }

        [HttpPut]
        public async Task Save(Session session)
        {
            await Service.SessionSaveAsync(session);
        }

        [HttpPost]
        public async Task<Session> Add(Session session)
        {
            await Service.SessionAddAsync(session);

            return session;
        }
    }
}