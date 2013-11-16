using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnezaApi.Controllers
{
    public class ReportsController : ApiController
    {
        [HttpGet]
        public Object Get()
        {
            return "return stuff";
        }
    }
}