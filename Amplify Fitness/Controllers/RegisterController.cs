using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amplify_Fitness.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {

            AmazonLambdaClient client = new AmazonLambdaClient("AKIAIB2B3AH6QMWGMADA", "LMzvQzBm6bXoCEZAn8lkBv7ZH+TFtEDa6sYlKoEM", RegionEndpoint.USEast1);


            InvokeRequest ir = new InvokeRequest
            {
                FunctionName = "RandomNumber",
                InvocationType = InvocationType.RequestResponse
            };

            InvokeResponse response = client.Invoke(ir);

            var sr = new StreamReader(response.Payload);
            JsonReader reader = new JsonTextReader(sr);

            var serilizer = new JsonSerializer();
            var op = serilizer.Deserialize(reader);
            
            ViewData["number"] = op;
            return View();
        }

       
            
}
}