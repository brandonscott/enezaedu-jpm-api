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
            // CF: TODO Add actual user auth
            JObject postData = JObject.Parse(request.Content.ReadAsStringAsync().Result);
            string username = (String)postData["username"];
            string password = (String)postData["password"];

            Models.User user = Models.User.AccountAuth(username, password);

            if (user == null)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(200));
            }

            return JObject.FromObject(new
            {
                valid = true,
                user_id = user.Id
            });
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
                    classes.Add(Class.GetById(teacherClass.classId));
                }
            }
            else if (user.user_type == 2) // student
            {
                List<StudentClass> studentClasses = StudentClass.GetByStudentId(id);
                foreach (StudentClass studentClass in studentClasses)
                {
                    classes.Add(Class.GetById(studentClass.classId));
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
        public Object Registration(HttpRequestMessage request)
        {
            JObject postData = JObject.Parse(request.Content.ReadAsStringAsync().Result);

            Models.User user = new Models.User();

            user.first_name = (String)postData["first_name"];
            user.last_name = (String)postData["last_name"];
            user.password = (String)postData["password"];
            user.mobile_number = (String)postData["mobile_number"];
            user.email = (String)postData["email"];
            user.user_type = (Int32)postData["user_type"];
            user.schoolId = (Int32)postData["school"];
            user.gender = (String)postData["gender"];

            return JObject.FromObject( new
                {
                    user = Models.User.OutputObject(Models.User.AddNew(user)),
                    valid = true
                });
            //return "newly created object";
        }

        [HttpGet]
        public Object Get(string parameters)
        {
            List<User> users = new List<User>();

            if (String.IsNullOrEmpty(parameters))
            {
                return ErrorReporting.GenerateCustomError(100);
            }

            String userNarrow = "";
            Dictionary<string, object> reqParams = UrlRouting.SplitParams(parameters);

            if (reqParams.ContainsKey("type"))
            {
                userNarrow = reqParams["type"].ToString();
            }

            if (userNarrow == "student")
            {
                users = Models.User.GetByType(3);
            }
            else if (userNarrow == "teacher")
            {
                users = Models.User.GetByType(1);
            }

            //return JObject.FromObject(reqParams);
            //return "list or individual user";
            return JObject.FromObject( new
            {
                users = users.Select(u =>
                {
                    return Models.User.OutputObject(u);
                }),
            });
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

        [HttpGet]
        public Object Messages(int id, int timestamp)
        {
            List<Message> messages = Message.GetMessagesSince(id, timestamp);
            List<Models.User> users = new List<Models.User>();

            foreach(Message message in messages)
            {
                Models.User tempFrom = Models.User.GetById(message.from_user);
                Models.User tempTo = Models.User.GetById(message.to_user);

                if (!users.Contains(tempFrom))
                {
                    users.Add(tempFrom);
                }

                if (!users.Contains(tempTo))
                {
                    users.Add(tempTo);
                }
            }

            return JObject.FromObject(new
            {
                messages = messages.Select(m =>
                {
                    return Message.OutputObject(m);
                }),
                users = users.Select(u =>
                {
                    return Models.User.OutputObject(u);
                })
            });
        }

        [HttpGet]
        public Object AverageGrades()
        {
            List<Models.User> users = Models.User.GetAll();

            for (int i = 0; i < users.Count; i++)
            {
                users[i].Grades = AssignmentGrade.GetByUserId(users[i].Id);
            }

            for (int i = users.Count - 1; i >= 0; i--)
            {
                if (users[i].Grades.Count == 0)
                {
                    users.RemoveAt(i);
                }
            }

            return JObject.FromObject(new
            {
                users = users.Select(u => new
                {
                    id = u.Id,
                    name = u.first_name + " " + u.last_name,
                    average = u.Grades.Average(a => a.mark)
                })
            });
        }
    }
}