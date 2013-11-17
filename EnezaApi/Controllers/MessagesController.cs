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
        public Object Post(HttpRequestMessage request)
        {
            JObject postData = JObject.Parse(request.Content.ReadAsStringAsync().Result);

            Message message = new Message();
            Models.User tempToUser = Models.User.GetByNumber((String)postData["toNumber"]);

            if (tempToUser == null)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(400));
            }

            message.to_user = tempToUser.Id;

            Models.User tempFromUser = Models.User.GetByNumber((String)postData["fromNumber"]);

            if (tempFromUser == null)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(400));
            }

            message.from_user = tempFromUser.Id;

            message.sent_time = (Int32)postData["sent_time"];
            message.received_time = (Int32)postData["received_time"];
            message.body = (String)postData["body"];
            MessageType tempMessageType = MessageType.GetByName((String)postData["message_time"]);

            if (tempMessageType == null)
            {
                return JObject.FromObject(ErrorReporting.GenerateCustomError(401));
            }

            message.message_type = tempMessageType.Id;

            Message newMessage = Message.AddNew(message);

            return Message.OutputObject(newMessage);
        }
    }
}