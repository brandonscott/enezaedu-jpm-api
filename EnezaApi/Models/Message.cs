using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 message_id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 from_user { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 to_user { get; set; }
        public Int32 sent_time { get; set; }
        public Int32 received_time { get; set; }
        public String body { get; set; }
        [ForeignKey("MessageType"), Column(Order = 0)]
        public Int32 message_type { get; set; }

        public virtual User User { get; set; }
        public virtual MessageType MessageType { get; set; }
    }
}