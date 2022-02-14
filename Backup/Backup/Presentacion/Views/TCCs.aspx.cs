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


namespace Presentacion.Views
{
    public partial class TCCs : Navigate
    {

        #region Private Members
        BConsultaTCC Btcc = new BConsultaTCC();
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
        }
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