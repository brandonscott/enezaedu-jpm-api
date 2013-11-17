using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EnezaApi.Models;
using Newtonsoft.Json.Linq;
using EnezaApi.Classes;

namespace EnezaApi.Controllers
{
    public class MessagesController : ApiController
    {
        [HttpPost]
        public Object Post(String toNumber, String fromNumber, Int32 sent_time, Int32 received_time, String body, String message_type)
        {
            Message message = new Message();
            message.to_user = Models.User.GetIdFromNumber(toNumber);
            message.from_user = Models.User.GetIdFromNumber(fromNumber);
            message.sent_time = sent_time;
            message.received_time = received_time;
            message.body = body;
            message.message_type = MessageType.GetIdByName(message_type);

            if (message.to_user == 0 || message.from_user == 0)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(400));
            }

            if (message.message_type == 0)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(401));
            }

            Message newMessage = Message.AddNew(message);

            return Message.OutputObject(newMessage);
        }
    }
}