using System;
using System.Collections.Generic;
using System.Text;
//using System.Web.Security;
using System.Web;
using System.Globalization;

namespace Infraestructura
{
   public static class Converts
    {
        private const string mascaraSeparadorMilesYDecimal = "#,#0.00";
        private const string mascaraSeparadorMiles = "#,#";

        /// <summary>
        /// Valida AlfaNúmerico si es igual a 0
        /// </summary>
        /// <param name="objeto">Objeto a ser validado</param>
        /// <returns>booleano/returns>
        public static bool ValidarAlfaNumerico(string objeto)
        {
            bool valid = true;
            string Cadena = objeto.Trim().ToString();
            for (int i = 0; i < Cadena.Length; i++)
            {
                if (Cadena.Substring(i, 1) == "0")
                {
                    valid = false;
                }
                else  return valid = true;
            }
            return valid;
        }
        private static object FiltrarPuntosString(object objeto)
        {
            if (objeto.GetType() == typeof(string))
            {
                string resultado = (string)objeto;
                return resultado.Replace(".", "");
            }
            return objeto;
        }

        /// <summary>
        /// Convierte el objeto a string
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a string</returns>
        public static string ConvertToString(object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return null;
                else
                    return Convert.ToString(objeto);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte un valor Numérico a un string con dos decimales
        /// </summary>
        /// <param name="objeto">El objeto a convertir</param>
        /// <returns>Un valor numérico con  dos decimales</returns>
        public static string ConvertToStringDosDecimales(object objeto)
        {
            try
            {
                if (objeto == null) objeto = new decimal(0);
                if (objeto is decimal || objeto is Decimal)
                {
                    Decimal objDec = (Decimal)objeto;
                    objDec = Math.Round(objDec, 2);
                    return objDec.ToString();
                }
                else
                    return Convert.ToString(objeto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /* 17-01-2009 - Javier Stickar
        * 
        * Sprint: 2 
        *  
        * 
        */
        /// <summary>
        /// Convierte un valor Numérico a un string con  separador de miles
        /// </summary>
        /// <param name="objeto">El objeto a convertir</param>
        /// <returns>Un valor numérico con  separador de miles</returns>
        public static string ConvertToStringSeparadorMiles(object objeto)
        {
            try
            {
                if (objeto == null) return null;
                if (objeto is int || objeto is Int16 || objeto is Int32 || objeto is Int64)
                {
                    Int64 objInt = Convert.ToInt64(objeto);
                    if (objInt == 0)
                        return "0";
                    return objInt.ToString(mascaraSeparadorMiles, CultureInfo.CurrentUICulture);
                }
                else
                    return Convert.ToString(objeto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte un valor Numérico a un string con dos decimales y separador de miles
        /// </summary>
        /// <param name="objeto">El objeto a convertir</param>
        /// <returns>Un valor numérico con  dos decimales y separador de miles</returns>
        public static string ConvertToStringDosDecimalesYSeparadorMiles(object objeto)
        {
            try
            {
                if (objeto == null) return null;
                if (objeto is decimal || objeto is Decimal)
                {
                    Decimal objDec = (Decimal)objeto;
                    objDec = Math.Round(objDec, 2);
                    return objDec.ToString(mascaraSeparadorMilesYDecimal, CultureInfo.CurrentUICulture);
                }
                else
                    return Convert.ToString(objeto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// Convierte el objeto a DateTime.
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a DateTime</returns>
        public static DateTime ConvertToDateTime(object objeto)
        {
            try
            {
                if (objeto == null) return (default(DateTime));
                else
                    return Convert.ToDateTime(objeto);
            }
            catch (Exception)
            {
                return (default(DateTime));
            }
        }

        /// <summary>
        /// Convierte el objeto a int
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a int</returns>
        public static int ConvertToInt(object objeto)
        {
            try
            {
                if (objeto == null) return default(int);
                else
                    return Convert.ToInt32(FiltrarPuntosString(objeto));
            }
            catch (Exception)
            {
                return default(int);
            }
        }

        /// <summary>
        /// Convierte el objeto a decimal
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a decimal</returns>
        public static decimal ConvertToDecimal(object objeto)
        {
            try
            {
                if (objeto == null) return default(decimal);
                else
                    return Convert.ToDecimal(objeto);
            }
            catch (Exception)
            {
                return default(decimal);
            }
        }

        /// <summary>
        /// Convierte el objeto a decimal
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <param name="provider">Especifíca la cultura a utilizar para hacer la conversión</param>
        /// <returns>El objeto convertido a decimal</returns>
        public static decimal ConvertToDecimal(object objeto, IFormatProvider provider)
        {
            try
            {
                if (objeto == null) return default(decimal);
                else
                    return Convert.ToDecimal(objeto, provider);
            }
            catch (Exception)
            {
                return default(decimal);
            }
        }

        /// <summary>
        /// Convierte el objeto a bool
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a bool</returns>
        public static bool ConvertToBool(object objeto)
        {
            try
            {
                if (objeto == null) return default(bool);
                else
                    return Convert.ToBoolean(objeto);
            }
            catch (Exception)
            {
                return default(bool);
            }
        }

        /// <summary>
        /// Convierte el objeto a IntNullable
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a IntNullable</returns>
        public static int? ConvertToIntNullable(object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value || string.Empty.Equals(objeto)) return null;
                else
                    return Convert.ToInt32(FiltrarPuntosString(objeto));
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte el objeto a DecimalNullable
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a DecimalNullable</returns>
        public static decimal? ConvertToDecimalNullable(object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value || string.Empty.Equals(objeto)) return null;
                else
                    return Convert.ToDecimal(objeto);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte el objeto a DecimalNullable
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <param name="provider">Especifíca la cultura a utilizar para hacer la conversión</param>
        /// <returns>El objeto convertido a DecimalNullable</returns>
        public static decimal? ConvertToDecimalNullable(object objeto, IFormatProvider provider)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value || string.Empty.Equals(objeto)) return null;
                else
                    return Convert.ToDecimal(objeto, provider);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte el objeto a BoolNullable
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a BoolNullable</returns>
        public static bool? ConvertToBoolNullable(object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return null;
                else
                    return Convert.ToBoolean(objeto);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte el objeto a DateTime o nulo.
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a DateTime</returns>
        public static DateTime? ConvertToDateTimeNullable(object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value || string.Empty.Equals(objeto) || DateTime.MinValue.Equals(objeto) || DateTime.MinValue.Equals(ConvertToDateTime(objeto)))
                    return (null);
                else
                    return Convert.ToDateTime(objeto);
            }
            catch (Exception)
            {
                return (null);
            }
        }

        /// <summary>
        /// Convierte el objeto a long
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a long</returns>
        public static long ConvertToLong(object objeto)
        {
            try
            {
                if (objeto == null) return default(long);
                else
                    return Convert.ToInt64(objeto);
            }
            catch (Exception)
            {
                return default(long);
            }
        }

        /// <summary>
        /// Convierte a long o nulo
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a long</returns>
        public static long? ConvertToLongNullable(object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value || string.Empty.Equals(objeto)) return null;
                return Convert.ToInt64(objeto);

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte el objeto a DateTime o nulo.
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido</param>
        /// <returns>El objeto convertido a DateTime</returns>
        public static DateTime? ConvertToDateTimeNullable(object objeto, IFormatProvider provider)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value || string.Empty.Equals(objeto) || DateTime.MinValue.Equals(objeto) || DateTime.MinValue.Equals(ConvertToDateTime(objeto)))
                    return (null);
                else
                    return Convert.ToDateTime(objeto, provider);
            }
            catch (Exception)
            {
                return (null);
            }
        }
    }
}
