using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentacion.Navigation;
using Infraestructura;
using Infraestructura.Exceptions;
using Negocio.SISU;
using Dominio.Objects;
using System.Text;
using System.Globalization;
using Presentacion.cl.ssichilexpress.ws;
using System.Web.Services;
using System.Web.Script.Services;


namespace Presentacion.Views
{
    public partial class IngresoServicioUrb : Navigate
    {

        #region Private Members

        BIngresoServUrb BIngServ = new BIngresoServUrb();

        #endregion Private Members

        #region Public Properties

        #region ViewState

        public List<Direccion> VS_DireccionesRetiro
        {
            get { return (List<Direccion>)(ViewState["DireccionesRetiro"]); }
            set { ViewState["DireccionesRetiro"] = value; }
        }
        public List<Direccion> VS_DireccionesDestino
        {
            get { return (List<Direccion>)(ViewState["DireccionesDestino"]); }
            set { ViewState["DireccionesDestino"] = value; }
        }
        public List<Producto> VS_ProductosSU
        {
            get { return (List<Producto>)(ViewState["VS_ProductosSU"]); }
            set { ViewState["VS_ProductosSU"] = value; }
        }
        public List<Valorizacion> VS_Valores
        {
            get { return (List<Valorizacion>)(ViewState["VS_Valores"]); }
            set { ViewState["VS_Valores"] = value; }
        }

        //jcrh
        public List<Coberturas> Lista_OfComerciales
        {
            get { return (List<Coberturas>)(ViewState["Lista_OfComerciales"]); }
            set { ViewState["Lista_OfComerciales"] = value; }
        }

        //jcrh

        public List<Coberturas> DireccionOfComercial
        {
            get { return (List<Coberturas>)(ViewState["DireccionOfComercial"]); }
            set { ViewState["DireccionOfComercial"] = value; }
        }


        public ServicioUrbano Formulario
        {
            get
            {
                if (ViewState["Formulario"] == null)
                    ViewState["Formulario"] = new ServicioUrbano();
                return (ServicioUrbano)ViewState["Formulario"];
            }
            set { ViewState["Formulario"] = value; }
        }

        #endregion ViewState

        #region Banner

        public string B_Remitente
        {
            get
            {
                return P2_txtRemitente.Text;
            }
            set
            {
                P2_txtRemitente.Text = value.ToUpper();
                P3_txtRemitente.Text = value.ToUpper();
            }
        }
        public string B_Destinatario
        {
            get
            {
                return P3_txtDestinatario.Text;
            }
            set
            {
                P3_txtDestinatario.Text = value.ToUpper();
            }
        }
        public string B_DirRemitente
        {
            get
            {
                return P2_txtDirRetiro.Text;
            }
            set
            {
                P2_txtDirRetiro.Text = value;
                P3_txtDirRetiro.Text = value;
            }
        }
        public string B_DirDestinatario
        {
            get
            {
                return P3_txtDirDestino.Text;
            }
            set
            {
                P3_txtDirDestino.Text = value;
            }
        }
        public string B_PesoPdto
        {
            get
            {
                return P1_lblPesoPdto.Text;
            }
            set
            {
                P1_lblPesoPdto.Text = value;
                P2_lblPesoPdto.Text = value;
                P3_lblPesoPdto.Text = value;
            }
        }
        public string B_DimensionesPdto
        {
            get
            {
                return P1_lblDimensionesPdto.Text;
            }
            set
            {
                P1_lblDimensionesPdto.Text = value;
                P2_lblDimensionesPdto.Text = value;
                P3_lblDimensionesPdto.Text = value;
            }
        }

        #endregion Banner

        #region Controls

        public string NroTCC
        {
            get { return lblNroTcc.Text; }
            set { lblNroTcc.Text = value; }
        }
        public string NombreTCC
        {
            get { return lblNombreTcc.Text; }
            set { lblNombreTcc.Text = value; }
        }

  //jcrh
  //      public string MailRemitente
  //      {
  //          get { return lblMailRemitente.Text; }
  //          set { lblMailRemitente.Text = value; }
  //      }
        public decimal Peso
        {
            get { return decimal.Round(Converts.ConvertToDecimal(txtPeso.Text.Replace('.', ',')), 2); }
            set { txtPeso.Text = value.ToString(); txtBoundPeso.Text = value.ToString(); }
        }
        public int Ancho
        {
            get { return Converts.ConvertToInt(txtAncho.Text); }
            set { txtAncho.Text = value.ToString(); txtBoundAncho.Text = value.ToString(); }
        }
        public int Largo
        {
            get { return Converts.ConvertToInt(txtLargo.Text); }
            set { txtLargo.Text = value.ToString(); txtBoundLargo.Text = value.ToString(); }
        }
        public int Alto
        {
            get { return Converts.ConvertToInt(txtAlto.Text); }
            set { txtAlto.Text = value.ToString(); txtBoundAlto.Text = value.ToString(); }
        }
        public string DireccionRemitente
        {
            get { return txtDirRemitente.Text; }
            set { txtDirRemitente.Text = value; }
        }
        public string ComplementoRemitente
        {
            get { return txtComplementoRemitente.Text; }
            set { txtComplementoRemitente.Text = value; }
        }
        public string NombreRemitente
        {
            get { return txtNomRemitente.Text; }
            set { txtNomRemitente.Text = value; }
        }
        public string TelefonoRemitente
        {
            get { return txtTelRemitente.Text; }
            set { txtTelRemitente.Text = value; }
        }

        //jcrh

        public bool OptionOfiDirec
        {
            get { return RBofcomercial.Checked  ; }
            set { RBofcomercial.Checked = value; }
        }


        public string MailRemitente
        {
            get { return txtmailremitente.Text; }
            set { txtmailremitente.Text = value; }
        }

        public string DireccionDestinatario
        {
            get { return txtDirDestino.Text; }
            set { txtDirDestino.Text = value; }
        }
        public string ComplementoDestinatario
        {
            get { return txtComplementoDestino.Text; }
            set { txtComplementoDestino.Text = value; }
        }
        public string NombreDestinatario
        {
            get { return txtNomDestino.Text; }
            set { txtNomDestino.Text = value; }
        }
        public string TelefonoDestinatario
        {
            get { return txtFonoDestino.Text; }
            set { txtFonoDestino.Text = value; }
        }
        public string MailDestinatario
        {
            get { return txtMailDestino.Text; }
            set { txtMailDestino.Text = value; }
        }
        public int ValorTotal
        {
            set { lblValorTotal.Text = "$" + value.ToString("N0"); }
        }

        #endregion Controls

        #endregion Public Properties

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    NroTCC = this.InParameters["TCC"];
                    NombreTCC = this.InParameters["NomTCC"];
                    MailRemitente = this.InParameters["Mail"];

                    InicializaListas();
                    MuestraPaso(1);
                }
                InicializaScript();
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
        protected void btnNuevaTcc_Click(object sender, EventArgs e)
        {
            try
            {
                this.RoutedTo(Transition.TCC);
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
        protected void btnNuevoEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarPaso(0);

                RBofcomercial.Checked = true;
                RBOf.Checked = true;
                RBdomicilio.Checked = false;
                RBDom.Checked = false;
                ComboBox1.Visible = true;
                ComboBox2.Visible = true;
                ComboBox3.Visible = true;
                Combobox4.Visible = true;


                MuestraPaso(1);
                InicializaListas();
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
        protected void btnOkGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                MapeaFormulario();


                List<ulong> Resultado = BIngServ.RegistraServicioUrbano(Formulario,  OptionOfiDirec);
                if (Resultado.Count != 2)
                    throw new ExceptionFuncional("Problemas al registrar el servicio, por favor intente nuevamente.");
                else
                {
                    lblNroot.Text = Resultado[0].ToString();
                    lblNroRetiro.Text = (Resultado[1] == 0) ? "S/N" : Resultado[1].ToString();
                    ModalRegistro.Show();
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
        protected void rblTarifas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValorTotal = Converts.ConvertToInt(VS_Valores[rblTarifas.SelectedIndex].Valor);
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
        protected void btnFTCC_Click(object sender, EventArgs e)
        {
            try
            {
                this.RoutedTo(Transition.TCC);
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
        protected void btnFServ_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarPaso(0);

                RBofcomercial.Checked = true;
                RBOf.Checked = true;
                RBdomicilio.Checked = false;
                RBDom.Checked = false;
                ComboBox1.Visible = true;
                ComboBox2.Visible = true;
                ComboBox3.Visible = true;
                Combobox4.Visible = true;

                MuestraPaso(1);
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
        protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.DataRow) return;
                if ((e.Row.RowType == DataControlRowType.DataRow))
                {
                    LinkButton Boton = (LinkButton)e.Row.FindControl("lbProducto");

                    switch (VS_ProductosSU[e.Row.RowIndex].Cod_producto)
                    {
                        case 1:
                            Boton.Text = "<div class=\"icon icon-envelope icon-left\"></div>" + VS_ProductosSU[e.Row.RowIndex].Gls_producto;
                            break;
                        case 2:
                            Boton.Text = "<div class=\"icon icon-bag icon-left\"></div>" + VS_ProductosSU[e.Row.RowIndex].Gls_producto;
                            break;
                        case 3:
                            Boton.Text = "<div class=\"icon icon-box icon-left\"></div>" + VS_ProductosSU[e.Row.RowIndex].Gls_producto;
                            break;
                        default:
                            Boton.Text = "<div class=\"icon icon-cxp-iso  icon-left\"></div>" + VS_ProductosSU[e.Row.RowIndex].Gls_producto;
                            break;
                    }
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

        #region Pasos

        #region Paso 1

        protected void lbProducto_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow Row = (GridViewRow)((LinkButton)sender).Parent.Parent;
                Formulario.Producto = VS_ProductosSU[Row.RowIndex];

                SeteaConfiguracionProducto();
                MuestraPaso(2);
                txtPeso.Focus();
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

        #endregion Paso 1

        #region Paso 2

        protected void BtnAnteriorPaso2_Click(object sender, EventArgs e) 
        {
            try
            {
                LimpiarPaso(2);
                MuestraPaso(1);
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

        protected void BtnSiguientePaso2_Click(object sender, EventArgs e)
        {
            try
            {
                BIngServ.VerificarDimensiones(Formulario.Producto, Largo, Ancho, Alto, Peso);
                //jcrh

                if (ComboBox1.Items.Count == 0)
                {
                    ComboBox1.DataSource = null;
                    ComboBox1.Items.Clear();
                    Lista_OfComerciales = BIngServ.CargaCoberturasOfiComercial();
                    foreach (Coberturas Valor in Lista_OfComerciales)
                    {

                        ListItem item = new ListItem(Valor.Cobertura.ToString(), Valor.CodCobertura.ToString());
                        //rblTarifas.Items.Add(item); }
                        ComboBox1.Items.Add(item);
                    }
                    //----------------------------
                    //jcrh
                    ComboBox2.DataSource = null;
                    ComboBox2.Items.Clear();
                    Lista_OfComerciales = BIngServ.CargaOfiComerciales(ComboBox1.SelectedValue);
                    foreach (Coberturas Valor in Lista_OfComerciales)
                    {

                        ListItem item = new ListItem(Valor.NombreUnidad.ToString(), Valor.CodUnidad.ToString());
                        //rblTarifas.Items.Add(item); }
                        ComboBox2.Items.Add(item);
                    }
                }

                //jcrh
                if (ComboBox2.SelectedValue != "")
                {
                    if (RBofcomercial.Checked)
                    { 
                        DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(ComboBox2.SelectedValue));

                        foreach (Coberturas Valor in DireccionOfComercial)
                        {
                            txtDirRemitente.ReadOnly = true;
                            txtDirRemitente.Text = Valor.Direccion.ToString();
                            B_DirRemitente = Valor.Direccion.ToString();
                        }
                    }
                }
                SeteaBannerProducto();
                MuestraPaso(3);
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



        #endregion Paso 2

        #region Paso 3

        



        protected void RBofcomercial_clik(object sender, System.EventArgs e)
            {
            try
            {
                ComboBox1.Visible = true;
                ComboBox2.Visible = true;
               
                OptionOfiDirec = true;
                //txtDirRemitente.Enabled = false;
                txtDirRemitente.ReadOnly = true;

                RBofcomercial.Checked = true;
                RBdomicilio.Checked = false;

                //jcrh
                DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(ComboBox2.SelectedValue));

                foreach (Coberturas Valor in DireccionOfComercial)
                {
                    txtDirRemitente.ReadOnly = true;
                    txtDirRemitente.Text = Valor.Direccion.ToString();
                    B_DirRemitente = Valor.Direccion.ToString();
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


        protected void RBOf_clik(object sender, System.EventArgs e)
        {
            try
            {
                ComboBox3.Visible = true;
                Combobox4.Visible = true;
                RBDom.Checked = false;
                RBOf.Checked = true;
                //OptionOfiDirec = true;
                txtDirDestino.ReadOnly = true;

                //jcrh
                //DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(ComboBox3.SelectedValue));
                DireccionOfComercial = BIngServ.CargaOfiComerciales(Convert.ToString(ComboBox3.SelectedValue));

                foreach (Coberturas Valor in DireccionOfComercial)
                {
                    txtDirDestino.ReadOnly = true;
                    txtDirDestino.Text = Valor.Direccion.ToString();
                    B_Destinatario = Valor.Direccion.ToString();
                     
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

        protected void RBdomicilio_clik(object sender, System.EventArgs e)
        {
            try
            {
                ComboBox1.Visible = false;
                ComboBox2.Visible = false;

                RBdomicilio.Checked = true;
                RBofcomercial.Checked = false;
                OptionOfiDirec = false;
                
                txtDirRemitente.ReadOnly = false;
                txtDirRemitente.Text = "";
                //RBDom.Checked = true;
                //RBOf.Checked = false;
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


        protected void RBDom_clik(object sender, System.EventArgs e)
        {
            try
            {
                ComboBox3.Visible = false;
                Combobox4.Visible = false;
                RBOf.Checked = false;
                RBDom.Checked = true;
                //  OptionOfiDirec = false;
                txtDirDestino.ReadOnly = false;
                txtDirDestino.Text = "";
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
        protected void BtnSiguientePaso3_Click(object sender, EventArgs e)
        {
            try
            {
         //       if (MailRemitente != "")
         //       {

                    Formulario.DirRemitente = BIngServ.ProcesarDireccion(this.DireccionRemitente);
                    Formulario.ComplementoRemitente = ComplementoRemitente;
                    Formulario.DirRemitente.NombreContacto = NombreRemitente;
                    Formulario.DirRemitente.Telefono = TelefonoRemitente;
                    //jcrh
                    Formulario.DirRemitente.Mail = MailRemitente;

                    B_Remitente = Formulario.DirRemitente.NombreContacto;
                    B_DirRemitente = Formulario.DirRemitente.DireccionCompleta.ToLower();
                    DireccionRemitente = Formulario.DirRemitente.DireccionCompleta;




                    //jcrh         
                    if (ComboBox3.Items.Count == 0)
                    {
                        ComboBox3.DataSource = null;
                        ComboBox3.Items.Clear();
                        Lista_OfComerciales = BIngServ.CargaCoberturasOfiComercial();
                        foreach (Coberturas Valor in Lista_OfComerciales)
                        {

                            ListItem item = new ListItem(Valor.Cobertura.ToString(), Valor.CodCobertura.ToString());
                            //rblTarifas.Items.Add(item); }
                            ComboBox3.Items.Add(item);
                        }
                        //----------------------------
                        //jcrh
                        Combobox4.DataSource = null;
                        Combobox4.Items.Clear();
                        Lista_OfComerciales = BIngServ.CargaOfiComerciales(ComboBox3.SelectedValue);
                        foreach (Coberturas Valor in Lista_OfComerciales)
                        {

                            ListItem item = new ListItem(Valor.NombreUnidad.ToString(), Valor.CodUnidad.ToString());
                            //rblTarifas.Items.Add(item); }
                            Combobox4.Items.Add(item);
                        }
                    }

                    //jcrh
                //    if (RBofcomercial.Checked )
                //    {
                //        RBOf.Checked = true;
                //        RBDom.Checked = false;
                //        ComboBox3.Visible = true;
                //        Combobox4.Visible = true;
                //}

                //    if (RBdomicilio.Checked )
                //    {
                //        RBDom.Checked = true;
                //        RBOf.Checked = false;
                //        ComboBox3.Visible = false;
                //        Combobox4.Visible = false;
                //}

                if (RBOf.Checked)
                {
                    ComboBox3.Visible = true;
                    Combobox4.Visible = true;
                }

                if (RBDom.Checked)
                {
                    ComboBox3.Visible = false;
                    Combobox4.Visible = false;
                }

                if (Combobox4.SelectedValue != "")
                    {
                        if (RBOf.Checked)
                        {
                            DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(Combobox4.SelectedValue));

                            foreach (Coberturas Valor in DireccionOfComercial)
                            {
                                txtDirDestino.ReadOnly = true;
                                txtDirDestino.Text = Valor.Direccion.ToString();
                                //B_DirRemitente = Valor.Direccion.ToString();
                            }
                        }
                    }

                    MuestraPaso(4);
           //     }
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


        protected void BtnAnteriorPaso3_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarPaso(3);
                MuestraPaso(2);
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
        protected void lnkDirRetiro_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow Row = (GridViewRow)((LinkButton)sender).Parent.Parent;
                Formulario.DirRemitente = VS_DireccionesRetiro[Row.RowIndex];

                DireccionRemitente = Formulario.DirRemitente.DireccionCompleta;
                NombreRemitente = Formulario.DirRemitente.NombreContacto;
                TelefonoRemitente = Formulario.DirRemitente.Telefono;
 //jcrh
                MailRemitente = Formulario.DirRemitente.Mail;
                B_Remitente = NombreRemitente;
                B_DirRemitente = DireccionRemitente.ToLower();
            //    MuestraPaso(4);
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

        #endregion Paso 3

        #region Paso 4

        protected void BtnSiguientePaso4_Click(object sender, EventArgs e)
        {
            try
            {
                Formulario.DirDestino = BIngServ.ProcesarDireccion(this.DireccionDestinatario);
                Formulario.ComplementoDestino = ComplementoDestinatario;
                Formulario.DirDestino.NombreContacto = NombreDestinatario;
                Formulario.DirDestino.Telefono = TelefonoDestinatario;
                Formulario.DirDestino.Mail = MailDestinatario;
                B_Destinatario = Formulario.DirDestino.NombreContacto;
                B_DirDestinatario = Formulario.DirDestino.DireccionCompleta.ToLower();
                DireccionRemitente = Formulario.DirDestino.DireccionCompleta;

                if (RBofcomercial.Checked == true) 
                {
                    OptionOfiDirec = true; 
                }
                else
                {
                    OptionOfiDirec = false;
                }

                VS_Valores = BIngServ.ObtieneValorizacionServicios(
                    Formulario.DirRemitente.CodCobertura,
                    Formulario.DirDestino.CodCobertura,
                    Formulario.Producto.Cod_producto,
                    Peso,
                    Alto,
                    Ancho,
                    Largo,
                    OptionOfiDirec);
                rblTarifas.Items.Clear();
                foreach (Valorizacion Valor in VS_Valores)
                {
                  
                    ListItem item = new ListItem(Valor.Nom_servicio + " / " + Valor.Gls_entrega, Valor.Cod_servicio.ToString());
                    rblTarifas.Items.Add(item);
                }
                MuestraPaso(5);
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
        protected void BtnAnteriorPaso4_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarPaso(4);
                MuestraPaso(3);
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
        protected void lnkDirDestino_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow Row = (GridViewRow)((LinkButton)sender).Parent.Parent;
                Formulario.DirDestino = VS_DireccionesDestino[Row.RowIndex];

                DireccionDestinatario = Formulario.DirDestino.DireccionCompleta;
                NombreDestinatario = Formulario.DirDestino.NombreContacto;
                TelefonoDestinatario = Formulario.DirDestino.Telefono;
                B_Destinatario = NombreDestinatario;
                B_DirDestinatario = DireccionDestinatario.ToLower();

                VS_Valores = BIngServ.ObtieneValorizacionServicios(
                    Formulario.DirRemitente.CodCobertura,
                    Formulario.DirDestino.CodCobertura,
                    Formulario.Producto.Cod_producto,
                    Peso,
                    Alto,
                    Ancho,
                    Largo,
                    OptionOfiDirec);
                rblTarifas.Items.Clear();
                foreach (Valorizacion Valor in VS_Valores)
                {
                    ListItem item = new ListItem(Valor.Nom_servicio + " / " + Valor.Gls_entrega, Valor.Cod_servicio.ToString());
                    rblTarifas.Items.Add(item);
                }
               // MuestraPaso(5);
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

        #endregion Paso 4

        #region Paso 5

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblTarifas.SelectedIndex >= 0)
                {
                    ModalGuardar.Show();
                }
                else
                {
                    throw new ExceptionFuncional("Debe seleccionar el servicio a solicitar.");
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

        #endregion Paso 5

        #endregion Pasos

        #endregion Protected Methods

        #region Private Methods

        private void MuestraPaso(int paso)
        {
            switch (paso)
            {
                case 1:
                    Tab_Banner1.Visible = true;
                    Tab_Banner2.Visible = false;
                    Tab_Banner3.Visible = false;
                    Tab_Banner4.Visible = false;
                    Tab_Paso1.Visible = true;
                    Tab_Paso2.Visible = false;
                    Tab_Paso3.Visible = false;
                    Tab_Paso4.Visible = false;
                    Tab_Pago.Visible = false;
                    btnNuevoEnvio.Visible = false;
                    btnNuevaTcc.Visible = true;
                    break;
                case 2:
                    Tab_Banner1.Visible = true;
                    Tab_Banner2.Visible = false;
                    Tab_Banner3.Visible = false;
                    Tab_Banner4.Visible = false;
                    Tab_Paso1.Visible = false;
                    Tab_Paso2.Visible = true;
                    Tab_Paso3.Visible = false;
                    Tab_Paso4.Visible = false;
                    Tab_Pago.Visible = false;
                    btnNuevoEnvio.Visible = true;
                    btnNuevaTcc.Visible = false;
                    break;
                case 3:
                    Tab_Banner1.Visible = false;
                    Tab_Banner2.Visible = true;
                    Tab_Banner3.Visible = false;
                    Tab_Banner4.Visible = false;
                    Tab_Paso1.Visible = false;
                    Tab_Paso2.Visible = false;
                    Tab_Paso3.Visible = true;
                    Tab_Paso4.Visible = false;
                    Tab_Pago.Visible = false;
                    btnNuevoEnvio.Visible = true;
                    btnNuevaTcc.Visible = false;
                    ComboBox1.Visible = true;
                    ComboBox2.Visible = true;

                    break;
                case 4:
                    Tab_Banner1.Visible = false;
                    Tab_Banner2.Visible = false;
                    Tab_Banner3.Visible = true;
                    Tab_Banner4.Visible = false;
                    Tab_Paso1.Visible = false;
                    Tab_Paso2.Visible = false;
                    Tab_Paso3.Visible = false;
                    Tab_Paso4.Visible = true;
                    Tab_Pago.Visible = false;
                    btnNuevoEnvio.Visible = true;
                    btnNuevaTcc.Visible = false;
                    break;
                case 5:
                    Tab_Banner1.Visible = false;
                    Tab_Banner2.Visible = false;
                    Tab_Banner3.Visible = false;
                    Tab_Banner4.Visible = true;
                    Tab_Paso1.Visible = false;
                    Tab_Paso2.Visible = false;
                    Tab_Paso3.Visible = false;
                    Tab_Paso4.Visible = false;
                    Tab_Pago.Visible = true;
                    btnNuevoEnvio.Visible = true;
                    btnNuevaTcc.Visible = false;
                    break;
            }
        }
        private void InicializaListas()
        {
            //Consulta
            VS_DireccionesRetiro = BIngServ.ConsultaDireccionesRetiroTCC(Converts.ConvertToInt(NroTCC));
            VS_DireccionesDestino = BIngServ.ConsultaDireccionesEntregaTCC(Converts.ConvertToInt(NroTCC));
            VS_ProductosSU = BIngServ.ObtenerServiciosUrbanos();

            //Asignación
            gvDireccionesEntrega.DataSource = VS_DireccionesDestino;
            gvDireccionesRetiro.DataSource = VS_DireccionesRetiro;
            gvProductos.DataSource = VS_ProductosSU;
            //Actualización
            gvDireccionesEntrega.DataBind();
            gvDireccionesRetiro.DataBind();
            gvProductos.DataBind();
        }
        private void LimpiarPaso(int paso)
        {
            if (paso == 0)
            {
                Peso = 0;
                Alto = 0;
                Ancho = 0;
                Largo = 0;
                txtDirRemitente.Text = string.Empty;
                txtComplementoRemitente.Text = string.Empty;
                txtNomRemitente.Text = string.Empty;
                txtTelRemitente.Text = string.Empty;
                txtDirDestino.Text = string.Empty;
                txtComplementoDestino.Text = string.Empty;
                txtNomDestino.Text = string.Empty;
                txtFonoDestino.Text = string.Empty;
                txtMailDestino.Text = string.Empty;
                Formulario.DirRemitente = new Direccion();
                Formulario.DirDestino = new Direccion();
                Formulario.Producto = new Producto();
                VS_Valores = new List<Valorizacion>();
                lblValorTotal.Text = "Sin valorizar";
// jcrh
                txtmailremitente.Text = string.Empty;
                rblTarifas.Items.Clear();
            }
            else if (paso == 2)
            {
                Peso = 0;
                Alto = 0;
                Ancho = 0;
                Largo = 0;
            }
            else if (paso == 3)
            {
                txtDirRemitente.Text = string.Empty;
                txtComplementoRemitente.Text = string.Empty;
                txtNomRemitente.Text = string.Empty;
                txtTelRemitente.Text = string.Empty;
 //jcrh
                txtmailremitente.Text = string.Empty;
                Formulario.DirRemitente = new Direccion();
            }
            else if (paso == 4)
            {
                txtDirDestino.Text = string.Empty;
                txtComplementoDestino.Text = string.Empty;
                txtNomDestino.Text = string.Empty;
                txtFonoDestino.Text = string.Empty;
                txtMailDestino.Text = string.Empty;
                Formulario.DirDestino = new Direccion();
            }
            else if (paso == 5)
            {
                Formulario.Producto = new Producto();
                VS_Valores = new List<Valorizacion>();
                lblValorTotal.Text = "Sin valorizar";
                rblTarifas.Items.Clear();
            }

        }
        private void InicializaScript()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script>$(function(){$('input,textarea').placeholder();});</script>", false);
        }
        private void SeteaConfiguracionProducto()
        {

            bool EnableDim = (Formulario.Producto.Dimension_Max > 0);
            bool EnablePeso = (Formulario.Producto.Peso_Max > 0);
            txtAlto.Enabled = EnableDim;
            txtAncho.Enabled = EnableDim;
            txtLargo.Enabled = EnableDim;
            txtBoundAlto.Visible = EnableDim;
            txtBoundAncho.Visible = EnableDim;
            txtBoundLargo.Visible = EnableDim;
            txtAlto_Slider.Enabled = EnableDim;
            txtLargo_Slider.Enabled = EnableDim;
            txtAncho_Slider.Enabled = EnableDim;


            if (EnablePeso)
            {
                txtPeso_Slider.Minimum = Convert.ToDouble(Formulario.Producto.Peso_Min);
                txtPeso_Slider.Maximum = Convert.ToDouble(Formulario.Producto.Peso_Max); ;
                txtPeso_Slider.Steps = Converts.ConvertToInt(Converts.ConvertToInt(Converts.ConvertToDecimal(Formulario.Producto.Peso_Max - Formulario.Producto.Peso_Min) / Converts.ConvertToDecimal(0.1)));
            }
            if (EnableDim)
            {
                int steps = Converts.ConvertToInt(Converts.ConvertToInt(Converts.ConvertToDecimal(Formulario.Producto.Dimension_Max - Formulario.Producto.Dimension_Min) / Converts.ConvertToDecimal(0.1)));
                txtAlto_Slider.Minimum = Convert.ToDouble(Formulario.Producto.Dimension_Min);
                txtAlto_Slider.Maximum = Convert.ToDouble(Formulario.Producto.Dimension_Max);
                txtAlto_Slider.Steps = steps;

                //dimensiones
                txtLargo_Slider.Minimum = Convert.ToDouble(Formulario.Producto.Dimension_Min);
                txtLargo_Slider.Maximum = Convert.ToDouble(Formulario.Producto.Dimension_Max);
                txtLargo_Slider.Steps = steps;

                txtAncho_Slider.Minimum = Convert.ToDouble(Formulario.Producto.Dimension_Min);
                txtAncho_Slider.Maximum = Convert.ToDouble(Formulario.Producto.Dimension_Max);
                txtAncho_Slider.Steps = steps;
            }
            Peso = 0;
            Ancho = 0;
            Largo = 0;
            Alto = 0;
        }
        private void SeteaBannerProducto()
        {
            switch (Formulario.Producto.Cod_producto)
            {
                case 1:
                    P1_ImgProducto.Attributes["class"] = "icon icon-envelope";
                    P2_ImgProducto.Attributes["class"] = "icon icon-envelope";
                    P3_ImgProducto.Attributes["class"] = "icon icon-envelope";
                    break;

                case 2:
                    P1_ImgProducto.Attributes["class"] = "icon icon-bag";
                    P2_ImgProducto.Attributes["class"] = "icon icon-bag";
                    P3_ImgProducto.Attributes["class"] = "icon icon-bag";
                    break;
                case 3:
                    P1_ImgProducto.Attributes["class"] = "icon icon-box";
                    P2_ImgProducto.Attributes["class"] = "icon icon-box";
                    P3_ImgProducto.Attributes["class"] = "icon icon-box";
                    break;
                default:
                    P1_ImgProducto.Attributes["class"] = "icon icon-cxp-iso";
                    P2_ImgProducto.Attributes["class"] = "icon icon-cxp-iso";
                    P3_ImgProducto.Attributes["class"] = "icon icon-cxp-iso";
                    break;
            }

            P1_txtProducto.Text = Formulario.Producto.Gls_producto.ToUpper();
            P2_txtProducto.Text = Formulario.Producto.Gls_producto.ToUpper();
            P3_txtProducto.Text = Formulario.Producto.Gls_producto.ToUpper();

            B_PesoPdto = (Formulario.Producto.Peso_Max == 0) ? "0 kg." : (txtPeso.Text + " kg.");
            B_DimensionesPdto = (Formulario.Producto.Dimension_Max == 0) ? "0 x 0 x 0 cm." : (txtAlto.Text + " x " + txtAncho.Text + " x " + txtLargo.Text + " cm.");
        }
        private void MapeaFormulario()
        {
            Formulario.DirRemitente.Mail = MailRemitente;
            Formulario.TipoServicio = VS_Valores[rblTarifas.SelectedIndex].Cod_servicio;
            Formulario.GlsServicio = VS_Valores[rblTarifas.SelectedIndex].Nom_servicio;
            Formulario.ValorServicio = VS_Valores[rblTarifas.SelectedIndex].Valor;
            Formulario.DimAlto = Alto;
            Formulario.DimAncho = Ancho;
            Formulario.DimLargo = Largo;
            Formulario.DimPeso = Peso;
            Formulario.IP = Request.UserHostAddress;
            Formulario.NroTCC = Converts.ConvertToInt(NroTCC);
            Formulario.DirDestino.NombreContacto = Formulario.DirDestino.Complemento.Trim().Length > 0 ?
                                                   (NombreDestinatario + " (" + Formulario.DirDestino.Complemento.Trim().ToUpper() + ")") : NombreDestinatario;
            Formulario.DirRemitente.NombreContacto = Formulario.DirRemitente.Complemento.Trim().Length > 0 ?
                                                   (NombreRemitente + " (" + Formulario.DirRemitente.Complemento.Trim().ToUpper() + ")") : NombreRemitente;
        }

        #endregion Private Methods

        #region WebMethods
        [WebMethod(EnableSession = true)]
        public static string[] ObtieneDireccionesWS(string strdirecciones)
        {
         List<string> direcciones = new List<string>();
            BIngresoServUrb NIngServ = new BIngresoServUrb();
            Infraestructura.WebConstrols.FailedValidationsControl control = new Infraestructura.WebConstrols.FailedValidationsControl();

            try
            {
                direcciones = NIngServ.ObtieneDireccionesWS(strdirecciones);

                if (direcciones.Count == 0)
                {
                    throw new ExceptionFuncional("No Existe Informacion para la dirección.");
                }
                else 
                {
                    return direcciones.ToArray();
                }
            }
            catch (ExceptionFuncional fe)
            {
                control.Mode = Infraestructura.WebConstrols.FailedValidationsControl.INFOMODE;
                control.ShowException(fe);
            }
            catch (Exception ex)
            {
                control.Mode = Infraestructura.WebConstrols.FailedValidationsControl.ERRORMODE;
                control.ShowException(ex);
            }
            return direcciones.ToArray();
        }
        #endregion WebMethods



 //jcrh
        protected void CargaOfiComerciales_click(object sender, EventArgs e)
        {
            try
            {
                //jcrh
                ComboBox2.DataSource = null;
                ComboBox2.Items.Clear();
                txtDirRemitente.Text = "";
                Lista_OfComerciales = BIngServ.CargaOfiComerciales(ComboBox1.SelectedValue);
                foreach (Coberturas Valor in Lista_OfComerciales)
                {
                    ListItem item = new ListItem(Valor.NombreUnidad.ToString(), Valor.CodUnidad.ToString());
                    //rblTarifas.Items.Add(item); }
                    ComboBox2.Items.Add(item);
                }


                //jcrh
                DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(ComboBox2.SelectedValue));

                foreach (Coberturas Valor in DireccionOfComercial)
                {
                    txtDirRemitente.ReadOnly = true;
                    txtDirRemitente.Text = Valor.Direccion.ToString();
                    B_DirRemitente = Valor.Direccion.ToString();
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


        //jcrh
        protected void CargaOfiComerciales3_click(object sender, EventArgs e)
        {
            try
            {
                //jcrh
                Combobox4.DataSource = null;
                Combobox4.Items.Clear();
                txtDirRemitente.Text = "";
                Lista_OfComerciales = BIngServ.CargaOfiComerciales(ComboBox3.SelectedValue);
                foreach (Coberturas Valor in Lista_OfComerciales)
                {
                    ListItem item = new ListItem(Valor.NombreUnidad.ToString(), Valor.CodUnidad.ToString());
                    //rblTarifas.Items.Add(item); }
                    Combobox4.Items.Add(item);
                }


                //jcrh
                DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(Combobox4.SelectedValue));

                foreach (Coberturas Valor in DireccionOfComercial)
                {
                    txtDirDestino.ReadOnly = true;
                    txtDirDestino.Text = Valor.Direccion.ToString();
                   // B_DirRemitente = Valor.Direccion.ToString();
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



        protected void CargaDirreccionOfCom(object sender, EventArgs e)
        {

            try
            {
                //jcrh
                DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(ComboBox2.SelectedValue));
                
                foreach (Coberturas Valor in DireccionOfComercial)
                {

                    // ListItem item = new ListItem(Valor.Direccion.ToString());
                    txtDirRemitente.Text = Valor.Direccion.ToString();
                    B_DirRemitente = Valor.Direccion.ToString();



                    //    //rblTarifas.Items.Add(item); }
                    //    txtDirRemitente.Text = item; 
                    //    ComboBox2.Items.Add(item);
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


        protected void CargaDirreccionOfCom4(object sender, EventArgs e)
        {

            try
            {
                //jcrh
                DireccionOfComercial = BIngServ.CargaDireccionOfCom(Convert.ToString(Combobox4.SelectedValue));

                foreach (Coberturas Valor in DireccionOfComercial)
                {

                    // ListItem item = new ListItem(Valor.Direccion.ToString());
                    txtDirDestino.Text = Valor.Direccion.ToString();
                    //B_DirRemitente = Valor.Direccion.ToString();



                    //    //rblTarifas.Items.Add(item); }
                    //    txtDirRemitente.Text = item; 
                    //    ComboBox2.Items.Add(item);
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

        protected void Option(object sender, GridViewCommandEventArgs e)
        {
            RBofcomercial.Checked = false;
            RBdomicilio.Checked = true;
            ComboBox1.Visible = false;
            ComboBox2.Visible = false; 
        }

        protected void Option1(object sender, GridViewCommandEventArgs e)
        {
            RBOf.Checked = false;
            RBDom.Checked = true;
            ComboBox3.Visible = false;
            Combobox4.Visible = false;
            

        }
    }
}
