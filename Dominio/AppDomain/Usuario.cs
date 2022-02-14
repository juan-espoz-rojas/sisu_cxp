using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.AppDomain
{
    public class Usuario
    {
        #region PrivateMembers
        string _Nombre = string.Empty;
        string _Rut = string.Empty;
        string _Dv = string.Empty;
        int _PerfilId = default(int);
        string _Perfil = string.Empty;
        int _IdOficina = default(int);
        int _NroError = default(int);
        string _Error = string.Empty;
        #endregion PrivateMembers

        #region PublicProperties
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Rut
        {
            get { return _Rut; }
            set { _Rut = value; }
        }
        public string Dv
        {
            get { return _Dv; }
            set { _Dv = value; }
        }
        public int PerfilId
        {
            get { return _PerfilId; }
            set { _PerfilId = value; }
        }
        public string Perfil
        {
            get { return _Perfil; }
            set { _Perfil = value; }
        }
        public int NroError
        {
            get { return _NroError; }
            set { _NroError = value; }
        }
        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        public int IdOficina
        {
            get { return _IdOficina; }
            set { _IdOficina = value; }
        }
        #endregion PublicProperties

        #region Constructors
        public Usuario() { }
        public Usuario(int iderror, string mensajeerror) {
            this.NroError = iderror;
            this.Error = mensajeerror;
        }
        #endregion Constructors
    }
}
