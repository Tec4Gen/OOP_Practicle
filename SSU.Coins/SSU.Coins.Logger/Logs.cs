using log4net;
using log4net.Config;

namespace SSU.Coins.Logger
{
    public static class Logs
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get
            {
                XmlConfigurator.Configure();

                return log;
            }
        }

    }
}
