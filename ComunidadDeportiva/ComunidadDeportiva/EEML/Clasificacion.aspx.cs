using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComunidadDeportiva.EEML
{
    public partial class Clasificacion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CDConexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try //seguridad de la página
            {
                if (Session["id"].ToString() == "")
                    Response.Redirect("~/Default.aspx");
                else if (Session["idEquipoJuego"].ToString() == "")
                    Response.Redirect("~/EEML/RegistroEquipo.aspx");
            }
            catch (Exception)
            {
            }

            if(!IsPostBack)
                llenarGrdClasificacion();

        }

        /// <summary>
        /// Función que llena el gridView con los equipos de los usuarios
        /// </summary>
        public void llenarGrdClasificacion()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT distinct e.id, e.nombre FROM equipoJuego e, puntuacionEquipoJuego p where e.id=p.idEquipoJuego", con);
            dataA.Fill(dt);

            GrdClasificacion.DataSource = dt;
            GrdClasificacion.DataBind();
        }

        /// <summary>
        /// Función que llena los campos de puntuación semanal y puntuación total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdClasificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex >= 0)
            {
                ((Label)e.Row.FindControl("LblPS")).Text = GetPuntosSemana(((Label)e.Row.FindControl("LblId")).Text);
                ((Label)e.Row.FindControl("LblPT")).Text = GetPuntosTotales(((Label)e.Row.FindControl("LblId")).Text);
            }
        }

        /// <summary>
        /// Función para paginar el gridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdClasificacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdClasificacion.PageIndex = e.NewPageIndex;
            llenarGrdClasificacion();
        }

        /// <summary>
        /// Función que devuelve la puntuación de la última semana de un equipo
        /// </summary>
        /// <param name="id">id del equipo</param>
        /// <returns></returns>
        protected string GetPuntosSemana(string id)
        {
            string puntuacion = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT top 1 puntuacionSemanal FROM puntuacionEquipoJuego where idEquipoJuego=" + id + " order by fecha desc", con);
                dataA.Fill(dt);
                if (dt.Rows.Count == 1)
                    puntuacion = dt.Rows[0]["puntuacionSemanal"].ToString();
            }
            catch (Exception)
            {
            }

            return puntuacion;
        }

        /// <summary>
        /// Función que devuelve los puntos totales de un equipo
        /// </summary>
        /// <param name="id">id del equipo</param>
        /// <returns></returns>
        protected string GetPuntosTotales(string id)
        {
            string puntuacion = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT sum(puntuacionSemanal) as suma FROM puntuacionEquipoJuego where idEquipoJuego=" + id, con);
                dataA.Fill(dt);
                if (dt.Rows.Count == 1)
                    puntuacion = dt.Rows[0]["suma"].ToString();
            }
            catch (Exception)
            {
            }

            return puntuacion;
        }
    }
}