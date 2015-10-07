using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComunidadDeportiva.menuPrincipal
{
    public partial class ArchivoNoticias : System.Web.UI.Page
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

            LlenarGrdNoticias();
        }

        /// <summary>
        /// Función que llena el GridView con todas las noticias
        /// </summary>
        protected void LlenarGrdNoticias()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA = new SqlDataAdapter("SELECT * FROM noticias order by fecha desc", con);
            con.Open();
            dataA.Fill(dt);
            con.Close();

            GrdNoticias.DataSource = dt;
            GrdNoticias.DataBind();
        }

        /// <summary>
        /// Función que devuelve un string con la fecha que entra por parametros transformada al formato "dd/MM/YYYY"
        /// </summary>
        /// <param name="fecha">objeto fecha</param>
        /// <returns></returns>
        public string getFecha(object fecha)
        {
            return (((DateTime)fecha).Date).ToShortDateString();
        }

        /// <summary>
        /// Función que sirve para paginar el GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdNoticias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdNoticias.PageIndex = e.NewPageIndex;
            LlenarGrdNoticias();
        }
    }
}