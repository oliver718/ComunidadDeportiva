using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComunidadDeportiva
{
    public partial class Ocio : System.Web.UI.Page
    {
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
        }
    }
}