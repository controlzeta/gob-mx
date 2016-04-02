using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace GobMxDummy.Models
{
    public class MailModels
    {
        public static int puerto = 587;
        public static string host = "smtp.gmail.com";
        public LinkedResource inlineLogo;

        public string sender { get; set; }
        public string receiver { get; set; }
        public string CC { get; set; }
        public string CCO { get; set; }
        public string body { get; set; }
        public string webLink { get; set; }

        public static SmtpClient CreaCliente()
        {
            SmtpClient client = new SmtpClient();
            client.Port = puerto;
            client.Host = host;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("stpsmail01@gmail.com", "NoTiene123");
            return client;
        }

        public string SendMail(string Subject, string Body, bool btn = false, string btnLink ="", string btnText = "")
        {
            try
            {
                //receiver = "francisco.arroyo@controlzeta.com.mx";
                SmtpClient cliente = CreaCliente();
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("stps@prenat.com.mx", "Secretaria del Trabajo y Previsión Social");
                correo.To.Add(receiver);
                correo.BodyEncoding = UTF8Encoding.UTF8;
                correo.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                correo.IsBodyHtml = true;
                correo.Subject = Subject;
                correo.Body = CreateBody(Subject, Body, btn, btnLink, btnText);
                var view = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                view.LinkedResources.Add(inlineLogo);
                correo.AlternateViews.Add(view);
                cliente.Send(correo);                
            }
            catch (Exception ex)
            {
                return "El mensaje no pudo ser enviado: " + ex.Message.ToString();
            }
            return "Mensaje enviado exitosamente";
        }

        public string CreateBody(string Subject, string Body, bool btn = false, string btnLink = "", string btnText = "Click Aquí")
        {
            webLink = "http://www.x1mexico.com";
            inlineLogo = new LinkedResource(HttpContext.Current.Server.MapPath("~/Images/gob-mx-logo.png"));
            inlineLogo.ContentId = Guid.NewGuid().ToString();
            string logo = string.Format(@"<div class='gob-mx-logo' style='float:left; padding-top: 15px; padding-left: 20px; padding-bottom: 15px;'><img  src='cid:" + inlineLogo.ContentId + " ' ></div> ", inlineLogo.ContentId);
            body = "<html style='font-family: Helvetica,Arial,sans-serif; font-size: 16px; line-height: 1.428571429; color: #545454;'> " +
                    "<head> " +
                    "<meta charset='UTF-8'> " +
                    "</head>" + styles() +
                    "<body style='background-color: #F3F3F3;'>" +
	                    "<div class='main' padding: 0px 27px 0px 27px ; background-color: #F3F3F3;> " +
                            "<div class='header'  style='min-width:560px; min-height:60px; background-color:#393C3E;' > " +
			                    logo +
			                    "<div class='dependencia' style='float:right; padding-top: 15px; padding-right: 20px; padding-bottom: 15px; color:#F3F3F3;'>X1 MÉXICO</div> " +
		                    "</div> " +
		                    "<div class='cuerpo'  style='min-height:350px; padding:10px; text-align:justify; background-color: #FFF;' > " +
			                    "<h1>" + Subject + "</h1> " +
			                    " " + Body + "   " +
			                    "<div class='call-to-action' style=' text-align: center; padding: 20px;'> " ;
				                if(btn)    
                                {
                                    body += "<a href='" + btnLink + "' style='background-color:#4A90E2; padding:20px; color:#FFF; font-family: Helvetica,Arial,sans-serif; font-size: 18px; border-radius: 10px; border-color: #3483de; box-shadow: 0 2px 0 0 #1b5dab;' >" + btnText + "</a> ";
                                }
                        body += "</div> " +
		                    "</div> " +
		                    "<div class='footer' style='min-width:560px; min-height:56px; background-color:#393C3E;'> " +
                                logo +
		                    "</div> " +
		                    "<div class='terms-conditions' style='text-align: center; padding: 5px;'> " +
			                    "<a href='"+ webLink +"'>Términos y condiciones </a> " +
		                    "</div> " +
	                    "</div> " +
                    "</body> " +
                    "</html>";
            return body;

        }

        public static string styles()
        {
            return @"<style>
                    html {
	                    font-family: Helvetica,Arial,sans-serif;
                        font-size: 16px;
                        line-height: 1.428571429;
                        color: #545454;
                    }
                    body {
	                    background-color: #F3F3F3;
                    }
                    button{
	                    background-color:#4A90E2; 
	                    padding:20px; color:#FFF; 
	                    font-family: Helvetica,Arial,sans-serif; 
	                    font-size: 18px;
	                    border-radius: 10px;
	                    border-color: #3483de;
	                    box-shadow: 0 2px 0 0 #1b5dab;
                    }
                    .gob-mx-logo {
	                    float:left;
	                    padding-top: 15px;
	                    padding-left: 20px;
	                    padding-bottom: 15px;
                    }
                    .dependencia {
	                    float:right;
	                    padding-top: 15px;
	                    padding-right: 20px;
	                    padding-bottom: 15px;
	                    color:#F3F3F3;
                    }
                    .main {
	                    padding: 0px 27px 0px 27px ;
	                    background-color: #F3F3F3;
                    }
                    .header {
	                    min-width:560px; 
	                    min-height:60px; 
	                    background-color:#393C3E
                    }
                    .cuerpo {
	                    min-height:350px; 
	                    padding:10px; 
	                    text-align:justify;
	                    background-color: #FFF;
                    }
                    .call-to-action {
	                    text-align: center;
	                    padding: 20px;
                    }
                    .footer {
	                    min-width:560px; 
	                    min-height:56px; 
	                    background-color:#393C3E
                    }
                    .footer img {
	                    width: 80%;
                    }
                    .terms-conditions{
	                    text-align: center;
	                    padding: 5px;
                    }
                    </style>";
        }
    }
}