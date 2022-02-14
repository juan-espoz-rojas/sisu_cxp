using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Objects
{
    [Serializable]
    public class Valorizacion
    {
        int _cod_servicio = default(int);
        string _nom_servicio = string.Empty;
        int _cod_producto = default(int);
        decimal _valor_normal = default(decimal);
        decimal _porcentaje_servicio = default(decimal);
        decimal _tasa_origen = default(decimal);
        decimal _tasa_destino = default(decimal);
        int _tipo_tarifa = default(int);
        int _cod_error = default(int);
        string _gls_error = string.Empty;
        decimal _valor = default(decimal);
        int _indPesoVol = default(int);
        decimal _peso_calculo = default(decimal);
        string _gls_entrega = string.Empty;

        public int Cod_servicio
        {
            get { return _cod_servicio; }
            set { _cod_servicio = value; }
        }
        public string Nom_servicio
        {
            get { return _nom_servicio; }
            set { _nom_servicio = value; }
        }
        public int Cod_producto
        {
            get { return _cod_producto; }
            set { _cod_producto = value; }
        }
        public decimal Valor_normal
        {
            get { return _valor_normal; }
            set { _valor_normal = value; }
        }
        public decimal Porcentaje_servicio
        {
            get { return _porcentaje_servicio; }
            set { _porcentaje_servicio = value; }
        }
        public decimal Tasa_origen
        {
            get { return _tasa_origen; }
            set { _tasa_origen = value; }
        }
        public decimal Tasa_destino
        {
            get { return _tasa_destino; }
            set { _tasa_destino = value; }
        }
        public int Tipo_tarifa
        {
            get { return _tipo_tarifa; }
            set { _tipo_tarifa = value; }
        }
        public int Cod_error
        {
            get { return _cod_error; }
            set { _cod_error = value; }
        }
        public string Gls_error
        {
            get { return _gls_error; }
            set { _gls_error = value; }
        }
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public int IndPesoVol
        {
            get { return _indPesoVol; }
            set { _indPesoVol = value; }
        }
        public decimal Peso_calculo
        {
            get { return _peso_calculo; }
            set { _peso_calculo = value; }
        }
        public string Gls_entrega
        {
            get { return _gls_entrega; }
            set { _gls_entrega = value; }
        }
    }
}
