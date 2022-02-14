using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.AppDomain;
using System.Xml;
using Infraestructura;
using System.Data;

namespace Datos.ServiciosWeb
{
    public class DServiciosSAU
    {

        public Usuario AutenticaUsuario (string Argument )
        {
            Usuario Usr = new Usuario();
            try
            {
                WsAutentificacion.ServicioAutentificacion Ssau = new WsAutentificacion.ServicioAutentificacion();
                Sau objSau = new Sau();
                string strArgumento = objSau.ValidaSesion(Argument);
                string consSistemaUsuario = objSau.ValidaIdSistema(Argument);
                DataSet Datos = Ssau.ValidaSession(strArgumento);

                if (Argument.Length != 0)
                {
                    if (Datos.Tables[0].Rows.Count >0 )
                    {
                        Usr.NroError = Converts.ConvertToInt(Datos.Tables[0].Rows[0]["nro_error"]);
                        Usr.Error = Converts.ConvertToString(Datos.Tables[0].Rows[0]["Msg_Error"]);
                        Usr.Rut = Converts.ConvertToString(Datos.Tables[0].Rows[0]["rut_usuario"]);
                        StringBuilder Nombre = new StringBuilder();
                        Nombre.Append(Converts.ConvertToString(Datos.Tables[0].Rows[0]["nom_usuario"]));
                        Nombre.Append(" ");
                        Nombre.Append(Converts.ConvertToString(Datos.Tables[0].Rows[0]["ape_pat"]));
                        Nombre.Append(" ");
                        Nombre.Append(Converts.ConvertToString(Datos.Tables[0].Rows[0]["apa_mat"]));
                        Usr.Nombre = Nombre.ToString().Trim();
                        Usr.PerfilId = Converts.ConvertToInt(Datos.Tables[0].Rows[0]["nom_perfil"]);
                    }
                    else 
                    {
                        Usr = new Usuario(-1, "Error de comunicación.");
                    }
                }
                else
                {
                    Usr = new Usuario(-1, "Sin argumentos de autenticación.");
                }
                #region asdf 
                /*
                XmlDocument m_xmld;
                XmlNode m_node;
                m_xmld = new XmlDocument();
                m_xmld.LoadXml(sXml);

                //Obtenemos la lista de los nodos "codigo error"
                m_node = m_xmld.SelectSingleNode("/data/usuario/Nro_Error");
                Usr.NroError = Converts.ConvertToInt(m_node.ChildNodes.Item(0).InnerText);

                //Obtenemos la lista de los nodos "usuario"
                m_node = m_xmld.SelectSingleNode("/data/usuario/Msg_Error");
                Usr.Error = m_node.ChildNodes.Item(0).InnerText;

                //Si no existe error entoces rescatamos el resto
                if (Usr.NroError == 0)
                {
                    //Obtenemos la lista de los nodos "usuario"
                    m_node = m_xmld.SelectSingleNode("/data/usuario/NombreUsuario");
                    Usr.Nombre = m_node.ChildNodes.Item(0).InnerText;

                    //Obtenemos la lista de los nodos "perfil"
                    m_node = m_xmld.SelectSingleNode("/data/usuario/NombrePerfil");
                    Usr.Perfil = m_node.ChildNodes.Item(0).InnerText;

                    //Obtenemos la lista de los nodos "oficina"
                    m_node = m_xmld.SelectSingleNode("/data/usuario/CodOficina");
                    Usr.IdOficina = Converts.ConvertToInt(m_node.ChildNodes.Item(0).InnerText);
                    //Obtenemos la lista de los nodos "Perfil"
                    m_node = m_xmld.SelectSingleNode("/data/usuario/Perfil");
                    Usr.PerfilId = Converts.ConvertToInt(m_node.ChildNodes.Item(0).InnerText);
                }
                */
                #endregion asdf
            }
            catch ( Exception ex)
            {
                Usr = new Usuario(-1, ex.Message.ToString());
            }
            return Usr;
        }

    }
}
