using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EnezaApi.Classes;
using Newtonsoft.Json.Linq;
using EnezaApi.Models;

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

        [HttpGet]
        public Object Classes(int id)
        {
            Models.User user = Models.User.GetById(id);
            List<Class> classes = new List<Class>();

            if (user.user_type == 1) // teacher
            {
                List<TeacherClass> teacherClasses = TeacherClass.GetByTeacherId(id);
                foreach(TeacherClass teacherClass in teacherClasses)
                {
                    classes.Add(Class.GetById(teacherClass.@class));
                }
            }
            else if (user.user_type == 2) // student
            {
                List<StudentClass> studentClasses = StudentClass.GetByStudentId(id);
                foreach (StudentClass studentClass in studentClasses)
                {
                    classes.Add(Class.GetById(studentClass.@class));
                }
            }
            else
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(300));
            }

            return JObject.FromObject(new
            {
                classes = classes.Select(cs =>
                {
                    return Class.OutputObject(cs);
                })
            });
            //return "all classes for student / teacher using Id";
        }

        [HttpPost]
        public Object Post(Models.User user)
        {
            Models.User newUser = Models.User.AddNew(user);

            return newUser;
            //return "newly created object";
        }

        [HttpGet]
        public Object Get(string parameters)
        {
            if (String.IsNullOrEmpty(parameters))
            {
                return ErrorReporting.GenerateCustomError(100);
            }

            String userNarrow = "";
            Dictionary<string, object> reqParams = UrlRouting.SplitParams(parameters);

            if (!reqParams.ContainsKey("type"))
            {
                userNarrow = reqParams["type"].ToString();
            }

            return JObject.FromObject(reqParams);
            //return "list or individual user";
        }

        [HttpPut]
        public Object Put(int id)
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