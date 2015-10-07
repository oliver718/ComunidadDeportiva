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
    public partial class EstaEsMiLiga : System.Web.UI.MasterPage
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

            //limpio estas sesiones para que el usuario salga de los equipos que no sean suyos
            Session["idOtroEquipo"] = "";
            Session["idOtraSeleccion"] = "";

            if (!IsPostBack)
                LblUsuario.Text = GetNombreUsuario();
        }

        /// <summary>
        /// Función que pone el nombre del equipo del usuario en la label LblNombreEquipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LblNombreEquipo_PreRender(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA = new SqlDataAdapter("SELECT nombre FROM equipoJuego WHERE id=" + Session["idEquipoJuego"].ToString(), con);
            dataA.Fill(dt);
            if(dt.Rows.Count == 1)
                LblNombreEquipo.Text = dt.Rows[0]["nombre"].ToString();
        }

        /// <summary>
        /// Función que se activa al hacer click en la boton-Imagen de salir, esta función limpia las sesiones y redirecciona a la página de entrada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }


        /// <summary>
        /// Función que devuelve un string con el nombre del usuario conectado
        /// </summary>
        /// <returns></returns>
        protected string GetNombreUsuario()
        {
            string nombre = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT nombre FROM usuario WHERE id=" + Session["id"].ToString(), con);
                dataA.Fill(dt);
                nombre = dt.Rows[0]["nombre"].ToString();
            }
            catch (Exception)
            {
            }

            return nombre;
        }
    }
}