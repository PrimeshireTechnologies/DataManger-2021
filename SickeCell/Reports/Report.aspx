<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SickeCell.Reports.Report" %>

<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <title></title>
      <link rel="icon" href="../../Images/SickeCell.png" style="width:30px;height:30px;"/>
   </head>
<body>
    <form id="form1" runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <rsweb:ReportViewer ID="ReportViewer1" runat="server" Showprintbutton="true" hasprintbutton="true" Height="100%" AsyncRendering="true" ZoomMode="Percent" KeepSessionAlive="true" SizeToReportContent="false" PageNavigationControls ="true"></rsweb:ReportViewer>
             <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" Showprintbutton="true" hasprintbutton="true"></rsweb:ReportViewer>--%>
    </form>

</body>
</html>




