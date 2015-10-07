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
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CDConexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["id"].ToString() != "")
                    Response.Redirect("~/menuPrincipal/Noticias.aspx");
            }
            catch (Exception)
            {
            }

            if (!IsPostBack)
            {
                LlenarDrpEquipo();
                LlenarDrpSeleccion();
            }

            LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
        }

        /// <summary>
        /// Función que se activa al pulsar el botón Crear cuenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCrearCuenta_Click(object sender, EventArgs e)
        {
            if (DatosOK())
            {
                if (!ExisteUsuario())
                {
                    if (RegistrarUsuario())
                        Response.Redirect("~/menuPrincipal/Noticias.aspx");
                }
            }
        }

        /// <summary>
        /// Función que comprueba si existe un usuario y un email, devuelve true si existe y false si no existe
        /// </summary>
        /// <returns></returns>
        protected bool ExisteUsuario()
        {
            bool existe = false;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataId = new SqlDataAdapter("SELECT id FROM usuario WHERE nombre='" + TxtNombre.Text + "'", con);
                con.Open();
                dataId.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    existe = true;
                    LblMensaje.Text = "Ese nombre de usuario ya está registrado";
                    throw new Exception();
                }

                SqlDataAdapter dataEmail = new SqlDataAdapter("SELECT id FROM usuario WHERE email='" + TxtEmail.Text + "'", con);
                con.Open();
                dataEmail.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    existe = true;
                    LblMensaje.Text = "Ese E-mail ya está registrado, no puede haber dos usuarios con el mismo E-mail";
                }


            }
            catch (Exception)
            {
            }

            return existe;
        }

        /// <summary>
        /// Función que registra un usuario, devuelve true si el registro se ha realizado con éxito y false si ha habido algún error.
        /// </summary>
        /// <returns></returns>
        protected bool RegistrarUsuario()
        {
            bool todoBien = true;
            try
            {
                string consulta = "INSERT INTO usuario values('" + TxtNombre.Text + "','" +
                     TxtContraseña.Text + "','" + TxtEmail.Text + "'," + DrpEquipo.SelectedValue +
                     "," + DrpSeleccion.SelectedValue + ",0)";

                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                comando.CommandText = consulta;
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
        /// Función que comprueba si los datos introducidos por el usuario son correctos, devuelve true si todo es correcto.
        /// </summary>
        /// <returns></returns>
        protected bool  DatosOK()
        {
            bool todoBien = true;
            int arroba = 0;
            int punto = 0;

            if (TxtNombre.Text == "" || TxtNombre.Text.Count() > 50)
            {
                LblMensaje.Text = "Error en el campo nombre";
                todoBien = false;
            }
            else if (TxtContraseña.Text == "" || TxtContraseña.Text.Count() > 10)
            {
                LblMensaje.Text = "Error en campo contraseña";
                todoBien = false;
            }
            else if (TxtContraseña.Text != TxtRContraseña.Text)
            {
                LblMensaje.Text = "Los campos de contraseña tiene que ser iguales";
                todoBien = false;
            }
            else if (TxtEmail.Text == "" || TxtEmail.Text.Count() > 30)
            {
                LblMensaje.Text = "Error en el campo Email";
                todoBien = false;
            }

            else if (DrpEquipo.SelectedItem.Text == "Escoge tu equipo...")
            {
                LblMensaje.Text = "Es necesario seleccionar un equipo";
                todoBien = false;
            }
            else if (DrpSeleccion.SelectedItem.Text == "Escoge tu selección...")
            {
                LblMensaje.Text = "Es necesario seleccionar una selección";
                todoBien = false;
            }

            //comprobación especial para el Email
            if (todoBien)
            {
                for (int i = 0; i < TxtEmail.Text.Count(); i++)
                {
                    if (TxtEmail.Text[i] == '@')
                        arroba++;
                    else if (TxtEmail.Text[i] == '.')
                        punto++;
                }
                if (punto == 0 || arroba != 1)
                {
                    LblMensaje.Text = "El Email que ha puesto no es correcto";
                    todoBien = false;
                }
                    
            }

            return todoBien;

        }

        /// <summary>
        /// Función que llena un dropDownList con los clubes disponibles
        /// </summary>
        protected void LlenarDrpEquipo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("Select id, nombre from equipo where seleccion=0", con);
                con.Open();
                dataA.Fill(dt);
                con.Close();
                DrpEquipo.Items.Clear();
                DrpEquipo.DataTextField = "nombre";
                DrpEquipo.DataValueField = "id";
                DrpEquipo.DataSource = dt;
                DrpEquipo.DataBind();
                DrpEquipo.Items.Insert(0, "Escoge un club...");//inserta en la primera posición
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Función que llena un dropDownList con las selecciones disponibles
        /// </summary>
        protected void LlenarDrpSeleccion()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("Select id, nombre from equipo where seleccion=1", con);
                con.Open();
                dataA.Fill(dt);
                con.Close();
                DrpSeleccion.Items.Clear();
                DrpSeleccion.DataTextField = "nombre";
                DrpSeleccion.DataValueField = "id";
                DrpSeleccion.DataSource = dt;
                DrpSeleccion.DataBind();
                DrpSeleccion.Items.Insert(0, "Escoge una selección...");//inserta en la primera posición
            }
            catch (Exception)
            {
            }
        }
    }
}