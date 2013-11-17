using EnezaApi.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public Int32 grade { get; set; }
        [ForeignKey("Subject"), Column(Order = 0)]
        public Int32 subject { get; set; }
        [ForeignKey("School"), Column(Order = 1)]
        public Int32 school { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual School School { get; set; }

        public static Class GetById(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.Classes.Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public static List<Class> GetAll()
        {
            using (DataContext db = new DataContext())
            {
                return db.Classes.ToList();
            }
        }

        public static Object OutputObject(Class @class)
        {
            return new {
                id = @class.Id,
                grade = @class.grade,
                subject = @class.subject,
                school = @class.school
            };
        }
    }
}