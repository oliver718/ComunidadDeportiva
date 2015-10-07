using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComunidadDeportiva
{
    public partial class ManualEEML : System.Web.UI.Page
    {
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
        }
    }
}