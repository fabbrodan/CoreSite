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

        public MailController(IOptions<MailConfiguration> mailConfig)
        {
            _mailConfig = mailConfig;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send()
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("daniel.aaslund@gmail.com"));
            message.From.Add(new MailboxAddress("daniel.aaslund@gmail.com"));
            message.Subject = "New message!";
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = Request.Form["body"]
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