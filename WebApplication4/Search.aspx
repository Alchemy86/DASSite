<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApplication4.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
    <link href="css/Search.css" rel="stylesheet" />
    <link href="css/iThing.css" rel="stylesheet" />
    <script type="text/javascript">
        function CorrectAllSearch() {
            $("#btnSearchAll").removeClass('active');
            $("#btnSearchAll").className = "btn btn-default";
        }

        function AllSearchOnly() {
            $("#btnSearchAuction").removeClass('active');
            $("#btnSearchBuyNow").removeClass('active');
            $("#btnSearchCloseOut").removeClass('active');
            $("#btnSearchOffer").removeClass('active');
            $("#btnSearchPendingDelete").removeClass('active');
            $("#btnBarginBin").removeClass('active');

        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
    Search
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    
    <div>
     <div class="container" id="slidermenuholder" runat="server" style="margin-top: 20px">
        
     </div>
    
    <br/>
    
    <div class="col-md-12">
        <asp:Panel ID="pnlSearch" class="navbar navbar-default" runat="server" DefaultButton="btnSearch" >                                   
        <div class="btn-group btn-group-xs" data-toggle="buttons" role="group" aria-label="Extra-small button group">
            <button type="button" class="btn btn-default active" id="btnSearchAll" runat="server" ClientIDMode="Static" onclick="AllSearchOnly()">All</button>
            <button type="button" class="btn btn-default" id="btnSearchAuction" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Auction</button>
            <button type="button" class="btn btn-default" id="btnSearchBuyNow" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Buy Now</button>
            <button type="button" class="btn btn-default" id="btnBarginBin" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Bargin Bin</button>
            <button type="button" class="btn btn-default" id="btnSearchCloseOut" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Closeout</button>
            <button type="button" class="btn btn-default" id="btnSearchPendingDelete" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Pending Delete</button>
            <button type="button" class="btn btn-default" id="btnSearchOffer" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Offer/Counter Offer</button>
        </div>

            <div class="container-fluid">

            <span class="pull-right">
                
                <asp:DropDownList ID="ddlTopResults" runat="server" CssClass="navbar-btn" AutoPostBack="true" >
                    <asp:ListItem Text="5" Value="5" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" />
                    <asp:ListItem Text="50" Value="50" Selected="True" />
                    <asp:ListItem Text="100" Value="100" />
                </asp:DropDownList>
                <span style="padding-right: 20px">&nbsp;Max Results to Display</span>
                <asp:TextBox ID="txtSearch" CssClass="navbar-btn" placeholder="Search" runat="server"></asp:TextBox>&nbsp;
                <asp:LinkButton ID="btnSearch" runat="server" OnClick="SearchClick" CssClass="btn btn-default" Text="Search"></asp:LinkButton>&nbsp;
                                        
            </span>
            </div>
                                
    </asp:Panel>
    </div>

    </div>
 
    
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js" ></script>
    <script src="js/jQAllRangeSliders-min.js"></script>
    <script src="js/JQSlierCustomConfig.js"></script>
    <script>
        //<!--
        $("#slider_pagerank").editRangeSlider();
        $("#slider2").editRangeSlider();
        $("#slider3").editRangeSlider();
        $("#slider4").editRangeSlider();
        //-->
    </script>
</asp:Content>
