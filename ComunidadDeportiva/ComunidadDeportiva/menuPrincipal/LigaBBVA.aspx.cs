﻿using System;
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
    public partial class LigaBBVA : System.Web.UI.Page
    {
        public int cont = 5;
        public int cont2 = 0;
        public int idEquipo;

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

            llenarRptEquipos();
        }

        /// <summary>
        /// Función que llena el repeater de selecciones.
        /// </summary>
        protected void llenarRptEquipos()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataA = new SqlDataAdapter("SELECT id,nombre FROM equipo WHERE seleccion=0", con);
            dataA.Fill(dt);
            con.Close();

            rptEquipos.DataSource = dt;
            rptEquipos.DataBind();
        }

        /// <summary>
        /// Función que devuelve un string con la ruta del escudo de la selección.
        /// </summary>
        /// <param name="nombre"> nombre de la selección</param>
        /// <returns></returns>
        public string getRutaImagen(object nombre)
        {
            string nombreEquipo = nombre.ToString();

            nombreEquipo = nombreEquipo.ToLower();
            nombreEquipo = nombreEquipo.Replace("á", "a");
            nombreEquipo = nombreEquipo.Replace("é", "e");
            nombreEquipo = nombreEquipo.Replace("í", "i");
            nombreEquipo = nombreEquipo.Replace("ó", "o");
            nombreEquipo = nombreEquipo.Replace("ú", "u");
            nombreEquipo = nombreEquipo.Replace(" ", "");
            
            return "~/escudos/" + nombreEquipo + ".png";

        }

        /// <summary>
        /// Función que devuelve la ruta del foro de la selección
        /// </summary>
        /// <param name="id"> id de la selección</param>
        /// <returns></returns>
        public string getRutaForo(object id)
        {
            return "~/menuIzquierda/Foro.aspx?e=" + id.ToString();
        }
    }
}