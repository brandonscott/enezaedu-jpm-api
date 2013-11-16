using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnezaApi.Controllers
{
    public class ClassesController : ApiController
    {
        [HttpGet]
        public Object Get()
        {
            return "return list of all classes";
        }

        [HttpGet]
        public Object Students(int id)
        {
            return "return list of students in class";
        }
    }
}