/*
 *Sistema de Envio de E-mail's 
 *Exemplo desenvolvido por
 *Julio Cesar Bueno de Arruda
 *julio.arruda@outlook.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias para enviar e-mail
using System.Net.Mail;
using System.Net;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______________________________________________");
            Console.WriteLine("Envio de E-mail's ROHR ");
            Console.WriteLine("______________________________________________");

            if (EnviarEmail("SendMail", "sistemas@rohr.com.br", "E-mail de Teste ROHR"))
                Console.WriteLine("E-mail enviado com sucesso");
            else
                Console.WriteLine("Erro ao enviar e-mail");

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();

        }

        static bool EnviarEmail(string assunto, string destinatario, string mensagem)
        {
            try
            {
                

                MailMessage mailMessage = new MailMessage();
                //Endereço que irá aparecer no e-mail do usuário
                mailMessage.From = new MailAddress("noreply@rohr.com.br", "Fale Conosco");
                //destinatarios do e-mail, para incluir mais de um basta separar por ponto e virgula 
                mailMessage.To.Add(destinatario);
                mailMessage.Subject = assunto;
                mailMessage.IsBodyHtml = true;
                //conteudo do corpo do e-mail
                mailMessage.Body = mensagem;
                mailMessage.Priority = MailPriority.High;
                //smtp do e-mail que irá enviar
                SmtpClient smtpClient = new SmtpClient("smtp.office365.com");
                smtpClient.EnableSsl = true;
                //credenciais da conta que utilizará para enviar o e-mail
                smtpClient.Credentials = new NetworkCredential("noreply@rohr.com.br", "system123!");
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
