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

namespace ComunidadDeportiva.menuIzquierda
{
    public partial class Jugadores : System.Web.UI.Page
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

            parametrosOk();

            if (!IsPostBack)
            {
                llenarGrdFotos();
                ImgEquipo.ImageUrl = getRutaImagen();
                ImgEquipo.ToolTip = getNombreEquipo();
            }
        }

        /// <summary>
        /// Función que comprueba si los parametros que entran por la url de la página son correctos
        /// </summary>
        protected void parametrosOk()
        {
            try
            {
                string equipo = Request["e"];
                if (equipo == "" || equipo == null)
                    throw new Exception();
            }
            catch (Exception)
            {
                Response.Redirect("~/menuPrincipal/Noticias.aspx");
            }
        }

        /// <summary>
        /// Función que llena el GridView con los jugadores del equipo
        /// </summary>
        public void llenarGrdFotos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT nombre, nacionalidad, fechaNac, demarcacion, foto FROM jugador WHERE idEquipo=" + Request["e"], con);
                dataA.Fill(dt);

                if (dt.Rows.Count == 0)//si está vacio puede que sea una selección
                    dt = esSeleccion();

                GrdFotos.DataSource = dt;
                GrdFotos.DataBind();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Función que devuelve un dataTable con los jugadores de una selección
        /// </summary>
        /// <returns></returns>
        public DataTable esSeleccion()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT nombre, nacionalidad, fechaNac, demarcacion, foto FROM jugador WHERE idSeleccion=" + Request["e"], con);
                dataA.Fill(dt);
            }
            catch (Exception)
            {
            }

            return dt;
        }

        /// <summary>
        /// Funcón que devuelve un string con la ruta de las fotos de los jugadores
        /// </summary>
        /// <param name="nombre">nombre de la imagen</param>
        /// <returns></returns>
        public string getUrl(object nombre)
        {
            return "~/FotosJugadores/" + nombre.ToString();
        }

        /// <summary>
        /// Función que sirve para paginar el GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdFotos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdFotos.PageIndex = e.NewPageIndex;
            llenarGrdFotos();
        }

        /// <summary>
        /// Función que devuelve la ruta del escudo del equipo
        /// </summary>
        /// <returns></returns>
        public string getRutaImagen()
        {
            string ruta = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT nombre FROM equipo WHERE id=" + Request["e"].ToString(), con);
                dataA.Fill(dt);

                if (dt.Rows.Count > 0)
                    ruta = "~/escudos/" + getNombreFoto(dt.Rows[0]["nombre"].ToString());
            }
            catch (Exception)
            {
            }

            return ruta;
        }

        /// <summary>
        /// Función que devuelve un string con el nombre del equipo
        /// </summary>
        /// <returns></returns>
        public string getNombreEquipo()
        {
            string nombre = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT nombre FROM equipo WHERE id=" + Request["e"].ToString(), con);
                dataA.Fill(dt);

                if (dt.Rows.Count > 0)
                    nombre = dt.Rows[0]["nombre"].ToString();
            }
            catch (Exception)
            {
            }

            return nombre;
        }

        /// <summary>
        /// Función que devuelve un string con el nombre de la foto del equipo
        /// </summary>
        /// <param name="nombreEquipo"> nombre del equipo</param>
        /// <returns></returns>
        protected string getNombreFoto(string nombreEquipo)
        {
            string nombreFoto = "";

            if (nombreEquipo != "")
            {
                nombreEquipo = nombreEquipo.ToLower();
                nombreEquipo = nombreEquipo.Replace("á", "a");
                nombreEquipo = nombreEquipo.Replace("é", "e");
                nombreEquipo = nombreEquipo.Replace("í", "i");
                nombreEquipo = nombreEquipo.Replace("ó", "o");
                nombreEquipo = nombreEquipo.Replace("ú", "u");
                nombreEquipo = nombreEquipo.Replace(" ", "");

                nombreFoto = nombreEquipo + ".png";
            }

            return nombreFoto;
        }

        /// <summary>
        /// Función que devuelve un string con la fecha que entra por parametro transformada al formato "dd/MM/YYYY"
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string arreglarFecha(object fecha)
        {
            return ((DateTime)fecha).Date.ToShortDateString();
        }
    }
}