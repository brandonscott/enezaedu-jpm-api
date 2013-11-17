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
        public Int32 schoolId { get; set; }
        public String gender { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<AssignmentGrade> Grades { get; set; }

        public static List<User> GetAll()
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.ToList();
            }
        }

        public static User GetById(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.Where(u => u.Id == id).FirstOrDefault();
            }
        }

        public static List<User> GetByType(int typeId)
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.Where(u => u.user_type == typeId).ToList();
            }
        }

        public static User GetByNumber(string phoneNumber)
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.Where(u => u.mobile_number == phoneNumber).FirstOrDefault();
            }
        }

        public static User AddNew(User newUser)
        {
            using (DataContext db = new DataContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();

                return newUser;
            }
        }

        public static User AccountAuth(String username, String password)
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.Where(u => u.email == username && u.password == password).FirstOrDefault();
            }
        }

        public static Object OutputObject(User user)
        {
            return new
            {
                id = user.Id,
                name = user.first_name + " " + user.last_name,
                mobile_number = user.mobile_number,
                email = user.email,
                user_type = user.user_type,
                school = user.schoolId,
                gender = user.gender
            };
        }
    }
}