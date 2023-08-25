using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace VGR_WebAPI
{
    public class Mail
    {
        public static MailAddress mailAddress = null;

        

        public static void mail(List_of_Data data)
        {
            var smtp = new SmtpClient("mailhost.vgregion.se");

            smtp.EnableSsl = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = true;
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential("mikjo64@vgregion.se", "Solros2023");


            MailMessage mailMessage = new MailMessage();

            string arr = "";
            //foreach(var d in data.Arra) 
            //{
            //    arr += "Myndighet: "+d.SelectSelection + "\nFrån datum " + d.FromDate + "   Till datum " + d.ToDate + "\n Datumintervallet avser: " + d.DateInterval + "\n" + 
            //        "Kön: "+d.Gender+"\nÄlder från "+d.AgeFrom + "   Ålder till " + d.AgeTo + "\n" +
            //        "Äldersintervallet avser "+d.AgeInterval + "\nKompletterande beskrivning: " + d.Additional + "\n" + "Variabellista"+d.V.Replace('\\', ' ') + "\n";
            //}

            mailMessage.Body = "Beställningen är mottagen. Behandling av ansökan sker inom 10 arbetsdagar \n\nNamn: " + data.Bestallare_Namn + "\nOrganisation: " + data.Bestallare_Organisation +
                "\nEpost: " + data.Bestallare_Epostadress + "\n\nProjektbeskrivning: " + data.Projektbeskrivning + "\n\nDatauttag\n\n" + arr;


            mailMessage.Subject = "Ansökan";
            mailMessage.From = new MailAddress("mikael.jonsson4@vgregion.se");

            mailMessage.To.Add(data.Bestallare_Epostadress);

            smtp.Send(mailMessage);
            smtp.Dispose();
        }
    }
}
