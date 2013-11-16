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
        static string AccountSid = "AC3b8cd1e12a5b6ff4e4ea25f431833a97";
        static string AuthToken = "22964db1d502e5069c2d44c9a49c8b6c";
        static TwilioRestClient twilio = new TwilioRestClient(AccountSid, AuthToken);
        static int i = 0;
        static void Main(string[] args)
        {

            var smss = twilio.ListMessages();
            var s =  smss.Messages.Where(x => x.To == "+441332402803").FirstOrDefault();
            
                Console.Write(s.Body);
        

          //  Console.WriteLine(smss.SMSMessages.First<SMSMessage>().Body);
            //Sam 447855815341
            //Chris 447879995760
            //var test = twilio.SendSmsMessage("+441332402803", "+447879995760", "Hi Lisa", "");

            poll.Interval = 10000;
            poll.Elapsed += poll_Elapsed;
            poll.Start();

            //Console.WriteLine(test.Status);
            Console.Read();


          }

        static void poll_Elapsed(object sender, ElapsedEventArgs e)
        {
            //i++;
            //var test = twilio.SendSmsMessage("+441332402803", "+447879995760", "Hi Lisa", "");
            //Console.WriteLine(i);
            //Console.Write(test);
        }
            

    }
 }
