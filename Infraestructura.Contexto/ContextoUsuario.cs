using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;


namespace Infraestructura.Contexto
{
    public static class ContextoUsuario
    {

        #region Public Static Properties

        /// <summary>
        /// Corresponde al usuario del contexto
        /// </summary>
        public static string Usuario
        {
            get
            {
                if (HttpContext.Current.Session["USR_NOM"] != null)
                    return HttpContext.Current.Session["USR_NOM"].ToString();
                else
                    return string.Empty;
            }
            set
            {
                HttpContext.Current.Session["USR_NOM"] = value;
            }
        }

        /// <summary>
        /// Corresponde al ID del Perfil
        /// </summary>
        public static int PerfilId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["PFL_ID"].ToString());
            }
            set
            {
                HttpContext.Current.Session["PFL_ID"] = value;
            }
        }

        /// <summary>
        /// Corresponde al RUT de la entidad
        /// </summary>
        public static string UsuarioRut
        {
            get
            {
                return (HttpContext.Current.Session["USR_RUT"].ToString());
            }
            set
            {
                HttpContext.Current.Session["USR_RUT"] = value;
            }
        }

        /// <summary>
        /// Corresponde al dígito verificador del Usuario
        /// </summary>
        public static string UsuarioDig
        {
            get
            {
                return HttpContext.Current.Session["USR_DIG"].ToString();
            }
            set
            {
                HttpContext.Current.Session["USR_DIG"] = value;
            }
        }

        /// <summary>
        /// Corresponde al RUT del Usuario
        /// </summary>
        public static string Perfil
        {
            get
            {
                return HttpContext.Current.Session["PFL_USR"].ToString();
            }
            set
            {
                HttpContext.Current.Session["PFL_USR"] = value;
            }
        }

        #endregion Public Static Properties
    }
}
