using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.General;
using Infraestructura.Contexto;

namespace Infraestructura.Exceptions
{
    public class ExceptionTecnica
    {
        public void GuardarLogError(string mensaje, string CssPath)
        {
            StringBuilder reporte = new StringBuilder();
            reporte.Append("<errores>");
            //reporte.Append("<user>" + ContextoUsuario.Usuario + "</user>");
            reporte.Append("<escenario>SISU</escenario>");
            reporte.Append("<paginaorigen>" + CssPath + "</paginaorigen>");
            //reporte.Append("<idUs>" + ContextoUsuario.UsuarioRut + "</idUs>");
            //reporte.Append("<idpfl>" + ContextoUsuario.PerfilId + "</idpfl>");
            reporte.Append("<tiposolicitud></tiposolicitud>");
            int error = 1;
            if (mensaje != null)
            {
                reporte.Append("<error>");
                reporte.Append("<codigo>" + mensaje.GetType().FullName + "</codigo>");
                reporte.Append("<mensaje></mensaje>");
                reporte.Append("<traza>" + mensaje + "</traza>");
                error++;
                reporte.Append("</error>");
            }
            reporte.Append("</errores>");
            DLogEvent Log = new DLogEvent();
            Log.RegistrarEvento(reporte.ToString(), "SISU");
        }
    }
}
