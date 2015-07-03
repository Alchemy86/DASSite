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

    <div class="container"  style="margin-top: 20px">
        <span id="slidermenuholder" runat="server"></span>
        <span id="slidermenuholder2" runat="server"></span>
        <span id="slidermenuholder3" runat="server"></span>
    </div>
    
        <div class="col-md-8">
            <b>Ends in:</b>   All/None<input id="ends_select_all" type="checkbox" checked="" onclick="selectEnds();" name="ends_select_all" data-size="mini">
                                    
            <br/>
                                    
            <label class="domaincheckbox"><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_com" id="ends_com" value="1" checked="true"/>.COM</label>
			<label class="domaincheckbox"><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_co" id="ends_co" value="1"/>.CO</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_info" id="ends_info" value="1"/>.INFO</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_net" id="ends_net" value="1"/>.NET</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_org" id="ends_org" value="1"/>.ORG</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_us" id="ends_us" value="1"/>.US</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_ca" id="ends_ca" value="1"/>.CA</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_mobi" id="ends_mobi" value="1"/>.MOBI</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_biz" id="ends_biz" value="1"/>.BIZ</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_me" id="ends_me" value="1"/>.ME</label>
            <br/>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_cc" id="ends_cc" value="1"/>.CC</label>             
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_tv" id="ends_tv" value="1"/>.TV</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_de" id="ends_de" value="1"/>.DE</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_au" id="ends_au" value="1"/>.AU</label>

	
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_asia" id="ends_asia" value="1"/>.ASIA</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_se" id="ends_se" value="1"/>.SE</label>
                                        
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_ch" id="ends_ch" value="1"/>.CH</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_fr" id="ends_fr" value="1"/>.FR</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_ie" id="ends_ie" value="1"/>.IE</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_nu" id="ends_nu" value="1"/>.NU</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_at" id="ends_at" value="1"/>.AT</label>
            <br/>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_pl" id="ends_pl" value="1"/>.PL</label>
			
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_be" id="ends_be" value="1"/>.BE</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_eu" id="ends_eu" value="1"/>.EU</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_in" id="ends_in" value="1"/>.IN</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_it" id="ends_it" value="1"/>.IT</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_ru" id="ends_ru" value="1"/>.RU</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_uk" id="ends_uk" value="1"/>.UK</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_misc" id="ends_misc" value="1"/>.MISC</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_mx" id="ends_mx" value="1"/>.MX</label>
			<label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_nl" id="ends_nl" value="1"/>.NL</label>
            <label class="domaincheckbox"><input type="checkbox"  ClientIDMode="Static" runat="server" name="ends_su" id="ends_su" value="1"/>.SU</label>
            <br/><br/>
                                        
            <b>Domain Source:</b>
            <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_GoDaddy" id="source_GoDaddy" value="1"/>GoDaddy</label>
            <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_NameJet" id="source_NameJet" value="1"/>NameJet</label>
            <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_DynaDot" id="source_DynaDot" value="1"/>DynaDot</label>
            <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_SnapName" id="source_SnapName" value="1"/>SnapName</label>
            <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_Sedo" id="source_Sedo" value="1"/>Sedo</label>
            <br/><br/>
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
