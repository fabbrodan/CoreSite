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

namespace Site.Controllers
{
    public class MailController : Controller
    {
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
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("daniel.aaslund@gmail.com", "Olisykes_8426!");
                client.Send(message);
                client.Disconnect(true);
            }

            return RedirectToAction("Index");
        }
    }
}