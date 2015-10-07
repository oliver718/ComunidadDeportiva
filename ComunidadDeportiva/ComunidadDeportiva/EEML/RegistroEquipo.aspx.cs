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
    public partial class RegistroEquipo : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CDConexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try //seguridad de la página
            {
                if (Session["id"].ToString() == "")
                    Response.Redirect("~/Default.aspx");
                else if (Session["idEquipoJuego"].ToString() != "")
                    Response.Redirect("~/EEML/Datos.aspx");
            }
            catch (Exception)
            {
            }

            LblMensaje.Text = "";
            LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
        }

        /// <summary>
        /// Función que activa cuando el usuario pulsa botón para crear equipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text == "" || TxtNombre.Text.Count() > 15)
                LblMensaje.Text = "El nombre del equipo no puede estar vacio ni tener más de 15 caracteres";
            else
            {
                if (existeEquipo())
                    LblMensaje.Text = "Ya hay un equipo con ese nombre";
                else if (registrarEquipo())
                {
                    sacarIdEquipoJuego();
                    contratarJugadoresAleatorios();
                    Response.Redirect("~/EEML/Datos.aspx");
                }
            }
            
        }

        /// <summary>
        /// Función que comprueba si existe un equipo, devuelve true si el equipo existe y false si no existe.
        /// </summary>
        /// <returns></returns>
        protected bool existeEquipo()
        {
            bool existe = false;

            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT id FROM equipojuego WHERE idUsuario=" + Session["id"], con);
            dataA.Fill(dt);

            if (dt.Rows.Count > 0)
                existe = true;

            return existe;
        }

        /// <summary>
        /// Función que registra un equipo, devuelve true si el registro se a realizado y false si ha habido algún error.
        /// </summary>
        /// <returns></returns>
        protected bool registrarEquipo()
        {
            bool todoBien = true;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                comando.CommandText = "INSERT INTO equipoJuego VALUES('" + TxtNombre.Text + "'," + Session["id"] +
                    ",convert(datetime,'" + DateTime.Now + "',103)," + 10000000 + ")";
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                todoBien = false;
            }

            return todoBien;
        }

        /// <summary>
        /// Función que llena la sesión idEquipoJuego con la id del equipo que ha creado el usuario
        /// </summary>
        protected void sacarIdEquipoJuego()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT id FROM equipoJuego WHERE idUsuario=" + Session["id"], con);
            dataA.Fill(dt);

            if (dt.Rows.Count == 1)
                Session["idEquipoJuego"] = dt.Rows[0]["id"].ToString();
        }

        /// <summary>
        /// Función que asigna jugadores aleatorios de cierta calidad al equipo que ha creado el usuario
        /// </summary>
        protected void contratarJugadoresAleatorios()
        {
            contratarPorteros(2);
            contratarDefensas(6);
            contratarCentrocampistas(6);
            contratarDelanteros(4);
        }

        /// <summary>
        /// Función que contrata porteros aleatorios que su coste sea menor a dos millones de euros
        /// </summary>
        /// <param name="cuantos">cantidad de porteros que se quieren contratar</param>
        protected void contratarPorteros(int cuantos)
        {

            int[] porteros;

            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT id FROM jugador WHERE precio<2000000 and demarcacion='portero'", con);
            dataA.Fill(dt);

            if (cuantos <= dt.Rows.Count)
            {
                porteros = llenarAleatorios(cuantos, dt.Rows.Count);

                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                for (int i = 0; i < cuantos; i++)
                {
                    comando.CommandText = "INSERT INTO jugadorEquipoJuego VALUES(" + Session["idEquipoJuego"] + 
                        "," + dt.Rows[porteros[i]]["id"].ToString() + ")";
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Función que contrata defensas aleatorios que su coste sea menor a dos millones de euros
        /// </summary>
        /// <param name="cuantos">cantidad de defensas que se quieren contratar</param>
        protected void contratarDefensas(int cuantos)
        {

            int[] defensas;

            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT id FROM jugador WHERE precio<2000000 and demarcacion='defensa'", con);
            dataA.Fill(dt);

            if (cuantos <= dt.Rows.Count)
            {
                defensas = llenarAleatorios(cuantos, dt.Rows.Count);

                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                for (int i = 0; i < cuantos; i++)
                {
                    comando.CommandText = "INSERT INTO jugadorEquipoJuego VALUES(" + Session["idEquipoJuego"] +
                        "," + dt.Rows[defensas[i]]["id"].ToString() + ")";
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Función que contrata centrocampistas aleatorios que su coste sea menor a dos millones de euros
        /// </summary>
        /// <param name="cuantos"> cantidad de centrocampista que se quieren contratar</param>
        protected void contratarCentrocampistas(int cuantos)
        {

            int[] centrocampistas;

            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT id FROM jugador WHERE precio<2000000 and demarcacion='centrocampista'", con);
            dataA.Fill(dt);

            if (cuantos <= dt.Rows.Count)
            {
                centrocampistas = llenarAleatorios(cuantos, dt.Rows.Count);

                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                for (int i = 0; i < cuantos; i++)
                {
                    comando.CommandText = "INSERT INTO jugadorEquipoJuego VALUES(" + Session["idEquipoJuego"] +
                        "," + dt.Rows[centrocampistas[i]]["id"].ToString() + ")";
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Función que contrata delanteros aleatorios que su coste sea menor a dos millones de euros
        /// </summary>
        /// <param name="cuantos">cantidad de delanteros que se quieren contratar</param>
        protected void contratarDelanteros(int cuantos)
        {

            int[] delanteros;

            DataTable dt = new DataTable();
            SqlDataAdapter dataA;
            dataA = new SqlDataAdapter("SELECT id FROM jugador WHERE precio<2000000 and demarcacion='delantero'", con);
            dataA.Fill(dt);

            if (cuantos <= dt.Rows.Count)
            {
                delanteros = llenarAleatorios(cuantos, dt.Rows.Count);

                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                for (int i = 0; i < cuantos; i++)
                {
                    comando.CommandText = "INSERT INTO jugadorEquipoJuego VALUES(" + Session["idEquipoJuego"] +
                        "," + dt.Rows[delanteros[i]]["id"].ToString() + ")";
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Función que devuelve un array de enteros con numeros aleatorios
        /// </summary>
        /// <param name="num">cantidad de numeros aleatorios</param>
        /// <param name="max">numero máximo para el rango del numero aleatorio (0-max)</param>
        /// <returns></returns>
        protected int[] llenarAleatorios(int num, int max)
        {
            bool existe = false;
            Random aleatorio = new Random();
            int[] numeros = new int[num];

            for (int i = 0; i < num; i++)
            {
                numeros[i] = aleatorio.Next(max);
                int j = 0;
                while (!existe && j < i)
                {
                    if (numeros[j] == numeros[i])
                    {
                        existe = true;
                        i--;
                    }
                    j++;
                }
                existe = false;
            }

            return numeros;
        }
    }
}