using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotificationDemo.Models
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailSender mailRequest);
    }
}
