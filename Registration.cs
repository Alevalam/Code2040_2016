using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code2014Registration
{
    class Registration
    {
        static void Main()
        {
            var url = "http://challenge.code2040.org/api/register";    

            dynamic jsonObject = new JObject();
            jsonObject.token = "3d886e47f8b097899fb925d7cfb5a00c";
            jsonObject.github = "https://github.com/Alevalam/Code2040_2016";


            string responsetxt = "";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                responsetxt = client.UploadString(url, "POST", jsonObject.ToString());
            }

            Debug.WriteLine(responsetxt);
        }
    }
}
