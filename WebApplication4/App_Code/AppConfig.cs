using System.Collections.Generic;
using System.Linq;
using DAL;

namespace WebApplication4
{
    public enum AppSettings
    {
        AlertEmail,
        DomCopUser,
        DomCopPass
    }

    public static class AppConfig
    {
        public static IEnumerable<SystemConfig> SystemConfig()
        {
            return new ASEntities().SystemConfig;
        }

        public static string GetSystemConfig(AppSettings value)
        {
            return SystemConfig().First(x => x.PropertyID == value.ToString()).Value;
        }

        public static Users GetUser(string username)
        {
            return new ASEntities().Users.FirstOrDefault(x => x.Username == username);
        }

    }
}