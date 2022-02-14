<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Presentacion.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
	    <title>Chilexpress: Portal de Personas</title>

        <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,800,700italic,700' rel='stylesheet' type='text/css'>
        <link rel="stylesheet" media="all" href="~/Resources/CSS/style.css">
        <link rel="stylesheet" media="all" href="~/Resources/CSS/icons/style.css">

        <script src="https://cdn.jsdelivr.net/gh/google/code-prettify@master/loader/run_prettify.js"></script>
        <script src="~/Resources/Scripts/jquery-2.0.3.min.js" type="text/javascript"></script>
        <script src="~/Resources/Scripts/jquery.hammer.min.js" type="text/javascript"></script>
        <script src="~/Resources/Scripts/responsiveCarousel.min.js" type="text/javascript"></script>
        <script src="~/Resources/Scripts/range.js" type="text/javascript"></script>
       <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <form id="Formulario" runat="server">
        <header id="header">   
            <div class="container">
                <div class="row">
                    <table style="border-style: none; width:1000px" align="center">
                        <tr>
                            <td style="border-style: none; width:65%" rowspan="2" >
                                <div >
                                    <h1 class="logo logo-cxp black">Chilexpress</h1>
                                    <h1>Sistema de Ingreso de Servicios Urbanos</h1>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </header>
        <div class="container">
            <div class="row">
                    <div class="row small">
                    <table class="no-border" style="border-style: none;width: 100%; height:500px"> <%--no-boxshadow--%>
                        <tr>
                            <td class="text-center" style="vertical-align:middle">
                                <div class="FontSize400" aria-hidden="true" data-icon="&#xf023;"></div>
                                <H3>Sesión cerrada exitosamente.</H3>
                            </td>
                        </tr>
                    </table>
                    </div>
			</div>
        </div>
    </form>
</body>
</html>
