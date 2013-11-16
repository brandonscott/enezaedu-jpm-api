﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 user_id { get;set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String password { get; set; }
        public String mobile_number { get; set; }
        public String email { get; set; }
        [ForeignKey("UserType"), Column(Order= 0)]
        public Int32 user_type { get; set; }
        [ForeignKey("School"), Column(Order= 0)]
        public Int32 school { get; set; }
        public char gender { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual School School { get; set; }

    }
}