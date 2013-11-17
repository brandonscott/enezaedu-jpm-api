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
    public class AssignmentsController : ApiController
    {
        [HttpGet]
        public Object Get()
        {
            List<Assignment> assignments = Assignment.GetAll();
            return JObject.FromObject(new
            {
                assignments = assignments.Select(a =>
                {
                    return Assignment.OutputObject(a);
                })
            });
        }
    }
}