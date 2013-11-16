using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnezaApi.Controllers
{
    public class RegionsController : ApiController
    {
        [HttpGet]
        public Object Get()
        {
            return "return all regions";
        }

        [HttpGet]
        public Object Schools(int id)
        {
            return "return all schools in specified region";
        }
    }
}