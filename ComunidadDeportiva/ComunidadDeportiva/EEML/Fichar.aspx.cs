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
    public partial class Fichar : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CDConexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["id"].ToString() == "")
                    Response.Redirect("~/Default.aspx");
                else if (Session["idEquipoJuego"].ToString() == "")
                    Response.Redirect("~/EEML/RegistroEquipo.aspx");
            }
            catch (Exception)
            {
            }

            if (!IsPostBack)
            {
                llenarGrdFotos("");
                llenarDrpEquipos();
                LblPresupuesto.Text = ponerPuntos(GetPresupuesto().ToString()) + " €";
            }
        }

        /// <summary>
        /// Función que llena el gridView con los jugadores que están a la venta para el usuario
        /// </summary>
        /// <param name="nombreEquipo"></param>
        public void llenarGrdFotos(string nombreEquipo)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("(SELECT j.*, e.nombre as nombreEquipo FROM jugador j, equipo e " + 
                "WHERE j.idEquipo=e.id and e.nombre like '%" + nombreEquipo + "%' except " + 
                "select j.*, e.nombre as nombreEquipo from equipo e, jugador j, jugadorEquipoJuego je " + 
                "where e.id=j.idEquipo and j.id=je.idJugador and je.idEquipoJuego=" + Session["idEquipoJuego"] + ") order by j.nombre", con);
            dataA.Fill(dt);

            if (dt.Rows.Count == 0)
                dt = esSeleccion(nombreEquipo);

            GrdFotos.DataSource = dt;
            GrdFotos.DataBind();
        }

        /// <summary>
        /// Función que devuelve un dataTable con los jugadores de la selección que el usuario puede comprar
        /// </summary>
        /// <param name="nombreEquipo"></param>
        /// <returns></returns>
        public DataTable esSeleccion(string nombreEquipo)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT j.*, e.nombre as nombreEquipo FROM jugador j, equipo e " +
                "WHERE j.idSeleccion=e.id and e.nombre like '%" + nombreEquipo + "%' except " +
                "select j.*, e.nombre as nombreEquipo from equipo e, jugador j, jugadorEquipoJuego je " +
                "where e.id=j.idEquipo and j.id=je.idJugador and je.idEquipoJuego=" + Session["idEquipoJuego"], con);
            dataA.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Función que llena el dropDownList con los equipos
        /// </summary>
        public void llenarDrpEquipos()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA = new SqlDataAdapter("Select * from equipo", con);
            dataA.Fill(dt);
            con.Close();
            DrpEquipos.Items.Clear();
            DrpEquipos.DataTextField = "nombre";
            DrpEquipos.DataValueField = "id";
            DrpEquipos.DataSource = dt;
            DrpEquipos.DataBind();
            DrpEquipos.Items.Insert(0, "Escoge un equipo...");//inserta en la primera posición
        }

        /// <summary>
        /// Función que devuelve la url de la foto del jugador
        /// </summary>
        /// <param name="nombre">nombre del jugador</param>
        /// <returns></returns>
        public string getUrl(object nombre)
        {
            return "~/FotosJugadores/" + nombre.ToString();
        }

        /// <summary>
        /// Función que sirve para paginar el gridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdFotos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdFotos.PageIndex = e.NewPageIndex;
            if(DrpEquipos.SelectedItem.Text == "Escoge un equipo...")
                llenarGrdFotos("");
            else
                llenarGrdFotos(DrpEquipos.SelectedItem.Text);
        }

        /// <summary>
        /// Función que se activa cuando se selecciona algún equipo del dropDownList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrpEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string nombre = DrpIdiomas.SelectedItem.Text; //da el nombre del jugador
            //string id = DrpIdiomas.SelectedValue; //da el id del jugador
            llenarGrdFotos(DrpEquipos.SelectedItem.Text);
        }

        /// <summary>
        /// Función que ficha a un jugador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdFotos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Fichar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int presupuestoEquipo = GetPresupuesto();

                if (presupuestoEquipo >= int.Parse(((Label)GrdFotos.Rows[index].FindControl("LblPrecioO")).Text))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = con;

                    //Insertar jugador en jugadorEquipoJuego
                    comando.CommandText = "INSERT INTO jugadorEquipoJuego VALUES(" + Session["idEquipoJuego"].ToString() +
                        "," + ((Label)GrdFotos.Rows[index].FindControl("LblId")).Text + ")";
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();

                    //Modificar el presupuesto del equipo
                    comando.CommandText = "Update equipoJuego set presupuesto=presupuesto-" +
                        ((Label)GrdFotos.Rows[index].FindControl("LblPrecioO")).Text + " where id=" + Session["idEquipoJuego"].ToString();
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();

                    LblMensaje.Text = "Has fichado a " + ((Label)GrdFotos.Rows[index].FindControl("LblNombre")).Text;
                    LblMensaje.ForeColor = System.Drawing.Color.Green;
                    LblPresupuesto.Text = ponerPuntos(GetPresupuesto().ToString()) + " €";
                }
                else
                {
                    LblMensaje.Text = ((Label)GrdFotos.Rows[index].FindControl("LblNombre")).Text +
                        " es demasiado caro para el presupuesto de tu equipo";
                    LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                }

                if (DrpEquipos.SelectedItem.Text == "Escoge un equipo...")
                    llenarGrdFotos("");
                else
                    llenarGrdFotos(DrpEquipos.SelectedItem.Text);
            }
        }

        /// <summary>
        /// Función que devuelve el presupuesto que tiene el equipo del usuario para la compra de jugadores
        /// </summary>
        /// <returns></returns>
        protected int GetPresupuesto()
        {
            int presupuesto = 0;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("Select presupuesto from equipoJuego where id=" +
                    Session["idEquipoJuego"].ToString(), con);
                dataA.Fill(dt);
                con.Close();
                presupuesto = (int)dt.Rows[0]["presupuesto"];
            }
            catch (Exception)
            {
            }

            return presupuesto;
        }

        /// <summary>
        /// Función que devuelve la fecha que entra por parametros en el formato "dd/MM/YYYY"
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string arreglarFecha(object fecha)
        {
            return ((DateTime)fecha).Date.ToShortDateString();
        }

        /// <summary>
        /// Función que devuelve un string con un numero dividido por puntos
        /// </summary>
        /// <param name="numero"></param>
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
        /// Función que devuelve un string con un numero mas el simbolo del euro
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string pasarAEuros(object num)
        {
            return num.ToString() + " €";
        }
    }
}