using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Code2014Registration
{
    class DateGame
    {
        static void Date()
        {
            var url = "http://challenge.code2040.org/api/dating";
            dynamic jsonObject = new JObject();
            jsonObject.token = "3d886e47f8b097899fb925d7cfb5a00c";

            //POST first JSON 
            string responsetxt = "";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                responsetxt = client.UploadString(url, "POST", jsonObject.ToString());
            }

            //Debug.WriteLine("RESPONSE: " + responsetxt);

            dynamic responsejson = JObject.Parse(responsetxt);

            int interval = responsejson.interval;
            string stamp = responsejson.datestamp;

            //Debug.WriteLine("ORIGINAL: " + stamp
            DateTime date = Convert.ToDateTime(stamp);
            //Debug.WriteLine("TIME: " + date
            DateTime newdate = date.AddSeconds(interval);

            //Debug.WriteLine("NEW TIME: " + newdate.ToString("yyyy-MM-dd" + "T" + "H:mm:ss" + "Z"));

            string senddate = newdate.ToString("yyyy-MM-dd" + "T" + "H:mm:ss" + "Z");

            jsonObject.datestamp = senddate;

            //POST answer
            string response2 = "";
            using (var client2 = new WebClient())
            {
                client2.Headers[HttpRequestHeader.ContentType] = "application/json";
                response2 = client2.UploadString("http://challenge.code2040.org/api/dating/validate", "POST", jsonObject.ToString());
            }

            //Debug.WriteLine("RESPONSE2: " + response2);


        }

        //static void Main()
        //{
        //    Date();
        //}
    }
}
