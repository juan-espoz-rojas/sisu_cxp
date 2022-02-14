using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.AppBusiness;
using Presentacion.Navigation;
using System.Configuration;

namespace Presentacion
{
    public partial class Login : Navigate
    {
        BUsuario BUser = new BUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //-------------------------------------------------------------------------------------
                if (Request.QueryString["token"] != null)
                {
                    string urlToken = Server.UrlDecode(Request.QueryString["token"]);
                    urlToken = urlToken.Replace(" ", "+");

                    SISU.Token = urlToken;
                }
                //-------------------------------------------------------------------------------------

                //bool ActivaValidacionSAU = (ConfigurationManager.AppSettings["SAU_ACT"] == "1");
                //String strStringParameters = string.Empty;
                //if (ActivaValidacionSAU)
                //    strStringParameters = Request["ID"];
                //else 
                //    strStringParameters = ConfigurationManager.AppSettings["DEF_AUT_SAU"];

                //if (BUser.ValidaSesion(strStringParameters))
                this.RoutedTo(Transition.TCC);
                //else
                //    this.RoutedTo(Transition.ACCESODENEGADO);
            }
            catch (Exception)
            {
                this.RoutedTo(Transition.ACCESODENEGADO);
            }
        }
    }
}