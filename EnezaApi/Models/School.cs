using EnezaApi.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String school_name { get; set; }
        [ForeignKey("Region"), Column(Order = 0)]
        public Int32 region { get; set; }

        public virtual Region Region { get; set; }

        public static List<School> GetAll()
        {
            using (DataContext db = new DataContext())
            {
                return db.Schools.ToList();
            }
        }

        public static Object OutputObject(School school)
        {
            return new
            {
                id = school.Id,
                school_name = school.school_name
            };
        }
    }
}