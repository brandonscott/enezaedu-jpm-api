using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class StudentClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 user { get; set; }
        [ForeignKey("Class"), Column(Order = 1)]
        public Int32 @class { get; set; }

        public virtual User User { get; set; }
        public virtual Class @Class { get; set; }
    }
}