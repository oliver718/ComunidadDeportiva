using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComunidadDeportiva.menuIzquierda
{
    public partial class Foro : System.Web.UI.Page
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
            LblMensaje.Text = "";

            if (!IsPostBack)
            {
                llenarGrdTemas();
                ImgEquipo.ImageUrl = getRutaImagen();
                ImgEquipo.ToolTip = getNombreEquipo();
                PnlCrearTema.Visible = false;
                BtnAbrirPanel.Visible = puedeCrear();
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
        /// Función que devuelve true si el usuario puede crear comentarios y false si no puede
        /// </summary>
        /// <returns></returns>
        protected bool puedeCrear()
        {
            bool puede = false;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT idEquipo, idSeleccion FROM usuario WHERE id=" + 
                    Session["id"].ToString(), con);
                dataA.Fill(dt);
                if (dt.Rows[0]["idEquipo"].ToString() == Request["e"].ToString() || dt.Rows[0]["idSeleccion"].ToString() == Request["e"].ToString())
                    puede = true;
            }
            catch (Exception)
            {
            }
            return puede;
        }

        /// <summary>
        /// Función que llena el gridView con los temas del foro del equipo
        /// </summary>
        protected void llenarGrdTemas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT * FROM temaForo WHERE idEquipo=" + Request["e"] + 
                    " order by fechaCreacion desc", con);
                dataA.Fill(dt);
                GrdTemas.DataSource = dt;
                GrdTemas.DataBind();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Función que devuelve un string con la ruta a la página de comentarios de los temas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getRuta(object id)
        {
            return "~/menuIzquierda/Comentarios.aspx?e=" + Request["e"] + "&t=" + id.ToString();
        }

        /// <summary>
        /// Función que se activa cuando el usuario pulsa el botón de crear tema, crea un tema nuevo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCrearTema_Click(object sender, EventArgs e)
        {
            string error = "Error al crear el tema";
            string creado = "Este tema ya está creado";
            string vacio = "El nombre del tema no puede esta vacio";
            string bien = "El tema se ha creado correctamente";
            string grande = "El nombre del tema no puede ser mayor a 50 caracteres";

            try
            {
                if (TxtTema.Text != "")
                {
                    if (TxtTema.Text.Count() > 50)
                        throw new Exception(grande);
                    DataTable dt = new DataTable();
                    SqlDataAdapter dataA;
                    dataA = new SqlDataAdapter("SELECT * FROM temaForo WHERE idEquipo=" + Request["e"].ToString() +
                        " and nombre='" + TxtTema.Text + "'", con);
                    dataA.Fill(dt);

                    if (dt.Rows.Count > 0)
                        throw new Exception(creado);
                    else
                    {
                        string consulta = "INSERT INTO temaForo values('" + TxtTema.Text + "'," +
                            Request["e"].ToString() + "," + Session["id"] + ",convert(datetime,'" + DateTime.Now + "',103))";

                        SqlCommand comando = new SqlCommand();
                        comando.Connection = con;
                        comando.CommandText = consulta;
                        con.Open();
                        comando.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                    throw new Exception(vacio);
                LblMensaje.Text = bien;
                LblMensaje.ForeColor = System.Drawing.Color.Green;
                llenarGrdTemas();
                PnlCrearTema.Visible = false;
            }
            catch (Exception m)
            {
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                if (m.Message == vacio)
                    LblMensaje.Text = vacio;
                else if (m.Message == creado)
                    LblMensaje.Text = creado;
                else if (m.Message == grande)
                    LblMensaje.Text = grande;
                else
                    LblMensaje.Text = error;
            }
        }

        /// <summary>
        /// Función habre el panel de nuevo tema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAbrirPanel_Click(object sender, EventArgs e)
        {
            PnlCrearTema.Visible = true;
            TxtTema.Text = "";
        }

        /// <summary>
        /// Función que devuelve un string con la ruta del escudo del equipo
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
        /// Función que devuelve el nombre de la foto del escudo del equipo
        /// </summary>
        /// <param name="nombreEquipo">nombre del equipo</param>
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
        /// Función que sirve para paginar el gridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdTemas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdTemas.PageIndex = e.NewPageIndex;
            llenarGrdTemas();
        }

        /// <summary>
        /// Función que cierra el panel de crear tema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            PnlCrearTema.Visible = false;
        }
    }
}