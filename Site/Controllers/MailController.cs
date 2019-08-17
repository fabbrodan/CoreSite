using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MailKit;
using MailKit.Net;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace Site.Controllers
{
    public class MailController : Controller
    {
        private readonly IOptions<MailConfiguration> _mailConfig;
        private readonly string[] badWords = new string[]
        {
            "cunt",
            "bitch",
            "fucker",
            "hora",
            "slyna",
            "judejävel",
            "jävel",
            "horjävel",
            "kuksugare",
            "cocksucker",
            "cock",
            "sucker",
            "kuk",
            "sugare",
            "fitta"
        };
        public MailController(IOptions<MailConfiguration> mailConfig)
        {
            _mailConfig = mailConfig;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InvalidMessage()
        {
            return View();
        }

        public IActionResult Send()
        {
            string bodyText = Request.Form["body"];
            string subject = Request.Form["subject"];

            string[] bodyWords = bodyText.Split(" ");
            string[] subjectWords = subject.Split(" ");

            foreach (string word in bodyWords)
            {
                foreach(string badWord in badWords)
                {
                    if(word.ToLower() == badWord)
                    {
                        return RedirectToAction("InvalidMessage");
                    }
                }
            }

            foreach (string word in subjectWords)
            {
                foreach(string badWord in badWords)
                {
                    if (word.ToLower() == badWord)
                    {
                        return RedirectToAction("InvalidMessage");
                    }
                }
            }

            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(_mailConfig.Value.Receiver));
            message.From.Add(new MailboxAddress(_mailConfig.Value.SmtpUser));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = bodyText + Environment.NewLine + Environment.NewLine + "Sent from your site."
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_mailConfig.Value.SmtpServer, _mailConfig.Value.SmtpPort, true);
                client.Authenticate(_mailConfig.Value.SmtpUser, _mailConfig.Value.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }

            return RedirectToAction("Index");
        }
    }
}