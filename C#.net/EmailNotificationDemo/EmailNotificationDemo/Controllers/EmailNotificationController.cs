using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using EmailNotificationDemo.Models;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Unity;

namespace EmailNotificationDemo.Controllers
{
    public class EmailNotificationController : ApiController
    {
        [Dependency]
        private readonly IMailService mailService;
        public EmailNotificationController(){}
        public EmailNotificationController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost]
        [Route("SendEmail")]
        public async Task<IHttpActionResult> SendEmail(EmailSender Model)
        {
            try
            {
                await this.mailService.SendEmailAsync(Model);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}