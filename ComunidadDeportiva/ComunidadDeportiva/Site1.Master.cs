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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CDConexion"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try //seguridad
            {
                if (Session["id"].ToString() == "")
                    Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                Response.Redirect("~/Default.aspx");
            }

            if(!IsPostBack)
                LblUsuario.Text = GetNombreUsuario();
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

        //FUNCIONES DE MENU LATERAL DINAMICO

        /// <summary>
        /// Función que pone "Mi club" si el usuario no está dentro de ningún equipo ó el nombre del equipo en el que este el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LblEquipo_PreRender(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT * FROM equipo WHERE id=" + Request["e"].ToString(), con);
                dataA.Fill(dt);
                if (((int)dt.Rows[0]["seleccion"]) == 0)
                {
                    if (dt.Rows[0]["id"].ToString() == Session["idEquipo"].ToString())
                        LblEquipo.Text = "Mi Club";
                    else
                    {
                        LblEquipo.Text = dt.Rows[0]["nombre"].ToString();
                        Session["idOtroEquipo"] = Request["e"].ToString();
                    }
                }
                else
                    LblEquipo.Text = "Mi Club";

            }
            catch (Exception)
            {
                    LblEquipo.Text = "Mi Club";
            }
        }

        /// <summary>
        /// Función que prepara el enlace de Foro de clubes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Equipo_Foro_PreRender(object sender, EventArgs e)
        {
            if (LblEquipo.Text == "Mi Club")
                Equipo_Foro.NavigateUrl = "~/menuIzquierda/Foro.aspx?e=" + Session["idEquipo"];
            else
                Equipo_Foro.NavigateUrl = "~/menuIzquierda/Foro.aspx?e=" + Session["idOtroEquipo"];
        }

        /// <summary>
        /// Función que prepara el enlace de Galeria de clubes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Equipo_Galeria_PreRender(object sender, EventArgs e)
        {
            if (LblEquipo.Text == "Mi Club")
                Equipo_Galeria.NavigateUrl = "~/menuIzquierda/Galeria.aspx?e=" + Session["idEquipo"];
            else
                Equipo_Galeria.NavigateUrl = "~/menuIzquierda/Galeria.aspx?e=" + Session["idOtroEquipo"];
        }

        /// <summary>
        /// Función que prepara el enlace de Jugadores de clubes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Equipo_Jugadores_PreRender(object sender, EventArgs e)
        {
            if (LblEquipo.Text == "Mi Club")
                Equipo_Jugadores.NavigateUrl = "~/menuIzquierda/Jugadores.aspx?e=" + Session["idEquipo"];
            else
                Equipo_Jugadores.NavigateUrl = "~/menuIzquierda/Jugadores.aspx?e=" + Session["idOtroEquipo"];
        }
        
        /// <summary>
        /// Función que activa el enlace de "volver a mi club" si el usuario está dentro de otro club que no sea el suyo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Equipo_volver_PreRender(object sender, EventArgs e)
        {
            if (LblEquipo.Text == "Mi Club")
                Equipo_volver.Visible = false;
            else
            {
                Session["idOtroEquipo"] = "";
                Equipo_volver.NavigateUrl = "~/menuIzquierda/Foro.aspx?e=" + Session["idEquipo"];
            }
        }

        /// <summary>
        /// Función que pone "Mi selección" si el usuario no está dentro de ningúna selección ó el nombre de la selección en el que este el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LblSeleccion_PreRender(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataA = new SqlDataAdapter("SELECT * FROM equipo WHERE id=" + Request["e"].ToString(), con);
                dataA.Fill(dt);
                if (((int)dt.Rows[0]["seleccion"]) == 1)
                {
                    if (dt.Rows[0]["id"].ToString() == Session["idSeleccion"].ToString())
                        LblSeleccion.Text = "Mi Selección";
                    else
                    {
                        LblSeleccion.Text = dt.Rows[0]["nombre"].ToString();
                        Session["idOtraSeleccion"] = Request["e"].ToString();
                    }
                }
                else
                    LblSeleccion.Text = "Mi Selección";
            }
            catch (Exception)
            {
                    LblSeleccion.Text = "Mi Selección";
            }
            
        }

        /// <summary>
        /// Función que prepara el enlace de Foro de selecciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Seleccion_Foro_PreRender(object sender, EventArgs e)
        {
            if (LblSeleccion.Text == "Mi Selección")
                Seleccion_Foro.NavigateUrl = "~/menuIzquierda/Foro.aspx?e=" + Session["idSeleccion"];
            else
                Seleccion_Foro.NavigateUrl = "~/menuIzquierda/Foro.aspx?e=" + Session["idOtraSeleccion"];
        }

        /// <summary>
        /// Función que prepara el enlace de Galería de selecciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Seleccion_Galeria_PreRender(object sender, EventArgs e)
        {
            if (LblSeleccion.Text == "Mi Selección")
                Seleccion_Galeria.NavigateUrl = "~/menuIzquierda/Galeria.aspx?e=" + Session["idSeleccion"];
            else
                Seleccion_Galeria.NavigateUrl = "~/menuIzquierda/Galeria.aspx?e=" + Session["idOtraSeleccion"];
        }

        /// <summary>
        /// Función que prepara el enlace de Jugadores de selecciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Seleccion_Jugadores_PreRender(object sender, EventArgs e)
        {
            if (LblSeleccion.Text == "Mi Selección")
                Seleccion_Jugadores.NavigateUrl = "~/menuIzquierda/Jugadores.aspx?e=" + Session["idSeleccion"];
            else
                Seleccion_Jugadores.NavigateUrl = "~/menuIzquierda/Jugadores.aspx?e=" + Session["idOtraSeleccion"];
        }

        /// <summary>
        /// Función que activa el enlace de "volver a mi selección" si el usuario está dentro de otra selección que no sea la suya
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Seleccion_volver_PreRender(object sender, EventArgs e)
        {
            if (LblSeleccion.Text == "Mi Selección")
                Seleccion_volver.Visible = false;
            else
                Seleccion_volver.NavigateUrl = "~/menuIzquierda/Foro.aspx?e=" + Session["idSeleccion"];
        }
    }
}