mxit-analytics
==============

A class to interface with the GoogleAnalyticsTracker module in C# Mxit apps

Steps to follow:

1. Get your Google Analytics API key. You'll need to follow their registration 
steps to link this to a website / mobile app.

2. Download the GoogleAnalyticsTracker project from: 
https://github.com/maartenba/GoogleAnalyticsTracker
You can either include the project inside your own App's solution, which will 
allow you to tweak the code, or alternately just add the GoogleAnalyticsTracker.dll 
file as a reference in your App. 
(you can find the dll in the GoogleAnalyticsTracker/bin/debug directory)

3. Add the MxitAnalytics.cs and Config.cs classes to your project, and adjust as
per the included comments.

4. Add the following property to your UserSession class: 
   public GoogleAnalyticsTracker.AnalyticsSession analyticsSession;

5. Wherever you want to log a visit, add: 
   MxitAnalytics.LogItem("Page Title", "/url/structure", UserSessionObject);

6. Go to Analytics -> Home -> Real-Time -> Overview to test that your calls are 
being registered correctly.

Author Info
==============
George Ziady
Contact: george[at]springfisher-dot-com


License Info (MIT License)
==============
Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the "Software"), to deal in 
the Software without restriction, including without limitation the rights to 
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all 
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 