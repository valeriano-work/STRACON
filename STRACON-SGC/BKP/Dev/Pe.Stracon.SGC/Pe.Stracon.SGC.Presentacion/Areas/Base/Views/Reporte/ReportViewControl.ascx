<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportViewControl.ascx.cs" Inherits="Pe.Stracon.SGC.Presentacion.Areas.Base.Views.Reporte.ReportViewControl" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Import Namespace="Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base" %>
<%--action='ReporteAuditoria/Visualizar'--%>


<% if (Model != null && Model is ReporteViewModel)
   { %>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" EnablePartialRendering="false"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer" runat="server" Width="100%" Height="100%" KeepSessionAlive="true" ProcessingMode="Remote" SizeToReportContent="true" ShowPrintButton="true"
        ShowZoomControl="false" >
    </rsweb:ReportViewer>
</form>

<% } %>