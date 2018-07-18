using JobBoardFinal.UI.Models;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace JobBoardFinal.UI.Controllers
{
   
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin,Manager,Employee")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormViewModel contact)
        {
            ViewBag.Message = "Your contact page.";
            if (ModelState.IsValid)
            {
                string messageContent = $"Name: {contact.Name}<br/>Email:" +
                    $"{contact.Email}<br/>Subject: {contact.Subject}<br/>" +
                    $"<h4>Message<h4> {contact.Message}<br/> TimeStamp:{contact.TimeStamp}";

                MailMessage m = new MailMessage("noreply@alexcroth.com", "a.c.roth89@gmail.com", contact.Subject, messageContent);
                m.IsBodyHtml = true;
                m.ReplyToList.Add(contact.Email);

                m.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient("mail.alexcroth.com");

                client.Credentials = new NetworkCredential("noreply@alexcroth.com", "Gibson89u@");

                using (client)
                {
                    try
                    {
                        client.Send(m);
                    }
                    catch (System.Exception)
                    {
                        ViewBag.ErrorMessage = "There was an error your message. Please try again";
                        return View(contact);
                    }

                }

                return View("ContactConfirm", contact);


            }

            return View();
        }
    }
}
