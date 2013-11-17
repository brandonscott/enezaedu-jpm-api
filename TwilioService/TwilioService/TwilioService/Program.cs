using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Twilio;

namespace TwilioService
{
    class Program
    {
        static Timer poll = new Timer();
        static string AccountSid;
        static string AuthToken;
        static TwilioRestClient twilio ;
        static long lastMessageTime;
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        static void Main(string[] args)
        {

            //BS: Setup account details and get our client
            AccountSid = "AC3b8cd1e12a5b6ff4e4ea25f431833a97";
            AuthToken = "22964db1d502e5069c2d44c9a49c8b6c";
            twilio = new TwilioRestClient(AccountSid, AuthToken);

            lastMessageTime = ConvertToTimestamp(GetReceivedMessages()[0].DateSent);

            poll.Interval = 2000;
            poll.Elapsed += poll_Elapsed;
            poll.Start();
           
            Console.Read(); 
          }
        
        static long ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long) elapsedTime.TotalSeconds;
        }
             
        /// <summary>
        /// Runs on each server poll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void poll_Elapsed(object sender, ElapsedEventArgs e)
        {
            //i++;
            //var test = twilio.SendSmsMessage("+441332402803", "+447879995760", "Hi Lisa", "");
            //Console.WriteLine(i);
            //Console.Write(test);
            try
            {
                GetNewReceivedMessages().ForEach((x) =>
                { //ADD MESSAGE ENDPOINT 
                    Console.WriteLine(x.Body);
                });
            }
            catch
            {

            }
        }

        /// <summary>
        /// Returns all messages sent to the service
        /// </summary>
        /// <returns>Messages List</returns>
        static List<Message> GetReceivedMessages ()  
        {
            List<Message> messages = null;
            try
            {
                var smss = twilio.ListMessages();
                messages = smss.Messages.Where(x => x.To == "+441332402803").ToList();
                
            }
            catch
            {

            }
            return messages;
            //Get the latest received message
#if DEBUG
            Console.WriteLine(messages[0].Body);
#endif
           
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       static List<Message> GetNewReceivedMessages ()
       {
           List<Message> messages = null;
           try
           {
               messages = GetReceivedMessages().Where(x => ConvertToTimestamp(x.DateSent) > lastMessageTime).ToList();
               if (messages.Count != 0)
                   lastMessageTime = ConvertToTimestamp(messages[0].DateSent);
              
           }
           catch
           {

           }
           return messages;
       }

    }
 }
