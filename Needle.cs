using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;
using System;

namespace Code2014Registration
{
    class NeedleHaystack
    {
        static void Needle()
        {
            var url = "http://challenge.code2040.org/api/haystack";

            dynamic jsonObject = new JObject();
            jsonObject.token = "3d886e47f8b097899fb925d7cfb5a00c";

            string responsetxt = "";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                responsetxt = client.UploadString(url, "POST", jsonObject.ToString());
            }

            //Debug.WriteLine("RESPONSE: " + responsetxt);

            dynamic responsejson = JObject.Parse(responsetxt);

            string needle = responsejson.needle;

            JArray haystack = responsejson.haystack;

            //Debug.WriteLine("NEEDLE: " + needle);

            // Debug.WriteLine("HAYSTACK: " + haystack);
            int index = 0;

            foreach (string word in haystack)
            {
                if (word == needle)
                {
                    break;
                }
                index++;
            }

            Debug.WriteLine("INDEX: " + index);

            jsonObject.needle = index;

            string response2 = "";
            using (var client2 = new WebClient())
            {
                client2.Headers[HttpRequestHeader.ContentType] = "application/json";
                response2 = client2.UploadString("http://challenge.code2040.org/api/haystack/validate", "POST", jsonObject.ToString());
            }

            Debug.WriteLine("RESPONSE2: " + response2);

        }

        //static void Main()
        //{
        //    Needle();
        //}
    }
}
