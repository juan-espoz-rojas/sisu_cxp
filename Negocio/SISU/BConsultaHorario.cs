using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.SISU;
using Dominio.Objects;
using Infraestructura.Exceptions;

namespace Negocio.SISU
{
    public class BConsultaHorario
    {
        DConsultaHorario DTCC = new DConsultaHorario();

  
        public Horario ConsultaHorarioPorNumero(int NroTcc)
        {
            Horario respuesta = new Horario();
            try
            {
                respuesta = DTCC.ConsultaHorarioPorNumero(NroTcc);
                return respuesta;
               
            }      
            catch (Exception ex)
            {
                throw ex;
            }          
        }
        public bool ValidaHorarioVigente(int NroTcc)
        {
            bool respuesta = false;
            try
            {              

                respuesta = (DTCC.ConsultaHorarioPorNumero(NroTcc) != null);
                
                if (!respuesta)
                    throw new ExceptionFuncional("Fuera de Horario");

            }
            catch (ExceptionFuncional ef)
            {
                throw ef;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }       

    }
}
