using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace taskss
{
    public class EmailSender
    {
        public void SendEmail(string adress, string fileName, string log)
        {
            MailAddress fromAddress = new MailAddress("dvoryanchikov.danil@bk.ru", "AQA WEB PSB" +
                "");
            MailAddress toAddress = new MailAddress(adress);
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Body = log;
            message.Subject = "лог";

            byte[] bytes = System.IO.File.ReadAllBytes($"{Environment.GetEnvironmentVariable("ScreensPath")}/{fileName}.png");
            MemoryStream ms = new MemoryStream(bytes);
            message.Attachments.Add(new Attachment(ms, $"{fileName}.png"));

   
            using (SmtpClient smtp = new SmtpClient("smtp.bk.ru", 2525))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, "Ht9L0gNwhr3QRxkyjcJf");
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }          
        }

    }
}
