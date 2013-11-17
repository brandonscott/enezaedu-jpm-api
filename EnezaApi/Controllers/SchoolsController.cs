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
        public Object AverageScores(int userId)
        {
            /*Models.User currUser = Models.User.GetById(userId);

            if (currUser.user_type != 1)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(500));
            }

            List<TeacherClass> tcList = TeacherClass.GetByTeacherId(userId);
            List<Class> uniqueClasses = new List<Class>();

            foreach(TeacherClass tc in tcList)
            {
                Class @class = Class.GetById(tc.@class);

                if (!uniqueClasses.Contains(@class))
                {
                    uniqueClasses.Add(@class);
                }
            }*/

            return JObject.FromObject(new { 
                schools = new ArrayList {
                    new { score = 87.6, name = "Rift Valley" },
                    new { score = 95.6, name = "North Eastern" }
                }
            });
        }
    }
}