using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class TeacherClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 teacher_class_id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 teacher { get; set; }
        [ForeignKey("Class"), Column(Order = 0)]
        public Int32 @class { get; set; }

        public virtual User User { get; set; }
        public virtual Class @Class { get; set; }
    }
}