using PremierZal.Data.Interfaces;
using PremierZal.Service.Interfaces;

namespace PremierZal.Service
{
    public partial class PremierZalService : IPrimierZalService
    {
        public PremierZalService(ISessionsRepository sessionsRepository, IOrdersRepository ordersRepository)
        {
            _sessionsRepositoty = sessionsRepository;
            _ordersRepository = ordersRepository;
        }

        private readonly ISessionsRepository _sessionsRepositoty;
        private readonly IOrdersRepository _ordersRepository;
    }
}