using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComunidadDeportiva
{
    public partial class Noticias : System.Web.UI.Page
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

            llenarGrdNoticias();
        }

        /// <summary>
        /// Función que llena el GridView con las 3 últimas noticias
        /// </summary>
        protected void llenarGrdNoticias()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA = new SqlDataAdapter("SELECT TOP 3 * FROM noticias order by fecha desc", con);
            dataA.Fill(dt);
            con.Close();

            GrdNoticias.DataSource = dt;
            GrdNoticias.DataBind();
        }

        /// <summary>
        /// Función que devuelve un string con la fecha en formato "dd/MM/YYYY"
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string getFecha(object fecha)
        {
            return (((DateTime)fecha).Date).ToShortDateString();
        }
    }
}