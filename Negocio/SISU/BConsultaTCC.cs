using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.SISU;
using Dominio.Objects;
using Infraestructura.Exceptions;

namespace Negocio.SISU
{
    public class BConsultaTCC
    {
        DConsultaTCC DTCC = new DConsultaTCC();

        public List<TCC> ConsultaTccPorRut(int Rut)
        {
            List<TCC> Lista = new List<TCC>();
            try
            {
                Lista = DTCC.ConsultaTccPorRut(Rut);

                foreach (TCC TCC in Lista)
                {
                    switch (TCC.Cod_estado_tarjeta)
                    {
                        case 1:
                            TCC.Glosa_Estado = "Vigente";
                            break;
                        case 2:
                            TCC.Glosa_Estado = "Suspendido";
                            break;
                        case 3:
                            TCC.Glosa_Estado = "No Vigente";
                            break;
                        case 4:
                            TCC.Glosa_Estado = "Castigado";
                            break;
                    }
                }
            }
            catch (ExceptionFuncional ef)
            {
                throw ef;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public TCC ConsultaTccPorNumero(int NroTcc)
        {
            TCC respuesta = new TCC();
            try
            {
                respuesta = DTCC.ConsultaTccPorNumero(NroTcc);
                switch (respuesta.Cod_estado_tarjeta)
                {
                    case 1:
                        respuesta.Glosa_Estado = "Vigente";
                        break;
                    case 2:
                        respuesta.Glosa_Estado = "Suspendido";
                        break;
                    case 3:
                        respuesta.Glosa_Estado = "No Vigente";
                        break;
                    case 4:
                        respuesta.Glosa_Estado = "Castigado";
                        break;
                }
            }
            catch (ExceptionFuncional ef)
            {
                throw ef;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (respuesta == null) ? new TCC() : respuesta;
        }
        public bool ValidaTCCVigente(int NroTcc)
        {
            bool respuesta = false;
            try
            {              

                respuesta = (DTCC.ConsultaTccPorNumero(NroTcc) != null);
                if (!respuesta)
                    throw new ExceptionFuncional("La TCC no se encuentra vigente");

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
