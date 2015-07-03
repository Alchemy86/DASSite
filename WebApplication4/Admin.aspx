<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication4.Admin" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
    Admin
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    <div class="col-md-12 col-md-offset-1">
        <asp:Chart ID="Chart1" runat="server">
            <Titles>
                <asp:Title ShadowOffset="3" Name="Items" />
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
            </Legends>
            <Series>
                <asp:Series Name="Default" />
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
</asp:Content>
