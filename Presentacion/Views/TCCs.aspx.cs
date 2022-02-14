using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Exceptions;
using Negocio.SISU;
using Dominio.Objects;
using Infraestructura;
using Presentacion.Navigation;
using Presentacion.EncriptadorDesencriptador;

using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace Presentacion.Views
{
    public partial class TCCs : Navigate
    {

        #region Private Members
        BConsultaTCC Btcc = new BConsultaTCC();
        BConsultaHorario Bhorario = new BConsultaHorario();
        #endregion Private Members

        #region Public Properties 

        public int NroTcc
        {
            get { return Converts.ConvertToInt(txtBuscarTCC.Text);}
            set { txtBuscarTCC.Text = (value == 0) ? "" : value.ToString(); }
        }
        public int Rut
        {
            get { return Converts.ConvertToInt(txtBuscarRut.Text); }
            set { txtBuscarRut.Text = (value == 0) ? "" : value.ToString(); }
        }
        public string Mail
        {
            get { return txtMail.Text; }
            set { txtMail.Text = value; }
        }

        #endregion Public Properties

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------
            if (SISU.Token != null)  
            {
                if (SISU.Token.Trim() != "") 
                    {
                    Proceso Token = new Proceso(); 
                    string varToken = Token.Desencriptar(SISU.Token, "chilexpress.2019"); 
                    this.txtBuscarTCC.Text = varToken; 
                    IngresoTokenNumeroTCC(varToken); 
                }
            }
            //-------------------------------------------------------------------------------------
        }

        //-------------------------------------------------------------------------------------
        protected void IngresoTokenNumeroTCC(string NroTcc)
        {
            int NroTccToken = Converts.ConvertToInt(NroTcc);
            try
            {
                if (Btcc.ValidaTCCVigente(NroTccToken))
                {
                    this.OutParameters.Add("TCC", this.NroTcc.ToString());
                    this.OutParameters.Add("NomTCC", Btcc.ConsultaTccPorNumero(NroTccToken).Gls_nombre_tarjeta);
                    this.OutParameters.Add("Mail", Mail);
                    this.RoutedTo(Transition.SERVICIOS);
                }
            }
            catch (ExceptionFuncional fe)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                MessageControl.ShowException(fe);
            }
            catch (Exception ex)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.ERRORMODE;
                MessageControl.ShowException(ex);
            }
        }

        //-------------------------------------------------------------------------------------
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TCC> lista = Btcc.ConsultaTccPorRut(Rut);
                if (lista.Count == 0) { MessageControl.Text = "Sin resultados de búsqueda."; MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE; }
                gvTCCs.DataSource = lista;
                gvTCCs.DataBind();
            }
            catch (ExceptionFuncional fe)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                MessageControl.ShowException(fe);
            }
            catch (Exception ex)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.ERRORMODE;
                MessageControl.ShowException(ex);
            }
        }
        protected void lnkNombreTcc_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkNombreTcc = (LinkButton)sender;
                GridViewRow Row = (GridViewRow)lnkNombreTcc.Parent.Parent;
                int NumTcc = Convert.ToInt32(Row.Cells[1].Text);

                //

                int Hor = Convert.ToInt32(DateTime.Now.Hour.ToString());
                int Minutos = Convert.ToInt32(DateTime.Now.Minute.ToString());

                try
                {
                    int Horita = Convert.ToInt32(Bhorario.ConsultaHorarioPorNumero(NroTcc).Hora.ToString());
                    int Minutitos = Convert.ToInt32(Bhorario.ConsultaHorarioPorNumero(NroTcc).Minutos.ToString());


                    if (Hor > Horita)
                    {
                        MessageControl.Text = "En estos momentos, no existen servicios disponibles para estas direcciones."; MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                        return;
                    }

                    if (Hor == Horita && Minutos >= Minutitos)
                    {
                        MessageControl.Text = "En estos momentos, no existen servicios disponibles para estas direcciones."; MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                        return;

                    }


                }
                catch (ExceptionFuncional fe)
                {
                    MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                    MessageControl.ShowException(fe);
                }
                catch (Exception ex)
                {
                    MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.ERRORMODE;
                    MessageControl.ShowException(ex);
                }

                //



                if (Btcc.ValidaTCCVigente(NumTcc))
                {
                    this.OutParameters.Add("TCC", NumTcc.ToString());
                    this.OutParameters.Add("NomTCC", lnkNombreTcc.Text);
                    this.OutParameters.Add("Mail", Mail);
                    this.RoutedTo(Transition.SERVICIOS);
                }
            }
            catch (ExceptionFuncional fe)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                MessageControl.ShowException(fe);
            }
            catch (Exception ex)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.ERRORMODE;
                MessageControl.ShowException(ex);
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {

            int Hor = Convert.ToInt32(DateTime.Now.Hour.ToString());
            int Minutos = Convert.ToInt32(DateTime.Now.Minute.ToString());

            try
            {
               int Horita  =   Convert.ToInt32(Bhorario.ConsultaHorarioPorNumero(NroTcc).Hora.ToString());
               int Minutitos = Convert.ToInt32(Bhorario.ConsultaHorarioPorNumero(NroTcc).Minutos.ToString());


                if (Hor > Horita)
                {
                    MessageControl.Text = "En estos momentos, no existen servicios disponibles para estas direcciones."; MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                    return;
                }

                if (Hor == Horita && Minutos >= Minutitos)
                {
                    MessageControl.Text = "En estos momentos, no existen servicios disponibles para estas direcciones."; MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                    return;

                }

    

            }
            catch (ExceptionFuncional fe)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                MessageControl.ShowException(fe);
            }
            catch (Exception ex)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.ERRORMODE;
                MessageControl.ShowException(ex);
            }



            try
            {
                if (Btcc.ValidaTCCVigente(NroTcc))
                {
                    this.OutParameters.Add("TCC", this.NroTcc.ToString());
                    this.OutParameters.Add("NomTCC", Btcc.ConsultaTccPorNumero(NroTcc).Gls_nombre_tarjeta);
                    this.OutParameters.Add("Mail", Mail);                    
                    this.RoutedTo(Transition.SERVICIOS);
                }
            }
            catch (ExceptionFuncional fe)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                MessageControl.ShowException(fe);
            }
            catch (Exception ex)
            {
                MessageControl.Mode = Infraestructura.WebConstrols.FailedValidationsControl.ERRORMODE;
                MessageControl.ShowException(ex);
            }
        }

       #endregion Protected Methods

    }
}