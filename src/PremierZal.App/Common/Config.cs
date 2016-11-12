using System.Configuration;

namespace PremierZal.App.Common
{
    public static class Config
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["baseUrl"];

        public static int DataRefreshInterval
        {
            get
            {
                int result;
                int.TryParse(ConfigurationManager.AppSettings["dataRefreshInterval"], out result);

                return result == 0 ? 5000 : result;
            }
        }
    }
}