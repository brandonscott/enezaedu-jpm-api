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
        public Int32 user { get; set; }
        public Int32 completed_date { get; set; }
        public float mark { get; set; }
        [ForeignKey("Assignment"), Column(Order = 1)]
        public Int32 assignment { get; set; }

        public virtual User User { get; set; }
        public virtual Assignment Assignment { get; set; }

    }
}