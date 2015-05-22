<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="WebApplication4.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
    FAQ
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    <!--FAQ-->
    <div class="col-md-10 col-md-offset-1">
        <h3>Countdown Doesnt End when the auction does?</h3>
        <p>Of course it does! GoDaddy end times are based on the time where their servers are based, not nessescerally the same time as your current time zone.
        If it says it ends at 9pm and thats and hour away for you - it could well be several more or less. Just keep your eye on the timers and bid history, that will keep you sane.
        </p>
        <br/>
        <h3>Why can't I bid this domain? It doesn't show up in search.</h3>
        <p>DAS is specifically built for Auction-format listings where you can set bids. You won't be able to use the sniper function for "Offer" listings or "Buy-it-now" domains
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
</asp:Content>
