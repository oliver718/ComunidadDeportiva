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
    public partial class Contacta : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CDConexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try //seguridad de la página
            {
                if (Session["id"].ToString() == "")
                    Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                Response.Redirect("~/Default.aspx");
            }

            Session["idOtroEquipo"] = "";
            Session["idOtraSeleccion"] = "";
        }

        /// <summary>
        /// Función que se activa cuando el usuario pulsa el botón de enviar, envia un correo con la sugerencia del usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAsunto.Text != "" || TxtMensaje.Text != "")
                {
                    DataTable dt = TraerDatosUsuario();
                    MailMessage correo = new MailMessage();
                    SmtpClient client = new SmtpClient();

                    correo.From = new MailAddress(dt.Rows[0]["email"].ToString());
                    correo.To.Add("oli_y_chibi@hotmail.com");
                    correo.Subject = TxtAsunto.Text;
                    correo.Body = "Mensaje de usuario: " + dt.Rows[0]["nombre"].ToString() + "<br><br>" + TxtMensaje.Text;
                    correo.IsBodyHtml = true;
                    correo.Priority = System.Net.Mail.MailPriority.Normal;

                    client.Credentials = new NetworkCredential("oli_y_chibi@hotmail.com", "destrangis");
                    client.Port = 587;
                    client.Host = "smtp.live.com";
                    client.EnableSsl = true;
                    client.Send(correo);

                    LblMensaje.Text = "Mensaje enviado con éxito";
                    LblMensaje.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception)
            {
                LblMensaje.Text = "Error al enviar el mensaje";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
            
        }

        /// <summary>
        /// Función que devuelve un DataTable con los datos del usuario.
        /// </summary>
        /// <returns></returns>
        protected DataTable TraerDatosUsuario()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT nombre, email FROM usuario where id=" + Session["id"].ToString(), con);
                dataA.Fill(dt);
            }
            catch (Exception)
            {
            }

            return dt;
        }
    }
}