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
        public Int32 assignment_grade_id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 user { get; set; }
        public Int32 completed_date { get; set; }
        public 
    }
}