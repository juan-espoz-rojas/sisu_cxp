using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Objects;
using Infraestructura.Exceptions;
using Datos.SISU;
using System.Configuration;

namespace Negocio.SISU
{

    public class BIngresoServUrb
    {
        DIngresoServUrb DIngServ = new DIngresoServUrb();

        public List<Direccion> ConsultaDireccionesEntregaTCC(int TCC)
        {
            List<Direccion> Lista = new List<Direccion>();
            try
            {
                Lista = DIngServ.ConsultaDireccionesEntregaTCC(TCC);
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
        public List<Direccion> ConsultaDireccionesRetiroTCC(int TCC)
        {
            List<Direccion> Lista = new List<Direccion>();
            try
            {
                Lista = DIngServ.ConsultaDireccionesRetiroTCC(TCC);
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
        public Direccion ConsultaDireccionExacta(string direccion)
        {
            Direccion respuesta = null;
            try
            {
                respuesta = DIngServ.ConsultaDireccionExacta(direccion);
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
        public Direccion ProcesarDireccion(string direccion)
        {
            Direccion respuesta = null;
            try
            {
                respuesta = ConsultaDireccionExacta(FormateaDireccion(direccion));
                if (respuesta == null)
                {
                    throw new ExceptionFuncional("No ha proporcionado una dirección exacta, favor reingresar.");
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
            return respuesta;
        }
        public List<string> ConsultaDireccionStr(string direccion)
        {
            List<string> Lista = new List<string>();
            try
            {
                Lista = DIngServ.ConsultaDireccionStr(direccion);
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
        public List<Valorizacion> ObtieneValorizacionServicios(string CodCoberturaOri, string CodCoberturaDes, int Producto, decimal Peso, int Alto, int Ancho, int Largo)
        {
            List<Valorizacion> respuesta = null;
            try
            {
                respuesta = DIngServ.ObtieneValorizacionServicios(CodCoberturaOri, CodCoberturaDes, Producto, Peso, Alto, Ancho, Largo);
                if (respuesta.Count == 0)
                    throw new ExceptionFuncional("En estos momentos, no existen servicios disponibles para estas direcciones.");
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
        public List<ulong> RegistraServicioUrbano(ServicioUrbano Servicio)
        {
            List<ulong> respuesta = new List<ulong>();
            try
            {
                respuesta = DIngServ.RegistraServicioUrbano(Servicio);
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
        private string FormateaDireccion(string direccion)
        {
            string[] dir = direccion.Split(',');
            string nuevadire = string.Empty;
            for (int i = 0; i < dir.Count(); i++)
            {
                nuevadire += (dir[i].Trim() + ",");
            }
            return nuevadire;
        }
        public void VerificarDimensiones(Producto Producto, int largo, int ancho, int alto, decimal peso)
        {
            try
            {
                //PESO
                if (Producto.Peso_Max < peso)
                    throw new ExceptionFuncional("El peso no puede superar los " + decimal.Round(Producto.Peso_Max, 2).ToString() + " kg.");
                if (Producto.Peso_Min > peso)
                    throw new ExceptionFuncional("El peso no puede ser menor a " + decimal.Round(Producto.Peso_Min, 2).ToString() + " kg.");
                //LARGO
                if (Producto.Dimension_Max < largo)
                    throw new ExceptionFuncional("El largo no puede superar los " + decimal.Round(Producto.Dimension_Max, 2).ToString() + " cm.");
                if (Producto.Dimension_Min > largo)
                    throw new ExceptionFuncional("El largo no puede ser menor a " + decimal.Round(Producto.Dimension_Min, 2).ToString() + " cm.");
                //ANCHO
                if (Producto.Dimension_Max < ancho)
                    throw new ExceptionFuncional("El ancho no puede superar los " + decimal.Round(Producto.Dimension_Max, 2).ToString() + " cm.");
                if (Producto.Dimension_Min > ancho)
                    throw new ExceptionFuncional("El ancho no puede ser menor a " + decimal.Round(Producto.Dimension_Min, 2).ToString() + " cm.");
                //ALTO
                if (Producto.Dimension_Max < alto)
                    throw new ExceptionFuncional("El alto no puede superar los " + decimal.Round(Producto.Dimension_Max, 2).ToString() + " cm.");
                if (Producto.Dimension_Min > alto)
                    throw new ExceptionFuncional("El alto no puede ser menor a " + decimal.Round(Producto.Dimension_Min, 2).ToString() + " cm.");
            }
            catch (ExceptionFuncional ef)
            {
                throw ef;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerServiciosUrbanos()
        {
            List<Producto> Lista = new List<Producto>();
            try
            {
                Lista = DIngServ.ObtenerServiciosUrbanos();
            }
            catch (ExceptionFuncional ef){throw ef;}
            catch (Exception ex){throw ex;}
            return Lista;
        }

        public List<string> ObtieneDireccionesWS(string dir)
        {
            List<string> lDirecciones = new List<string>();
            try
            {

                lDirecciones = DIngServ.ObtieneDireccionesWS(dir);
                if (lDirecciones == null || lDirecciones.Count == 0)
                {
                    //resultado = new 
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
            return lDirecciones;
        }
    }
}
