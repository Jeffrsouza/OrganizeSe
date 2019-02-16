using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRetorno.Text = "";
        }

        protected void sendMail_Click(object sender, EventArgs e)
        {
            string remetenteEmail = "jeff.hcti@gmail.com"; //O e-mail do remetente

            MailMessage mail = new MailMessage();
            mail.To.Add("duck_hc@hotmail.com");//Email add
            mail.To.Add("jefferson.ti@hotmail.com"); //Email add
            mail.From = new MailAddress(remetenteEmail, "Teste de email", System.Text.Encoding.UTF8);
            mail.Subject = "Assunto:Referente ao e-mail automático";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "<html>" +
                            "<body>" +
                                "<img src = 'http://www.organizeseop.com.br/src/img/imgRight.jpg' style='width:250px; height:250px; border-radius:15px' " +
                                "<p>Teste de e-mail enviado</p>" +
                            "</body>" +
                        "</html>";

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; //Prioridade do E-Mail

            SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
            client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "Freud1010");

            client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio
            client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail
            client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

            try
            {
                client.Send(mail);
                lblRetorno.Text = "Envio do E-mail com sucesso";

            }

            catch (Exception ex)
            {
                lblRetorno.Text = "Ocorreu um erro ao enviar:" + ex.Message;
            }
        }
    }
}