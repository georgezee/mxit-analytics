using System;
using System.Configuration;

namespace YOURAPP.NAMESPACE
{
    class Config
    {
        //Corresponding entries should be placed in your app.config file
        public static bool AnalyticsEnabled = Boolean.Parse(ConfigurationManager.AppSettings["AnalyticsEnabled"]);
        public static string AnalyticsKey = ConfigurationManager.AppSettings["AnalyticsKey"];
        public static string AnalyticsSite = ConfigurationManager.AppSettings["AnalyticsSite"];
    }
}
