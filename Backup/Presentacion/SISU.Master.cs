using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Contexto;
using System.Reflection;

namespace Presentacion
{
    public partial class SISU : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ContextoUsuario.Usuario.Length > 0)
            //{
            //    lblUsuario.Text = ContextoUsuario.Usuario;
            //    lblFecha.Text = DateTime.Now.ToShortDateString();
            //    BtnCerrarSesion.Visible = true;
            //}
            //else
            //{
            //    Response.Redirect("~/AccesoDenegado.aspx");
            //    //lblUsuario.Text = "Usuario Anónimo";
            //    //BtnCerrarSesion.Visible = false;
            //    //lblFecha.Text = DateTime.Now.ToShortDateString();
            //}

            AppDomain currentDomain = AppDomain.CurrentDomain;
            Object version = Session["Version"];
            if (!Page.IsPostBack && Session["Version"] == null || version == null)
            {
                foreach (Assembly assembly in currentDomain.GetAssemblies())
                {
                    AssemblyName ass = assembly.GetName();
                    if (ass.Name == "Presentacion")
                    {
                        Session["Version"] = "Versión " + ass.Version;
                        version = Session["Version"];
                        break;
                    }
                }
            }
            lblVersion.Text = version.ToString();
        }

        //protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Logout.aspx");
        //}
    }
}