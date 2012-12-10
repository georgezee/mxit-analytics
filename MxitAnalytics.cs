using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsTracker;
using MXit.User;
using log4net;

namespace YOURAPP.NAMESPACE
{
    class MxitAnalytics
    {
        //Assuming you're using Log4Net for your logging
        private static readonly ILog log = LogManager.GetLogger(typeof(MxitAnalytics));

        //the UserSession class here is where I store the users session information, including the UserInfo object.
        //Add to your User Session/Player object : [JsonIgnoreAttribute] public GoogleAnalyticsTracker.AnalyticsSession analyticsSession;  

        public static void LogItem(string pageTitle, string pageURL, UserSession userSession)
        {

            //Allow the Analytics to be turned on/off dynamically.
            if (!Config.AnalyticsEnabled)
            {
                return;
            }

            try
            {
                if (userSession.analyticsSession == null)
                {
                    userSession.analyticsSession = new AnalyticsSession();
                }

                using (Tracker tracker = new Tracker(Config.AnalyticsKey, Config.AnalyticsSite, userSession.analyticsSession))
                {
                    //You can define your own custom variables here. You can either use a unique 'site' per app, 
                    //or combine them all in one site, and use a custom variable to pass your app name in.
                    //You can then use Advanced Segments to split your statistics by App                    
                    tracker.SetCustomVariable(1, "app", Config.AppName);
                    if (userSession.userInfo == null)
                    {
                        tracker.SetCustomVariable(2, "country", "unknown");
                        tracker.SetCustomVariable(3, "city", "unknown");
                        tracker.SetCustomVariable(4, "gender", "unknown");
                    }
                    else
                    {
                        tracker.SetCustomVariable(2, "country", userSession.userInfo.CurrentCountry);
                        tracker.SetCustomVariable(3, "city", userSession.userInfo.CurrentCity);
                        switch (userSession.userInfo.Gender)
                        {
                            case GenderType.Male:
                                tracker.SetCustomVariable(4, "gender", "male");
                                break;
                            case GenderType.Female:
                                tracker.SetCustomVariable(4, "gender", "female");
                                break;
                        }
                    }
                    //This uses asynchronous calls, so won't hold up your thread 
                    //(was able to leave enabled during a Tradepost Broadcast)                   
                    tracker.TrackPageView(pageTitle, pageURL);
                }
            }
            catch (Exception e)
            {
                log.Error("Error logging analytics", e);
            }
        }
    }
}