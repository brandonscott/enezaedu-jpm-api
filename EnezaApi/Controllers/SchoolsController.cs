using EnezaApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnezaApi.Controllers
{
    public class SchoolsController : ApiController
    {
        [HttpGet]
        public Object Get()
        {
            List<School> schools = School.GetAll();

            return JObject.FromObject(new
            {
                schools = schools.Select(s =>
                {
                    return School.OutputObject(s);
                })
            });
            //return "return all Schools";
        }
    }
}