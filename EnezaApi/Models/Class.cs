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
        public Int32 class_id { get; set; }
        public Int32 grade { get; set; }
        [ForeignKey("Subject"), Column(Order = 0)]
        public Int32 subject { get; set; }
        [ForeignKey("School"), Column(Order = 0)]
        public Int32 school { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual School School { get; set; }
    }
}