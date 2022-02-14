using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Datos.General;
using Dominio.Objects;
using System.Data;
using Infraestructura;
using System.Data.SqlClient;
using System.Web.Services;
using Datos.DireccionesSSO;
using System.Configuration;

namespace Datos.SISU
{
    public class DIngresoServUrb
    {
        #region Private Members
        private Database BDSigo;
        private Database BDExp_Corp;
        private Database BDExp_Inhouse;
        private Database BDExp_Clientes;
        private Database BDExp_Retiros;
        private Database BDSso;
        #endregion Private Members

        #region Constructors
        public DIngresoServUrb()
        {
            SqlDatabase BDsig = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "SIGO"));
            SqlDatabase BDcorp = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "EXP_CORP"));
            SqlDatabase Bdinhouse = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "EXP_INHOUSE"));
            SqlDatabase BDclientes = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "EXP_CLIENTES"));
            SqlDatabase BDretiros = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "EXP_RETIROS"));
            SqlDatabase BDsso = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "SSO"));
            this.BDSigo = BDsig;
            this.BDExp_Corp = BDcorp;
            this.BDExp_Inhouse = Bdinhouse;
            this.BDExp_Clientes = BDclientes;
            this.BDExp_Retiros = BDretiros;
            this.BDSso = BDsso;
        }
        #endregion Constructors

        #region Public Methods

        public List<Direccion> ConsultaDireccionesRetiroTCC(int NroTCC)
        {
            List<Direccion> Lista = new List<Direccion>();
            IDataReader dr = null;
            try
            {
                dr = this.BDExp_Retiros.ExecuteReader("PR_S_RETIROS_CONSULTA_DIRECCION_TCC", NroTCC, "RM");
               
                while (dr.Read())
                {
                    Direccion Direccion = new Direccion();

                    if (dr["Nro_Error"] != DBNull.Value)
                    {
                        if (Converts.ConvertToInt(dr["Nro_Error"]) != 0)
                            break;
                        else
                        {

                            if (dr["IndDireccionTCCRet"] != DBNull.Value)
                                Direccion.IndiceDireccion = Converts.ConvertToInt(dr["IndDireccionTCCRet"]);
                            if (dr["NroTCC"] != DBNull.Value)
                                Direccion.NroTCC = Converts.ConvertToDecimal(dr["NroTCC"]);
                            if (dr["DireccionTCCRet"] != DBNull.Value)
                                Direccion.NDireccion = Converts.ConvertToString(dr["DireccionTCCRet"]);
                            if (dr["Numeracion"] != DBNull.Value)
                                Direccion.Numeracion = Converts.ConvertToString(dr["Numeracion"]);
                            if (dr["CarAnt"] != DBNull.Value)
                                Direccion.CarAnt = Converts.ConvertToString(dr["CarAnt"]);
                            if (dr["CarPos"] != DBNull.Value)
                                Direccion.CarPos = Converts.ConvertToString(dr["CarPos"]);
                            if (dr["Comuna"] != DBNull.Value)
                                Direccion.CodComuna = Converts.ConvertToString(dr["Comuna"]);
                            if (dr["CodCobertura"] != DBNull.Value)
                                Direccion.CodCobertura = Converts.ConvertToString(dr["CodCobertura"]);
                            if (dr["Contacto"] != DBNull.Value)
                                Direccion.NombreContacto = Converts.ConvertToString(dr["Contacto"]);
                            if (dr["Telefono"] != DBNull.Value)
                                Direccion.Telefono = Converts.ConvertToString(dr["Telefono"]);
                            if (dr["LugarRetiro"] != DBNull.Value)
                                Direccion.LugarRetiro = Converts.ConvertToString(dr["LugarRetiro"]);
                            if (dr["CodEstado"] != DBNull.Value)
                                Direccion.CodEstado = Converts.ConvertToInt(dr["CodEstado"]);
                            if (dr["CodBlock"] != DBNull.Value)
                                Direccion.CodBlock = Converts.ConvertToDecimal(dr["CodBlock"]);
                            if (dr["IDDireccion"] != DBNull.Value)
                                Direccion.IdDireccion = Converts.ConvertToDecimal(dr["IDDireccion"]);
                            if (dr["Lat"] != DBNull.Value)
                                Direccion.Latitud = Converts.ConvertToDecimal(dr["Lat"]);
                            if (dr["lon"] != DBNull.Value)
                                Direccion.Longitud = Converts.ConvertToDecimal(dr["lon"]);
                            if (dr["Email"] != DBNull.Value)
                                Direccion.Mail = Converts.ConvertToString(dr["Email"]);

                            StringBuilder DirCmp = new StringBuilder();
                            DirCmp.Append(Direccion.NDireccion.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CarAnt.Trim());
                            DirCmp.Append(Direccion.Numeracion);
                            DirCmp.Append(Direccion.CarPos.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CodComuna.Trim());
                            Direccion.DireccionCompleta = DirCmp.ToString();

                            Lista.Add(Direccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr=null;
            }
            return Lista;
        }
        public List<Direccion> ConsultaDireccionesEntregaTCC(int NroTCC)
        {
            List<Direccion> Lista = new List<Direccion>();
            IDataReader dr = null;
            try
            {
                dr = this.BDSigo.ExecuteReader("pr_s_SIGO_Consulta_Direccion_Tcc", NroTCC, "RM");
                while (dr.Read())
                {
                    Direccion Direccion = new Direccion();
                    if (dr["Nro_Error"] != DBNull.Value)
                    {
                        if (Converts.ConvertToInt(dr["Nro_Error"]) != 0)
                            break;
                        else
                        {
                            if (dr["CodDireccion"] != DBNull.Value)
                                Direccion.IndiceDireccion = Converts.ConvertToInt(dr["CodDireccion"]);
                            if (dr["NroTCC"] != DBNull.Value)
                                Direccion.NroTCC = Converts.ConvertToDecimal(dr["NroTCC"]);
                            if (dr["DireccionOt"] != DBNull.Value)
                                Direccion.NDireccion = Converts.ConvertToString(dr["DireccionOt"]);
                            if (dr["Numeracion"] != DBNull.Value)
                                Direccion.Numeracion = Converts.ConvertToString(dr["Numeracion"]);
                            if (dr["CarAnt"] != DBNull.Value)
                                Direccion.CarAnt = Converts.ConvertToString(dr["CarAnt"]);
                            if (dr["CarPos"] != DBNull.Value)
                                Direccion.CarPos = Converts.ConvertToString(dr["CarPos"]);
                            if (dr["Comuna"] != DBNull.Value)
                                Direccion.CodComuna = Converts.ConvertToString(dr["Comuna"]);
                            if (dr["CodCobertura"] != DBNull.Value)
                                Direccion.CodCobertura = Converts.ConvertToString(dr["CodCobertura"]);
                            if (dr["NombreEntrega"] != DBNull.Value)
                                Direccion.NombreContacto = Converts.ConvertToString(dr["NombreEntrega"]);
                            if (dr["Telefono"] != DBNull.Value)
                                Direccion.Telefono = Converts.ConvertToString(dr["Telefono"]);
                            if (dr["CodBlock"] != DBNull.Value)
                                Direccion.CodBlock = Converts.ConvertToDecimal(dr["CodBlock"]);
                            if (dr["IDDireccion"] != DBNull.Value)
                                Direccion.IdDireccion = Converts.ConvertToDecimal(dr["IDDireccion"]);
                            if (dr["Lat"] != DBNull.Value)
                                Direccion.Latitud = Converts.ConvertToDecimal(dr["Lat"]);
                            if (dr["lon"] != DBNull.Value)
                                Direccion.Longitud = Converts.ConvertToDecimal(dr["lon"]);

                            StringBuilder DirCmp = new StringBuilder();
                            DirCmp.Append(Direccion.NDireccion.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CarAnt.Trim());
                            DirCmp.Append(Direccion.Numeracion);
                            DirCmp.Append(Direccion.CarPos.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CodComuna.Trim());
                            Direccion.DireccionCompleta = DirCmp.ToString();

                            Lista.Add(Direccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
            }
            return Lista;
        }
        public List<string> ConsultaDireccionStr(string Dir)
        {
            List<string> Lista = new List<string>();
            IDataReader dr = null;
            try
            {
                dr = this.BDExp_Inhouse.ExecuteReader("pr_s_FormateaDireccion", Dir);
                while (dr.Read())
                {
                    Direccion Direccion = new Direccion();
                    if (dr["LpResultado"] != DBNull.Value)
                    {
                        if ((Converts.ConvertToInt(dr["LpResultado"]) != 20) && (Converts.ConvertToInt(dr["LpResultado"]) != 15))
                            break;
                        //LpGlsResultado
                        else
                        {
                            if (dr["lpNombreCalle"] != DBNull.Value)
                                Direccion.NDireccion = Converts.ConvertToString(dr["lpNombreCalle"]);
                            if (dr["LpNumeracion"] != DBNull.Value)
                                Direccion.Numeracion = Converts.ConvertToString(dr["LpNumeracion"]);
                            if (dr["LpCan"] != DBNull.Value)
                                Direccion.CarAnt = Converts.ConvertToString(dr["LpCan"]);
                            if (dr["LpCpn"] != DBNull.Value)
                                Direccion.CarPos = Converts.ConvertToString(dr["LpCpn"]);
                            if (dr["LpComplemento"] != DBNull.Value)
                                Direccion.Complemento = Converts.ConvertToString(dr["LpComplemento"]);
                            if (dr["LpComuna"] != DBNull.Value)
                                Direccion.CodComuna = Converts.ConvertToString(dr["LpComuna"]);

                            StringBuilder DirCmp = new StringBuilder();
                            DirCmp.Append(Direccion.NDireccion.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CarAnt.Trim());
                            DirCmp.Append(Direccion.Numeracion);
                            DirCmp.Append(Direccion.CarPos.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CodComuna.Trim());
                            if (Direccion.Complemento.Trim().Length > 0)
                            {
                                DirCmp.Append(", ");
                                DirCmp.Append(Direccion.Complemento.Trim());
                            }
                            Direccion.DireccionCompleta = DirCmp.ToString();
                            Lista.Add(Direccion.DireccionCompleta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
            }
            return Lista;
        }
        public Direccion ConsultaDireccionExacta(string Dir)
        {

            List<string> lDireccion = new List<string>();
            Direccion Direccion = new Direccion();
            try
            {
                DireccionesSSO.DireccionesSSO obtieneDirWs = new DireccionesSSO.DireccionesSSO();
                //obtieneDirWs.Url = ConfigurationManager.AppSettings["Url"].ToString();
                ValidarDireccionRequest req = new ValidarDireccionRequest();
                req.reqValidarDireccion = new ValidarDireccionRequestType();
                req.reqValidarDireccion.glsDireccion = Dir;
                ValidarDireccionResponse resp = obtieneDirWs.ValidarDireccionOp(req);
                int estado = Convert.ToInt32(resp.respValidarDireccion.estadoOperacion.codigoEstado);
                string desc = resp.respValidarDireccion.estadoOperacion.descripcionEstado;

                if (estado == 0)
                {
                    foreach (DireccionType dtype in resp.respValidarDireccion.listaDirecciones)
                    {
                        if ((dtype.codResultado != 15) && (dtype.codResultado != 20))
                        {
                            break;
                        }
                        else
                        {
                            if (dtype.codResultado == 20)
                            {
                                Direccion = null;
                            }
                            else
                            {
                                Direccion.NDireccion = dtype.nombreCalle;
                                Direccion.Numeracion = dtype.numeracion;
                                Direccion.CarAnt = dtype.numCaracterAnt;
                                Direccion.CarPos = dtype.numCaracterPost;
                                Direccion.Complemento = dtype.complemento;
                                Direccion.CodComuna = dtype.glsComuna;
                                Direccion.CodCobertura = dtype.codComuna;
                                Direccion.Segmento = dtype.numSegmento;
                                Direccion.CodBlock = dtype.numBlock;
                                Direccion.IdDireccion = dtype.numDireccion;
                                Direccion.Latitud = dtype.valLatitud;
                                Direccion.Longitud = dtype.valLongitud;

                                StringBuilder DirCmp = new StringBuilder();
                                DirCmp.Append(Direccion.NDireccion.Trim());
                                DirCmp.Append(", ");
                                DirCmp.Append(Direccion.CarAnt.Trim());
                                DirCmp.Append(Direccion.Numeracion);
                                DirCmp.Append(Direccion.CarPos.Trim());
                                DirCmp.Append(", ");
                                DirCmp.Append(Direccion.CodComuna.Trim());
                                if (Direccion.Complemento.Trim().Length > 0)
                                {
                                    DirCmp.Append(", ");
                                    DirCmp.Append(Direccion.Complemento.Trim());
                                }
                                Direccion.DireccionCompleta = DirCmp.ToString();
                            }
                        }
                    }
                }
                else { Direccion = null; }
            }
            catch (Exception ex) { throw ex; }
            return Direccion;
        }
        public List<Valorizacion> ObtieneValorizacionServicios(string CodCoberturaOri, string CodCoberturaDes, int Producto, decimal Peso, int Alto, int Ancho, int Largo, bool optionOfiDire)
        {
            
            List<Valorizacion> respuesta = new List<Valorizacion>();;
            IDataReader dr = null;
            try
            {
                if (optionOfiDire == true)
                {

                    dr = this.BDSigo.ExecuteReader("pr_s_ValorizaCourier_SU"
                    , CodCoberturaOri      //@ciudad_origen 	varchar(4)
                    , CodCoberturaDes      //,@ciudad_destino 	varchar(4)
                    , Producto             //,@cod_producto 		int
                    , Peso                 //,@peso				numeric(18,2)
                    , Alto                 //,@alto				int
                    , Ancho//,@ancho				int
                    , Largo//,@largo				int 	
                    , 0//,@IndHorario		int				= 0 )
                    , 0  //option oficina comercial
                    );
                }
                else
                {
                    dr = this.BDSigo.ExecuteReader("pr_s_ValorizaCourier_SU"
                        , CodCoberturaOri      //@ciudad_origen 	varchar(4)
                        , CodCoberturaDes      //,@ciudad_destino 	varchar(4)
                        , Producto             //,@cod_producto 		int
                        , Peso                 //,@peso				numeric(18,2)
                        , Alto                 //,@alto				int
                        , Ancho//,@ancho				int
                        , Largo//,@largo				int 	
                        , 0//,@IndHorario		int				= 0 )
                        , 0  //option oficina comercial
                        );
                }
                while (dr.Read())
                {
                    if (dr["COD_ERROR"] != DBNull.Value || dr["COD_ERROR"].Equals(0))
                    {
                        if (Converts.ConvertToInt(dr["COD_ERROR"]) != 0)
                        {
                            //if (dr["GLS_ERROR"] != DBNull.Value)
                            //    throw new exce Converts.ConvertToString(dr["GLS_ERROR"]);
                            break;
                        }
                        else
                        {
                            Valorizacion Val = new Valorizacion();
                            if (dr["COD_SERVICIO"] != DBNull.Value)
                                Val.Cod_servicio = Converts.ConvertToInt(dr["COD_SERVICIO"]);
                            if (dr["NOM_SERVICIO"] != DBNull.Value)
                                Val.Nom_servicio = Converts.ConvertToString(dr["NOM_SERVICIO"]);
                            if (dr["COD_PRODUCTO"] != DBNull.Value)
                                Val.Cod_producto = Converts.ConvertToInt(dr["COD_PRODUCTO"]);
                            if (dr["VALOR_NORMAL"] != DBNull.Value)
                                Val.Valor_normal = Converts.ConvertToDecimal(dr["VALOR_NORMAL"]);
                            if (dr["PORCENTAJE_SERVICIO"] != DBNull.Value)
                                Val.Porcentaje_servicio = Converts.ConvertToDecimal(dr["PORCENTAJE_SERVICIO"]);
                            if (dr["TASA_ORIGEN"] != DBNull.Value)
                                Val.Tasa_origen = Converts.ConvertToDecimal(dr["TASA_ORIGEN"]);
                            if (dr["TASA_DESTINO"] != DBNull.Value)
                                Val.Tasa_destino = Converts.ConvertToDecimal(dr["TASA_DESTINO"]);
                            if (dr["TIPO_TARIFA"] != DBNull.Value)
                                Val.Tipo_tarifa = Converts.ConvertToInt(dr["TIPO_TARIFA"]);
                            if (dr["VALOR"] != DBNull.Value)
                                Val.Valor = Converts.ConvertToDecimal(dr["VALOR"]);
                            if (dr["INDPESOVOL"] != DBNull.Value)
                                Val.IndPesoVol = Converts.ConvertToInt(dr["INDPESOVOL"]);
                            if (dr["PESO_CALCULO"] != DBNull.Value)
                                Val.Peso_calculo = Converts.ConvertToDecimal(dr["PESO_CALCULO"]);
                            if (dr["GLS_ENTREGA"] != DBNull.Value)
                                Val.Gls_entrega = Converts.ConvertToString(dr["GLS_ENTREGA"]);
                            respuesta.Add(Val);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally{dr.Close();}

            return respuesta;
        }


        public List<ulong> RegistraServicioUrbano(ServicioUrbano Servicio, bool OptionOfiDirec)
        {
            List<ulong> Resultado = new List<ulong>();
            IDataReader dr = null;
            try
            {
                if (OptionOfiDirec == true)
                {
                    Servicio.DirRemitente.TipoAdmisionEntrega = 1;
                }
                else
                {
                    Servicio.DirRemitente.TipoAdmisionEntrega = 0;
                }
                dr = this.BDSigo.ExecuteReader("pr_i_SISU_OT",
                        Servicio.TipoServicio,//@nroServicio              INT
                        Servicio.Producto.Cod_producto,//@tipoProducto             INT
                        Servicio.DirRemitente.NombreContacto,//@nombreRemitente          VARCHAR(200)
                        Servicio.DirRemitente.Mail,//@correoRemitente          VARCHAR(200)
                        Servicio.DirRemitente.Telefono,//@telefonoRemitente        VARCHAR(15)

                        Servicio.DirRemitente.CodComuna,//@glsComunaOrigen          VARCHAR(200)
                        Servicio.DirRemitente.NDireccion,//@nomCalleOrigen           VARCHAR(100)
                        Servicio.DirRemitente.Numeracion,//@numCalleOrigen           INT
                        Servicio.DirRemitente.CarAnt,//@canOrigen                CHAR(4)
                        Servicio.DirRemitente.CarPos,//@cpnOrigen                CHAR(4)
                        
                        Servicio.DirRemitente.Latitud,//@latitudOrigen            NUMERIC(11,8)
                        Servicio.DirRemitente.Longitud,//@longitudOrigen           NUMERIC(11,8)
                        Servicio.DirDestino.NombreContacto,//@nombreDestinatario       VARCHAR(200)
                        Servicio.DirDestino.Mail,//@correoDestinatario       VARCHAR(200)
                        Servicio.DirDestino.Telefono,//@telefonoDestinatario     VARCHAR(15)
                        
                        Servicio.DirDestino.CodComuna,//@glsComunaDestino         VARCHAR(200)
                        Servicio.DirDestino.NDireccion,//@nomCalleDestino          VARCHAR(100)
                        Servicio.DirDestino.Numeracion,//@numCalleDestino          INT
                        Servicio.DirDestino.CarAnt,//@canDestino               CHAR(4)                        
                        Servicio.DirDestino.CarPos,//@cpnDestino               CHAR(4)
                        
                        Servicio.DirDestino.Latitud,//@latitudDestino           NUMERIC(11,8)
                        Servicio.DirDestino.Longitud,//@longitudDestino          NUMERIC(11,8)
                        Servicio.NroTCC,//@nroTCC                   INT
                        Servicio.ValorServicio,//@mtoServicio              INT
                        DateTime.Now,//@fechaCreacion            DATETIME
                        
                        1,// ContextoUsuario.UsuarioRut,//@rutUsCreacion            INT
                        Servicio.IP,//@ipCreacion               VARCHAR(20)
                        Servicio.DimPeso,//@PesoOT                   FLOAT
                        Servicio.DimLargo,//@LargoPza                 INT    
                        Servicio.DimAncho,//@AnchoPza                 INT    
                        
                        Servicio.DimAlto,//@AltoPza                  INT
                        Servicio.DirRemitente.CodBlock,//@Id_Block_Origen          NUMERIC(12)
                        Servicio.DirRemitente.IdDireccion,//@Id_Direccion_Origen      VARCHAR(50)  
                        Servicio.DirDestino.CodBlock,//@Id_Block_Destino         NUMERIC(12)
                        Servicio.DirDestino.IdDireccion,//@Id_Direccion_Destino     VARCHAR(50)
                        
                        Servicio.ComplementoRemitente,// @complementoOrigen VARCHAR(50)
                        Servicio.ComplementoDestino, // @complementoDestino VARCHAR(20)
                        Servicio.DirRemitente.TipoAdmisionEntrega // jcrh @TipoAdmisionEntrega INT
                        );

                if (dr.Read())
                {

                    if (dr["NRO_ERROR"] != DBNull.Value)
                    {
                        if (Converts.ConvertToInt(dr["NRO_ERROR"]) == 0)
                        {
                            if (dr["NRO_OT"] != DBNull.Value)
                                Resultado.Add(Convert.ToUInt64(dr["NRO_OT"]));
                                Servicio.DirRemitente.NroTCC = Convert.ToUInt64(dr["NRO_OT"]);
                            if (dr["NRO_RETIRO"] != DBNull.Value)
                                Resultado.Add(Convert.ToUInt64(dr["NRO_RETIRO"]));
                        }
                        else
                            throw new Exception(Converts.ConvertToString((dr["MSG_ERROR"] != DBNull.Value) ? dr["MSG_ERROR"] : "Error SP pr_i_SISU_OT"));
                    }
                }


                //jcrh envio correo

                dr = this.BDSso.ExecuteReader("pr_i_sso_enviar_notificacion_sisu",
                        Servicio.DirRemitente.Mail,                     //@GlsCorreoRemitente		VARCHAR(100)
                        Servicio.DirRemitente.NombreContacto,           //@GlsNomRemitente          VARCHAR(300)
                        Servicio.DirRemitente.NDireccion + " " + Servicio.DirRemitente.Numeracion     + ", " + Servicio.DirRemitente.CodComuna,

                        Servicio.DirDestino.Mail,                       //@GlsCorreoDestinatario    VARCHAR(150)
                        Servicio.DirDestino.NombreContacto,             //@GlsNomDestinatario       VARCHAR(300)
                        Servicio.DirDestino.NDireccion + " " + Servicio.DirDestino.Numeracion + ", " + Servicio.DirDestino.CodComuna,
                        Servicio.DirRemitente.NroTCC                    //NroOT
                        );

                //fin jcrh envio correo

            }
            catch (Exception ex) { throw ex; }
            finally { dr.Close(); }
            return Resultado;
        }
        public List<Producto> ObtenerServiciosUrbanos()
        {
            List<Producto> Lista = new List<Producto>();
            IDataReader dr = null;
            try
            {
                dr = this.BDSigo.ExecuteReader("pr_s_SIGO_Busca_Productos",1 );
                while (dr.Read())
                {
                    Producto atach = new Producto();
                    if (dr["cod_error"] != DBNull.Value)
                    {
                        if (Converts.ConvertToInt(dr["cod_error"]) != 0)
                            throw new Exception(Converts.ConvertToString(dr["gls_error"]));
                        else
                        {
                            if (dr["cod_producto"] != DBNull.Value)
                                atach.Cod_producto = Converts.ConvertToInt(dr["cod_producto"]);
                            if (dr["gls_producto"] != DBNull.Value)
                                atach.Gls_producto = Converts.ConvertToString(dr["gls_producto"]);
                            if (dr["Peso_Min"] != DBNull.Value)
                                atach.Peso_Min = Converts.ConvertToDecimal(dr["Peso_Min"]); 
                            if (dr["Peso_Max"] != DBNull.Value)
                                atach.Peso_Max = Converts.ConvertToDecimal(dr["Peso_Max"]);
                            if (dr["Dimension_Min"] != DBNull.Value)
                                atach.Dimension_Min = Converts.ConvertToDecimal(dr["Dimension_Min"]);
                            if (dr["Dimension_Max"] != DBNull.Value)
                                atach.Dimension_Max = Converts.ConvertToDecimal(dr["Dimension_Max"]);

                            Lista.Add(atach);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally{dr.Close();}
            return Lista;
        }
        public List<string> ObtieneDireccionesWS(string dir)
        {
            List<string> lDireccion = new List<string>();
            Direccion Direccion = new Direccion();
            try
            {
                DireccionesSSO.DireccionesSSO obtieneDirWs = new DireccionesSSO.DireccionesSSO();
                //obtieneDirWs.Url = ConfigurationManager.AppSettings["Url"].ToString();
                ValidarDireccionRequest req = new ValidarDireccionRequest();
                req.reqValidarDireccion = new ValidarDireccionRequestType();
                req.reqValidarDireccion.glsDireccion = dir;
                ValidarDireccionResponse resp = obtieneDirWs.ValidarDireccionOp(req);
                int estado = Convert.ToInt32(resp.respValidarDireccion.estadoOperacion.codigoEstado);
                string desc = resp.respValidarDireccion.estadoOperacion.descripcionEstado;

                if (resp.respValidarDireccion.listaDirecciones != null)
                {
                    foreach (DireccionType dtype in resp.respValidarDireccion.listaDirecciones)
                    {
                        if (estado == 0)
                        {
                            Direccion.NDireccion = dtype.nombreCalle;
                            Direccion.Numeracion = dtype.numeracion;
                            Direccion.CarAnt = dtype.numCaracterAnt;
                            Direccion.CarPos = dtype.numCaracterPost;
                            Direccion.Complemento = dtype.complemento;
                            Direccion.CodComuna = dtype.glsComuna;

                            StringBuilder DirCmp = new StringBuilder();
                            DirCmp.Append(Direccion.NDireccion.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CarAnt.Trim());
                            DirCmp.Append(Direccion.Numeracion);
                            DirCmp.Append(Direccion.CarPos.Trim());
                            DirCmp.Append(", ");
                            DirCmp.Append(Direccion.CodComuna.Trim());
                            if (Direccion.Complemento.Trim().Length > 0)
                            {
                                DirCmp.Append(", ");
                                DirCmp.Append(Direccion.Complemento.Trim());
                            }
                            Direccion.DireccionCompleta = DirCmp.ToString();
                            lDireccion.Add(Direccion.DireccionCompleta);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return lDireccion;
        }

        // jcrh opcion 1

        public List<Coberturas> CargaCoberturasOfiComercial()
        {
            List<Coberturas> Respuesta = new List<Coberturas>(); 
            IDataReader dr = null;
            try
            {
               
                dr = this.BDSigo.ExecuteReader("pr_s_Coberturas", 1, "", 0, 0, 0);
                while (dr.Read())
                {
                    Coberturas atach = new Coberturas();
                    if (dr["cod_error"] != DBNull.Value)
                    {
                        if (Converts.ConvertToInt(dr["cod_error"]) != 0)
                            throw new Exception(Converts.ConvertToString(dr["gls_error"]));
                        else
                        {
                            if (dr["CodCobertura"] != DBNull.Value)
                                atach.CodCobertura = Converts.ConvertToString(dr["CodCobertura"]);
                            if (dr["Cobertura"] != DBNull.Value)
                                atach.Cobertura = Converts.ConvertToString(dr["Cobertura"]);


                            Respuesta.Add(atach);
                        }
                    }
                }
            }
                catch (Exception ex) { throw ex; }
                finally { dr.Close(); }
                return Respuesta ;
        }


        // jcrh opcion 2
        public List<Coberturas> CargaOfiComerciales(string Dato)           
        {
            List<Coberturas> Respuesta = new List<Coberturas>();
            IDataReader dr = null;
            try
            {
                dr = this.BDSigo.ExecuteReader("pr_s_Coberturas", 2, Dato, 0, 0, 0);
                while (dr.Read())
                {
                    Coberturas atach = new Coberturas();
                    if (dr["cod_error"] != DBNull.Value)
                    {
                        if (Converts.ConvertToInt(dr["cod_error"]) != 0)
                            throw new Exception(Converts.ConvertToString(dr["gls_error"]));
                        else
                        {
                            if (dr["CodUnidad"] != DBNull.Value)
                                atach.CodUnidad = Converts.ConvertToString(dr["CodUnidad"]);
                            if (dr["NombreUnidad"] != DBNull.Value)
                                atach.NombreUnidad = Converts.ConvertToString(dr["NombreUnidad"]);

                            Respuesta.Add(atach);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { dr.Close(); }
            return Respuesta;
        }

        public List<Coberturas> CargaDireccionOfCom(string Dato)
        {
            List<Coberturas> Respuesta = new List<Coberturas>();
            IDataReader dr = null;
            try
            {
                dr = this.BDSigo.ExecuteReader("pr_s_Coberturas", 3, "", Dato, 0, 0);


                if (dr.Read())
                {
                    Coberturas atach = new Coberturas();
                    if (dr["cod_error"] != DBNull.Value)
                    {
                        if (Converts.ConvertToInt(dr["cod_error"]) == 0)
                        {
                            if (dr["Direccion"] != DBNull.Value)
                                
                            atach.Direccion  = Converts.ConvertToString(dr["Direccion"]);
                            Respuesta.Add(atach);
                        }
                        else
                            throw new Exception(Converts.ConvertToString((dr["MSG_ERROR"] != DBNull.Value) ? dr["MSG_ERROR"] : "Error SP pr_s_Coberturas"));
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { dr.Close(); }
            return Respuesta;
        }
        

        #endregion Public Methods

    }
}
