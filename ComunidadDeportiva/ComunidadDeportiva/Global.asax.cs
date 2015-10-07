using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ComunidadDeportiva
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["usuario"] = "";
            Session["id"] = "";
            Session["idEquipo"] = "";
            Session["idSeleccion"] = "";
            Session["idOtroEquipo"] = "";
            Session["idOtraSeleccion"] = "";
            Session["idFotoEquipo"] = "";
            Session["idEquipoJuego"] = "";
            Session.Timeout = 30;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
           
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Session["usuario"] = "";
            Session["id"] = "";
            Session["idEquipo"] = "";
            Session["idSeleccion"] = "";
            Session["idOtroEquipo"] = "";
            Session["idOtraSeleccion"] = "";
            Session["idFotoEquipo"] = "";
            Session["idEquipoJuego"] = "";
        }
    }
}