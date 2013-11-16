using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EnezaApi.Classes;
using Newtonsoft.Json.Linq;

namespace EnezaApi.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public Object Authenticate(HttpRequestMessage request)
        {
            JObject postData = JObject.Parse(request.Content.ReadAsStringAsync().Result);
            string username = (String)postData["username"];
            string password = (String)postData["password"];

            if (username == "admin" && password == "admin")
            {
                return JObject.FromObject(new { valid = true });
            }
            else
            {
                return ErrorReporting.GenerateCustomError(200);
            }
        }

        [HttpPost]
        public Object Post()
        {
            return "newly created object";
        }

        [HttpGet]
        public Object Get(string parameters)
        {
            if (String.IsNullOrEmpty(parameters))
            {
                return ErrorReporting.GenerateCustomError(100);
            }

            Dictionary<string, object> reqParams = UrlRouting.SplitParams(parameters);
            return JObject.FromObject(reqParams);
            //return "list or individual user";
        }

        [HttpPut]
        public Object Put()
        {
            return "updated user";
        }

        [HttpDelete]
        public Object Delete()
        {
            return "user deleted json";
        }
    }
}