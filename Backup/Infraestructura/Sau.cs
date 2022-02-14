using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura
{
    public class Sau
    {
        public string ValidaSesion ( string CodSession)
        {
            try
            {
                int LargoSession = CodSession.Length;
                string[] Codigo =  CodSession.Split('_');
                return Codigo[0];
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string ValidaIdSistema ( string CodSession)
        {
            try
            {
                int LargoSession = CodSession.Length;
                string[] Codigo =  CodSession.Split('_');
                return Codigo[1];
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
