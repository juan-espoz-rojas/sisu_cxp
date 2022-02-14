using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Reflection;
using Infraestructura.Exceptions;

namespace Infraestructura.WebConstrols
{
    [ToolboxData("<{0}:FailedValidationsControl ID=FailedValidationsControl1 Width=100% runat=server></{0}:FailedValidationsControl>")]
    public class FailedValidationsControl : WebControl 
    {
        #region Public Constants
        public const string ERRORMODE = "ERROR";
        public const string WARNINGMODE = "WARN";
        public const string INFOMODE = "INFO";
        public const string SINIMGMODE = "SINIMAGEN";
        #endregion Public Constants

        #region Private Members
        private Image warningImage = new Image();
        private Image _warningImg = new Image();
        private Image _errorImg = new Image();
        private Image _infoImg = new Image();
        private Image _SinImg = new Image();
        private Label lblMessage = new Label();
        private Label lblnbsp = new Label();
        private string _text = string.Empty;
        private string _mode = string.Empty;
        private Exception _exception = null;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Sets the web control's image url.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The image that shows the control.")]
        public string WarningImageUrl
        {
            get
            {
                return warningImage.ImageUrl;
            }
            set
            {
                warningImage.ImageUrl = value;
            }
        }

        /// <summary>
        /// Sets the web control's image url.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The image that shows the control if the mode is 'Warning'.")]
        public string WarningImgURL
        {
            get
            {
                return _warningImg.ImageUrl;
            }
            set
            {
                _warningImg.ImageUrl = value;
            }
        }

        /// <summary>
        /// Sets the web control's image url.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The image that shows the control if the mode is 'Error'.")]
        public string ErrorImgURL
        {
            get
            {
                return _errorImg.ImageUrl;
            }
            set
            {
                _errorImg.ImageUrl = value;
            }
        }

        /// <summary>
        /// The image that shows the control if the mode is 'Info'.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The image that shows the control if the mode is 'Info'.")]
        public string InfoImgURL
        {
            get
            {
                return _infoImg.ImageUrl;
            }
            set
            {
                _infoImg.ImageUrl = value;
            }
        }

        /// <summary>
        /// The image that shows the control if the mode is 'Info'.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The image that shows the control if the mode is 'SinImagen'.")]
        public string SinImgURL
        {
            get
            {
                return _SinImg.ImageUrl;
            }
            set
            {
                _SinImg.ImageUrl = value;
            }
        }

        /// <summary>
        /// Sets an specific message to display.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The text that shows the control.")]
        public string Text
        {
            get
            {
                if (this.Exception == null)
                {
                    return _text;
                }
                else
                {
                    return this.Exception.Message;
                }
            }
            set
            {
                _text = value;
            }
        }

        /// <summary>
        /// Sets an specific message to display.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The mode of the control.")]
        private Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
            }
        }

        /// <summary>
        /// Sets an specific message to display.
        /// </summary>
        [Bindable(true)]
        [Category("Huddle")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The mode of the control.")]
        public string Mode
        {
            get
            {
                if (string.IsNullOrEmpty(this._mode)) return ERRORMODE;
                else return this._mode;
            }
            set
            {
                _mode = value;
            }
        }
        #endregion Public Properties

        #region Init & Render
        protected override void CreateChildControls()
        {
            Table table = new Table();
            table.Width = Unit.Percentage(100);
            table.CellPadding = 0;
            table.CellSpacing = 0;
            table.BorderWidth = 0;
            table.CssClass = "error-det";

            TableRow tr = new TableRow();
            TableCell cell = new TableCell();
            cell.VerticalAlign = VerticalAlign.Middle;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Width = Unit.Pixel(3);
            if (string.Compare(Mode, WARNINGMODE, true) == 0)
            {
                _warningImg.Height = Unit.Pixel(24);
                _warningImg.Width = Unit.Pixel(24);
                cell.Controls.Add(_warningImg);
                tr.Controls.Add(cell);
                cell = new TableCell();
                cell.CssClass = "td-warning";
                cell.Controls.Add(lblMessage);
                tr.Controls.Add(cell);
                table.Controls.Add(tr);
            }
            else if (string.Compare(Mode, INFOMODE, true) == 0)
            {
                _infoImg.Height = Unit.Pixel(24);
                _infoImg.Width = Unit.Pixel(24);
                cell.Controls.Add(_infoImg);
                tr.Controls.Add(cell);
                cell = new TableCell();
                cell.CssClass = "td-carteles";
                cell.Controls.Add(lblMessage);
                tr.Controls.Add(cell);
                table.Controls.Add(tr);
            }
            else if (string.Compare(Mode, SINIMGMODE, true) == 0)
            {
                _infoImg.Height = Unit.Pixel(24);
                _infoImg.Width = Unit.Pixel(24);
                cell.Controls.Add(_SinImg);
                tr.Controls.Add(cell);
                cell = new TableCell();
                cell.CssClass = "td-carteles";
                cell.Controls.Add(lblMessage);
                tr.Controls.Add(cell);
                table.Controls.Add(tr);
            }
            else
            {
                _errorImg.Height = Unit.Pixel(24);
                _errorImg.Width = Unit.Pixel(24);
                cell.Controls.Add(_errorImg);
                tr.Controls.Add(cell);
                cell = new TableCell();
                lblnbsp.Text = "&nbsp";
                cell.Controls.Add(lblnbsp);
                tr.Controls.Add(cell);
                table.Controls.Add(tr);
                cell = new TableCell();
                cell.VerticalAlign = VerticalAlign.Top;
                cell.Controls.Add(lblMessage);
                tr.Controls.Add(cell);
                table.Controls.Add(tr);
            }
            Controls.Add(table);
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            if (this.Text.Equals(string.Empty))
            {
                if (this.Page.IsPostBack)
                {
                    int failedValidators = this.CountFailedValidators();
                    if (failedValidators > 0)
                    {
                        if (failedValidators == 1)
                        {
                            StringBuilder Mensaje = new StringBuilder();
                            Mensaje.Append("Se encontró un error de validación en los datos ingresados en el formulario. Verifique y vuelva a intentarlo.");
                            ValidatorCollection validators = this.Page.Validators;
                            if (!(validators == null && validators.Count > 0))
                            {
                                foreach (BaseValidator validator in validators)
                                {
                                    if ((!(validator.IsValid)))
                                    {
                                        Mensaje.Append("<li>");
                                        Mensaje.Append(validator.ErrorMessage);
                                        Mensaje.Append("</li>");
                                    }
                                }
                            }
                            lblMessage.Text = Mensaje.ToString();
                        }
                        else
                        {
                            StringBuilder Mensaje = new StringBuilder();
                            Mensaje.Append("Se encontraron ");
                            Mensaje.Append(failedValidators.ToString());
                            Mensaje.Append(" errores de validación de datos ingresados en el formulario. Verifique los datos y vuelva a intentarlo.");
                            Mensaje.Append("<br>");
                            ValidatorCollection validators = this.Page.Validators;
                            if (!(validators == null && validators.Count > 0))
                            {
                                foreach (BaseValidator validator in validators)
                                {
                                    if ((!(validator.IsValid)))
                                    {
                                        Mensaje.Append("<li>");
                                        Mensaje.Append(validator.ErrorMessage);
                                        Mensaje.Append("</li>");
                                    }
                                }
                            }
                            lblMessage.Text = Mensaje.ToString();
                        }
                        base.RenderContents(output);
                    }
                }
            }
            else
            {
                lblMessage.Text = this.Text;
                base.RenderContents(output);
            }
            //output.Write( Text );
        }
        #endregion Init & Render

        #region Private Methods
        /// <summary>
        /// Calculates how many validators have failed.
        /// </summary>
        /// <returns>The number of failed validators.</returns>
        private int CountFailedValidators()
        {
            ValidatorCollection validators = new ValidatorCollection();
            string validationGroup = string.Empty;
            int count = 0;
            validators = this.Page.Validators;
            if (!(validators == null && validators.Count > 0))
            {
                foreach (BaseValidator validator in validators)
                {
                    if ((!(validator.IsValid)))
                    {
                        count = count + 1;
                    }
                }
            }
            return count;
        }
        #endregion Private Methods

        #region Public Methods
        public void ShowException(Exception ex)
        {
                ExceptionTecnica ExceptionTecnica = new ExceptionTecnica();
                string CssPath = HttpContext.Current.Request.Url.AbsolutePath;
                ExceptionTecnica.GuardarLogError(ex.ToString(), CssPath);
                this.Exception = new Exception("En estos momentos no podemos procesar su solicitud. Por favor intente nuevamente." );
        }
        public void ShowException(ExceptionFuncional ex)
        {
                this.Exception = ex;
                this.Visible = true;
        }
        #endregion Public Methods
    }
}
