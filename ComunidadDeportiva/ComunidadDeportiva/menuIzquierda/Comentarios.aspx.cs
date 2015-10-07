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
    public partial class Comentarios : System.Web.UI.Page
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
                llenarGrdComentarios();
                LblTema.Text = getNombreTema();
                ImgEquipo.ImageUrl = getRutaImagen();
                ImgEquipo.ToolTip = getNombreEquipo();
                PnlCrearComentario.Visible = false;
                BtnAbrirPanel.Visible = puedeCrear();
            }
        }

        /// <summary>
        /// Función que devuelve el nombre del tema que se ha seleccionado en la página de temas
        /// </summary>
        /// <returns></returns>
        protected string getNombreTema()
        {
            string nombre = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT nombre FROM temaForo WHERE id=" +
                    Request["e"].ToString(), con);
                dataA.Fill(dt);

                nombre = dt.Rows[0]["nombre"].ToString();
            }
            catch (Exception)
            {
            }

            return nombre;
        }

        /// <summary>
        /// Función que comprueba si los parametros que entran por la url de la página son correctos
        /// </summary>
        protected void parametrosOk()
        {
            try
            {
                string equipo = Request["e"];
                string tema = Request["t"];
                if (equipo == "" || tema == "" || equipo == null || tema == null)
                    throw new Exception();
            }
            catch (Exception)
            {
                Response.Redirect("~/menuPrincipal/Noticias.aspx");
            }
        }

        /// <summary>
        /// Función que comprueba si un usuario puede crear un nuevo comentario
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
        /// Función que llena el gridView con los comentarios del tema
        /// </summary>
        protected void llenarGrdComentarios()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA;
                dataA = new SqlDataAdapter("SELECT c.fechaCreacion, c.comentario, u.nombre FROM comentarioForo c, usuario u " +
                    "WHERE c.idUsuario = u.id and c.idTema=" + Request["t"] + " order by c.fechaCreacion desc", con);
                dataA.Fill(dt);
                GrdComentarios.DataSource = dt;
                GrdComentarios.DataBind();
            }
            catch (Exception m)
            {
                string asd = m.Message;
            }
        }

        /// <summary>
        /// Función que crea un comentario cuando el usuario pulsa el boton de crear comentario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCrearComentario_Click(object sender, EventArgs e)
        {
            
            string comentario;
            try
            {
                if ((TxtComentario.Text).Trim() != "")
                {
                    if (TxtComentario.Text.Count() > 1000)
                        throw new Exception("grande");
                    pruebaErrores();
                    comentario = TxtComentario.Text.Replace("\n", "<br>");

                    string consulta = "INSERT INTO comentarioForo values(" + Request["t"] + "," +
                        Session["id"] + ",convert(datetime,'" + DateTime.Now + "',103),'" + comentario + "')";

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = con;
                    comando.CommandText = consulta;
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                }
                llenarGrdComentarios();
                TxtComentario.Text = "";
                PnlCrearComentario.Visible = false;
                LblMensaje.Text = "Comentario creado correctamente";
                LblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception m)
            {
                LblMensaje.ForeColor = System.Drawing.Color.DarkRed;

                if (m.Message == "grande")
                    LblMensaje.Text = "El comentario no puede tener mas de 1000 caracteres";
                else
                    LblMensaje.Text = "Error al crear el comentario";
                
            }
        }

        /// <summary>
        /// Función que controla que si el usuario entra texto sin espacios en el comentario, este se muestre bien
        /// </summary>
        protected void pruebaErrores()
        {
            int maxSeguido = 60;
            int minEspacios;
            string[] espacios;
            int caracteres = TxtComentario.Text.Count();
            int posicion = 0;

            if (caracteres > maxSeguido)
            {
                minEspacios = caracteres / maxSeguido;
                espacios = TxtComentario.Text.Split(' ');
                if (espacios.Length < minEspacios + 1)
                {
                    for (int i = 0; i < minEspacios; i++)
                    {
                        posicion += maxSeguido;
                        TxtComentario.Text = TxtComentario.Text.Insert(posicion, " ");
                    }
                }
            }
        }

        /// <summary>
        /// Función que habre el panel de crear comentario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAbrirPanel_Click(object sender, EventArgs e)
        {
            PnlCrearComentario.Visible = true;
        }

        /// <summary>
        /// Función que sirve para paginar el gridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdComentarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdComentarios.PageIndex = e.NewPageIndex;
            llenarGrdComentarios();
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
        /// <param name="nombreEquipo"></param>
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
        /// Función que cierra el panel de crear comentario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            PnlCrearComentario.Visible = false;
            TxtComentario.Text = "";
            LblMensaje.Text = "";
        }
    }
}