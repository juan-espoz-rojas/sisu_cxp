using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Infraestructura.Exceptions;

namespace Presentacion.Navigation 
{
    public class Navigate: Page
    {
        #region Private Members

        private ParameterCollection inParameters = new ParameterCollection();
        private ParameterCollection outParameters = new ParameterCollection();

        #endregion Private Members

        #region Public Properties

        public ParameterCollection InParameters
        {
            get
            {
                return inParameters;
            }
            set
            {
                inParameters = value;
            }
        }
        public ParameterCollection OutParameters
        {
            get
            {
                return outParameters;
            }
            set
            {
                outParameters = value;
            }
        }

        #endregion Public Properties

        #region Constructors

        public Navigate()
        {
            this.PreInit += new EventHandler( NavigablePage_PreInit );
        }

        #endregion Constructors

        #region Public Methods

        public string GetParameters()
        {
            string data = "?data=";
            string parameters = "";
            foreach (KeyValuePair<string, string> item in OutParameters)
            {
                parameters += item.Key + "=" + item.Value + "~";
            }
            if (!parameters.Equals(string.Empty))
            {
                data += this.Encryptar(parameters.Substring(0, parameters.Length - 1));
                return (data);
            }
            return (string.Empty);

        }
        private string GetCurrentSource()
        {
            return (base.Context.Request.ServerVariables["PATH_INFO"]);
        }
        public void RoutedTo(string transition)
        {
            this.Context.Response.Redirect(transition + GetParameters(), false);
        }
        void NavigablePage_PreInit(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    this.InParameters = this.Restore(this.Context);
                }
            }
            catch (ExceptionFuncional)
            {
                throw new ExceptionFuncional("No se puede resolver los parámetros.");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public ParameterCollection Restore(HttpContext context)
        {
            ParameterCollection collectionParameters = new ParameterCollection();
            string Data = string.Empty;
            if (context.Request["data"] != null)
            {
                Data = this.Descryptar(context.Request["data"]);
                string[] s = Data.Split('~');
                foreach (string Parametro in s)
                {
                    string[] par = Parametro.Split('=');
                    collectionParameters.Add(par[0], par[1]);
                }
            }
            return collectionParameters;
        }

        #endregion Public Methods

        #region Metodos de encriptacion
        public string Encryptar(string strCadena)
        {
            System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("secretillo"));
            DES.Mode = System.Security.Cryptography.CipherMode.ECB;
            byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(strCadena);
            return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        public string Descryptar(string strCadena)
        {
            string Cadena = strCadena.Replace(" ", "+");
            System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("secretillo"));
            DES.Mode = System.Security.Cryptography.CipherMode.ECB;
            byte[] Buffer = Convert.FromBase64String(Cadena);
            return System.Text.ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        #endregion Metodos de encriptacion

    }
}