using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Negocio.SISU;

namespace Presentacion.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class ServicioDirecciones : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] ConsultaDirecciones(string Direccion)
        {
            BIngresoServUrb BIngServ = new BIngresoServUrb();
            List<string> Direcciones = BIngServ.ConsultaDireccionStr(Direccion);
            return Direcciones.ToArray();
        }
    }
}
