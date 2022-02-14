using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Objects
{
    [Serializable]
    public class Coberturas
    {
        public Coberturas() { }

        string _CodCobertura = string.Empty;
        string _Cobertura = string.Empty;
        string _CodUnidad = string.Empty;
        string _NombreUnidad = string.Empty;
        string _Direccion = string.Empty;
            

        public string CodCobertura
        {
            get { return _CodCobertura; }
            set { _CodCobertura = value; }
        }
        public string Cobertura
        {
            get { return _Cobertura; }
            set { _Cobertura = value; }
        }

        public string CodUnidad
        {
            get { return _CodUnidad; }
            set { _CodUnidad = value; }
        }

        public string NombreUnidad
        {
            get { return _NombreUnidad; }
            set { _NombreUnidad = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

    }
}
