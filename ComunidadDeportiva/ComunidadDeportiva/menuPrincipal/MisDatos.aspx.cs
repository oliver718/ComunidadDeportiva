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
    public partial class MisDatos : System.Web.UI.Page
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

            LblMensaje.Text = "";
            
            if(!IsPostBack)
                cargarDatos();
        }

        /// <summary>
        /// Función que llena los TextBox con los datos del usuario
        /// </summary>
        protected void cargarDatos()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA = new SqlDataAdapter("SELECT nombre, email FROM usuario WHERE id=" + Session["id"].ToString(), con);
            dataA.Fill(dt);
            TxtNombre.Text = dt.Rows[0]["nombre"].ToString();
            TxtEmail.Text = dt.Rows[0]["email"].ToString();
            con.Close();
        }

        /// <summary>
        /// Función que se activa cuando el usuario pulsa el botón de Aceptar para cambiar la contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAceptarContraseña_Click(object sender, EventArgs e)
        {
            if (TxtNContraseña.Text != "" && TxtNContraseña.Text == TxtRContraseña.Text)
            {
                if (contraseñaOK(TxtAContraseña.Text))
                    modificarContraseña();
                else
                {
                    LblMensaje.Text = "Contraseña erronea";
                    LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            else
            {
                LblMensaje.Text = "Los campos de nueva contraseña y repita nueva contraseña tienen que ser iguales";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        /// <summary>
        /// Función que devuelve true si la contraseña que entra por parametros es la contraseña del usuario y false si no lo es
        /// </summary>
        /// <param name="contraseña">contraseña del usuario</param>
        /// <returns></returns>
        protected bool contraseñaOK(string contraseña)
        {
            bool bien = false;

            try
            {
                if (contraseña != "")
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter dataA = new SqlDataAdapter("SELECT contrasenia FROM usuario WHERE id=" + Session["id"].ToString(), con);
                    dataA.Fill(dt);
                    if (dt.Rows[0]["contrasenia"].ToString() == contraseña)
                        bien = true;
                }
            }
            catch (Exception)
            {
            }

            return bien;
        }

        /// <summary>
        /// Función que modifica la contraseña del usuario
        /// </summary>
        protected void modificarContraseña()
        {
            try
            {
                string consulta = "update usuario set contrasenia='" + TxtNContraseña.Text + "' where id=" + Session["id"];

                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                comando.CommandText = consulta;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
                LblMensaje.Text = "Contraseña modificada correctamente";
                LblMensaje.ForeColor = System.Drawing.Color.Green;
                PnlContraseña.Visible = false;
            }
            catch (Exception)
            {
                LblMensaje.Text = "Error al modificar la contraseña";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        /// <summary>
        /// Función que modifica los datos del usuario.
        /// </summary>
        protected void modificarDatos()
        {
            try
            {
                string consulta = "update usuario set nombre='" + TxtNombre.Text + "', email='" + TxtEmail.Text + "' where id=" + Session["id"];

                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                comando.CommandText = consulta;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
                cargarDatos();
                LblMensaje.Text = "Datos modificados correctamente";
                LblMensaje.ForeColor = System.Drawing.Color.Green;
                PnlConfirmarContraseña.Visible = false;
            }
            catch (Exception)
            {
                LblMensaje.Text = "Error al modificar los datos";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        /// <summary>
        /// Función que se activa cuando el usuario pulsa el botón de modificar contraseña, habre el panel de contraseña.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnModificarContraseña_Click(object sender, EventArgs e)
        {
            PnlConfirmarContraseña.Visible = false;
            PnlContraseña.Visible = true;
        }

        /// <summary>
        /// Función que se activa cuando el usuario pulsa el botón de aceptar para modificar datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAceptarDatos_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text != "" && TxtEmail.Text != "")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT * FROM usuario WHERE nombre='" + TxtNombre.Text + "'", con);
                dataA.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["id"].ToString() != Session["id"].ToString())
                    {
                        LblMensaje.Text = "Ese nombre de usuario ya esta registrado, escoja otro nombre.";
                        LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                if (contraseñaOK(TxtCContraseña.Text))
                    modificarDatos();
                else
                {
                    LblMensaje.Text = "Contraseña incorrecta";
                    LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            else
            {
                LblMensaje.Text = "El nombre y el email no pueden estar vacios";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        /// <summary>
        /// Función que se activa cuando el usuario pulsa el botón de modificar datos, habre el panel para confirmar la contraseña de usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnModificarDatos_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text != "" && TxtEmail.Text != "")
            {
                PnlContraseña.Visible = false;
                PnlConfirmarContraseña.Visible = true;
            }
            else
            {
                LblMensaje.Text = "El nombre y el email no pueden estar vacios";
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
            }
        }


    }
}