using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;
using System;

namespace Code2014Registration
{
    class ReverseString
    {
        static void Reverse()
        {
            var url = "http://challenge.code2040.org/api/reverse";

            dynamic jsonObject = new JObject();
            jsonObject.token = "3d886e47f8b097899fb925d7cfb5a00c";

            string responsetxt = "";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                responsetxt = client.UploadString(url, "POST", jsonObject.ToString());
            }

            //Debug.WriteLine("RESPONSE: " + responsetxt);

            char[] wordarray = responsetxt.ToCharArray();
            Array.Reverse(wordarray);
            string reversed = "";

            foreach (char elt in wordarray)
            {
                reversed += elt;
            }
            // Debug.WriteLine("REVERSED: " + reversed);

            jsonObject.Add("string", reversed);
            string response2 = "";

            using (var client2 = new WebClient())
            {
                client2.Headers[HttpRequestHeader.ContentType] = "application/json";
                response2 = client2.UploadString("http://challenge.code2040.org/api/reverse/validate", "POST", jsonObject.ToString());
            }

            //Debug.WriteLine("RESPONSE: " + response2);

        }

        //static void Main()
        //{
        //    Reverse();
        //}
    }
}
