using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Datos.General;
using System.Data.Common;
using Dominio.Objects;
using System.Data;
using Infraestructura;

namespace Datos.SISU
{
    public class DConsultaTCC
    {
        #region Private Members
        private Database BDSigo;
        private Database BDExp_Corp;
        private Database BDExp_Inhouse;
        private Database BDExp_Clientes;
        private Database BDSso;
        #endregion Private Members

        #region Constructors
        public DConsultaTCC()
        {
            SqlDatabase BDsig = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "SIGO"));
            SqlDatabase BDcorp = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "EXP_CORP"));
            SqlDatabase Bdinhouse = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "EXP_INHOUSE"));
            SqlDatabase BDclientes = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "EXP_CLIENTES"));
            SqlDatabase BDsso = new SqlDatabase(Registreria.ConstantesRegistry(Registreria.SISU, "SSO")); 
            this.BDSigo = BDsig;
            this.BDExp_Corp = BDcorp;
            this.BDExp_Inhouse = Bdinhouse;
            this.BDExp_Clientes = BDclientes;
            this.BDSso = BDsso;
        }
        #endregion Constructors

        #region Public Methods
        public TCC ConsultaTccPorNumero(int NroTCC)
        {
            TCC Tcc = null;
            IDataReader dr = null;
            try
            {
                dr = this.BDExp_Clientes.ExecuteReader("pr3c_s_busca_tcc_vigente", NroTCC);
                if (dr.Read())
                {

                    Tcc = new TCC();                    
                    if (dr["rut_cliente"] != DBNull.Value)
                        Tcc.Rut_cliente = Converts.ConvertToInt(dr["rut_cliente"]);
                    if (dr["num_tarjeta"] != DBNull.Value)
                        Tcc.Num_tarjeta = Converts.ConvertToDecimal(dr["num_tarjeta"]);
                    if (dr["rut_ejecutivo"] != DBNull.Value)
                        Tcc.Rut_ejecutivo = Converts.ConvertToInt(dr["rut_ejecutivo"]);
                    if (dr["gls_nombre_tarjeta"] != DBNull.Value)
                        Tcc.Gls_nombre_tarjeta = Converts.ConvertToString(dr["gls_nombre_tarjeta"]);
                    if (dr["gls_atencion_a"] != DBNull.Value)
                        Tcc.Gls_atencion_a = Converts.ConvertToString(dr["gls_atencion_a"]);
                    if (dr["cod_estado_tarjeta"] != DBNull.Value)
                        Tcc.Cod_estado_tarjeta = Converts.ConvertToInt(dr["cod_estado_tarjeta"]);
                    if (dr["fec_estado"] != DBNull.Value)
                        Tcc.Fec_estado = Converts.ConvertToDateTime(dr["fec_estado"]);
                    if (dr["cod_causal_novigencia"] != DBNull.Value)
                        Tcc.Cod_causal_novigencia = Converts.ConvertToInt(dr["cod_causal_novigencia"]);
                    if (dr["num_tarjeta_cobro"] != DBNull.Value)
                        Tcc.Num_tarjeta_cobro = Converts.ConvertToInt(dr["num_tarjeta_cobro"]);
                    if (dr["ind_imprime_anexo"] != DBNull.Value)
                        Tcc.Ind_imprime_anexo = Converts.ConvertToInt(dr["ind_imprime_anexo"]);
                    if (dr["ind_cobro_anexo"] != DBNull.Value)
                        Tcc.Ind_cobro_anexo = Converts.ConvertToInt(dr["ind_cobro_anexo"]);
                    if (dr["num_valijas"] != DBNull.Value)
                        Tcc.Num_valijas = Converts.ConvertToInt(dr["num_valijas"]);
                    if (dr["usr_ingresado_por"] != DBNull.Value)
                        Tcc.Usr_ingresado_por = Converts.ConvertToString(dr["usr_ingresado_por"]);
                    if (dr["fecha_ingreso"] != DBNull.Value)
                        Tcc.Fec_ingreso = Converts.ConvertToDateTime(dr["fecha_ingreso"]);
                    if (dr["cod_sucursal"] != DBNull.Value)
                        Tcc.Cod_sucursal_env = Converts.ConvertToInt(dr["cod_sucursal"]);
                    if (dr["num_valijas"] != DBNull.Value)
                        Tcc.Num_valijas = Converts.ConvertToInt(dr["num_valijas"]);
                    if (dr["cod_tolerancia"] != DBNull.Value)
                        Tcc.Cod_tolerancia = Converts.ConvertToInt(dr["cod_tolerancia"]);
                    if (dr["ind_direccion_normalizada"] != DBNull.Value)
                        Tcc.Ind_direccion_normalizada = Converts.ConvertToInt(dr["ind_direccion_normalizada"]);
                    if (dr["ind_area_negocio"] != DBNull.Value)
                        Tcc.Ind_area_negocio = Converts.ConvertToInt(dr["ind_area_negocio"]);
                    if (dr["cod_estado_registro"] != DBNull.Value)
                        Tcc.Cod_estado_registro = Converts.ConvertToInt(dr["cod_estado_registro"]);
                    if (dr["imprime_ot_en_linea"] != DBNull.Value)
                        Tcc.Ind_imprime_ot_en_linea = Converts.ConvertToInt(dr["imprime_ot_en_linea"]);
                    if (dr["ind_usa_ot_externa"] != DBNull.Value)
                        Tcc.Ind_usa_ot_externa = Converts.ConvertToInt(dr["ind_usa_ot_externa"]);
                    
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
            return Tcc;
        }
        public List<TCC> ConsultaTccPorRut(int Rut)
        {
            List<TCC> Lista = new List<TCC>();
            IDataReader dr = null;
            try
            {
                dr = this.BDExp_Clientes.ExecuteReader("pr3c_s_busca_tcc_vigente_rut", Rut);
                while (dr.Read())
                {
                    
                    TCC Tcc = new TCC();
                    if (dr["rut_cliente"] != DBNull.Value)
                        Tcc.Rut_cliente = Converts.ConvertToInt(dr["rut_cliente"]);
                    if (dr["num_tarjeta"] != DBNull.Value)
                        Tcc.Num_tarjeta = Converts.ConvertToDecimal(dr["num_tarjeta"]);
                    if (dr["rut_ejecutivo"] != DBNull.Value)
                        Tcc.Rut_ejecutivo = Converts.ConvertToInt(dr["rut_ejecutivo"]);
                    if (dr["gls_nombre_tarjeta"] != DBNull.Value)
                        Tcc.Gls_nombre_tarjeta = Converts.ConvertToString(dr["gls_nombre_tarjeta"]);
                    if (dr["gls_atencion_a"] != DBNull.Value)
                        Tcc.Gls_atencion_a = Converts.ConvertToString(dr["gls_atencion_a"]);
                    if (dr["cod_estado_tarjeta"] != DBNull.Value)
                        Tcc.Cod_estado_tarjeta = Converts.ConvertToInt(dr["cod_estado_tarjeta"]);
                    if (dr["fec_estado"] != DBNull.Value)
                        Tcc.Fec_estado = Converts.ConvertToDateTime(dr["fec_estado"]);
                    if (dr["cod_causal_novigencia"] != DBNull.Value)
                        Tcc.Cod_causal_novigencia = Converts.ConvertToInt(dr["cod_causal_novigencia"]);
                    if (dr["num_tarjeta_cobro"] != DBNull.Value)
                        Tcc.Num_tarjeta_cobro = Converts.ConvertToInt(dr["num_tarjeta_cobro"]);
                    if (dr["ind_imprime_anexo"] != DBNull.Value)
                        Tcc.Ind_imprime_anexo = Converts.ConvertToInt(dr["ind_imprime_anexo"]);
                    if (dr["ind_cobro_anexo"] != DBNull.Value)
                        Tcc.Ind_cobro_anexo = Converts.ConvertToInt(dr["ind_cobro_anexo"]);
                    if (dr["num_valijas"] != DBNull.Value)
                        Tcc.Num_valijas = Converts.ConvertToInt(dr["num_valijas"]);
                    if (dr["usr_ingresado_por"] != DBNull.Value)
                        Tcc.Usr_ingresado_por = Converts.ConvertToString(dr["usr_ingresado_por"]);
                    if (dr["fecha_ingreso"] != DBNull.Value)
                        Tcc.Fec_ingreso = Converts.ConvertToDateTime(dr["fecha_ingreso"]);
                    if (dr["cod_sucursal"] != DBNull.Value)
                        Tcc.Cod_sucursal_env = Converts.ConvertToInt(dr["cod_sucursal"]);
                    if (dr["num_valijas"] != DBNull.Value)
                        Tcc.Num_valijas = Converts.ConvertToInt(dr["num_valijas"]);
                    if (dr["cod_tolerancia"] != DBNull.Value)
                        Tcc.Cod_tolerancia = Converts.ConvertToInt(dr["cod_tolerancia"]);
                    if (dr["ind_direccion_normalizada"] != DBNull.Value)
                        Tcc.Ind_direccion_normalizada = Converts.ConvertToInt(dr["ind_direccion_normalizada"]);
                    if (dr["ind_area_negocio"] != DBNull.Value)
                        Tcc.Ind_area_negocio = Converts.ConvertToInt(dr["ind_area_negocio"]);
                    if (dr["cod_estado_registro"] != DBNull.Value)
                        Tcc.Cod_estado_registro = Converts.ConvertToInt(dr["cod_estado_registro"]);
                    if (dr["imprime_ot_en_linea"] != DBNull.Value)
                        Tcc.Ind_imprime_ot_en_linea = Converts.ConvertToInt(dr["imprime_ot_en_linea"]);
                    //if (dr["ind_usa_ot_externa"] != DBNull.Value)
                    //    Tcc.Ind_usa_ot_externa = Converts.ConvertToInt(dr["ind_usa_ot_externa"]);
                    //if (dr["gls_Giro"] != DBNull.Value)
                    //    Tcc.Glosa_Giro = Converts.ConvertToString(dr["gls_Giro"]);
                    Lista.Add(Tcc);
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
     
        #endregion Public Methods
    }
}
