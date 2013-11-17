using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EnezaApi.Models;
using Newtonsoft.Json.Linq;
using EnezaApi.Classes;

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
                    subject = Subject.GetById(c.subject).name,
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

        [HttpPost]
        public Object AddUser(int id, int userId)
        {
            Models.User currUser = Models.User.GetById(userId);

            if (currUser.user_type == 1) // teacher
            {
                TeacherClass teacherClass = TeacherClass.AddTeacher(id, userId);
                return JObject.FromObject(new
                {
                    class_link = teacherClass,
                    valid = true
                });
            }
            else if (currUser.user_type == 2) // teacher
            {
                StudentClass studentClass = StudentClass.AddStudent(id, userId);
                return JObject.FromObject(new
                {
                    class_link = studentClass,
                    valid = true
                });
            }
            else
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(300));
            }
        }

        [HttpDelete]
        public Object DeleteUser(int id, int userId)
        {
            Models.User currUser = Models.User.GetById(userId);
            Boolean result = false;

            if (currUser.user_type == 1) // teacher
            {
                result = TeacherClass.RemoveTeacher(id, userId);
            }
            else if (currUser.user_type == 2) // teacher
            {
                result = StudentClass.RemoveStudent(id, userId);
            }
            else
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(300));
            }

            if (!result)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(301));
            }

            return JObject.FromObject(new
            {
                valid = true
            });
        }
    }
}