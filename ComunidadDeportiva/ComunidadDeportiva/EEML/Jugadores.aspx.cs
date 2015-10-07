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
    public partial class Jugadores : System.Web.UI.Page
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
                llenarGrdFotos();
        }

        /// <summary>
        /// Función que llena el gridView con los jugadores del equipo del usuario
        /// </summary>
        public void llenarGrdFotos()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT j.*, e.nombre as nombreEquipo FROM equipo e, jugador j, jugadorEquipoJuego je " + 
                "WHERE e.id=j.idEquipo and j.id=je.idjugador and je.idEquipoJuego="
                + Session["idEquipoJuego"] + " order by j.demarcacion", con);
            dataA.Fill(dt);

            GrdFotos.DataSource = dt;
            GrdFotos.DataBind();
        }

        /// <summary>
        /// Función que devuelve la ruta de la imagen del jugador
        /// </summary>
        /// <param name="nombre">nombre del jugador</param>
        /// <returns></returns>
        public string getUrl(object nombre)
        {
            return "~/FotosJugadores/" + nombre.ToString();
        }

        /// <summary>
        /// Función para paginar el gridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdFotos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdFotos.PageIndex = e.NewPageIndex;
            llenarGrdFotos();
        }

        /// <summary>
        /// Función para despedir a un jugador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdFotos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Despedir")
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = con;

                    //Borrar jugador de equipo
                    comando.CommandText = "DELETE FROM jugadorEquipoJuego where idJugador=" +
                        ((Label)GrdFotos.Rows[index].FindControl("LblId")).Text + " and idEquipoJuego=" +
                        Session["idEquipoJuego"].ToString();
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();

                    LblMensaje.Text = "Has despedido a " + ((Label)GrdFotos.Rows[index].FindControl("LblNombre")).Text + " de tu equipo";
                    LblMensaje.ForeColor = System.Drawing.Color.Green;
                    llenarGrdFotos();
                }
            }
            catch (Exception)
            {
                LblMensaje.Text = "Error al despedir jugador";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        /// <summary>
        /// Función que devuelve un string con la fecha que entra por parametros tranformada al formato "dd/MM/YYYY"
        /// </summary>
        /// <param name="fecha">fecha</param>
        /// <returns></returns>
        public string arreglarFecha(object fecha)
        {
            return ((DateTime)fecha).Date.ToShortDateString();
        }

        /// <summary>
        /// Función que devuelve un string con un numero que entra por parametros separado por puntos
        /// </summary>
        /// <param name="numero">numero</param>
        /// <returns></returns>
        public string ponerPuntos(object numero)
        {
            string num = numero.ToString();
            int tres = 1;
            for (int i = num.Count() - 1; i >= 0; i--)
            {
                if (tres == 3)
                {
                    num = num.Insert(i, ".");
                    tres = 0;
                }
                tres++;
            }

            if (num[0] == '.')
                num = num.Remove(0, 1);

            return num;
        }

        /// <summary>
        /// Función que devuelve un string con un numero que entra por parametros y el simbolo del euro
        /// </summary>
        /// <param name="num">numero</param>
        /// <returns></returns>
        public string pasarAEuros(object num)
        {
            return num.ToString() + " €";
        }
    }
}