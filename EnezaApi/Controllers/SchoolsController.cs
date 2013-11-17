using EnezaApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Collections;
using EnezaApi.Classes;

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

        [HttpGet]
        public Object AverageScores()
        {
            /*Models.User currUser = Models.User.GetById(userId);

            if (currUser.user_type != 1)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(500));
            }

            List<TeacherClass> tcList = TeacherClass.GetByTeacherId(userId);
            List<Class> uniqueClasses = new List<Class>();
            List<Models.User> uniqueUsers = new List<Models.User>();

            foreach(TeacherClass tc in tcList)
            {
                Class @class = Class.GetById(tc.classId);

                if (!uniqueClasses.Contains(@class))
                {
                    uniqueClasses.Add(@class);
                }
            }

            foreach(Class item in uniqueClasses)
            {
                Models.User user = Models.User.GetById(item.);
                if (!uniqueUsers.Contains())
                {
                    uniqueUsers.Add(user);
                }
            }*/



            return JObject.FromObject(new { 
                schools = new ArrayList {
                    new { score = 87.6, name = "Rift Valley" },
                    new { score = 95.4, name = "North Eastern" },
                    new { score = 75.5, name = "Eastern" },
                    new { score = 65.3, name = "Western" },
                    new { score = 85.8, name = "Nairobi" },
                    new { score = 91.9, name = "Nyanza" }
                }
            });
        }
    }
}