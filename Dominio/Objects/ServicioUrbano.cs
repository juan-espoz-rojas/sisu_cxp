using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Objects
{
    [Serializable]
    public class ServicioUrbano
    {
        public ServicioUrbano() { }

        int _TipoServicio = default(int);
        decimal _DimPeso = default(decimal);
        int _DimLargo = default(int);
        int _DimAncho = default(int);
        int _DimAlto = default(int);
        decimal _ValorServicio = default(decimal);
        string _GlsServicio = string.Empty;
        Direccion _DirRemitente;
        Direccion _DirDestino;
        Producto _Producto;
        int _NroTCC = default(int);
        string _IP = string.Empty;
        string _ComplementoRemitente = string.Empty;
        string _ComplementoDestino = string.Empty;



        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        public int NroTCC
        {
            get { return _NroTCC; }
            set { _NroTCC = value; }
        }
        public int TipoServicio
        {
            get { return _TipoServicio; }
            set { _TipoServicio = value; }
        }
        public string GlsServicio
        {
            get { return _GlsServicio; }
            set { _GlsServicio = value; }
        }
        public decimal ValorServicio
        {
            get { return _ValorServicio; }
            set { _ValorServicio = value; }
        }
        public Direccion DirDestino
        {
            get { return _DirDestino; }
            set { _DirDestino = value; }
        }
        public Direccion DirRemitente
        {
            get { return _DirRemitente; }
            set { _DirRemitente = value; }
        }
        public Producto Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }
        public int DimAlto
        {
            get { return _DimAlto; }
            set { _DimAlto = value; }
        }
        public int DimAncho
        {
            get { return _DimAncho; }
            set { _DimAncho = value; }
        }
        public int DimLargo
        {
            get { return _DimLargo; }
            set { _DimLargo = value; }
        }
        public decimal DimPeso
        {
            get { return _DimPeso; }
            set { _DimPeso = value; }
        }
        public string ComplementoRemitente
        {
            get { return _ComplementoRemitente; }
            set { _ComplementoRemitente = value; }
        }
        public string ComplementoDestino
        {
            get { return _ComplementoDestino; }
            set { _ComplementoDestino = value; }
        }


    }
}
