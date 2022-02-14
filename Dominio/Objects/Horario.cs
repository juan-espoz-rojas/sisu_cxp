using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Objects
{
    [Serializable]
    public class Horario
    {
        
        private int _Hora;
        private int _Minutos;

        public int Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }
        public int Minutos
        {
            get { return _Minutos; }
            set { _Minutos = value; }
        }
    }
}
