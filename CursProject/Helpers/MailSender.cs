using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using CursProject.Classes;

namespace CursProject.Helpers
{
    class MailSender
    {
        internal static void SendOffer(Client client, string fileName)
        {
            var smtpClient = new SmtpClient
            {
                Port = Settings.Port, // 587
                Host = Settings.Host, // "smtp.gmail.com"
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(Settings.Login, Settings.Password)
            };


            var text = string.Format("Здравствуйте {0}!. Наша турфирма предлагает Вам ознакомиться с нашими специальными предложениями. Вы можете посмотреть их в, прикрепленном к этому письму, документе.\r\nТуристическое агенство: exat.ru;\r\nE-mail: exatru@mail.ru", client.Fio);
            var mm = new MailMessage(Settings.Login, client.Email, "Специальное предложение", text)
            {
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            if (fileName != "")
            {
                var attachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(fileName);
                disposition.ModificationDate = File.GetLastWriteTime(fileName);
                disposition.ReadDate = File.GetLastAccessTime(fileName);
                disposition.FileName = Path.GetFileName(fileName);
                disposition.Size = new FileInfo(fileName).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                mm.Attachments.Add(attachment);
            }

            smtpClient.Send(mm);
        }
    }
}
