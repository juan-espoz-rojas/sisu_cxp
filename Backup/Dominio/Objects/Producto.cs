using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Objects
{
    [Serializable]
    public class Producto
    {
        public Producto() { }

        int _cod_error = default(int);
        string _gls_error = string.Empty;
        int _cod_producto = default(int);
        string _gls_producto = string.Empty;
        decimal _Peso_Min = default(decimal);
        decimal _Peso_Max = default(decimal);
        decimal _Dimencion_Min = default(decimal);
        decimal _Dimension_Max = default(decimal);

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
        public int Cod_producto
        {
            get { return _cod_producto; }
            set { _cod_producto = value; }
        }
        public string Gls_producto
        {
            get { return _gls_producto; }
            set { _gls_producto = value; }
        }
        public decimal Peso_Min
        {
            get { return _Peso_Min; }
            set { _Peso_Min = value; }
        }
        public decimal Peso_Max
        {
            get { return _Peso_Max; }
            set { _Peso_Max = value; }
        }
        public decimal Dimension_Min
        {
            get { return _Dimencion_Min; }
            set { _Dimencion_Min = value; }
        }
        public decimal Dimension_Max
        {
            get { return _Dimension_Max; }
            set { _Dimension_Max = value; }
        }

    }
}
