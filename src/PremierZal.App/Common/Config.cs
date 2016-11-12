using System.Configuration;

namespace PremierZal.App.Common
{
    public static class Config
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["baseUrl"];
        public static int SessionsRefreshInterval {
            get
            {
                int result;
                int.TryParse(ConfigurationManager.AppSettings["sessionsRefreshInterval"], out result);

                return result == 0 ? 5000 : result;
            }
        }
    }
}