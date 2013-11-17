using EnezaApi.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get;set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String password { get; set; }
        public String mobile_number { get; set; }
        public String email { get; set; }
        [ForeignKey("UserType"), Column(Order= 0)]
        public Int32 user_type { get; set; }
        [ForeignKey("School"), Column(Order= 1)]
        public Int32 school { get; set; }
        public String gender { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual School School { get; set; }

        public static User GetById(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.Where(u => u.Id == id).FirstOrDefault();
            }
        }

        public static User AddNew(User user)
        {
            using (DataContext db = new DataContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

                return user;
            }
        }

        public static Object OutputObject(User user)
        {
            return new
            {
                id = user.Id,
                name = user.first_name + user.last_name,
                mobile_number = user.mobile_number,
                email = user.email,
                user_type = user.user_type,
                school = user.school,
                gender = user.gender
            };
        }
    }
}