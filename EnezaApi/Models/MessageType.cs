using EnezaApi.DataManager;
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
        public Int32 Id { get; set; }
        public String name { get; set; }

        public static MessageType GetByName(string name)
        {
            using (DataContext db = new DataContext())
            {
                return db.MessageTypes.Where(mt => mt.name == name).FirstOrDefault();
            }
        }
    }
}