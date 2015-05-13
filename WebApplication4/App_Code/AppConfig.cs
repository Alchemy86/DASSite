using System.Collections.Generic;
using System.Linq;
using ASEntityFramework;

namespace WebApplication4
{
    public static class AppConfig
    {
        public static IEnumerable<SystemConfig> SystemConfig()
        {
            return new ASEntities().SystemConfig;
        }

        public static string GetSystemConfig(string value)
        {
            return SystemConfig().First(x => x.PropertyID == value).Value;
        }

    }
}