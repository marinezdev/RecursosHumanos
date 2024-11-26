using Aspose.Cells.Drawing.Texts;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto.Paddings;
using ProyectoBase.Data;
using ProyectoBase.Models;
using ProyectoBase.Models.Consultas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ProspectoEntrevista
    {
        Data.ProspectoEntrevista _ProspectoEntrevista = new Data.ProspectoEntrevista();
        Data.Prospecto _Prospecto = new Data.Prospecto();
        WSCorreo.CorreoSoapClient correo = new WSCorreo.CorreoSoapClient();

        public Models.ProspectoEntrevista ProspectoEntrevista_Agregar(Models.ProspectoEntrevista prospectoEntrevista)
        {
            Models.ProspectoEntrevista dbProspectoEntrevista = _ProspectoEntrevista.ProspectoEntrevista_Agregar(prospectoEntrevista);
            
            if (prospectoEntrevista.EntrevistaAceptada == 0)
            {
                if(prospectoEntrevista.Responsable == 1)
                {
                    Models.Consultas.VacanteResponsables VacanteResponsables = _Prospecto.Prospecto_Seleccionar_Responsable_IdProspecto(prospectoEntrevista.Prospecto);
                    correo.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", VacanteResponsables.VacanteResponsable.Email, "Asae Consultores S.A de C.V", "Agenda de entrevista - " + VacanteResponsables.Vacante.Titulo, CorreoAgendarEntrevistaResponsable(VacanteResponsables, prospectoEntrevista));
                }
                else
                {
                    // ENVIO DE CORREO A LIDER DE PROYECTO
                    Models.Consultas.VacanteUsuario vacanteUsuario = _Prospecto.Prospecto_Seleccionar_Usuario_IdProspecto(prospectoEntrevista.Prospecto);
                    correo.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", vacanteUsuario.EMails.Email, "Asae Consultores S.A de C.V", "Agenda de entrevista - " + vacanteUsuario.Vacante.Titulo, CorreoAgendarEntrevista(vacanteUsuario, prospectoEntrevista));
                }
                
            }

            return dbProspectoEntrevista;
        }
        public List<Models.ProspectoEntrevista> ProspectoEntrevista_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            return _ProspectoEntrevista.ProspectoEntrevista_Seleccionar_IdVacante(vacante);
        }
        public List<Models.ProspectoEntrevista> ProspectoEntrevista_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoEntrevista.ProspectoEntrevista_Seleccionar_IdProspecto(prospecto);
        }

        public Models.ProspectoEntrevista ProspectoEntrevista_Actualizar_IdEstatus(Models.ProspectoEntrevista prospectoEntrevista)
        {
            Models.ProspectoEntrevista dbrospectoEntrevista = _ProspectoEntrevista.ProspectoEntrevista_Actualizar_IdEstatus(prospectoEntrevista);

            if(dbrospectoEntrevista.Id > 0)
            {
                if(prospectoEntrevista.Notificar == 1)
                {
                    string Asunto = "";
                    string contenido = "";
                    Models.ProspectoEntrevista dbrospectoEntrevista1 = _ProspectoEntrevista.ProspectoEntrevista_Seleccionar_Id(prospectoEntrevista);
                    if (dbrospectoEntrevista1.Cat_EstatusEntrevistas.Nombre == "ACEPTADA")
                    {
                        Asunto = "Aceptada";
                        contenido = $@"<p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:39px;color:#455A64;font-size:26px;text-align:center"">
                                        <strong> Entrevista Aceptada</strong>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:center"">
                                        <br>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                        Estimado/a  <strong> {dbrospectoEntrevista1.Prospecto.Nombre + " " + dbrospectoEntrevista1.Prospecto.ApellidoPaterno + " " + dbrospectoEntrevista1.Prospecto.ApellidoMaterno}  </strong>.<br><br>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                        Gracias por su interés en la vacante <strong> {dbrospectoEntrevista1.Vacante.Titulo}  </strong>.<br><br>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                        Nos complace confirmar que su solicitud ha sido aceptada y que le invitamos a una entrevista el <strong>{dbrospectoEntrevista1.FechaEntrevista}</strong><br><br>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                        <br> Observaciones: <br> 
                                            <strong> {dbrospectoEntrevista1.Observaciones} </strong>
                                        <br><br>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                        Pronto recibirás detalles adicionales sobre los siguientes pasos y la coordinación específica de la entrevista, incluyendo la ubicación o plataforma virtual correspondiente. Ante cualquier consulta o requerimiento adicional, no dudes en comunicarte con nosotros.
                                        <br><br> Agradecemos tu compromiso y profesionalismo en este proceso. <br><br>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                        Atentamente: <br>
                                        <strong>Asae Consultores S.A de C.V </strong><br><br>
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                        <strong>P.D.:</strong> Si tiene alguna pregunta, no dude en ponerse en contacto conmigo. 
                                    </p>
                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                        <br><br>
                                    </p>";
                    }
                    else if (dbrospectoEntrevista1.Cat_EstatusEntrevistas.Nombre == "REAGENDADA")
                    {
                        Asunto = "Reagendación Entrevista";
                        contenido = $@"<p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:39px;color:#455A64;font-size:26px;text-align:center"">
                                            <strong> Reagendación Entrevista </strong>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:center"">
                                            <br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                            Estimado/a  <strong> {dbrospectoEntrevista1.Prospecto.Nombre + " " + dbrospectoEntrevista1.Prospecto.ApellidoPaterno + " " + dbrospectoEntrevista1.Prospecto.ApellidoMaterno}  </strong>.<br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                            Se le informa que hemos tenido que reagendar tu entrevista para {dbrospectoEntrevista1.FechaEntrevista} debido a <strong> {dbrospectoEntrevista1.Observaciones } </strong>. <br> <br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                            Lamentamos cualquier inconveniente que esto pueda causarte y agradecemos tu comprensión. <br><br>
                                        </p>      
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            Si hay alguna dificultad con la nueva fecha, por favor avísanos lo antes posible. ¡Gracias por tu comprensión! <br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            Atentamente: <br>
                                            <strong>Asae Consultores S.A de C.V </strong><br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            <strong>P.D.:</strong> Si tiene alguna pregunta, no dude en ponerse en contacto conmigo. 
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                            <br><br>
                                        </p>";
                    }
                    else if (dbrospectoEntrevista1.Cat_EstatusEntrevistas.Nombre == "EN PROCESÓ DE ACEPTACIÓN")
                    {
                        Asunto = "Seguimiento Proceso de Entrevista";
                        contenido = $@"<p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:39px;color:#455A64;font-size:26px;text-align:center"">
                                            <strong> Seguimiento Proceso de Entrevista </strong>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:center"">
                                            <br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                            Estimado/a  <strong> {dbrospectoEntrevista1.Prospecto.Nombre + " " + dbrospectoEntrevista1.Prospecto.ApellidoPaterno + " " + dbrospectoEntrevista1.Prospecto.ApellidoMaterno}  </strong>.<br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                            Queremos informarte que tu entrevista está actualmente en la fase de <strong>En Proceso de Aceptación<strong>. En este momento, nuestro equipo evaluador está dedicando tiempo y atención para asegurarse de tomar la mejor decisión respecto a tu candidatura. <br> <br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                            Te mantendremos informado sobre cualquier actualización importante. Si tienes alguna pregunta o necesitas más información, no dudes en ponerte en contacto con nosotros.<br><br>
                                        </p>      
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            <br> Observaciones: <br> 
                                                <strong> {dbrospectoEntrevista1.Observaciones} </strong>
                                            <br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            ¡Agradecemos tu paciencia y esperamos contar contigo pronto!<br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            Atentamente: <br>
                                            <strong>Asae Consultores S.A de C.V </strong><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            <strong>P.D.:</strong> Si tiene alguna pregunta, no dude en ponerse en contacto conmigo. 
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                            <br><br>
                                        </p>";
                    }
                    else if (dbrospectoEntrevista1.Cat_EstatusEntrevistas.Nombre == "CANCELADA")
                    {
                        Asunto = "Cancelación  Entrevista";
                        contenido = $@"<p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:39px;color:#455A64;font-size:26px;text-align:center"">
                                            <strong> Cancelación  Entrevista </strong>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:center"">
                                            <br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                            Estimado/a  <strong> {dbrospectoEntrevista1.Prospecto.Nombre + " " + dbrospectoEntrevista1.Prospecto.ApellidoPaterno + " " + dbrospectoEntrevista1.Prospecto.ApellidoMaterno}  </strong>.<br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                           Lamentamos informarte que hemos tenido que cancelar tu entrevista programada para <strong>{dbrospectoEntrevista1.FechaEntrevista}</strong> debido a <strong>{dbrospectoEntrevista1.Observaciones}</strong>. Entendemos que esto puede ser inconveniente y queremos disculparnos por cualquier molestia que pueda haber causado. <br> <br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                           Estamos evaluando posibles soluciones y, si es necesario, nos pondremos en contacto contigo para reprogramar. Agradecemos tu comprensión en este asunto.<br><br>
                                        </p>      
                                        
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                           Si tienes alguna pregunta o necesitas más información, por favor, no dudes en comunicarte con nosotros.<br><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                            Atentamente: <br>
                                            <strong>Asae Consultores S.A de C.V </strong><br>
                                        </p>
                                        <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                            <br><br>
                                        </p>";
                    }

                    correo.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", dbrospectoEntrevista1.Prospecto.CorreElectronico, "Asae Consultores S.A de C.V", Asunto + " - " + dbrospectoEntrevista1.Vacante.Titulo, CorreoNotificarEntrevista(dbrospectoEntrevista1, contenido));
                }
            }

            return dbrospectoEntrevista;
        }

        public string CorreoNotificarEntrevista(Models.ProspectoEntrevista dbrospectoEntrevista, string contenido)
        {
            string HTML = $@"
                    <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                    <html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
                     <head>
                      <meta charset=""UTF-8"">
                      <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
                      <meta name=""x-apple-disable-message-reformatting"">
                      <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                      <meta content=""telephone=no"" name=""format-detection"">
                      <title>Nuevo mensaje</title><!--[if (mso 16)]>
                        <style type=""text/css"">
                        a {{text-decoration: none;}}
                        </style>
                        <![endif]--><!--[if gte mso 9]><style>sup {{ font-size: 100% !important; }}</style><![endif]--><!--[if gte mso 9]>
                    <xml>
                        <o:OfficeDocumentSettings>
                        <o:AllowPNG></o:AllowPNG>
                        <o:PixelsPerInch>96</o:PixelsPerInch>
                        </o:OfficeDocumentSettings>
                    </xml>
                    <![endif]--><!--[if !mso]><!-- -->
                      <link href=""https://fonts.googleapis.com/css2?family=Orbitron&display=swap"" rel=""stylesheet""><!--<![endif]-->
                      <style type=""text/css"">
                    #outlook a {{
	                    padding:0;
                    }}
                    .es-button {{
	                    mso-style-priority:100!important;
	                    text-decoration:none!important;
                    }}
                    a[x-apple-data-detectors] {{
	                    color:inherit!important;
	                    text-decoration:none!important;
	                    font-size:inherit!important;
	                    font-family:inherit!important;
	                    font-weight:inherit!important;
	                    line-height:inherit!important;
                    }}
                    .es-desk-hidden {{
	                    display:none;
	                    float:left;
	                    overflow:hidden;
	                    width:0;
	                    max-height:0;
	                    line-height:0;
	                    mso-hide:all;
                    }}
                    p {{
                        Margin:0;
                        -webkit-text-size-adjust:none;
                        -ms-text-size-adjust:none;
                        mso-line-height-rule:exactly;
                        font-family:arial, 'helvetica neue', helvetica, sans-serif;
                        line-height:21px;
                        color:#455A64;
                        font-size:14px;
                        text-align:left
                    }}
                    @media only screen and (max-width:600px) {{p, ul li, ol li, a {{ line-height:150%!important }} h1, h2, h3, h1 a, h2 a, h3 a {{ line-height:120% }} h1 {{ font-size:30px!important; text-align:left }} h2 {{ font-size:24px!important; text-align:left }} h3 {{ font-size:20px!important; text-align:left }} .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a {{ font-size:30px!important; text-align:left }} 
                    .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a {{ font-size:24px!important; text-align:left }} .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a {{ font-size:20px!important; text-align:left }} .es-menu td a {{ font-size:14px!important }} .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a {{ font-size:14px!important }} .es-content-body p, 
                    .es-content-body ul li, .es-content-body ol li, .es-content-body a {{ font-size:14px!important }} .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a {{ font-size:14px!important }} .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a {{ font-size:12px!important }} *[class=""gmail-fix""] {{ display:none!important }} .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, 
                    .es-m-txt-c h3 {{ text-align:center!important }} .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 {{ text-align:right!important }} .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 {{ text-align:left!important }} .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img {{ display:inline!important }} .es-button-border {{ display:inline-block!important }} a.es-button, 
                    button.es-button {{ font-size:18px!important; display:inline-block!important }} .es-adaptive table, .es-left, .es-right {{ width:100%!important }} .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header {{ width:100%!important; max-width:600px!important }} .es-adapt-td {{ display:block!important; width:100%!important }} .adapt-img {{ width:100%!important; height:auto!important }} 
                    .es-m-p0 {{ padding:0!important }} .es-m-p0r {{ padding-right:0!important }} .es-m-p0l {{ padding-left:0!important }} .es-m-p0t {{ padding-top:0!important }} .es-m-p0b {{ padding-bottom:0!important }} .es-m-p20b {{ padding-bottom:20px!important }} .es-mobile-hidden, .es-hidden {{ display:none!important }} 
                    tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden {{ width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }} tr.es-desk-hidden {{ display:table-row!important }} table.es-desk-hidden {{ display:table!important }} td.es-desk-menu-hidden {{ display:table-cell!important }} .es-menu td {{ width:1%!important }} 
                    table.es-table-not-adapt, .esd-block-html table {{ width:auto!important }} table.es-social {{ display:inline-block!important }} table.es-social td {{ display:inline-block!important }} .es-desk-hidden {{ display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important }} .es-m-p5 {{ padding:5px!important }} .es-m-p5t {{ padding-top:5px!important }} 
                    .es-m-p5b {{ padding-bottom:5px!important }} .es-m-p5r {{ padding-right:5px!important }} .es-m-p5l {{ padding-left:5px!important }} .es-m-p10 {{ padding:10px!important }} .es-m-p10t {{ padding-top:10px!important }} .es-m-p10b {{ padding-bottom:10px!important }} .es-m-p10r {{ padding-right:10px!important }} .es-m-p10l {{ padding-left:10px!important }} .es-m-p15 {{ padding:15px!important }} 
                    .es-m-p15t {{ padding-top:15px!important }} .es-m-p15b {{ padding-bottom:15px!important }} .es-m-p15r {{ padding-right:15px!important }} .es-m-p15l {{ padding-left:15px!important }} .es-m-p20 {{ padding:20px!important }} .es-m-p20t {{ padding-top:20px!important }} .es-m-p20r {{ padding-right:20px!important }} .es-m-p20l {{ padding-left:20px!important }} .es-m-p25 {{ padding:25px!important }} 
                    .es-m-p25t {{ padding-top:25px!important }} .es-m-p25b {{ padding-bottom:25px!important }} .es-m-p25r {{ padding-right:25px!important }} .es-m-p25l {{ padding-left:25px!important }} .es-m-p30 {{ padding:30px!important }} .es-m-p30t {{ padding-top:30px!important }} .es-m-p30b {{ padding-bottom:30px!important }} .es-m-p30r {{ padding-right:30px!important }} .es-m-p30l {{ padding-left:30px!important }} 
                    .es-m-p35 {{ padding:35px!important }} .es-m-p35t {{ padding-top:35px!important }} .es-m-p35b {{ padding-bottom:35px!important }} .es-m-p35r {{ padding-right:35px!important }} .es-m-p35l {{ padding-left:35px!important }} .es-m-p40 {{ padding:40px!important }} .es-m-p40t {{ padding-top:40px!important }} .es-m-p40b {{ padding-bottom:40px!important }} .es-m-p40r {{ padding-right:40px!important }} 
                    .es-m-p40l {{ padding-left:40px!important }} }}
                    </style>
                     </head>
                     <body style=""width:100%;font-family:arial, 'helvetica neue', helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0"">
                      <div class=""es-wrapper-color"" style=""background-color:#EFEFEF""><!--[if gte mso 9]>
			                    <v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
				                    <v:fill type=""tile"" color=""#efefef"" origin=""0.5, 0"" position=""0.5, 0""></v:fill>
			                    </v:background>
		                    <![endif]-->
                       <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#EFEFEF"">
                         <tr>
                          <td valign=""top"" style=""padding:0;Margin:0"">
                           <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table class=""es-content-body"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#cfe2f3;width:600px"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#cfe2f3"" align=""center"">
                                 <tr>
                                  <td align=""left"" style=""padding:0;Margin:0"">
                                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td class=""es-m-p0r es-m-p20b"" valign=""top"" align=""center"" style=""padding:0;Margin:0;width:600px"">
                                       <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" style=""padding:0;Margin:0;position:relative""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#068FC1;font-size:14px""><img class=""adapt-img"" src=""https://mcbihx.stripocdn.email/content/guids/bannerImgGuid/images/image16953231768215542.png"" alt=""World tourism day"" title=""World tourism day"" width=""600"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""384""></a></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                               </table></td>
                             </tr>
                           </table>
                           <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""Margin:0;padding-top:20px;padding-left:20px;padding-right:20px;padding-bottom:30px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                            <td align=""left"" class=""es-m-txt-c es-m-p0r es-m-p0l"" style=""padding:0;Margin:0;padding-left:40px;padding-right:40px"">
                                                { contenido }
                                            </td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
             
                               </table></td>
                             </tr>
                           </table>
                          
                            <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" style=""padding:0;Margin:0;font-size:0"">
                                           <table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                             <tr>
                                              <td style=""padding:0;Margin:0;border-bottom:1px solid #9cd3ec;background:unset;height:1px;width:100%;margin:0px""></td>
                                             </tr>
                                           </table></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                                 <tr>
                                 </table>
                                </td>
                             </tr>
                           </table>
                           <table cellpadding=""0"" cellspacing=""0"" class=""es-footer"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-footer-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""Margin:0;padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:40px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" style=""padding:0;Margin:0""><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                                 <tr>
                                  <td align=""left"" style=""Margin:0;padding-left:20px;padding-right:20px;padding-top:30px;padding-bottom:30px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""left"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" class=""es-infoblock made_with"" style=""padding:0;Margin:0;line-height:14px;font-size:0px;color:#CCCCCC""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#CCCCCC;font-size:12px""><img src=""https://mcbihx.stripocdn.email/content/guids/CABINET_dd9638105a0e16e64bb51094f748e01204c98b514c82e3a56b420241fe394548/images/asaelogo_kRs.png"" alt width=""125"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""52""></a></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                               </table></td>
                             </tr>
                           </table></td>
                         </tr>
                       </table>
                      </div>
                     </body>
                    </html>
                    ";

            return HTML;
        }
        public string CorreoAgendarEntrevista(Models.Consultas.VacanteUsuario vacanteUsuario, Models.ProspectoEntrevista prospectoEntrevista)
        {
            string Prospecto = Application.UrlCifrardo.Encriptar(prospectoEntrevista.Prospecto.Id.ToString());
            string Html = $@"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
 <head>
  <meta charset=""UTF-8"">
  <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
  <meta name=""x-apple-disable-message-reformatting"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <meta content=""telephone=no"" name=""format-detection"">
  <title>Nuevo mensaje</title><!--[if (mso 16)]>
    <style type=""text/css"">
    a {{text-decoration: none;}}
    </style>
    <![endif]--><!--[if gte mso 9]><style>sup {{ font-size: 100% !important; }}</style><![endif]--><!--[if gte mso 9]>
<xml>
    <o:OfficeDocumentSettings>
    <o:AllowPNG></o:AllowPNG>
    <o:PixelsPerInch>96</o:PixelsPerInch>
    </o:OfficeDocumentSettings>
</xml>
<![endif]--><!--[if !mso]><!-- -->
  <link href=""https://fonts.googleapis.com/css2?family=Orbitron&display=swap"" rel=""stylesheet""><!--<![endif]-->
  <style type=""text/css"">
#outlook a {{
	padding:0;
}}
.es-button {{
	mso-style-priority:100!important;
	text-decoration:none!important;
}}
a[x-apple-data-detectors] {{
	color:inherit!important;
	text-decoration:none!important;
	font-size:inherit!important;
	font-family:inherit!important;
	font-weight:inherit!important;
	line-height:inherit!important;
}}
.es-desk-hidden {{
	display:none;
	float:left;
	overflow:hidden;
	width:0;
	max-height:0;
	line-height:0;
	mso-hide:all;
}}
@media only screen and (max-width:600px) {{p, ul li, ol li, a {{ line-height:150%!important }} h1, h2, h3, h1 a, h2 a, h3 a {{ line-height:120% }} h1 {{ font-size:30px!important; text-align:left }} h2 {{ font-size:24px!important; text-align:left }} h3 {{ font-size:20px!important; text-align:left }} .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a {{ font-size:30px!important; text-align:left }} .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a {{ font-size:24px!important; text-align:left }} .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a {{ font-size:20px!important; text-align:left }} .es-menu td a {{ font-size:14px!important }} .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a {{ font-size:14px!important }} .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a {{ font-size:14px!important }} .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a {{ font-size:14px!important }} .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a {{ font-size:12px!important }} *[class=""gmail-fix""] {{ display:none!important }} .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 {{ text-align:center!important }} .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 {{ text-align:right!important }} .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 {{ text-align:left!important }} .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img {{ display:inline!important }} .es-button-border {{ display:inline-block!important }} a.es-button, button.es-button {{ font-size:18px!important; display:inline-block!important }} .es-adaptive table, .es-left, .es-right {{ width:100%!important }} .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header {{ width:100%!important; max-width:600px!important }} .es-adapt-td {{ display:block!important; width:100%!important }} .adapt-img {{ width:100%!important; height:auto!important }} .es-m-p0 {{ padding:0!important }} .es-m-p0r {{ padding-right:0!important }} .es-m-p0l {{ padding-left:0!important }} .es-m-p0t {{ padding-top:0!important }} .es-m-p0b {{ padding-bottom:0!important }} .es-m-p20b {{ padding-bottom:20px!important }} .es-mobile-hidden, .es-hidden {{ display:none!important }} tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden {{ width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }} tr.es-desk-hidden {{ display:table-row!important }} table.es-desk-hidden {{ display:table!important }} td.es-desk-menu-hidden {{ display:table-cell!important }} .es-menu td {{ width:1%!important }} table.es-table-not-adapt, .esd-block-html table {{ width:auto!important }} table.es-social {{ display:inline-block!important }} table.es-social td {{ display:inline-block!important }} .es-desk-hidden {{ display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important }} .es-m-p5 {{ padding:5px!important }} .es-m-p5t {{ padding-top:5px!important }} .es-m-p5b {{ padding-bottom:5px!important }} .es-m-p5r {{ padding-right:5px!important }} .es-m-p5l {{ padding-left:5px!important }} .es-m-p10 {{ padding:10px!important }} .es-m-p10t {{ padding-top:10px!important }} .es-m-p10b {{ padding-bottom:10px!important }} .es-m-p10r {{ padding-right:10px!important }} .es-m-p10l {{ padding-left:10px!important }} .es-m-p15 {{ padding:15px!important }} .es-m-p15t {{ padding-top:15px!important }} .es-m-p15b {{ padding-bottom:15px!important }} .es-m-p15r {{ padding-right:15px!important }} .es-m-p15l {{ padding-left:15px!important }} .es-m-p20 {{ padding:20px!important }} .es-m-p20t {{ padding-top:20px!important }} .es-m-p20r {{ padding-right:20px!important }} .es-m-p20l {{ padding-left:20px!important }} .es-m-p25 {{ padding:25px!important }} .es-m-p25t {{ padding-top:25px!important }} .es-m-p25b {{ padding-bottom:25px!important }} .es-m-p25r {{ padding-right:25px!important }} .es-m-p25l {{ padding-left:25px!important }} .es-m-p30 {{ padding:30px!important }} .es-m-p30t {{ padding-top:30px!important }} .es-m-p30b {{ padding-bottom:30px!important }} .es-m-p30r {{ padding-right:30px!important }} .es-m-p30l {{ padding-left:30px!important }} .es-m-p35 {{ padding:35px!important }} .es-m-p35t {{ padding-top:35px!important }} .es-m-p35b {{ padding-bottom:35px!important }} .es-m-p35r {{ padding-right:35px!important }} .es-m-p35l {{ padding-left:35px!important }} .es-m-p40 {{ padding:40px!important }} .es-m-p40t {{ padding-top:40px!important }} .es-m-p40b {{ padding-bottom:40px!important }} .es-m-p40r {{ padding-right:40px!important }} .es-m-p40l {{ padding-left:40px!important }} }}
</style>
 </head>
 <body style=""width:100%;font-family:arial, 'helvetica neue', helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0"">
  <div class=""es-wrapper-color"" style=""background-color:#EFEFEF""><!--[if gte mso 9]>
			<v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
				<v:fill type=""tile"" color=""#efefef"" origin=""0.5, 0"" position=""0.5, 0""></v:fill>
			</v:background>
		<![endif]-->
   <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#EFEFEF"">
     <tr>
      <td valign=""top"" style=""padding:0;Margin:0"">
       <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table class=""es-content-body"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#cfe2f3;width:600px"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#cfe2f3"" align=""center"">
             <tr>
              <td align=""left"" style=""padding:0;Margin:0"">
               <table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td class=""es-m-p0r es-m-p20b"" valign=""top"" align=""center"" style=""padding:0;Margin:0;width:600px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0;position:relative""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#068FC1;font-size:14px""><img class=""adapt-img"" src=""https://mcbihx.stripocdn.email/content/guids/bannerImgGuid/images/image16953231768215542.png"" alt=""World tourism day"" title=""World tourism day"" width=""600"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""384""></a></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
           </table></td>
         </tr>
       </table>
       <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
             <tr>
              <td align=""left"" style=""Margin:0;padding-top:20px;padding-left:20px;padding-right:20px;padding-bottom:30px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                        <td align=""left"" class=""es-m-txt-c es-m-p0r es-m-p0l"" style=""padding:0;Margin:0;padding-left:40px;padding-right:40px"">
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:39px;color:#455A64;font-size:26px;text-align:center"">
                                <strong> Agenda de entrevista  </strong>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                            <br>
                                Estimado/a  {vacanteUsuario.Personas.Nombre + " " + vacanteUsuario.Personas.ApPaterno + " " + vacanteUsuario.Personas.ApMaterno}
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                Le escribo para solicitar un espacio para recbir el candidato para la entrevista {vacanteUsuario.Vacante.Titulo} 
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:right"">
                            <br>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                -- Observaciones : <br> {prospectoEntrevista.Observaciones}
                            <br>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                            <br>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                Apreciamos su interés y apoyo en este proceso de selección. Estaremos atentos a los avances y mantendremos informado al equipo de proyecto sobre cualquier actualización relevante.
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                <br><br>
                            </p>
                        </td>
                     </tr>
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:20px"">
                                <a href="""" target=""_blank"" hidden>
	                                <v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" esdevVmlButton href=""https://www.asae.com.mx/Entrevistas/EntrevistaAceptada?sold={Prospecto}""  style=""height:60px; v-text-anchor:middle; width:154px"" arcsize=""24%"" stroke=""f""  fillcolor=""#44a8df"">
		                            <w:anchorlock></w:anchorlock>
		                            <center style='color:#ffffff; font-family:arial, ""helvetica neue"", helvetica, sans-serif; font-size:15px; font-weight:400; line-height:20px;  mso-text-raise:1px' href="""">Aceptar entrevista</center>
	                                </v:roundrect>
                                </a>
                            &nbsp;&nbsp;&nbsp;
                            <a href="""" target=""_blank"" hidden>
	                            <v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" esdevVmlButton href=""https://www.asae.com.mx/Entrevistas/ReagendarEntrevista?sold={Prospecto}""  style=""height:60px; v-text-anchor:middle; width:154px"" arcsize=""24%"" stroke=""f""  fillcolor=""#44a8df"">
		                        <w:anchorlock></w:anchorlock>
		                        <center style='color:#ffffff; font-family:arial, ""helvetica neue"", helvetica, sans-serif; font-size:15px; font-weight:400; line-height:20px;  mso-text-raise:1px'>Reagendar entrevista </center>
	                            </v:roundrect>
                            </a>
                            <![endif]--><!--[if !mso]><!-- --><span class=""msohide es-button-border"" style=""border-style:solid;border-color:#2CB543;background:#44a8df;border-width:0px;display:inline-block;border-radius:10px;width:auto;mso-hide:all""><a href="""" class=""es-button"" target=""_blank"" style=""mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#FFFFFF;font-size:18px;padding:10px 20px 10px 20px;display:inline-block;background:#44a8df;border-radius:10px;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-weight:normal;font-style:normal;line-height:22px;width:auto;text-align:center;mso-padding-alt:0;mso-border-alt:10px solid #44A8DF"">Ver vacante 2</a></span><!--<![endif]--></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             
           </table></td>
         </tr>
       </table>
       <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
             <tr>
              <td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0;font-size:0"">
                       <table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                         <tr>
                          <td style=""padding:0;Margin:0;border-bottom:1px solid #9cd3ec;background:unset;height:1px;width:100%;margin:0px""></td>
                         </tr>
                       </table></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr>
             </table>
            </td>
         </tr>
       </table>
       <table cellpadding=""0"" cellspacing=""0"" class=""es-footer"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table bgcolor=""#ffffff"" class=""es-footer-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
             <tr>
              <td align=""left"" style=""Margin:0;padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:40px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0""><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr>
              <td align=""left"" style=""Margin:0;padding-left:20px;padding-right:20px;padding-top:30px;padding-bottom:30px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""left"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" class=""es-infoblock made_with"" style=""padding:0;Margin:0;line-height:14px;font-size:0px;color:#CCCCCC""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#CCCCCC;font-size:12px""><img src=""https://mcbihx.stripocdn.email/content/guids/CABINET_dd9638105a0e16e64bb51094f748e01204c98b514c82e3a56b420241fe394548/images/asaelogo_kRs.png"" alt width=""125"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""52""></a></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
           </table></td>
         </tr>
       </table></td>
     </tr>
   </table>
  </div>
 </body>
</html>
";
            return Html;
        }
        public string CorreoAgendarEntrevistaResponsable(Models.Consultas.VacanteResponsables vacanteResponsables, Models.ProspectoEntrevista prospectoEntrevista)
        {
            string Prospecto = Application.UrlCifrardo.Encriptar(prospectoEntrevista.Prospecto.Id.ToString());
            string Html = $@"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
 <head>
  <meta charset=""UTF-8"">
  <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
  <meta name=""x-apple-disable-message-reformatting"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <meta content=""telephone=no"" name=""format-detection"">
  <title>Nuevo mensaje</title><!--[if (mso 16)]>
    <style type=""text/css"">
    a {{text-decoration: none;}}
    </style>
    <![endif]--><!--[if gte mso 9]><style>sup {{ font-size: 100% !important; }}</style><![endif]--><!--[if gte mso 9]>
<xml>
    <o:OfficeDocumentSettings>
    <o:AllowPNG></o:AllowPNG>
    <o:PixelsPerInch>96</o:PixelsPerInch>
    </o:OfficeDocumentSettings>
</xml>
<![endif]--><!--[if !mso]><!-- -->
  <link href=""https://fonts.googleapis.com/css2?family=Orbitron&display=swap"" rel=""stylesheet""><!--<![endif]-->
  <style type=""text/css"">
#outlook a {{
	padding:0;
}}
.es-button {{
	mso-style-priority:100!important;
	text-decoration:none!important;
}}
a[x-apple-data-detectors] {{
	color:inherit!important;
	text-decoration:none!important;
	font-size:inherit!important;
	font-family:inherit!important;
	font-weight:inherit!important;
	line-height:inherit!important;
}}
.es-desk-hidden {{
	display:none;
	float:left;
	overflow:hidden;
	width:0;
	max-height:0;
	line-height:0;
	mso-hide:all;
}}
@media only screen and (max-width:600px) {{p, ul li, ol li, a {{ line-height:150%!important }} h1, h2, h3, h1 a, h2 a, h3 a {{ line-height:120% }} h1 {{ font-size:30px!important; text-align:left }} h2 {{ font-size:24px!important; text-align:left }} h3 {{ font-size:20px!important; text-align:left }} .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a {{ font-size:30px!important; text-align:left }} .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a {{ font-size:24px!important; text-align:left }} .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a {{ font-size:20px!important; text-align:left }} .es-menu td a {{ font-size:14px!important }} .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a {{ font-size:14px!important }} .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a {{ font-size:14px!important }} .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a {{ font-size:14px!important }} .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a {{ font-size:12px!important }} *[class=""gmail-fix""] {{ display:none!important }} .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 {{ text-align:center!important }} .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 {{ text-align:right!important }} .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 {{ text-align:left!important }} .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img {{ display:inline!important }} .es-button-border {{ display:inline-block!important }} a.es-button, button.es-button {{ font-size:18px!important; display:inline-block!important }} .es-adaptive table, .es-left, .es-right {{ width:100%!important }} .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header {{ width:100%!important; max-width:600px!important }} .es-adapt-td {{ display:block!important; width:100%!important }} .adapt-img {{ width:100%!important; height:auto!important }} .es-m-p0 {{ padding:0!important }} .es-m-p0r {{ padding-right:0!important }} .es-m-p0l {{ padding-left:0!important }} .es-m-p0t {{ padding-top:0!important }} .es-m-p0b {{ padding-bottom:0!important }} .es-m-p20b {{ padding-bottom:20px!important }} .es-mobile-hidden, .es-hidden {{ display:none!important }} tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden {{ width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }} tr.es-desk-hidden {{ display:table-row!important }} table.es-desk-hidden {{ display:table!important }} td.es-desk-menu-hidden {{ display:table-cell!important }} .es-menu td {{ width:1%!important }} table.es-table-not-adapt, .esd-block-html table {{ width:auto!important }} table.es-social {{ display:inline-block!important }} table.es-social td {{ display:inline-block!important }} .es-desk-hidden {{ display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important }} .es-m-p5 {{ padding:5px!important }} .es-m-p5t {{ padding-top:5px!important }} .es-m-p5b {{ padding-bottom:5px!important }} .es-m-p5r {{ padding-right:5px!important }} .es-m-p5l {{ padding-left:5px!important }} .es-m-p10 {{ padding:10px!important }} .es-m-p10t {{ padding-top:10px!important }} .es-m-p10b {{ padding-bottom:10px!important }} .es-m-p10r {{ padding-right:10px!important }} .es-m-p10l {{ padding-left:10px!important }} .es-m-p15 {{ padding:15px!important }} .es-m-p15t {{ padding-top:15px!important }} .es-m-p15b {{ padding-bottom:15px!important }} .es-m-p15r {{ padding-right:15px!important }} .es-m-p15l {{ padding-left:15px!important }} .es-m-p20 {{ padding:20px!important }} .es-m-p20t {{ padding-top:20px!important }} .es-m-p20r {{ padding-right:20px!important }} .es-m-p20l {{ padding-left:20px!important }} .es-m-p25 {{ padding:25px!important }} .es-m-p25t {{ padding-top:25px!important }} .es-m-p25b {{ padding-bottom:25px!important }} .es-m-p25r {{ padding-right:25px!important }} .es-m-p25l {{ padding-left:25px!important }} .es-m-p30 {{ padding:30px!important }} .es-m-p30t {{ padding-top:30px!important }} .es-m-p30b {{ padding-bottom:30px!important }} .es-m-p30r {{ padding-right:30px!important }} .es-m-p30l {{ padding-left:30px!important }} .es-m-p35 {{ padding:35px!important }} .es-m-p35t {{ padding-top:35px!important }} .es-m-p35b {{ padding-bottom:35px!important }} .es-m-p35r {{ padding-right:35px!important }} .es-m-p35l {{ padding-left:35px!important }} .es-m-p40 {{ padding:40px!important }} .es-m-p40t {{ padding-top:40px!important }} .es-m-p40b {{ padding-bottom:40px!important }} .es-m-p40r {{ padding-right:40px!important }} .es-m-p40l {{ padding-left:40px!important }} }}
</style>
 </head>
 <body style=""width:100%;font-family:arial, 'helvetica neue', helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0"">
  <div class=""es-wrapper-color"" style=""background-color:#EFEFEF""><!--[if gte mso 9]>
			<v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
				<v:fill type=""tile"" color=""#efefef"" origin=""0.5, 0"" position=""0.5, 0""></v:fill>
			</v:background>
		<![endif]-->
   <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#EFEFEF"">
     <tr>
      <td valign=""top"" style=""padding:0;Margin:0"">
       <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table class=""es-content-body"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#cfe2f3;width:600px"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#cfe2f3"" align=""center"">
             <tr>
              <td align=""left"" style=""padding:0;Margin:0"">
               <table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td class=""es-m-p0r es-m-p20b"" valign=""top"" align=""center"" style=""padding:0;Margin:0;width:600px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0;position:relative""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#068FC1;font-size:14px""><img class=""adapt-img"" src=""https://mcbihx.stripocdn.email/content/guids/bannerImgGuid/images/image16953231768215542.png"" alt=""World tourism day"" title=""World tourism day"" width=""600"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""384""></a></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
           </table></td>
         </tr>
       </table>
       <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
             <tr>
              <td align=""left"" style=""Margin:0;padding-top:20px;padding-left:20px;padding-right:20px;padding-bottom:30px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                        <td align=""left"" class=""es-m-txt-c es-m-p0r es-m-p0l"" style=""padding:0;Margin:0;padding-left:40px;padding-right:40px"">
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:39px;color:#455A64;font-size:26px;text-align:center"">
                                <strong> Agenda de entrevista  </strong>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                            <br>
                                Estimado/a  {vacanteResponsables.VacanteResponsable.Nombre}
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                Le escribo para solicitar un espacio para recbir el candidato para la entrevista {vacanteResponsables.Vacante.Titulo} 
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:right"">
                            <br>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                -- Observaciones : <br> { prospectoEntrevista.Observaciones }
                            <br>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                            <br>
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                Apreciamos su interés y apoyo en este proceso de selección. Estaremos atentos a los avances y mantendremos informado al equipo de proyecto sobre cualquier actualización relevante.
                            </p>
                            <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                <br><br>
                            </p>
                        </td>
                     </tr>
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:20px"">
                            <a href="""" target=""_blank"" hidden>
	                            <v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" esdevVmlButton href=""https://www.asae.com.mx/Entrevistas/EntrevistaAceptada?sold={Prospecto}""  style=""height:60px; v-text-anchor:middle; width:154px"" arcsize=""24%"" stroke=""f""  fillcolor=""#44a8df"">
		                        <w:anchorlock></w:anchorlock>
		                        <center style='color:#ffffff; font-family:arial, ""helvetica neue"", helvetica, sans-serif; font-size:15px; font-weight:400; line-height:20px;  mso-text-raise:1px' href="""">Aceptar entrevista</center>
	                            </v:roundrect>
                            </a>
                            &nbsp;&nbsp;&nbsp;
                            <a href="""" target=""_blank"" hidden>
	                            <v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" esdevVmlButton href=""https://www.asae.com.mx/Entrevistas/ReagendarEntrevista?sold={Prospecto}""  style=""height:60px; v-text-anchor:middle; width:154px"" arcsize=""24%"" stroke=""f""  fillcolor=""#44a8df"">
		                        <w:anchorlock></w:anchorlock>
		                        <center style='color:#ffffff; font-family:arial, ""helvetica neue"", helvetica, sans-serif; font-size:15px; font-weight:400; line-height:20px;  mso-text-raise:1px'>Reagendar entrevista </center>
	                            </v:roundrect>
                            </a>
                            <![endif]--><!--[if !mso]><!-- --><span class=""msohide es-button-border"" style=""border-style:solid;border-color:#2CB543;background:#44a8df;border-width:0px;display:inline-block;border-radius:10px;width:auto;mso-hide:all""><a href="""" class=""es-button"" target=""_blank"" style=""mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#FFFFFF;font-size:18px;padding:10px 20px 10px 20px;display:inline-block;background:#44a8df;border-radius:10px;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-weight:normal;font-style:normal;line-height:22px;width:auto;text-align:center;mso-padding-alt:0;mso-border-alt:10px solid #44A8DF"">Ver vacante 2</a></span><!--<![endif]--></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             
           </table></td>
         </tr>
       </table>
       <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
             <tr>
              <td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0;font-size:0"">
                       <table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                         <tr>
                          <td style=""padding:0;Margin:0;border-bottom:1px solid #9cd3ec;background:unset;height:1px;width:100%;margin:0px""></td>
                         </tr>
                       </table></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr>
             </table>
            </td>
         </tr>
       </table>
       <table cellpadding=""0"" cellspacing=""0"" class=""es-footer"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top"">
         <tr>
          <td align=""center"" style=""padding:0;Margin:0"">
           <table bgcolor=""#ffffff"" class=""es-footer-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
             <tr>
              <td align=""left"" style=""Margin:0;padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:40px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" style=""padding:0;Margin:0""><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr>
              <td align=""left"" style=""Margin:0;padding-left:20px;padding-right:20px;padding-top:30px;padding-bottom:30px"">
               <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr>
                  <td align=""left"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr>
                      <td align=""center"" class=""es-infoblock made_with"" style=""padding:0;Margin:0;line-height:14px;font-size:0px;color:#CCCCCC""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#CCCCCC;font-size:12px""><img src=""https://mcbihx.stripocdn.email/content/guids/CABINET_dd9638105a0e16e64bb51094f748e01204c98b514c82e3a56b420241fe394548/images/asaelogo_kRs.png"" alt width=""125"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""52""></a></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
           </table></td>
         </tr>
       </table></td>
     </tr>
   </table>
  </div>
 </body>
</html>
";
            return Html;
        }
        
        public Models.ProspectoEntrevista Vacante_Actualizar_entrevista(Models.ProspectoEntrevista prospectoEntrevista)
        {
            return _ProspectoEntrevista.Vacante_Actualizar_entrevista(prospectoEntrevista);
        }
        public Models.ProspectoEntrevista Prospecto_EliminarEntrevista(Models.ProspectoEntrevista prospectoEntrevista)
        {
            return _ProspectoEntrevista.Prospecto_EliminarEntrevista(prospectoEntrevista);
        }
    }
}
