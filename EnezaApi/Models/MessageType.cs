using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class MessageType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 message_type_id { get; set; }
        public String name { get; set; }
    }
}