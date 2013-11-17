using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EnezaApi.Models;

namespace EnezaApi.Controllers
{
    public class MessagesController : ApiController
    {
        [HttpPost]
        public Object Post(Message message)
        {
            Message newMessage = Message.AddNew(message);

            return Message.OutputObject(newMessage);
        }
    }
}