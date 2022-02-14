<%@ Page Title="" Language="C#" 
MasterPageFile="~/SISU.Master" 
AutoEventWireup="true" 
CodeBehind="TCCs.aspx.cs" 
Inherits="Presentacion.Views.TCCs" 
MaintainScrollPositionOnPostback="true"
UICulture="es" 
Culture="es-ES"
%>

<%@ Register Assembly="Infraestructura.WebConstrols" Namespace="Infraestructura.WebConstrols" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MessagesContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="smPage" runat="server">
        <Scripts>
            <asp:ScriptReference  Path="~/Resources/Scripts/jquery-2.0.3.min.js"/>
            <asp:ScriptReference  Path="~/Resources/Scripts/jsValidacion.js"/>
        </Scripts>
    </ajaxToolkit:ToolkitScriptManager>

    <script type="text/javascript">
        function pageLoad() {
            ValidarPegaCaracteres('txtBuscarTCC', 1, 0);
            ValidarCaractereskeypress('txtBuscarTCC', 1, 0);
            ValidarPegaCaracteres('txtBuscarRut', 1, 0);
            ValidarCaractereskeypress('txtBuscarRut', 1, 0);
            //solo emails
            ValidarPegaCaracteres('txtMail', 4, 2);
            ValidarCaractereskeypress('txtMail', 4, 2);
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
                <table align="center" class="no-border widget-featured" style="border:none; width:1000px">
                    <tr>
                    <td>
                    
                    </td>
                    </tr>
                    <tr>
                    <td class="no-padding tcenter">
                        <asp:Panel ID="Panel3"  runat="server" DefaultButton="btn">
                            <table style="border:none;width: 100%;" class="no-boxshadow no-padding no-border" >
                            <tr>
                            <td class="tright no-padding" style="width:33%;vertical-align: middle;">
                                Correo electrónico</td>
                            <td class=" tleft no-padding" style="width:66% ;vertical-align: middle; padding-left:60px">
                                <asp:TextBox ID="txtMail" runat="server" Width="400px" ClientIDMode="Static" CssClass="uppercase"
                                    MaxLength="200"></asp:TextBox>
                            </td>
                            </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    </tr>
                    <tr>
                        <td class="tcenter no-padding">
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="btn">

                            <table style="border:none;width: 100%;" 
                                    class="no-boxshadow no-padding no-border" >
                                <tr>
                                    <td class="tright no-padding" style="width:33% ;vertical-align: middle;">
                                        <asp:Label ID="Label2" runat="server" Text="Número TCC"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfvNroTcc" runat="server" 
                                            ControlToValidate="txtBuscarTCC" CssClass="bold " ErrorMessage="(*)" 
                                            ForeColor="#FF3300" Text="(*)" ValidationGroup="SUGroup"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="tcenter no-padding" style="width:33% ;vertical-align: middle;">
                                        <asp:TextBox ID="txtBuscarTCC" runat="server" class="input-append" 
                                            ClientIDMode="Static" MaxLength="10"  Width="200px"></asp:TextBox>
                                    </td>
                                    <td class="tleft no-padding" style="width:33% ;vertical-align: middle;">
                                        <asp:Button ID="btn" runat="server" class="btn btn-Huge" ClientIDMode="Static" 
                                            onclick="btn_Click" Text="Solicitar SU" ValidationGroup="SUGroup" />
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>

                            </td>
                    </tr>
                    <tr>
                        <td class="tcenter no-padding">
                            
                            <asp:Panel ID="Panel2" runat="server" DefaultButton="btnBuscar">
                            <table style="border:none;width: 100%;" 
                                    class="no-boxshadow no-padding no-border">
                            <tr>
                            <td class="tright no-padding" style="width:33% ;vertical-align: middle;">
                            <asp:Label ID="Label1" runat="server" Text="Número RUT"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvtxtBuscarRut" runat="server" 
                                    ControlToValidate="txtBuscarRut" Text="(*)" ErrorMessage="(*)"
                                ValidationGroup="BuscarGroup" CssClass="bold " ForeColor="#FF3300"></asp:RequiredFieldValidator>
                           
                           </td>
                            <td class="tcenter no-padding" style="width:33% ;vertical-align: middle;">


                            <asp:TextBox ID="txtBuscarRut" runat="server" class="input-append" 
                                ClientIDMode="Static" MaxLength="8"  
                                ValidationGroup="BuscarGroup" Width="200px"></asp:TextBox>
                            

                            </td>
                            <td class="tleft no-padding" style="width:33% ;vertical-align: middle;">

                            <asp:Button ID="btnBuscar" runat="server" class="btn btn-Huge" 
                                ClientIDMode="Static" onclick="btnBuscar_Click" Text="Buscar TCC's" 
                                ValidationGroup="BuscarGroup" />
                                </td>
                            </tr>
                            </table>
                            </asp:Panel>

                            </td>
                    </tr>
                    <tr>
                        <td class="tcenter" style="text-align: center">
                            <br />
                            <asp:GridView class="table-striped table-hover widget" ID="gvTCCs" 
                                runat="server" AutoGenerateColumns="False" Width="980px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Nombre TCC" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkNombreTcc" runat="server" 
                                            onclick="lnkNombreTcc_Click" 
                                            Text='<%# DataBinder.Eval(Container, "DataItem.Gls_nombre_tarjeta")%>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Nro. TCC" DataField="Num_tarjeta" >
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Giro Comercial" DataField="Glosa_Giro" ><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /></asp:BoundField>
                                    <asp:BoundField HeaderText="Estado TCC" DataField="Glosa_Estado" ><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
