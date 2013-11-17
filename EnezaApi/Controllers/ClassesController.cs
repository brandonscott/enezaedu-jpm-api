using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EnezaApi.Models;
using Newtonsoft.Json.Linq;

namespace EnezaApi.Controllers
{
    public class ClassesController : ApiController
    {
        [HttpGet]
        public Object Get()
        {
            List<Class> classes = Class.GetAll();

            return JObject.FromObject(new
            {
                classes = classes.Select(c => new
                {
                    id = c.Id,
                    grade = c.grade,
                    subject = c.subject,
                    school = c.school
                })
            });
            //return "return list of all classes";
        }

        [HttpGet]
        public Object Students(int id)
        {
            List<StudentClass> classList = StudentClass.GetByClassId(id);

            return JObject.FromObject(new
            {
                students = classList.Select(cs => {
                    return Models.User.OutputObject(Models.User.GetById(cs.student));
                })
            });
            //return "return list of students in class";
        }
    }
}