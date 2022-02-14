using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
namespace Datos.General
{
    public static class Registreria
    {
        public const string SISU = "SISU\\WEBSITE\\CONSQL";
        public static string ConstantesRegistry(string folderReg, string nameReg)
        {
            //try
            //{
                RegistryKey regKey;
                if (Environment.Is64BitOperatingSystem)
                    regKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                else
                    regKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
                string KeyVal = "SOFTWARE\\CXP\\" + folderReg;
                Object oResultado;
                oResultado = regKey.OpenSubKey(KeyVal, true).GetValue(nameReg);
                regKey.Close();
                return oResultado.ToString();
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
