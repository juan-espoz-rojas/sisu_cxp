using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Objects
{
    [Serializable]
    public class Direccion
    {
        public Direccion() { }
        
        int _IndiceDireccion = default(int);
        decimal _NroTCC = default(decimal);
        string _Direccion = string.Empty;
        int _Numeracion = default(int);
        string _Complemento = string.Empty;
        string _CarAnt = string.Empty;
        string _CarPos = string.Empty;
        string _CodComuna = string.Empty;
        string _NombreContacto = string.Empty;
        string _Telefono = string.Empty;
        string _LugarRetiro = string.Empty;
        int _CodEstado = default(int);
        decimal _Latitud = default(decimal);
        decimal _Longitud = default(decimal);
        decimal _IdDireccion = default(decimal);
        decimal _CodBlock = default(decimal);
        string _DireccionCompleta = string.Empty;
        decimal _Segmento = default(decimal);
        string _Mail = string.Empty;
        string _CodCobertura = string.Empty;

        public string CodCobertura
        {
            get { return _CodCobertura; }
            set { _CodCobertura = value; }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }
        public decimal Segmento
        {
            get { return _Segmento; }
            set { _Segmento = value; }
        }
        public string DireccionCompleta
        {
            get { return _DireccionCompleta; }
            set { _DireccionCompleta = value; }
        }
        public int IndiceDireccion
        {
            get { return _IndiceDireccion; }
            set { _IndiceDireccion = value; }
        }
        public decimal NroTCC
        {
            get { return _NroTCC; }
            set { _NroTCC = value; }
        }
        public string NDireccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public int Numeracion
        {
            get { return _Numeracion; }
            set { _Numeracion = value; }
        }
        public string CarAnt
        {
            get { return _CarAnt; }
            set { _CarAnt = value; }
        }
        public string CarPos
        {
            get { return _CarPos; }
            set { _CarPos = value; }
        }
        public string CodComuna
        {
            get { return _CodComuna; }
            set { _CodComuna = value; }
        }
        public string NombreContacto
        {
            get { return _NombreContacto; }
            set { _NombreContacto = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string LugarRetiro
        {
            get { return _LugarRetiro; }
            set { _LugarRetiro = value; }
        }
        public int CodEstado
        {
            get { return _CodEstado; }
            set { _CodEstado = value; }
        }
        public decimal Latitud
        {
            get { return _Latitud; }
            set { _Latitud = value; }
        }
        public decimal Longitud
        {
            get { return _Longitud; }
            set { _Longitud = value; }
        }
        public decimal IdDireccion
        {
            get { return _IdDireccion; }
            set { _IdDireccion = value; }
        }
        public decimal CodBlock
        {
            get { return _CodBlock; }
            set { _CodBlock = value; }
        }

    }
}
