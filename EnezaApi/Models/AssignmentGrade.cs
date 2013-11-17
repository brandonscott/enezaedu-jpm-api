using EnezaApi.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class AssignmentGrade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 userId { get; set; }
        public Int32 completed_date { get; set; }
        public Decimal mark { get; set; }
        [ForeignKey("Assignment"), Column(Order = 1)]
        public Int32 assignmentId { get; set; }

        public virtual User User { get; set; }
        public virtual Assignment Assignment { get; set; }

        public static List<AssignmentGrade> GetByUserId(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.AssignmentGrades.Where(ag => ag.userId == id).ToList();
            }
        }
    }
}