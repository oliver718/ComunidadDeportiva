using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ComunidadDeportiva
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CDConexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            LblMensaje.Text = "";
        }

        /// <summary>
        /// Función que se activa al hacer click en el botón ENTRAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (LlenarSesionesUsuario())
            {
                LlenarSesionJuego();
                Response.Redirect("~/menuPrincipal/Noticias.aspx");
            }
            else
            {
                LblMensaje.Text = "Nombre de usuario o contraseña no validos";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        /// <summary>
        /// Función que llena la la sesión con los datos del usuario, devuelve true si todo ha salido bien y false si ha habido algún error
        /// </summary>
        /// <returns></returns>
        protected bool LlenarSesionesUsuario()
        {
            bool todoBien = false;
            try
            {
                DataTable dt = traerDatosUsuario();

                if (dt.Rows.Count == 1 && TxtPassword.Text == dt.Rows[0]["contrasenia"].ToString())
                {
                    Session["id"] = dt.Rows[0]["id"].ToString();
                    Session["idEquipo"] = dt.Rows[0]["idEquipo"].ToString();
                    Session["usuario"] = dt.Rows[0]["nombre"].ToString();
                    Session["idSeleccion"] = dt.Rows[0]["idSeleccion"].ToString();
                    todoBien = true;
                }
            }
            catch (Exception) 
            {
            }

            return todoBien;
        }

        /// <summary>
        /// Función que devuelve un DataTable con los datos del usuario.
        /// </summary>
        /// <returns></returns>
        protected DataTable traerDatosUsuario()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT * FROM usuario WHERE nombre='" + TxtNombre.Text + "'", con);
                dataA.Fill(dt);
                con.Close();
            }
            catch (Exception)
            {
                LblMensaje.Text = "Nombre de usuario no valido";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }

            return dt;
        }

        /// <summary>
        /// Función que llena la sesión idEquipoJuego con la id del equipo de ESTA ES MI LIGA del usuario
        /// </summary>
        protected void LlenarSesionJuego()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT id FROM equipoJuego WHERE idUsuario=" + Session["id"], con);
                dataA.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 1)
                    Session["idEquipoJuego"] = dt.Rows[0]["id"].ToString();
                else
                    Session["idEquipoJuego"] = "";
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// Función que se activa al pulsar en el botón de "He olvidado mi contraseña", esta función manda un email al usuario con su contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnOContraseña_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text == "")
            {
                LblMensaje.Text = "Pon tu nombre de usuario y vuelve a pulsar <b>He olvidado mi contraseña</b>";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
            else
            {
                try
                {
                    DataTable dt = traerDatosUsuario();
                    MailMessage correo = new MailMessage();
                    SmtpClient client = new SmtpClient();

                    correo.From = new MailAddress("Administradores@comunidadDeportiva.com");
                    correo.To.Add(dt.Rows[0]["email"].ToString());
                    correo.Subject = "Contraseña Olvidada en Comunidad Deportiva";
                    correo.Body = "Su contraseña es: " + dt.Rows[0]["contrasenia"].ToString() + "<br><br>Muchas gracias por formar parte de Comunidad Deportiva.";
                    correo.IsBodyHtml = true;
                    correo.Priority = System.Net.Mail.MailPriority.Normal;

                    client.Credentials = new NetworkCredential("oli_y_chibi@hotmail.com", "destrangis");
                    client.Port = 587;
                    client.Host = "smtp.live.com";
                    client.EnableSsl = true;
                    client.Send(correo);

                    LblMensaje.Text = "Se ha enviado a su email un correo con su contraseña";
                    LblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception)
                {
                    LblMensaje.Text = "Error al enviarle un email con su contraseña";
                    LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                }
            }


        }

        /// <summary>
        /// Función que se activa cuando el usuario pulsa el botón para registrarse, redirecciona a la página de RegistroUsuario.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnRegistrarme_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistroUsuario.aspx");
        }
    }
}