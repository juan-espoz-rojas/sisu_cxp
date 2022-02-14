<%@ Page Title="" 
Language="C#" 
MasterPageFile="~/SISU.Master" 
AutoEventWireup="true" 
CodeBehind="IngresoServicioUrb.aspx.cs" 
Inherits="Presentacion.Views.IngresoServicioUrb" 
MaintainScrollPositionOnPostback="true"
UICulture="es" 
Culture="es-ES"
%>

<%@ Register Assembly="Infraestructura.WebConstrols" Namespace="Infraestructura.WebConstrols" TagPrefix="cc1" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><style type="text/css">
    .auto-style1 {
        padding: 0;
        width: 50%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MessagesContent" runat="server">
    <p>
        <br />
    </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <link rel="stylesheet" media="all" href="../Resources/CSS/jquery-ui.css" />
    <script src="../Resources/Scripts/jquery.placeholder.js" type="text/javascript"></script>
    <script src="../Resources/Scripts/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    

    <ajaxToolkit:ToolkitScriptManager ID="smPage" runat="server">
        <Scripts>
            <asp:ScriptReference  Path="../Resources/Scripts/jquery-2.0.3.min.js"/>
            <asp:ScriptReference  Path="../Resources/Scripts/jquery-ui-1.10.3.min.js"/>
            <asp:ScriptReference  Path="../Resources/Scripts/jsValidacion.js"/>
            <asp:ScriptReference  Path="../Resources/Scripts/processing-1.4.1.min.js"/>
            <asp:ScriptReference  Path="../Resources/Scripts/jquery.tools.min.js"/>
        </Scripts>
    </ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript">
        function pageLoad() {
            //solamente numeros
            ValidarPegaCaracteres('txtPeso', 1, 2);
            ValidarCaractereskeypress('txtPeso', 1, 2);
            ValidarPegaCaracteres('txtAncho', 1, 2);
            ValidarCaractereskeypress('txtAncho', 1, 2);
            ValidarPegaCaracteres('txtLargo', 1, 2);
            ValidarCaractereskeypress('txtLargo', 1, 2);
            ValidarPegaCaracteres('txtAlto', 1, 2);
            ValidarCaractereskeypress('txtAlto', 1, 2);

            //numeros y guión
            ValidarPegaCaracteres('txtTelRemitente', 1, 1);
            ValidarCaractereskeypress('txtTelRemitente', 1, 1);
            ValidarPegaCaracteres('txtFonoDestino', 1, 1);
            ValidarCaractereskeypress('txtFonoDestino', 1, 1);

            //sólo letras
            ValidarPegaCaracteres('txtNomRemitente', 3, 0);
            ValidarCaractereskeypress('txtNomRemitente', 3, 0);
            ValidarPegaCaracteres('txtNomDestino', 3, 0);
            ValidarCaractereskeypress('txtNomDestino', 3, 0);

            //letras numeros y signos de puntuacion
            ValidarPegaCaracteres('txtDirDestino', 3, 2);
            ValidarCaractereskeypress('txtDirDestino', 3, 2);
            ValidarPegaCaracteres('txtDirRemitente', 3, 2);
            ValidarCaractereskeypress('txtDirRemitente', 3, 2);

            //solo emails
            ValidarPegaCaracteres('txtMailDestino', 4, 2);
            ValidarCaractereskeypress('txtMailDestino', 4, 2);

            ValidarPegaCaracteres('txtmailremitente', 4, 2);
            ValidarCaractereskeypress('txtmailremitente', 4, 2);
            Sys.Navegador.WebKit = {};
            si(navigator.userAgent.indexOf('WebKit/') > -1) {
                Sys.Browser.agente = Sys.Browser.WebKit;
                Sys.Browser.version = parseFloat(navigator.userAgent.match(/WebKit\/(\d+(\.\d+)?)/)[1]);
                Sys.Navegador.nombre = 'WebKit';
            }
        }
    </script>
    <script type = "text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
		        $(document).ready(function () {
                     $('#txtDirRemitente').autocomplete({
                         source: function (request, response) {
                             $.ajax({
                                //url: '../WebServices/ServicioDirecciones.asmx/ConsultaDirecciones',
								url:'IngresoServicioUrb.aspx/ObtieneDireccionesWS',
                                data: JSON.stringify({
                                strdirecciones: $('#txtDirRemitente').val(),
                                }),
                                dataType: 'json',
                                type: 'POST',
                                contentType: 'application/json; charset=utf-8',
                                success: function(data) {
                                response(data.d);
                                 }
                             });
                         },
                         minLength: 3
                     });
                }); 
                $('#txtPeso').focus(function() {
                    $(this).select();
                });
                $(document).ready(function () {
                    $('#txtDirDestino').autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                //url: '../WebServices/ServicioDirecciones.asmx/ConsultaDirecciones',
								url:'IngresoServicioUrb.aspx/ObtieneDireccionesWS',
                                data: JSON.stringify({
                                strdirecciones: $('#txtDirDestino').val(),
                                }),
                                dataType: 'json',
                                type: 'POST',
                                contentType: 'application/json; charset=utf-8',
                                success: function(data) {
                                    response(data.d);
                                }
                            });
                        },
                        minLength: 3
                    });
                }); 
				$(function() {
					$( document ).tooltip();
				});
        $(function() {
            $( "#accordion" ).accordion({
            active: false,
            collapsible: true
            });
            });
            } 
        });
         
    </script>
    <script type="text/javascript">
        function ConfirmarGuardar() {
            document.getElementById('btnOkGuardar').style.display = 'none';
            document.getElementById('btnCnlGuardar').style.display = 'none';
            document.getElementById('ImgLoad').style.display = 'inline';
            document.getElementById('lblGuardar').style.display = 'inline';
            document.getElementById('PanelGuardar').style.height = '150px';
        }    
    </script>

    <asp:UpdatePanel ID="UpdCargar" runat="server">
        <ContentTemplate>
            <div class="no-border">
                <cc1:FailedValidationsControl 
                    ID="MessageControl" runat="server" Width="94%" 
                    WarningImgUrl="~/Resources/Images/Warning.png"
                    ErrorImgURL="~/Resources/Images/error.png"
                    InfoImgURL = "~/Resources/Images/Info.png"/>   
            </div>
            <div id="main" class="black-background">
            <table align="center" class="no-border no-padding no-boxshadow no-borderradius widget-featured"
            style="border:none; width: 1000px;">
                <tr>
                    <td class="w-70" style="padding: 12px; vertical-align:middle">
                        Número de TCC:
                        <asp:Label ID="lblNroTcc" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="w-30 tright" 
                        style="padding: 12px; vertical-align: middle;" rowspan="2">
                        <asp:LinkButton ID="btnNuevoEnvio" runat="server" 
                            class="btn btn-Medium btn-primary black" onclick="btnNuevoEnvio_Click">
                            <div class="icon icon-box-fast icon-left"></div>Nuevo Envío
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnNuevaTcc" class="btn btn-Medium btn-primary black"  
                            runat="server" onclick="btnNuevaTcc_Click" >
                            <div class="icon icon-credit icon-left"></div>Nueva TCC
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="w-70" style="padding: 12px; vertical-align:top">
                        Nombre TCC:
                        <asp:Label ID="lblNombreTcc" runat="server" Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblMailRemitente" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
           <br />
            <table runat="server" ID="Tab_Banner1" align="center"
            class="no-border no-padding no-boxshadow no-borderradius" 
            style="border:none; width: 1000px;">
                <tr>
                    <td class="no-padding">
                        <div class="row">
                            <div class="banner-sending  step1 tcenter">
                                <div class="banner-sending-button left">
                                    <span class="aux aux-arrow">flecha</span>
                                        <i class="icon icon-cxp-iso"></i>
                                        Producto
                                </div>
                                <div class="banner-sending-button middle desactive">
                                <span class="aux aux-arrow">flecha</span>
                                <i class="icon icon-truck"></i>
                                Retiro
                                </div>
                                <div class="banner-sending-button right desactive">
                                    <span class="aux aux-arrow">flecha</span>
                                    <i class="icon icon-user"></i>
                                    Destino
                                </div>
                            </div>
			            </div>
                    </td>
                </tr>
            </table>
            <table runat="server" ID="Tab_Banner2" align="center"
            class="no-border no-padding no-boxshadow no-borderradius" 
            style="border:none; width: 1000px;">
                <tr>
                    <td class="no-padding">
                        <div class="row">
                            <div class="banner-sending step2 tcenter">
                                <div class="banner-sending-button left active">
                                    <span class="aux aux-arrow">flecha</span>
                                        <div runat="server" id="P1_ImgProducto"></div>
                                        <span class="defined">
                                            <strong><asp:Label ID="P1_txtProducto" runat="server"></asp:Label></strong>
                                            <br>
                                            <i class="icon-weight"></i>
                                            <asp:Label ID="P1_lblPesoPdto" runat="server" Text=""></asp:Label>&nbsp;
                                            <i class="icon-measure"></i>
                                            <asp:Label ID="P1_lblDimensionesPdto" runat="server" Text=""></asp:Label>
                                        </span>
                                </div>
                                <div class="banner-sending-button middle active">
                                <span class="aux aux-arrow">flecha</span>
                                <i class="icon icon-truck"></i>
                                Retiro
                                </div>
                                <div class="banner-sending-button right desactive">
                                    <span class="aux aux-arrow">flecha</span>
                                    <i class="icon icon-user"></i>
                                    Destino
                                </div>
                            </div>
			            </div>
                    </td>
                </tr>
            </table>
            <table runat="server" ID="Tab_Banner3" align="center"
            class="no-border no-padding no-boxshadow no-borderradius" 
            style="border:none; width: 1000px;">
                <tr>
                    <td class="no-padding">
                        <div class="row">
                            <div class="banner-sending step3 tcenter">
                                <div class="banner-sending-button left active">
                                    <span class="aux aux-arrow">flecha</span>
                                    <div runat="server" id="P2_ImgProducto"></div>
                                     <span class="defined">
                                        <strong><asp:Label ID="P2_txtProducto" runat="server"></asp:Label></strong>
                                        <br>
                                            <i class="icon-weight"></i>
                                            <asp:Label ID="P2_lblPesoPdto" runat="server" Text=""></asp:Label>&nbsp;
                                            <i class="icon-measure"></i>
                                            <asp:Label ID="P2_lblDimensionesPdto" runat="server" Text=""></asp:Label>
                                        </span>
                                </div>

                                <div class="banner-sending-button middle active">
                                <span class="aux aux-arrow">flecha</span>
                                <i class="icon icon-truck"></i>
                                    <span class="defined">
                                    <strong>
                                        <asp:Label ID="P2_txtRemitente" runat="server"></asp:Label></strong>
                                    <br>
                                    <i class="icon-location"></i>
                                    <asp:Label ID="P2_txtDirRetiro" runat="server"></asp:Label>
                                    </span>
                                </div>

                                <div class="banner-sending-button right active">
                                    <span class="aux aux-arrow">flecha</span>
                                    <i class="icon icon-user"></i>
                                    Destino
                                </div>
                            </div>
			            </div>
                    </td>
                </tr>
            </table>
            <table runat="server" ID="Tab_Banner4" align="center"
            class="no-border no-padding no-boxshadow no-borderradius" 
            style="border:none; width: 1000px;">
                <tr>
                    <td class="no-padding">
                        <div class="row">
                            <div class="banner-sending tcenter">
                                <div class="banner-sending-button left active">
                                    <span class="aux aux-arrow">flecha</span>
                                    <div runat="server" id="P3_ImgProducto" class="icon icon-box-fast"></div>
                                     <span class="defined">
                                        <strong><asp:Label ID="P3_txtProducto" runat="server" Text="Sobre"></asp:Label></strong>
                                        <br>
                                        <i class="icon-weight"></i>
                                        <asp:Label ID="P3_lblPesoPdto" runat="server" Text=""></asp:Label>&nbsp;
                                        <i class="icon-measure"></i>
                                        <asp:Label ID="P3_lblDimensionesPdto" runat="server" Text=""></asp:Label>
                                     </span>
                                </div>

                                <div class="banner-sending-button middle active">
                                <span class="aux aux-arrow">flecha</span>
                                <i class="icon icon-truck"></i>
                                    <span class="defined">
                                    <strong>
                                        <asp:Label ID="P3_txtRemitente" runat="server"></asp:Label></strong>
                                    <br>
                                    <i class="icon-location"></i>
                                    <asp:Label ID="P3_txtDirRetiro" runat="server"></asp:Label>
                                    </span>
                                </div>

                                <div class="banner-sending-button right active">
                                    <span class="aux ">flecha</span>
                                    <i class="icon icon-user"></i>
                                    <span class="defined">
                                    <strong>
                                        <asp:Label ID="P3_txtDestinatario" runat="server"></asp:Label></strong>
                                    <br>
                                    <i class="icon-location"></i>
                                    <asp:Label ID="P3_txtDirDestino" runat="server" ></asp:Label>
                                    </span>
                                </div>
                            </div>
			            </div>
                    </td>
                </tr>
            </table>

            <table runat="server" ID="Tab_Paso1" align="center"
            class="no-border no-padding no-boxshadow no-borderradius" 
            style="border:none; width: 1000px;">
                <tr>
                    <td class="no-padding">
                        <div class="container">
                            <div class="row">
                                <div class="box-features box-empresas widget-featured">
                                    <div class=" box-features-content">
							            <h2 class="feature-title">¿qué quieres enviar?</h2>

                                        <asp:GridView ID="gvProductos" runat="server" CssClass="no-border" style="border:none; width: auto;"
                                        runat="server" AutoGenerateColumns="False" ShowHeader="False" 
                                            onrowdatabound="gvProductos_RowDataBound">
                                            <Columns>
                                               <asp:TemplateField >
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbProducto" runat="server"  style="width:300px"
                                                        onclick="lbProducto_Click" class="btn btn-large btn-wide btn-primary black"/>
                                                        <%--Text='<%# DataBinder.Eval(Container, "DataItem.Gls_producto")%>' --%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
						            </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr> 
            </table>
            <table runat="server" ID="Tab_Paso2" align="center"
            class="no-border no-padding no-boxshadow no-borderradius widget-featured" 
            style="border:none; width: 1000px;">
                <tr>
                    <td class="no-padding w50">
                        <div class="container widget">
                            <div class="row">
                                <div class="box-features-content">
                                    <h2 class="feature-title">¿cuánto pesa?</h2>
                                    <asp:TextBox ID="txtBoundPeso" runat="server" Width="1px"></asp:TextBox>
                                    <asp:TextBox CssClass="range" ID="txtPeso" runat="server" ClientIDMode="Static" 
                                        MaxLength="5"></asp:TextBox>
                                    <ajaxToolkit:SliderExtender ID="txtPeso_Slider" runat="server" Enabled="True" 
                                        Length="450" Maximum="50" Minimum="0.1" Steps="49" TargetControlID="txtBoundPeso" 
                                        BoundControlID="txtPeso" Decimals="1" >
                                    </ajaxToolkit:SliderExtender>
                                    <span class="unit">kilos de peso:</span>
                                </div>
                           </div>
                        </div>
                    </td>
                    <td  class="no-padding w50 box">
                        <div class="container widget">
                            <div class="row">
                                <div class="box-features-content">
                                    <h2 class="feature-title">¿cuánto mide?</h2>
                                        <asp:TextBox ID="txtBoundAncho" runat="server" Width="1px"></asp:TextBox>
                                        <asp:TextBox CssClass="range" ID="txtAncho" runat="server" 
                                        ClientIDMode="Static" MaxLength="5"></asp:TextBox>
                                        <ajaxToolkit:SliderExtender ID="txtAncho_Slider" runat="server" Enabled="True" 
                                        Length="450" Maximum="100" Minimum="1" Steps="99" TargetControlID="txtBoundAncho" 
                                        BoundControlID="txtAncho">
                                        </ajaxToolkit:SliderExtender>
                                        <span class="unit">cm. de ancho:</span> 
                                        <br /><br /><br />
                                        <asp:TextBox ID="txtBoundLargo" runat="server" Width="1px"></asp:TextBox>
                                        <asp:TextBox CssClass="range" ID="txtLargo" runat="server" 
                                        ClientIDMode="Static" MaxLength="5"></asp:TextBox>
                                        <ajaxToolkit:SliderExtender ID="txtLargo_Slider" runat="server" Enabled="True" 
                                        Length="450" Maximum="100" Minimum="1" Steps="99" TargetControlID="txtBoundLargo" 
                                        BoundControlID="txtLargo">
                                        </ajaxToolkit:SliderExtender>
                                        <span class="unit">cm. de largo:</span>
                                        <br /><br /><br />
                                        <asp:TextBox ID="txtBoundAlto" runat="server" Width="1px"></asp:TextBox>
                                        <asp:TextBox CssClass="range" ID="txtAlto" runat="server" 
                                        ClientIDMode="Static" MaxLength="5"></asp:TextBox>
                                        <ajaxToolkit:SliderExtender ID="txtAlto_Slider" runat="server" Enabled="True" 
                                        Length="450" Maximum="100" Minimum="1" Steps="99" TargetControlID="txtBoundAlto" 
                                        BoundControlID="txtAlto" >
                                        </ajaxToolkit:SliderExtender>
                                        <span class="unit">cm. de alto:</span>
                                </div>
                            </div>
                        </div>
                        
                    </td>
                </tr>
                <tr>
                <td class="no-padding">
                        <div class="feature-services box-features-content text-left">
                            <asp:LinkButton ID="BtnAnteriorPaso2" class="btn  btn-Medium"  
                                runat="server" onclick="BtnAnteriorPaso2_Click">
                                &nbsp;
                            <div class="icon icon-caret-left icon-left"></div>
                             anterior
                           </asp:LinkButton>
                            </div>
                    </td>
                    <td class="no-padding" >
                        <div class="feature-services box-features-content tright">
                            <asp:LinkButton ID="BtnSiguientePaso2" class="btn  btn-Medium"  
                                runat="server" onclick="BtnSiguientePaso2_Click">
                                siguiente
                                <div class="icon icon-caret-right icon-right"></div>
                            </asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="PnlPaso3" runat="server" DefaultButton="BtnSiguientePaso3" >
            <table runat="server" ID="Tab_Paso3" align="center"
            class="no-border no-padding no-boxshadow no-borderradius widget-featured" 
            style="border:none; width: 1000px;">
                <tr>
                    <td class="w-50">
                        <div class="container widget">
                            <div class="row">
                                <div class="box-features-content">
                                    <h2 
                                        class="feature-title">¿dónde retiramos?
                                    </h2>
 <!-- jcrh dir="rtl"-->                               
                                    <h3  align="center" class="RadioButton">
                                        <asp:RadioButton ID="RBofcomercial" 
                                            runat="server" 
                                            Font-Size="Medium" 
                                            AutoPostBack="true"
                                            OnCheckedChanged="RBofcomercial_clik" 
                                            OnSelectedIndexChanged="RBofcomercial_clik" 
                                            Text="Oficina Comercial" Checked="True" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


                                         <asp:RadioButton ID="RBdomicilio" 
                                             runat="server" 
                                             Font-Size="Medium" 
                                             AutoPostBack="true"
                                             OnCheckedChanged="RBdomicilio_clik" 
                                             OnSelectedIndexChanged="RBdomicilio_clik" 
                                             Text="Domicilio" />
                                    </h3>   

                                        
                                    <h3 align="center" class="ComboBox">
                                        <asp:DropDownList ID="ComboBox1" 
                                            runat="server" 
                                            EmptyMessage="" 
                                            EnableLoadOnDemand="True" 
                                            EnableVirtualScrolling="true" 
                                            Font-Size="Medium" 
                                            Height="30px" 
                                            OnItemsRequested="RadComboBox1_ItemsRequested" 
                                            RenderMode="Lightweight" 
                                            ShowMoreResultsBox="true" 
                                            Visible="False" 
                                            Width="180px" 
                                             AutoPostBack="True" OnSelectedIndexChanged="CargaOfiComerciales_click">
                                        </asp:DropDownList>

                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="ComboBox2" 
                                            runat="server" EmptyMessage="" 
                                            EnableLoadOnDemand="True" 
                                            EnableVirtualScrolling="true" 
                                            Font-Size="Medium" 
                                            Height="30px" 
                                            OnItemsRequested="RadComboBox2_ItemsRequested" 
                                            RenderMode="Lightweight" 
                                            ShowMoreResultsBox="true" 
                                            Visible="False" 
                                            Width="180px" AutoPostBack="True" OnSelectedIndexChanged="CargaDirreccionOfCom">
                                        </asp:DropDownList>
                                    </h3>


                                    <asp:TextBox ID="txtDirRemitente" 
                                                runat="server" 
                                                ClientIDMode="Static" 
                                                CssClass="w-100 uppercase" 
                                                MaxLength="250" 
                                                placeholder="Calle, Número, Comuna">
                                    </asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfv_DirRemitente" 
                                        runat="server" 
                                        ControlToValidate="txtDirRemitente" 
                                        Display="None" 
                                        ErrorMessage="Indique dirección de retiro." 
                                        ValidationGroup="GroupPaso3">
                                    </asp:RequiredFieldValidator>

                                    <ajaxToolkit:ValidatorCalloutExtender 
                                        ID="rfv_DirRemitente_VCE" 
                                        runat="server" 
                                        Enabled="True" 
                                        PopupPosition="BottomRight" 
                                        TargetControlID="rfv_DirRemitente" 
                                        WarningIconImageUrl="~/Resources/Images/warn.png" 
                                        Width="200px"> 
                                    </ajaxToolkit:ValidatorCalloutExtender>

                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtComplementoRemitente" runat="server" ClientIDMode="Static" CssClass="w-100 uppercase" MaxLength="50" placeholder="Complemento"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtNomRemitente" runat="server" ClientIDMode="Static" CssClass="w-100 uppercase" MaxLength="40" placeholder="Nombre o Contacto de Retiro"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNomRemitente" runat="server" ControlToValidate="txtNomRemitente" Display="None" ErrorMessage="Indique nombre de contacto." ValidationGroup="GroupPaso3"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfvNomRemitente_VCE" runat="server" Enabled="True" PopupPosition="BottomRight" TargetControlID="rfvNomRemitente" WarningIconImageUrl="~/Resources/Images/warn.png" Width="200px"> </ajaxToolkit:ValidatorCalloutExtender>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtTelRemitente" runat="server" ClientIDMode="Static" CssClass="w50 uppercase" MaxLength="15" placeholder="Teléfono"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_FonoRemitente" runat="server" ControlToValidate="txtTelRemitente" Display="None" ErrorMessage="Indique el teléfono de retiro." ValidationGroup="GroupPaso3"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfv_FonoRemitente_VCE" runat="server" Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv_FonoRemitente" WarningIconImageUrl="~/Resources/Images/warn.png" Width="200px">
                                    </ajaxToolkit:ValidatorCalloutExtender>

<!--jcrh-->
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtmailremitente" runat="server" ClientIDMode="Static" CssClass="w50 uppercase" MaxLength="50" placeholder="Correo Electrónico" Width="500px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_MailRemitente" runat="server" ControlToValidate="txtmailremitente" Display="None" ErrorMessage="Indique el correo de contacto." ValidationGroup="GroupPaso3"></asp:RequiredFieldValidator>
                                    
                                    	<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="txtmailremitente" ErrorMessage="Formato de correo no valido" 
										ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GroupPaso3"></asp:regularexpressionvalidator>

                                        
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv_MailRemitente" WarningIconImageUrl="~/Resources/Images/warn.png" Width="200px">
                                        </ajaxToolkit:ValidatorCalloutExtender>
 <!--jcrh   
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                            

                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
                                        <h3></h3>
    -->                                

                                </div>
                            </div>
                        </div>
                    </td>
                    <td class="w-50">
                        <div class="container widget Horizontalpadding">
                        <br /><br /><br /><br />
                                    <div id="accordion">
                                    <h3><i>tus direcciones anteriores:</i></h3>
                                    <asp:GridView class="table-striped table-hover ultrasmall w-100" ID="gvDireccionesRetiro" 
                                        runat="server" AutoGenerateColumns="False" ShowHeader="False" OnRowCommand="Option">
                                        <Columns>
                                            <asp:TemplateField >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDirRetiro" runat="server" 
                                                    onclick="lnkDirRetiro_Click" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.NombreContacto")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField >
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldirRetGrid" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.DireccionCompleta")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                            
                        </div>
                    </td>
                </tr>
                <tr>
                     <td class="auto-style1">
                        <div class="feature-services box-features-content text-left">
                            <asp:LinkButton ID="BtnAnteriorPaso3" class="btn  btn-Medium"  
                                runat="server" onclick="BtnAnteriorPaso3_Click">
                                &nbsp;
                                <div class="icon icon-caret-left icon-left"></div>
                                 anterior
                            </asp:LinkButton>
                        </div>
                    </td>
                   <td class="no-padding">
                        <div class="feature-services box-features-content tright">
                            <asp:LinkButton ID="BtnSiguientePaso3" class="btn  btn-Medium"  
                                runat="server" onclick="BtnSiguientePaso3_Click" 
                                ValidationGroup="GroupPaso3">
                                siguiente
                                <div class="icon icon-caret-right icon-right"></div>
                            </asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="PnlPaso4" runat="server" DefaultButton="BtnSiguientePaso4" >
            <table runat="server" ID="Tab_Paso4" align="center"
            class="no-border no-padding no-boxshadow no-borderradius widget-featured" 
            style="border:none; width: 1000px;">
                <tr>
                     <td class="w-50">
                        <div class="container widget">
                            <div class="row">
                                <div class="box-features-content">
                                    <h2 class="feature-title">¿dónde entregamos?</h2>

                                        <h3  align="center" class="RadioButton">
                                            <asp:RadioButton ID="RBOf" 
                                                runat="server" 
                                                Font-Size="Medium" 
                                                AutoPostBack="true"
                                                Text="Oficina Comercial"
                                                OnCheckedChanged="RBOf_clik" 
                                                OnSelectedIndexChanged="RBOf_clik" Checked="True"  />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


                                             <asp:RadioButton ID="RBDom" 
                                                 runat="server" 
                                                 Font-Size="Medium" 
                                                 AutoPostBack="true"
                                                 Text="Domicilio"
                                                 OnCheckedChanged="RBDom_clik" 
                                                 OnSelectedIndexChanged="RBDom_clik"  />
                                        </h3> 

                                        <h3 align="center" class="ComboBox">
                                            <asp:DropDownList ID="ComboBox3" 
                                                runat="server" 
                                                EmptyMessage="" 
                                                EnableLoadOnDemand="True" 
                                                EnableVirtualScrolling="true" 
                                                Font-Size="Medium" 
                                                Height="30px" 
                                                OnItemsRequested="RadComboBox3_ItemsRequested" 
                                                RenderMode="Lightweight" 
                                                ShowMoreResultsBox="true" 
                                                Visible="False" 
                                                Width="180px" 
                                                 AutoPostBack="True" OnSelectedIndexChanged="CargaOfiComerciales3_click">
                                            </asp:DropDownList>

                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="Combobox4" 
                                                runat="server" EmptyMessage="" 
                                                EnableLoadOnDemand="True" 
                                                EnableVirtualScrolling="true" 
                                                Font-Size="Medium" 
                                                Height="30px" 
                                                OnItemsRequested="RadComboBox4_ItemsRequested" 
                                                RenderMode="Lightweight" 
                                                ShowMoreResultsBox="true" 
                                                Visible="False" 
                                                Width="180px" AutoPostBack="True" OnSelectedIndexChanged="CargaDirreccionOfCom4">
                                            </asp:DropDownList>
                                        </h3>


                                    <asp:TextBox CssClass="w-100 uppercase" ID="txtDirDestino" runat="server" 
                                        placeholder="Calle, Número, Comuna" ClientIDMode="Static" 
                                        MaxLength="250" ></asp:TextBox>
                                    <br />


                                    <asp:RequiredFieldValidator ID="rfvDirDestino" runat="server" 
                                        ControlToValidate="txtDirDestino" Display="None" 
                                        ErrorMessage="Indique la dirección de destino." 
                                        ValidationGroup="GroupPaso4"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfvDirDestino_VCE" runat="server" WarningIconImageUrl="~/Resources/Images/warn.png"
                                        Width="200px" Enabled="True" TargetControlID="rfvDirDestino">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <br />
									<asp:TextBox CssClass="w-100 uppercase" ID="txtComplementoDestino" runat="server"
										placeholder="Complemento" ClientIDMode="Static" MaxLength="50"></asp:TextBox>
									<br />
									<br />									
                                    <asp:TextBox CssClass="w-100 uppercase" ID="txtNomDestino" runat="server" 
                                        placeholder="Nombre o Contacto del Destinatario" ClientIDMode="Static" 
                                        MaxLength="40" ></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvNomDestino" runat="server" 
                                        ControlToValidate="txtNomDestino" Display="None" 
                                        ErrorMessage="Indique el nombre de contacto." ValidationGroup="GroupPaso4"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfvNomDestino_VCE" runat="server" WarningIconImageUrl="~/Resources/Images/warn.png"
                                        Width="200px" Enabled="True" TargetControlID="rfvNomDestino">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <br />
                                    <asp:TextBox CssClass="w50 uppercase" ID="txtFonoDestino" runat="server" 
                                        placeholder="Teléfono" ClientIDMode="Static" MaxLength="15" ></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvFonoDestino" runat="server" 
                                        ControlToValidate="txtFonoDestino" Display="None" 
                                        ErrorMessage="Indique el teléfono de destino." 
                                        ValidationGroup="GroupPaso4"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfvFonoDestino_VCE" runat="server" WarningIconImageUrl="~/Resources/Images/warn.png"
                                        Width="200px" Enabled="True" TargetControlID="rfvFonoDestino">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <br />
                                    <asp:TextBox CssClass="w-100 uppercase" ID="txtMailDestino" runat="server" 
                                        placeholder="Correo electrónico" ClientIDMode="Static" MaxLength="200" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMailDestino" runat="server" 
                                        ControlToValidate="txtMailDestino" Display="None"
                                        ErrorMessage="Indique el mail del destinatario."
                                        ValidationGroup="GroupPaso4"></asp:RequiredFieldValidator>
									<asp:regularexpressionvalidator id="revEmail" runat="server" ControlToValidate="txtMailDestino" ErrorMessage="Formato de correo no valido" 
										ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GroupPaso4"></asp:regularexpressionvalidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfvMailDestino_VCE" runat="server"  WarningIconImageUrl="~/Resources/Images/warn.png"
                                        Width="200px" Enabled="True" TargetControlID="rfvMailDestino">
                                    </ajaxToolkit:ValidatorCalloutExtender>
									<ajaxToolkit:ValidatorCalloutExtender ID="rfvMailDestino_2" runat="server"  WarningIconImageUrl="~/Resources/Images/warn.png"
                                        Width="200px" Enabled="True" TargetControlID="revEmail">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                        </div>
                    </td>
                     <td class="w-50">
                        <div class="container widget Horizontalpadding">
                                <br /><br /><br /><br />
                                <div id="accordion">
                                    <h3><i>tus direcciones anteriores:</i></h3>
                                    <asp:GridView class="table-striped table-hover ultrasmall w-100" ID="gvDireccionesEntrega" 
                                        runat="server" AutoGenerateColumns="False" ShowHeader="false" OnRowCommand="Option1">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDirDestino" runat="server" 
                                                    onclick="lnkDirDestino_Click" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.NombreContacto")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkDirDestComp" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.DireccionCompleta")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                        </div>
                    </td>
                </tr>
                <tr>
                     <td class="no-padding">
                        <div class="feature-services box-features-content text-left">
                            <asp:LinkButton ID="BtnAnteriorPaso4" class="btn  btn-Medium"  
                                runat="server" onclick="BtnAnteriorPaso4_Click">
                            &nbsp;
                            <div class="icon icon-caret-left icon-left"></div>
                             anterior
                            </asp:LinkButton>
                       </div>
                    </td>
                   <td class="no-padding">
                        <div class="feature-services box-features-content tright">
                            <asp:LinkButton ID="BtnSiguientePaso4" class="btn  btn-Medium"  
                                runat="server" onclick="BtnSiguientePaso4_Click" 
                                ValidationGroup="GroupPaso4">
                                siguiente
                                <div class="icon icon-caret-right icon-right"></div>
                            </asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="PnlPaso5" runat="server"  DefaultButton="btnConfirmar">
            <table runat="server" ID="Tab_Pago" align="center"
            class="no-border no-padding no-boxshadow no-borderradius widget-featured" 
            style="border:none; width: 1000px;">
                <tr>
                    <td colspan="2">
                        <div class="container widget">
                            <div class="box-features-content">
                                <h2 class="feature-title">¿cuándo lo entregamos?</h2>
                                <asp:RadioButtonList ID="rblTarifas" runat="server" 
                                    CssClass="table-striped table-hover small" style="width:95%;" align="center" 
                                    AutoPostBack="True" onselectedindexchanged="rblTarifas_SelectedIndexChanged" 
                                    ViewStateMode="Enabled">
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="no-padding" style="padding: 20px; background-color: #F2F2F2; vertical-align: middle;">
                         <div class="price left tleft">
                            <i class="icon icon-money FontSize400"></i><asp:Label ID="lblValorTotal" runat="server" CssClass="cost">Sin valorizar</asp:Label>
                           </div>
                    </td>
                    <td class="no-padding" 
                        style="padding: 20px; background-color: #F2F2F2; text-align: right;">
                            <asp:Button CssClass="btn  btn-large" ID="btnConfirmar" 
                                runat="server" Text="confirmar el servicio" Height="65px" 
                                onclick="btnConfirmar_Click" />
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <br />
            </div>
            <ajaxToolkit:ModalPopupExtender ID="ModalGuardar" runat="server" BackgroundCssClass="modalBackground" TargetControlID="hbtnGuardar" PopupControlID="PanelGuardar" CancelControlID="btnCnlGuardar" />
            <asp:Button ID="hbtnGuardar" runat="server" style="display:none;" />
            <asp:Panel runat="server" ClientIDMode="Static" ID="PanelGuardar" style="display:none; width: 300px;height: 120px;background-color: #F2F2F2; border: 1px solid #E8A81B;">
                <section class="widget">
                    <div class="widget-content">
                        <div  class="widget-alpha-background hentry">
                            <div class="section-title bold" style="background-color: #E8A81B">
                            &nbsp;<i class="icon icon-help"></i>&nbsp;Guardar
                            </div>
                            <div class="tcenter">
                            <p >¿Desea registrar el servicio urbano?</p>
                            <asp:Button ID="btnOkGuardar" runat="server" Text="Aceptar" CssClass="btn btn-small" 
                            ClientIDMode="Static"  OnClientClick="return ConfirmarGuardar();" 
                            onclick="btnOkGuardar_Click"/>&nbsp;&nbsp;
                            <asp:Button ID="btnCnlGuardar" runat="server" Text="Cancelar" CssClass="btn btn-small" ClientIDMode="Static"/><br />
                            <asp:Label ID="lblGuardar" runat="server" Text="guardando" ClientIDMode="Static" style="display:none"></asp:Label><br />
                            <img src="../Resources/Images/Loading.gif" style="display:none" id="ImgLoad" ClientIDMode="Static"/><br />
                            </div>
                        </div>
                    </div>
                </section>
            </asp:Panel>


            <ajaxToolkit:ModalPopupExtender ID="ModalRegistro" runat="server" BackgroundCssClass="modalBackground" TargetControlID="hbtnRegistro" PopupControlID="PanelRegistro" />
            <asp:Button ID="hbtnRegistro" runat="server" style="display:none;" />
            <asp:Panel runat="server" ClientIDMode="Static" ID="PanelRegistro" style="display:none; width: 550px;height: 190px;background-color: #F2F2F2; border: 1px solid #E8A81B;">
                <section class="widget">
                    <div class="widget-content">
                        <div  class="widget-alpha-background hentry">
                            <div class="section-title bold" style="background-color: #E8A81B">
                            &nbsp;<i class="icon icon-ok"></i>&nbsp;Información
                            </div>
                            <div class="tleft">
                            <br />
                            <p >&nbsp;&nbsp;El servicio solicitado ha sido registrado exitosamente con los siguentes datos:
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;Orden de retiro N°: <strong><asp:Label ID="lblNroRetiro" runat="server" Text=""></asp:Label></strong>
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;Orden de transporte N°: <strong><asp:Label ID="lblNroot" runat="server" Text=""></asp:Label></strong>
                            </p><br />
                            <div class="tcenter">
                            <asp:Button ID="btnFTCC" runat="server" CssClass="btn btn-small" 
                                    ClientIDMode="Static" Text="Seleccionar otra tcc" onclick="btnFTCC_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnFServ" runat="server" CssClass="btn btn-small" 
                                    ClientIDMode="Static" Text="Ingresar nuevo servicio" onclick="btnFServ_Click"/><br/>
                            </div>
                            </div>
                        </div>
                    </div>
                </section>
            </asp:Panel>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnAnteriorPaso2" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnAnteriorPaso3" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnAnteriorPaso4" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnSiguientePaso2" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnSiguientePaso3" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnSiguientePaso4" EventName="Click" />
<%--            <asp:AsyncPostBackTrigger ControlID="lnkDirRetiro" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lnkDirDestino" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="btnConfirmar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="rblTarifas" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

        <%--bug scrolll bar--%>

    <script type="text/javascript" language="javascript">
        Sys.UI.Point = function Sys$UI$Point(x, y) {
            x = Math.round(x);
            y = Math.round(y);
            var e = Function._validateParams(arguments, [
                { name: "x", type: Number, integer: true },
                { name: "y", type: Number, integer: true }
            ]);
            if (e) throw e;
            this.x = x;
            this.y = y;
        }
    </script>

</asp:Content>

