using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;


namespace ProyectoBase.Application
{
    public class Vacante
    {
        Data.Vacante _Vacante = new Data.Vacante();
        Data.UsuarioResponsable _UsuarioResponsable = new Data.UsuarioResponsable();

        public List<Models.Vacante> Vacante_Seleccionar()
        {
            return _Vacante.Vacante_Seleccionar();
        }

        public Models.Vacante Vacante_Seleccionar_Id(Models.Vacante vacante)
        {
            return _Vacante.Vacante_Seleccionar_Id(vacante);
        }

        public Models.Vacante Vacante_Actualizar_IdEstatus(Models.Vacante vacante)
        {
            return _Vacante.Vacante_Actualizar_IdEstatus(vacante);
        }

        public Models.Consultas.VacanteUsuario Vacante_Seleccionar_Usuario_IdVacante(Models.Vacante vacante)
        {
            return _Vacante.Vacante_Seleccionar_Usuario_IdVacante(vacante);
        }

        public List<Models.Vacante> Vacante_Seleccionar_Usuarios()
        {
            return _Vacante.Vacante_Seleccionar_Usuarios();
        }

        public List<Models.Vacante> Vacante_Seleccionar_IdUsuario(Models.Usuarios usuarios)
        {
            return _Vacante.Vacante_Seleccionar_IdUsuario(usuarios);
        }

        public List<Models.Cat_EstatusVacante> Vacante_Estatus_IdUsuario(Models.Usuarios usuarios)
        {
            return _Vacante.Vacante_Estatus_IdUsuario(usuarios);
        }

        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos_IdUsuario(Models.Usuarios usuarios)
        {
            return _Vacante.Vacante_Estatus_Prospectos_IdUsuario(usuarios);
        }
        public List<Models.Vacante> Vacante_Seleccionar_Reporte()
        {
            return _Vacante.Vacante_Seleccionar_Reporte();
        }
        public Models.Vacante Prospecto_Eliminar_Id(Models.Vacante vacante)
        {
            return _Vacante.Prospecto_Eliminar_Id(vacante);
        }
        /// <summary>
        /// CONSULTA GENERAL 
        public List<Models.Cat_EstatusVacante> Vacante_Estatus_Seleccionar()
        {
            return _Vacante.Vacante_Estatus_Seleccionar();
        }
        public List<Models.Cat_Clientes> Vacante_Clientes_Seleccionar()
        {
            return _Vacante.Vacante_Clientes_Seleccionar();
        }
        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos()
        {
            return _Vacante.Vacante_Estatus_Prospectos();
        }
        public Models.Vacante Vacante_Agregar(Models.Vacante vacante)
        {
            Models.Vacante dbvacante = new Models.Vacante();
            dbvacante = _Vacante.Vacante_Agregar(vacante);
            //// ENVIO DE CORREO ELECTRONICO
            WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();

            //if (dbvacante.Id > 0)
            //{
            //    List<Models.UsuarioResponsable> dbUsuarioResposble = _UsuarioResponsable.UsuarioResponsable_Seleccionar();

            //    if (dbUsuarioResposble != null)
            //    {
            //        foreach (Models.UsuarioResponsable usuarioResponsable in dbUsuarioResposble)
            //        {

            //            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_",
            //                usuarioResponsable.Email, "Asae Consultores S.A de C.V", "Nueva vacante registrada", NuevaVacante(dbvacante)) == "Correo enviado")
            //            {

            //            }
            //        }
            //    }
            //}
            return dbvacante;
        }
        public string NuevaVacante(Models.Vacante vacante)
        {
            Models.Vacante dbVacante = _Vacante.Vacante_Seleccionar_Id(vacante);
            List<Models.Vacante> ListVacante = new List<Models.Vacante>();
            ListVacante = _Vacante.Vacante_Seleccionar_Top3();

            string host = HttpContext.Current.Request.Url.Authority;
            Models.URL Url = new Models.URL();
            Url.UrlVaible = dbVacante.Id.ToString();
            string IdVacante = Application.UrlCifrardo.Encriptar(Url.UrlVaible);

            string Html = "<!DOCTYPE html>" +
                        "<html lang='en' xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'>" +
                        "<head>" +
                        "<meta charset='utf-8'> <!-- utf-8 works for most cases -->" +
                        "<meta name='viewport' content='width=device-width'> <!-- Forcing initial-scale shouldn't be necessary -->" +
                        "<meta http-equiv='X-UA-Compatible' content='IE=edge'> <!-- Use the latest (edge) version of IE rendering engine -->" +
                        "<meta name='x-apple-disable-message-reformatting'>  <!-- Disable auto-scale in iOS 10 Mail entirely -->" +
                        "<title></title> <!-- The title tag shows in email notifications, like Android 4.4. -->" +

                        "<link href='https://fonts.googleapis.com/css?family=Work+Sans:200,300,400,500,600,700' rel='stylesheet'>" +

                        "<!-- CSS Reset : BEGIN -->" +
                        "<style>" +
                        "	html," +
                        "	body {" +
                        "		margin: 0 auto !important;" +
                        "		padding: 0 !important;" +
                        "		height: 100% !important;" +
                        "		width: 100% !important;" +
                        "		background: #f1f1f1;" +
                        "	}" +

                        "	* {" +
                        "		-ms-text-size-adjust: 100%;" +
                        "		-webkit-text-size-adjust: 100%;" +
                        "	}" +

                        "	div[style*='margin: 16px 0'] {" +
                        "		margin: 0 !important;" +
                        "	}" +

                        "	table," +
                        "	td {" +
                        "		mso-table-lspace: 0pt !important;" +
                        "		mso-table-rspace: 0pt !important;" +
                        "	}" +

                        "	table {" +
                        "		border-spacing: 0 !important;" +
                        "		border-collapse: collapse !important;" +
                        "		table-layout: fixed !important;" +
                        "		margin: 0 auto !important;" +
                        "	}" +

                        "	img {" +
                        "		-ms-interpolation-mode:bicubic;" +
                        "	}" +

                        "	a {" +
                        "		text-decoration: none;" +
                        "	}" +

                        "	*[x-apple-data-detectors],  /* iOS */" +
                        "	.unstyle-auto-detected-links *," +
                        "	.aBn {" +
                        "		border-bottom: 0 !important;" +
                        "		cursor: default !important;" +
                        "		color: inherit !important;" +
                        "		text-decoration: none !important;" +
                        "		font-size: inherit !important;" +
                        "		font-family: inherit !important;" +
                        "		font-weight: inherit !important;" +
                        "		line-height: inherit !important;" +
                        "	}" +

                        "	/* What it does: Prevents Gmail from displaying a download button on large, non-linked images. */" +
                        "	.a6S {" +
                        "		display: none !important;" +
                        "		opacity: 0.01 !important;" +
                        "	}" +

                        "	/* What it does: Prevents Gmail from changing the text color in conversation threads. */" +
                        "	.im {" +
                        "		color: inherit !important;" +
                        "	}" +

                        "	/* If the above doesn't work, add a .g-img class to any image in question. */" +
                        "	img.g-img + div {" +
                        "		display: none !important;" +
                        "	}" +

                        "	/* What it does: Removes right gutter in Gmail iOS app: https://github.com/TedGoas/Cerberus/issues/89  */" +
                        "	/* Create one of these media queries for each additional viewport size you'd like to fix */" +
                        "	" +
                        "	/* iPhone 4, 4S, 5, 5S, 5C, and 5SE */" +
                        "	@media only screen and (min-device-width: 320px) and (max-device-width: 374px) {" +
                        "		u ~ div .email-container {" +
                        "			min-width: 320px !important;" +
                        "		}" +
                        "	}" +
                        "	/* iPhone 6, 6S, 7, 8, and X */" +
                        "	@media only screen and (min-device-width: 375px) and (max-device-width: 413px) {" +
                        "		u ~ div .email-container {" +
                        "			min-width: 375px !important;" +
                        "		}" +
                        "	}" +
                        "	/* iPhone 6+, 7+, and 8+ */" +
                        "	@media only screen and (min-device-width: 414px) {" +
                        "		u ~ div .email-container {" +
                        "			min-width: 414px !important;" +
                        "		}" +
                        "	}" +

                        "		</style>" +
                        "<style>" +
                        "    .primary{" +
                        "		background: #f34949;" +
                        "	}" +
                        "	.bg_white{" +
                        "		background: #ffffff;" +
                        "	}" +
                        "	.bg_light{" +
                        "		background: #f7fafa;" +
                        "	}" +
                        "	.bg_black{" +
                        "		background: #000000;" +
                        "	}" +
                        "	.bg_dark{" +
                        "		background: rgba(0,0,0,.8);" +
                        "	}" +
                        "	.email-section{" +
                        "		padding:2.5em;" +
                        "	}" +

                        "	/*BUTTON*/" +
                        "	.btn{" +
                        "		padding: 3px 10px;" +
                        "		display: inline-block;" +
                        "	}" +
                        "	.btn.btn-primary{" +
                        "		border-radius: 5px;" +
                        "		background: #4056a7;" +
                        "		color: #ffffff;" +
                        "	}" +
                        "	.btn.btn-white{" +
                        "		border-radius: 5px;" +
                        "		background: #ffffff;" +
                        "		color: #000000;" +
                        "	}" +
                        "	.btn.btn-white-outline{" +
                        "		border-radius: 5px;" +
                        "		background: transparent;" +
                        "		border: 1px solid #fff;" +
                        "		color: #fff;" +
                        "	}" +
                        "	.btn.btn-black-outline{" +
                        "		border-radius: 0px;" +
                        "		background: transparent;" +
                        "		border: 2px solid #000;" +
                        "		color: #000;" +
                        "		font-weight: 700;" +
                        "	}" +
                        "	.btn-custom{" +
                        "		color: rgba(0,0,0,.3);" +
                        "		text-decoration: underline;" +
                        "	}" +

                        "	h1,h2,h3,h4,h5,h6{" +
                        "		font-family: 'Work Sans', sans-serif;" +
                        "		color: #000000;" +
                        "		margin-top: 0;" +
                        "		font-weight: 400;" +
                        "	}" +

                        "	body{" +
                        "		font-family: 'Work Sans', sans-serif;" +
                        "		font-weight: 400;" +
                        "		font-size: 15px;" +
                        "		line-height: 1.8;" +
                        "		color: rgba(0,0,0,.4);" +
                        "	}" +

                        "	a{" +
                        "		color: #43a7de;" +
                        "	}" +

                        "	table{" +
                        "	}" +
                        "	/*LOGO*/" +

                        "	.logo h1{" +
                        "		margin: 0 0 20px 0;" +
                        "	}" +
                        "	.logo h1 a{" +
                        "		color: #000;" +
                        "		font-size: 24px;" +
                        "		font-weight: 300;" +
                        "		font-family: 'Work Sans', sans-serif;" +
                        "	}" +

                        "	/*HERO*/" +
                        "	.hero{" +
                        "		position: relative;" +
                        "		z-index: 0;" +
                        "	}" +

                        "	.hero .text{" +
                        "		color: rgba(0,0,0,.3);" +
                        "	}" +
                        "	.hero .text h2{" +
                        "		color: #000;" +
                        "		font-size: 34px;" +
                        "		margin-bottom: 15px;" +
                        "		font-weight: 300;" +
                        "		line-height: 1.2;" +
                        "	}" +
                        "	.hero .text h3{" +
                        "		font-size: 24px;" +
                        "		font-weight: 200;" +
                        "	}" +
                        "	.hero .text h2 span{" +
                        "		font-weight: 600;" +
                        "		color: #000;" +
                        "	}" +


                        "	/*PRODUCT*/" +
                        "	.product-entry{" +
                        "		display: block;" +
                        "		position: relative;" +
                        "		float: left;" +
                        "		padding-top: 20px;" +
                        "	}" +
                        "	.product-entry .text{" +
                        "		width: calc(100% - 125px);" +
                        "		padding-left: 20px;" +
                        "	}" +
                        "	.product-entry .text h3{" +
                        "		margin-bottom: 0;" +
                        "		padding-bottom: 0;" +
                        "	}" +
                        "	.product-entry .text p {" +
                        "		margin-top: 0;" +
                        "	}" +
                        "	.product-entry .text span{" +
                        "		color: #000;" +
                        "		font-size: 14px;" +
                        "		font-weight: 600;" +
                        "		display: inline-block;" +
                        "		margin-bottom: 10px;" +
                        "	}" +
                        "	.product-entry img, .product-entry .text{" +
                        "		float: left;" +
                        "	}" +

                        "	ul.social{" +
                        "		padding: 0;" +
                        "	}" +
                        "	ul.social li{" +
                        "		display: inline-block;" +
                        "		margin-right: 10px;" +
                        "	}" +

                        "	/*FOOTER*/ " +

                        "	.footer{" +
                        "		color: rgba(0,0,0,.5);" +
                        "	}" +
                        "	.footer .heading{" +
                        "		color: #000;" +
                        "		font-size: 20px;" +
                        "	}" +
                        "	.footer ul{" +
                        "		margin: 0;" +
                        "		padding: 0;" +
                        "	}" +
                        "	.footer ul li{" +
                        "		list-style: none;" +
                        "		margin-bottom: 10px;" +
                        "	}" +
                        "	.footer ul li a{" +
                        "		color: rgba(0,0,0,1);" +
                        "	}" +
                        " @media screen and (max-width: 500px) {" +

                        " } " +

                        "</style>" +

                        "	</head> " +

                        "	<body width='100%' style='margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #f1f1f1;'>" +
                        "		<center style='width: 100%; background-color: #f1f1f1;'>" +
                        "		<div style='display: none; font-size: 1px;max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;'>" +
                        "		  &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;" +
                        "		</div>" +
                        "		<div style='max-width: 600px; margin: 0 auto;' class='email-container'>" +
                        "			<!-- BEGIN BODY -->" +
                        "		  <table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
                          "			<tr>" +
                        "			  <td valign='top' class='bg_white' style='padding: 1em 2.5em 0 2.5em;'>" +
                          "				<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                          "					<tr>" +
                          "						<td class='logo' style='text-align: left;'>" +
                        "							<h1 style='text-align:center;'><a href='#'>Asae Recursos Humanos</a></h1>" +
                        "						  </td>" +
                          "					</tr>" +
                          "				</table>" +
                        "			  </td>" +
                        "			  </tr><!-- end tr -->" +
                        "			  <tr>" +
                        "			  <td valign='middle' class='hero bg_white'>" +
                        "					<div class='overlay'></div>" +
                        "					<img src = 'https://www.asae.com.mx/01/reclutamiento.png' alt='' style='width: 100%; height: auto; margin: auto; display: block;'>" +
                        "			  </td>" +
                        "			  </tr><!-- end tr -->" +
                        "					<tr>" +
                        "			  <td valign='middle' class='hero bg_white' style='padding: 2em 0 2em 0;'>" +
                        "				<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                        "					<tr>" +
                        "						<td style='padding: 0 2.5em; text-align: left;'>" +
                        "							<div class='text'>" +
                        "								<h2>Nueva vacante registrada </h2>" +
                        "								<h3>Se solicita de su apoyo para iniciar el proceso de reclutamiento de esta nueva vacante: <br> <strong>'" + dbVacante.Titulo + "'</strong></h3>" +
                        "								<ul>" +
                        "									<li style='font-size: 15px; color: #838383; font-weight: 400; line-height: 1.2;'> Si deseas consultar los detalles de la publicación, puedes ingresar al siguiente link: <br> ";
            Html += "                                       <a href='http://" + host + "/Vacantes/InfoVacante?Id=" + IdVacante + "'> http://" + host + "/Vacantes/InfoVacante?Id=" + IdVacante + " </a> ";
            Html += "                                   </li>" +
                        "									<li style='font-size: 15px; color: #838383; font-weight: 400; line-height: 1.2;'> Copia el siguiente link donde contiene un formulario de registro: <br> ";
            Html += "                                       <a href='http://" + host + "/Prospecto/Solicitud?Id=" + IdVacante + "'> http://" + host + "/Prospecto/Solicitud?Id=" + IdVacante + " </a> " +
                        "                                   </li>" +
                        "									<li style='font-size: 15px; color: #838383; font-weight: 400; line-height: 1.2;'> Pega el link de registro en las plataformas de publicación de vacantes: <strong>OCC, compu trabajo, LinkedIn, etcétera </strong></li>" +
                        "								  </ul>" +
                        "							</div>" +
                        "						</td>" +
                        "					</tr>" +
                        "				</table>" +
                        "			  </td>" +
                        "			  </tr><!-- end tr -->" +
                        "			  <tr>" +
                          "				<td class='bg_white' style='padding: 0 0 4em 0;'>" +
                          "					<table class='bg_white' role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>";

            foreach (Models.Vacante _Vacante in ListVacante)
            {
                Html += "							  <tr style='border-bottom: 1px solid rgba(0,0,0,.05);'>" +
                        " 								<td valign='middle' width='70%' style='text-align:left; padding: 0 2.5em;'>" +
                        "  									<div class='product-entry'>" +
                        "  										<br><img src='https://www.asae.com.mx/01/AsaeLogo_Email.png' alt='' style='width: 100px; max-width: 600px; height: auto; margin-bottom: 20px; display: block;'>" +
                        "  										<div class='text'>" +
                        "  											<h3 style='line-height: 1.2;'>" + _Vacante.Titulo + "</h3>" +
                        "  											<span>Fecha publicación: " + _Vacante.FechaRegistro + "</span>" +
                        "  											<p>" + _Vacante.Cat_ProyectoServicios.Cat_Clientes.Nombre + " - " + _Vacante.Cat_ProyectoServicios.Nombre + "</p>" +
                        "  										</div>" +
                        "  									</div>" +
                        "  								</td>" +
                        "  								<td valign='middle' width='30%' style='text-align:center; padding-right: 2.5em;'>" +
                        "  									<span class='price' style='color: #000000; font-size: 20px; display: block;'> " + _Vacante.Prospecto + "</span>" +
                        "  									<span style='display: block;'>Prospectos</span>" +
                        "  									<span><a href='#' class='btn btn-primary'>Mostrar</a></span>" +
                        "  								</td>" +
                        "							  </tr>";
            }


            Html += "					</table>" +
                           "				  </td>" +
                           "			  </tr><!-- end tr -->" +
                           "		  <!-- 1 Column Text + Button : END -->" +
                           "		  </table>" +
                           "		  <table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
                             "			<tr>" +
                           "			  <td valign='middle' class='bg_light footer email-section'>" +
                           "			  </td>" +
                           "			</tr><!-- end: tr -->" +
                           "			<tr>" +
                           "			  <td class='bg_white' style='text-align: center;'>" +
                           "			  </td>" +
                           "			</tr>" +
                           "		  </table>" +

                           "		</div>" +
                           "	  </center>" +
                           "	</body>" +
                           "	</html>";

            return Html;
        }
        /// <summary>
        //////////////////////////
        public List<Models.Vacante> Vacante_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            return _Vacante.Vacante_Seleccionar_IdCliente(cat_Clientes);
        }

        public List<Models.Cat_EstatusVacante> Vacante_Estatus_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            return _Vacante.Vacante_Estatus_IdCliente(cat_Clientes);
        }

        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            return _Vacante.Vacante_Estatus_Prospectos_IdCliente(cat_Clientes);
        }

        /// <summary>
        /// ///////////////////////
        /// 

        public List<Models.Vacante> Vacante_Seleccionar_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _Vacante.Vacante_Seleccionar_IdProyecto(cat_ProyectoServicios);
        }

        public List<Models.Cat_EstatusVacante> Vacante_Estatus_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _Vacante.Vacante_Estatus_IdProyecto(cat_ProyectoServicios);
        }

        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _Vacante.Vacante_Estatus_Prospectos_IdProyecto(cat_ProyectoServicios);
        }
    }
}
