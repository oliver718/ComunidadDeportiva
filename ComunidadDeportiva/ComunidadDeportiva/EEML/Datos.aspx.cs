using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComunidadDeportiva.EEML
{
    public partial class Datos : System.Web.UI.Page
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

            cargarDatos();
        }

        /// <summary>
        /// Función que llena las Label con los datos del equipo del usuario
        /// </summary>
        protected void cargarDatos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT e.nombre, e.fechaCreacion, e.presupuesto, u.nombre as usuario FROM equipoJuego e, usuario u WHERE e.idUsuario=u.id and e.id=" + Session["idEquipoJuego"].ToString(), con);
                dataA.Fill(dt);

                LblNombre.Text = dt.Rows[0]["nombre"].ToString();
                LblFecha.Text = ((DateTime)dt.Rows[0]["fechaCreacion"]).Date.ToShortDateString();
                LblPresupuesto.Text = ponerPuntos(dt.Rows[0]["presupuesto"].ToString()) + " €";
                LblDueño.Text = dt.Rows[0]["usuario"].ToString();
                LblSalario.Text = CalcularSalario();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Función que calcula el salario de los jugadores del equipo del usuario a la semana
        /// </summary>
        /// <returns></returns>
        protected string CalcularSalario()
        {
            string cantidad = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT sum(j.salario) as suma FROM jugadorEquipoJuego je, jugador j " +
                    "WHERE j.id = je.idJugador and je.idEquipoJuego=" + Session["idEquipoJuego"].ToString(), con);
                dataA.Fill(dt);
                cantidad = dt.Rows[0]["suma"].ToString();
                cantidad = ponerPuntos(cantidad);
                cantidad += " €";
            }
            catch (Exception)
            {
            }

            return cantidad;
        }

        /// <summary>
        /// Función que devuelve un string con un numero dividido por puntos
        /// </summary>
        /// <param name="num">numero</param>
        /// <returns></returns>
        protected string ponerPuntos(string num)
        {
            int tres = 1;
            for (int i = num.Count() - 1; i >= 0 ; i--)
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
    }
}