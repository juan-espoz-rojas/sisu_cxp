using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.WsAutentificacion;
using System.Data;
using Infraestructura.Contexto;
using Dominio.AppDomain;
using Datos.ServiciosWeb;

namespace Negocio.AppBusiness
{
    public class BUsuario
    {

        public bool ValidaSesion(string strStringParameters)
        {
            try
            {
                DServiciosSAU Dsau = new DServiciosSAU();
                Usuario Usr = Dsau.AutenticaUsuario(strStringParameters);
                if (Usr.NroError == 0)
                {
                    ContextoUsuario.Usuario = Usr.Nombre;
                    ContextoUsuario.Perfil = Usr.Perfil;
                    ContextoUsuario.PerfilId = Usr.PerfilId;
                    ContextoUsuario.UsuarioRut = Usr.Rut;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
