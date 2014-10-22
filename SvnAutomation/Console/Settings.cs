using System.Configuration;

namespace SvnAutomation
{
    class Settings
    {
        public static string MoodleUrl = ConfigurationManager.AppSettings["MoodleUrl"];
        public static string SvnAdminPath = ConfigurationManager.AppSettings["SvnAdminPath"];
        public static string SvnRepositoriesPath = ConfigurationManager.AppSettings["SvnRepositoriesPath"];
        public static string SvnAuthzFile = ConfigurationManager.AppSettings["SvnAuthzFile"];
        public static string CacheFile = ConfigurationManager.AppSettings["CacheFile"];
    }
}
