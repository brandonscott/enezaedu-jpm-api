using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class Assignment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public Int32 start_date { get; set; }
        public Int32 end_date { get; set; }
        [ForeignKey("Class"), Column(Order = 1)]
        public Int32 @class { get; set; }
        public String assignment_title { get; set; }
        public String assignment_body { get; set; }

        public virtual EnezaApi.Models.Class @Class { get; set; }
    }
}