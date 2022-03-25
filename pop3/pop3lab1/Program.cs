using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limilabs.Mail;
using Limilabs.Client.POP3;

namespace pop3 
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Pop3 pop3 = new Pop3())
            {
                pop3.Connect("elen.9719@gmail.com");  // or ConnectSSL for SSL
                pop3.UseBestLogin("elen.9719@gmail.com", "yscjedicjgkchnjb");

                // Receive all messages and display the subject
                MailBuilder builder = new MailBuilder();
                foreach (string uid in pop3.GetAll())
                {
                    IMail email = builder.CreateFromEml(
                      pop3.GetMessageByUID(uid));

                    Console.WriteLine(email.Subject);
                    Console.WriteLine(email.Text);
                }
                pop3.Close();
            }
        }
    }
}


