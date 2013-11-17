using EnezaApi.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String name { get; set; }

        public static Subject GetById(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.Subjects.Where(s => s.Id == id).FirstOrDefault();
            }
        }
    }
}