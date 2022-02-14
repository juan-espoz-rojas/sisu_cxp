using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Objects
{
    [Serializable]
    public class TCC
    {
        private int _rut_cliente;
        private decimal _num_tarjeta;
        private int _cod_sucursal_env;
        private int _rut_ejecutivo;
        private string _gls_nombre_tarjeta;
        private string _gls_atencion_a;
        private int _cod_estado_tarjeta;
        private DateTime _fec_estado;
        private int _cod_causal_novigencia;
        private decimal _num_tarjeta_cobro;
        private int _ind_imprime_anexo;
        private int _ind_cobro_anexo;
        private int _num_valijas;
        private string _usr_ingresado_por;
        private DateTime _fec_ingreso;
        private int _cod_estado_registro;
        private int _ind_imprime_ot_en_linea;
        private int _cod_tolerancia;
        private int _ind_direccion_normalizada;
        private int _ind_area_negocio;
        private string _gls_procedimiento_recepcion;
        private int _ind_requiere_pod;
        private int _ind_requiere_ref_multiple;
        private string _gls_imagen_banner;
        private int _ind_usa_ot_externa;
        private int _cod_criterio_ot_en_linea;
        private int _ind_envio_mail;
        private string _gls_envio_mail;
        private DateTime _fec_envio_mail;
        private bool _sw_referencia_multiple;
        private int _cod_tipo_ot_masiva;
        private string _Glosa_Estado;
        private string _Glosa_Giro;
        private int _Hora;


        public string Glosa_Giro
        {
            get { return _Glosa_Giro; }
            set { _Glosa_Giro = value; }
        }
        public int Rut_cliente
        {
            get { return _rut_cliente; }
            set { _rut_cliente = value; }
        }
        public decimal Num_tarjeta
        {
            get { return _num_tarjeta; }
            set { _num_tarjeta = value; }
        }
        public int Cod_sucursal_env
        {
            get { return _cod_sucursal_env; }
            set { _cod_sucursal_env = value; }
        }
        public int Rut_ejecutivo
        {
            get { return _rut_ejecutivo; }
            set { _rut_ejecutivo = value; }
        }
        public string Gls_nombre_tarjeta
        {
            get { return _gls_nombre_tarjeta; }
            set { _gls_nombre_tarjeta = value; }
        }
        public string Gls_atencion_a
        {
            get { return _gls_atencion_a; }
            set { _gls_atencion_a = value; }
        }
        public int Cod_estado_tarjeta
        {
            get { return _cod_estado_tarjeta; }
            set { _cod_estado_tarjeta = value; }
        }
        public DateTime Fec_estado
        {
            get { return _fec_estado; }
            set { _fec_estado = value; }
        }
        public int Cod_causal_novigencia
        {
            get { return _cod_causal_novigencia; }
            set { _cod_causal_novigencia = value; }
        }
        public decimal Num_tarjeta_cobro
        {
            get { return _num_tarjeta_cobro; }
            set { _num_tarjeta_cobro = value; }
        }
        public int Ind_imprime_anexo
        {
            get { return _ind_imprime_anexo; }
            set { _ind_imprime_anexo = value; }
        }
        public int Ind_cobro_anexo
        {
            get { return _ind_cobro_anexo; }
            set { _ind_cobro_anexo = value; }
        }
        public int Num_valijas
        {
            get { return _num_valijas; }
            set { _num_valijas = value; }
        }
        public string Usr_ingresado_por
        {
            get { return _usr_ingresado_por; }
            set { _usr_ingresado_por = value; }
        }
        public DateTime Fec_ingreso
        {
            get { return _fec_ingreso; }
            set { _fec_ingreso = value; }
        }
        public int Cod_estado_registro
        {
            get { return _cod_estado_registro; }
            set { _cod_estado_registro = value; }
        }
        public int Ind_imprime_ot_en_linea
        {
            get { return _ind_imprime_ot_en_linea; }
            set { _ind_imprime_ot_en_linea = value; }
        }
        public int Cod_tolerancia
        {
            get { return _cod_tolerancia; }
            set { _cod_tolerancia = value; }
        }
        public int Ind_direccion_normalizada
        {
            get { return _ind_direccion_normalizada; }
            set { _ind_direccion_normalizada = value; }
        }
        public int Ind_area_negocio
        {
            get { return _ind_area_negocio; }
            set { _ind_area_negocio = value; }
        }
        public string Gls_procedimiento_recepcion
        {
            get { return _gls_procedimiento_recepcion; }
            set { _gls_procedimiento_recepcion = value; }
        }
        public int Ind_requiere_pod
        {
            get { return _ind_requiere_pod; }
            set { _ind_requiere_pod = value; }
        }
        public int Ind_requiere_ref_multiple
        {
            get { return _ind_requiere_ref_multiple; }
            set { _ind_requiere_ref_multiple = value; }
        }
        public string Gls_imagen_banner
        {
            get { return _gls_imagen_banner; }
            set { _gls_imagen_banner = value; }
        }
        public int Ind_usa_ot_externa
        {
            get { return _ind_usa_ot_externa; }
            set { _ind_usa_ot_externa = value; }
        }
        public int Cod_criterio_ot_en_linea
        {
            get { return _cod_criterio_ot_en_linea; }
            set { _cod_criterio_ot_en_linea = value; }
        }
        public int Ind_envio_mail
        {
            get { return _ind_envio_mail; }
            set { _ind_envio_mail = value; }
        }
        public string Gls_envio_mail
        {
            get { return _gls_envio_mail; }
            set { _gls_envio_mail = value; }
        }
        public DateTime Fec_envio_mail
        {
            get { return _fec_envio_mail; }
            set { _fec_envio_mail = value; }
        }
        public bool Sw_referencia_multiple
        {
            get { return _sw_referencia_multiple; }
            set { _sw_referencia_multiple = value; }
        }
        public int Cod_tipo_ot_masiva
        {
            get { return _cod_tipo_ot_masiva; }
            set { _cod_tipo_ot_masiva = value; }
        }
        public string Glosa_Estado
        {
            get { return _Glosa_Estado; }
            set { _Glosa_Estado = value; }
        }
        public int Hr
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

    }
}
