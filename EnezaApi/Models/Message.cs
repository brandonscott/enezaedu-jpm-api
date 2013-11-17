using EnezaApi.DataManager;
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
        public Int32 Id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 from_user { get; set; }
        public Int32 to_user { get; set; }
        public Int32 sent_time { get; set; }
        public Int32 received_time { get; set; }
        public String body { get; set; }
        [ForeignKey("MessageType"), Column(Order = 1)]
        public Int32 message_type { get; set; }

        public virtual User User { get; set; }
        public virtual MessageType MessageType { get; set; }

        public static Message GetById(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.Messages.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public static List<Message> GetMessagesSince(int userId, int timestamp)
        {
            using (DataContext db = new DataContext())
            {
                return db.Messages.Where(m => m.sent_time > timestamp && m.from_user == userId || m.to_user == userId).ToList();
            }
        }

        public static Message AddNew(Message message)
        {
            using (DataContext db = new DataContext())
            {
                db.Messages.Add(message);
                db.SaveChanges();

                return message;
            }
        }

        public static Object OutputObject(Message message)
        {
            return new
            {
                id = message.Id,
                from_user = message.from_user,
                to_user = message.to_user,
                sent_time = message.sent_time,
                received_time = message.received_time,
                body = message.body,
                message_type = message.message_type
            };
        }
    }
}