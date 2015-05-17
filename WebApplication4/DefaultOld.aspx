<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DefaultOld.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="WebApplication4.index" %>
<%@ Import Namespace="ASEntityFramework" %>
<%@ Register TagPrefix="cc1" Namespace="LunchboxWebControls" Assembly="LunchboxWebControls" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<html>
<head>
	<title>Auction Sniper WEB</title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel='shortcut icon' type='image/x-icon' href='favicon.ico' />
	<link href = "css/bootstrap.css" rel = "stylesheet">
	<link href = "css/styles.css" rel = "stylesheet">
    <link href="css/bootstrap-switch.css" rel="stylesheet" /> 
    <link href="css/highlight.css" rel="stylesheet" />
    <link href="css/iThing.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/searchfunctions.js"></script>
    
    <script type="text/javascript">
      
        $('body').on('click','#btn-group-instance button', function() {
            $(this).toggleClass('active');
            // if active/else not active logic
        } );
        
        
        $(function() {
            $('[data-toggle="popover"]').popover();
        });

        function hidemessage() {
            $("#emailmessage").fadeOut();
        };
        
        function CorrectCorner() {
            location.reload();
            document.getElementById("maincontent").setAttribute("border-top-left-radius", "0px");
            ResizeSliders();
        }
        
        function myFunction(val) {
            var myBookId = val;
            $("#bookId").val(myBookId);
        };
        
        function myFunction2(val) {
            var myBookId = val;
            $("#historyid").val(myBookId);
        };
        
        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
        

    </script>
    
    <script type="text/javascript">
        function Myfunction2() {
            alert('Overrides successfully Updated.');
        }
    </script>

</head>
	<body>
        <div class="container">
          <form id="Form1" >
              
              <div class="pull-right">
              <asp:Label ID="Welcome" runat="server" />
                <span style="padding-left: 20px">
                    <asp:LinkButton ID="LinkButton1" OnClick="Signout_Click" class="btn btn-xs btn-info" runat="server">Sign Out  &nbsp;<span class="glyphicon glyphicon-off"/></asp:LinkButton>
                </span>
              </div>
              
                <% var accountID = new ASEntities().Users.First(x => x.Username == Context.User.Identity.Name).UserID;%>
                <% var godaddyaccount = new ASEntities().GoDaddyAccount.FirstOrDefault(x => x.UserID == accountID); %>
                <% if (godaddyaccount != null) %>
                <%
                   { %>
                    <% if (!godaddyaccount.Verified) %>
                    <% 
                    { %>
                    <canvas id="flash" width="20" height="40"></canvas>
                    <script>
                        var canvas = document.getElementById("flash");
                        var context = canvas.getContext("2d");
                        context.arc(10, 10, 10, 0, Math.PI * 2, false);
                        context.fillStyle = '#B00000';
                        context.fill();
                    </script>
                    <div style="display: inline">
                        <a href="Default.aspx">
                            <img style="margin-top: -25px" src="img/domain-auction-sniper-logo.png" class="pull-left" />
                        </a>
                        <a id="flash" class="pull-left"  href="Default.aspx#settings" data-toggle="tab" runat="server">Verify Account &nbsp;</a>
                        <asp:Label ID="AccountVerifiedLabel" class="pull-left" runat="server" />
                    </div>
                <% } else { %>
                    <img style="margin-top: -25px" src="img/domain-auction-sniper-logo.png" class="pull-left" />
                    <a id="A1" class="pull-left" data-toggle="tab">Account Verified:<i> <%=godaddyaccount.GoDaddyUsername %></i></a>
                <% } %>
              <% } %>
                                  
              <asp:Label ID="sentmessage" style="display:none" Class="alert alert-success" role="alert" ForeColor="Green" runat="server" />
          </form>

        </div>

        <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
        <ProgressTemplate>
            <div id="overlay">
                <div id="modalprogress">
                    <div id="theprogress" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                        <asp:Image ID="imgWaitIcon" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/loading2.gif" />
                    </div>
                </div>
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>

        <% if(new ASEntities().GoDaddyAccount.FirstOrDefault(x=>x.UserID == accountID) == null) %>
        <% { %>
            <div class="container">
                <asp:Panel runat="server" ID="pnlCustomer" class="form-horizontal" role="form" DefaultButton="LinkButton3">
                      <div class="form-group">
                        <label class="col-sm-2 control-label">GoDaddy Login</label>
                        <div class="col-md-6">
                            <asp:TextBox type="text" class="form-control" ID="inputEmail3" placeholder="Username" runat="server" required autofocus/>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="col-sm-2 control-label">Password</label>
                        <div class="col-md-5">
                            <asp:TextBox type="password" class="form-control" placeholder="Password" id="inputPassword3" TextMode="Password" runat="server" required />
                        </div>
                            <asp:LinkButton ID="LinkButton3" Text="Save" class="btn btn-default" OnClick="btnSave_Godaddy" runat="server">Save</asp:LinkButton>
                      </div>
                </asp:Panel>
            </div>

        <% } else { %>
        
                    <ul id="tabs" class="nav nav-tabs" data-tabs="tabs">
                        <li class="active"><a id="Resize" href="#search" onclick="CorrectCorner()">Search</a></li>
                        <li><a href="#multibidtab" data-toggle="tab">Multi Bid</a></li>
                        <li><a href="#mybids" data-toggle="tab" >My Bids   <span runat="server" id="bidcount" class="badge"></span></a></li>
                        <li><a href="#settings" data-toggle="tab">Settings</a></li>
                        <li class="pull-right"><a href="#FAQ" data-toggle="tab">FAQ</a></li>
                        <li class="pull-right"><a href="#Admin" data-toggle="tab">Admin</a></li>
                    </ul>

		    <div class="container" id="maincontent">
                    <div id="my-tab-content" class="tab-content">
                        <div class="tab-pane active" id="search">

                            <h4>Search</h4>
                            <p>Search for new domains to bid on, Set you max bid and leave it to us!</p>
                                
                            <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch" >                                   
                                <nav class="navbar navbar-default">
                                    <% if (AdvSearchAccess) %>
                                    <%
                                       { %>
                                <div class="btn-group btn-group-xs" data-toggle="buttons" role="group" aria-label="Extra-small button group">
                                  <button type="button" class="btn btn-default active" id="btnSearchAll" runat="server" ClientIDMode="Static" onclick="AllSearchOnly()">All</button>
                                    <button type="button" class="btn btn-default" id="btnSearchAuction" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Auction</button>
                                  <button type="button" class="btn btn-default" id="btnSearchBuyNow" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Buy Now</button>
                                    <button type="button" class="btn btn-default" id="btnBarginBin" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Bargin Bin</button>
                                    <button type="button" class="btn btn-default" id="btnSearchCloseOut" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Closeout</button>
                                    <button type="button" class="btn btn-default" id="btnSearchPendingDelete" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Pending Delete</button>
                                    <button type="button" class="btn btn-default" id="btnSearchOffer" runat="server" ClientIDMode="Static" onclick="CorrectAllSearch()">Offer/Counter Offer</button>
                                </div>
                                    <% } %>
                                  <div class="container-fluid">
                                    <div class="navbar-header">
                                        <asp:TextBox ID="txtSearch" CssClass="navbar-btn" runat="server"></asp:TextBox>&nbsp;
                                        <asp:LinkButton ID="btnSearch" runat="server" OnClick="SearchClick" CssClass="navbar-btn" Text="Search"></asp:LinkButton>&nbsp;

                                        <asp:DropDownList ID="ddlTopResults" runat="server" CssClass="navbar-btn" AutoPostBack="true" >
                                            <asp:ListItem Text="5" Value="5" />
                                            <asp:ListItem Text="10" Value="10" />
                                            <asp:ListItem Text="25" Value="25" />
                                            <asp:ListItem Text="50" Value="50" Selected="True" />
                                            <asp:ListItem Text="100" Value="100" />
                                        </asp:DropDownList>
                                        <span>&nbsp;Max Results to Display</span>
                                        <br/>
                                        <% if (AdvSearchAccess) %>
                                        <%
                                           { %>
                                        <form role="form" class="form-inline">
                                        <div class="btn-group" id="one" role="group">
                                            <label>
                                            <input runat="server" id="startswith" type="radio" onchange="SethiddenValueForsearch()" ClientIDMode="Static" name="optradio"/>starts
                                            </label>
                                            <label><input runat="server" id="contains" type="radio" onchange="SethiddenValueForsearch()" checked="true" ClientIDMode="Static" name="optradio"/>contains</label>
                                            <label><input runat="server" id="endwith" type="radio" onchange="SethiddenValueForsearch()" ClientIDMode="Static" name="optradio"/>ends with</label>
                                        </div>
                                            </form>

                                        <% } %>
                                    </div>
                                      
                                    <% if (AdvSearchAccess) %>
                                    <%
                                       { %>
                                      <!-- Advanced Pin -->

                                    <span class="pull-right">
                                        <span>&nbsp; Adv Search Saves</span>
                                        <asp:DropDownList ID="DDLSavedSearchs" runat="server" CssClass="navbar-btn" AutoPostBack="true" >
                                        </asp:DropDownList>
                                        
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        Advanced Search: 

                                        <input id="cbAdvancedSeach" type="checkbox" runat="server" ClientIDMode="Static" checked="true" name="my-checkbox" data-size="mini"/>
									
                                        <button type="button" class="btn btn-xs btn-info navbar-btn" title="Show/Hide Adv Search" data-toggle="collapse" id="toggleAdvSearch" data-target="#toggleDemo" value="Toggle Button">
                                            <span class="glyphicon glyphicon-pushpin" aria-hidden="true"></span>
                                        </button>
                                        <br/>
                                    
                                        <div class="btn-group btn-group-xs pull-right" role="group" data-toggle="collapse" data-target="#toggleDemo">
                                            <button type="button" data-toggle="collapse" data-target="#toggleSocial"  class="btn btn-info">Switch</button>
                                        </div>
                                
                                        
                                    </span>
                                 <% } %>
                                  </div>
                                </nav>
                                
                            </asp:Panel>
                           
                            <% if (AdvSearchAccess) %>
                            <%
                               { %>
                            <!-- ADVANCED ACCESS -->
                                <!-- Collapsible Element HTML -->
                                <div id="toggleDemo" class="collapse in">
                                    
                                    <div class="container" id="content-one">
                                       
                                    <div class="col-md-8">
                                        <b>Ends in:</b>   All/None<input id="ends_select_all" type="checkbox" checked="" onclick="selectEnds();" name="ends_select_all" data-size="mini">
                                    
                                        <br/>
                                    
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_com" id="ends_com" value="1" checked="true"/>.COM</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_co" id="ends_co" value="1"/>.CO</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_info" id="ends_info" value="1"/>.INFO</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_net" id="ends_net" value="1"/>.NET</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_org" id="ends_org" value="1"/>.ORG</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_us" id="ends_us" value="1"/>.US</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_ca" id="ends_ca" value="1"/>.CA</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_mobi" id="ends_mobi" value="1"/>.MOBI</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_biz" id="ends_biz" value="1"/>.BIZ</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_me" id="ends_me" value="1"/>.ME</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_cc" id="ends_cc" value="1"/>.CC</label>
                                        <br/>
                                    
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_tv" id="ends_tv" value="1"/>.TV</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_de" id="ends_de" value="1"/>.DE</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_au" id="ends_au" value="1"/>.AU</label>

	
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_asia" id="ends_asia" value="1"/>.ASIA</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_se" id="ends_se" value="1"/>.SE</label>
                                        
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_ch" id="ends_ch" value="1"/>.CH</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_fr" id="ends_fr" value="1"/>.FR</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_ie" id="ends_ie" value="1"/>.IE</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_nu" id="ends_nu" value="1"/>.NU</label>
                                        <br/>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_pl" id="ends_pl" value="1"/>.PL</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_at" id="ends_at" value="1"/>.AT</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_be" id="ends_be" value="1"/>.BE</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_eu" id="ends_eu" value="1"/>.EU</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_in" id="ends_in" value="1"/>.IN</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_it" id="ends_it" value="1"/>.IT</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_ru" id="ends_ru" value="1"/>.RU</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_uk" id="ends_uk" value="1"/>.UK</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_misc" id="ends_misc" value="1"/>.MISC</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_mx" id="ends_mx" value="1"/>.MX</label>
									    <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_nl" id="ends_nl" value="1"/>.NL</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="ends_su" id="ends_su" value="1"/>.SU</label>
                                        <br/><br/>
                                        
                                        <b>Domain Source:</b>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_GoDaddy" id="source_GoDaddy" value="1"/>GoDaddy</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_NameJet" id="source_NameJet" value="1"/>NameJet</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_DynaDot" id="source_DynaDot" value="1"/>DynaDot</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_SnapName" id="source_SnapName" value="1"/>SnapName</label>
                                        <label><input type="checkbox" ClientIDMode="Static" runat="server" name="source_Sedo" id="source_Sedo" value="1"/>Sedo</label>
                                        <br/><br/>
								    </div>
                                    
                                    <div class="col-md-4" style="height: 150px">
                                            <!--PRSilder-->
                                        <div id="PRSilder"></div>
                                            <p class="text-center"><b>Page Rank</b></p>
                                        <div class="col-sm-6">
                                        <!--CFSilder-->
                                        <div id="DomainAge"></div>
                                        <p class="text-center"><b>Domain Age</b></p>
                                            
                                        </div>
                                        <div class="col-sm-6">
                                        <!--CFSilder-->
                                        <!--<div id="DomainPrice"></div>-->
                                        <input type="text" ID="MaxPrice" Name="MaxPrice" value onkeypress="return isNumberKey(event);"/>
                                        <p class="text-center"><label><input type="checkbox" ClientIDMode="Static" runat="server" name="DomainPriceMaxApply" id="DomainPriceMaxApply" value="1"/><b>   Cap Price</b></label>
                                            </p>
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="col-md-4">  
                                        <!--MABacklinks-->
                                        <div id="MABacklinks"></div>
                                        <p class="text-center"><b>Majestic Backlinks</b></p>
                                        
                                        <!--Majestic IPS-->
                                        <div id="MajesticIPS"></div>
                                        <p class="text-center"><b>Majestic IPS</b></p>
                                    </div>
                                    <div class="col-md-4">  
                                        <!--MATrustFlow-->
                                        <div id="MATrustFlow"></div>
                                        <p class="text-center"><b>Majestic Trustflow</b></p>
                                                                                
                                        <!--CFSilder-->
                                        <div id="CFSilder"></div>
                                        <p class="text-center"><b>Majestic Citationflow</b></p>
                                    </div>
                               
                                    <div class="col-md-4">  
                                        <!--MOZPA-->
                                        <div id="MOZPA"></div>
                                            <p class="text-center"><b>MOZ PA</b></p>
                                        <div id="MOZDA"></div>
                                            <p class="text-center"><b>MOZ DA</b></p>
                                    </div>

                                    
                                    
                                    
                                    <!--HIDDEN VALUES-->
                                    <asp:HiddenField ID="SaveChangesHidden" runat="server" ClientIDMode="Static" Value="false"/>
                                    <asp:HiddenField ID="SearchAllHidden" runat="server" ClientIDMode="Static" Value="false"/>
                                    <!--PageRank-->
                                    <asp:HiddenField ID="PageRankHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="PageRankHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--CitationFlow-->
                                    <asp:HiddenField ID="CitationFlowHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="CitationFlowHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--Majestic Backlinks-->
                                    <asp:HiddenField ID="MajesticBacklinksHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="MajesticBacklinksHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--Majestic Trustflow-->
                                    <asp:HiddenField ID="MajesticTrustflowHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="MajesticTrustflowHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--Majestic IPS-->
                                    <asp:HiddenField ID="MajesticIPSHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="MajesticIPSHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--MOZPA-->
                                    <asp:HiddenField ID="MOZPAHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="MOZPAHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--MOZDA-->
                                    <asp:HiddenField ID="MOZDAHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="MOZDAHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--Domain Age-->
                                    <asp:HiddenField ID="DomainAgeHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="DomainAgeHiddenMax" runat="server" ClientIDMode="Static"/>
                                    <!--Domain Price-->
                                    <asp:HiddenField ID="DomainPriceHiddenMin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="DomainPriceHiddenMax" runat="server" ClientIDMode="Static"/>
                                        
                                        
                                    <!--HIDDEN Domain Types-->
                                    <asp:HiddenField ID="HiddenTypeAuction" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenTypeAll" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenTypeCloseOut" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenTypeBuyNow" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenTypeBarginBin" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenTypePendingDelete" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenTypeOfferCounterOffer" runat="server" ClientIDMode="Static"/>
                                        
                                    <asp:HiddenField ID="HiddenEndsWith" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenStartsWith" runat="server" ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HiddenContains" runat="server" ClientIDMode="Static"/>

                                </div>
                            </div>
                            
                                <div id="toggleSocial" class="collapse">
                                    Social!
                                    Temp Removed. ** Correct javascript resize
                                </div>
                            <% } %>
			            <br />
                        <div class="table-responsive">
                        <asp:UpdatePanel ID="SearchUpdate" runat="server">
                                <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>
                            <% if (AdvSearchAccess) %>
                            <%
                               { %>
                                
                                
                                <cc1:LunchboxGridView ID="gvAdvSearchResults" runat="server" AutoGenerateColumns="False"  onrowcreated="gvAgency_DataBound" 
                                                        CellPadding="4" CssClass="gridOverall" GridLines="None" AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" >
                                    <EmptyDataTemplate>No results to display</EmptyDataTemplate>
                                    <Columns>
                                        <asp:HyperLinkField
                                            DataNavigateUrlFields="DomainLink"
                                            DataNavigateUrlFormatString="{0}"
                                            DataTextField="DomainName"
                                            HeaderText="Domain"
                                            Target="_blank"
                                            SortExpression="DomainLink" />
                                        <asp:BoundField HeaderText="Ref" SortExpression="Ref" DataField="Ref" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Age" SortExpression="Age" DataField="Age" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Rank" SortExpression="PageRank" DataField="PageRank" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="DA" SortExpression="MOZDA" DataField="MOZDA" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="PA" SortExpression="MOZPA" DataField="MOZPA" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Rank" SortExpression="MozRank" DataField="MozRank" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="TF" SortExpression="MozTrust" DataField="MozTrust" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="CF" SortExpression="CF" DataField="CF" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="TF" SortExpression="TF" DataField="TF" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Alexa" SortExpression="AlexARank" DataField="AlexARank" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="MOZ DOM" SortExpression="MozDom" DataField="MozDom" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="MAJ DOM" SortExpression="MajDom" DataField="MajDom" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Price" SortExpression="DomainPrice" DataField="DomainPrice" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Expires" SortExpression="EsitmateEnd" DataField="EsitmateEnd" HtmlEncode="false"/>

                                        <asp:TemplateField HeaderText="" SortExpression="">
                                            <ItemTemplate>
                                                <span id="timer_<%# Container.DataItemIndex %>" 
                                                  class="timer" 
                                                  data-start=20></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a id="SetBid" <%# (!(bool)Eval("IsAuction") || !(bool)Eval("IsGOdaddy")) ? "style='display:none'" : "" %> data-toggle="modal" onclick="myFunction('<%#Eval("Ref")%>')" data-id="<%#Eval("Ref")%>" style="color: #ffffff" href="#addBookDialog" class="open-AddBookDialog btn btn-sm btn-primary">Set Bid</a> 
                                                <span id="tst" ></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="gridRow" />
                                    <AlternatingRowStyle CssClass="gridAltRow" />
                                    <HeaderStyle CssClass="gridHeader" />
                                </cc1:LunchboxGridView>
                                
                                <% }
                               else
                               { %>
                                
                                <cc1:LunchboxGridView ID="LunchboxGridView1" runat="server" AutoGenerateColumns="False"  onrowcreated="gvAgency_DataBound" 
                                                        CellPadding="4" CssClass="gridOverall" GridLines="None" AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" >
                                    <EmptyDataTemplate>No results to display</EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField HeaderText="Domain" SortExpression="DomainName" DataField="DomainName" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Ref" SortExpression="AuctionRef" DataField="AuctionRef" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Traffic" SortExpression="Traffic" DataField="Traffic" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Minimum Bid" SortExpression="MinBid" DataField="MinBid" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Estimated End Date" SortExpression="EstimateEndDate" DataField="EstimateEndDate" HtmlEncode="false"/>
                                        <asp:TemplateField HeaderText="" SortExpression="">
                                            <ItemTemplate>
                                                <span id="timer_<%# Container.DataItemIndex %>" 
                                                  class="timer" 
                                                  data-start=20></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a id="SetBid" data-toggle="modal" onclick="myFunction('<%#Eval("AuctionRef")%>')" data-id="<%#Eval("AuctionRef")%>" style="color: #ffffff" href="#addBookDialog" class="open-AddBookDialog btn btn-sm btn-primary">Set Bid</a> 
                                                <span id="tst" ></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="gridRow" />
                                    <AlternatingRowStyle CssClass="gridAltRow" />
                                    <HeaderStyle CssClass="gridHeader" />
                                </cc1:LunchboxGridView>

                                
                                <% } %>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>

                        </div>
                        
                        <!--MASS BID -->
                        <div class="tab-pane" id="multibidtab">
                            
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="table-responsive">
                        <div class="modal-header">
                            <h4>Multi Bid <span class="glyphicon glyphicon-barcode pull-right"></span></h4>
                            <div id="reset" runat="server" style="display: none">
                                <asp:LinkButton ID="LinkButton7" OnClick="Reset" runat="server">Reset Search</asp:LinkButton>
                            </div>
                        </div> 
                        <div class="modal-body">
                            <div class="form-group" id="multipaste" runat="server">
                            <label for="inputbid" class="sr-only">Paste your URLs below</label>
                                <asp:TextBox  id="TextBox1"  onkeyDown="checkTextAreaMaxLength(this,event,'500');" class="span12" rows="10" Columns="120" placeholder="Urls here" TextMode="MultiLine" runat="server" type="text" width="100%" height="100%" MaxLength="500" required autofocus>
                                        </asp:TextBox>
                            </div>

                            <div class="form-group" id="hiddenmulti" style="display: none" runat="server" width="100%">
                                <label for="inputbid" class="sr-only">Paste your URLs below</label>
                                <cc1:LunchboxGridView  OnRowCommand="MassBids_RowCommand" ID="LunchboxGridView4" runat="server" AutoGenerateColumns="False"  
                                                      DataKeyNames="AuctionID"  CellPadding="4" CssClass="gridOverall" GridLines="None" AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" >
                                    <EmptyDataTemplate>No bids currenlty set</EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField HeaderText="Domain" SortExpression="DomainName" DataField="DomainName" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Ref" SortExpression="AuctionRef" DataField="AuctionRef" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Traffic" SortExpression="Traffic" DataField="Traffic" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Minimum Bid" SortExpression="MinBid" DataField="MinBid" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Estimated End Date" SortExpression="EstimateEndDate" DataField="EstimateEndDate" HtmlEncode="false"/>
                                        <asp:TemplateField HeaderText="" SortExpression="">
                                            <ItemTemplate>
                                                <span id="timer_<%# Container.DataItemIndex %>" 
                                                  class="timer" 
                                                  data-start=20></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" SortExpression="">
                                            <ItemTemplate >
                                                <asp:LinkButton id="lnBtnDel" runat="server" CommandName="DeleteRow" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" CommandArgument='<%#Eval("AuctionID")%>'>Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Set Bid" SortExpression="MyBid">
                                            <ItemTemplate >
                                                <asp:TextBox ID="bidvalue" runat="server" type="number" min='<%#Eval("MinBid")%>' placeholder="Max Bid override" data-id='<%#Eval("AuctionID")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="gridRow" />
                                    <AlternatingRowStyle CssClass="gridAltRow" />
                                    <HeaderStyle CssClass="gridHeader" />
                                </cc1:LunchboxGridView>
                            </div>

                            <asp:LinkButton ID="LinkButton5" OnClick="GenerateMultiBids" runat="server" class="btn btn-default">Find Auctions</asp:LinkButton>
                            

                        </div>
                        </div>
                            
                            <div id="masssubmit" runat="server" style="display: none">
                                <asp:Panel ID="Panel2" runat="server">
                            
                                    <div class="form-group" id="divSubmitMultibids"  runat="server" width="100%">
                                        <input id="fullApplyvalue" placeholder="Amount to Bid on all" min="1" type="text" runat="server" />
                                        <asp:LinkButton ID="LinkButton6" OnClick="SubmitMultiBids" runat="server" class="btn btn-default">Submit Bids</asp:LinkButton>
                                        This amount will be set as you maximum value for each of the above auctions that dont have their own value set.
                                    </div>

                                </asp:Panel>
                            </div>

                        </ContentTemplate>
                </asp:UpdatePanel>
                            
                            
                        </div>
                        
                        <!--MY BIDS -->
                        <div class="tab-pane" id="mybids">
                            <h1>Bids</h1>
                            <p>My Current Bids</p>
                            <div class="table-responsive">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                    
                                <cc1:LunchboxGridView OnRowCommand="MyBids_RowCommand" ID="LunchboxGridView2" runat="server" AutoGenerateColumns="False"  
                                   OnRowDataBound="grdViewCustomers_OnRowDataBound"  onrowcreated="gvAgency_DataBound" 
                                                      DataKeyNames="AuctionID"  CellPadding="4" CssClass="gridOverall" GridLines="None" AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" >
                                    <EmptyDataTemplate>No bids currenlty set</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                        <itemtemplate>
                                            <a id="togg" data-toggle="modal" onclick="divexpandcollapse('<%#Eval("AuctionID")%>')" href="#<%#Eval("AuctionID")%>" />
                                            <div class="modal fade" id="<%#Eval("AuctionID")%>" role="dialog">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <form class="form-inline" role="form">
                                                        <div class="modal-header">
                                                            <h4>History<span class="glyphicon glyphicon-signal pull-right"></span></h4>
                                                            <h5>(Times are server based)</h5>
                                                        </div> 
                                                        <div class="modal-body">
                                                            <asp:GridView ID="grdViewOrdersOfCustomer" 
                                                                    runat="server" AutoGenerateColumns="false"
                                                                    CellPadding="4" CssClass="gridOverall" GridLines="None" AllowSorting="False" Width="100%"
                                                                    DataKeyNames="HistoryID">
                                                                <columns>
                                                                    <asp:BoundField ItemStyle-Width="150px" 
                                                                      DataField="CreatedDate" HeaderText="Created" />
                                                                    <asp:BoundField ItemStyle-Width="150px" 
                                                                      DataField="Text" HeaderText="Description" />
                                                                </columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <a class="btn btn-default" data-dismiss="modal">Close</a>
                                                        </div>
                                                    </form>
                                                </div>
                                            </div>
                                            </div>
                                        </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:HyperLinkField
                                            DataNavigateUrlFields="AuctionRef"
                                            DataNavigateUrlFormatString="https://auctions.godaddy.com/trpItemListing.aspx?miid={0}"
                                            DataTextField="DomainName"
                                            HeaderText="Domain"
                                            Target="_blank"
                                            SortExpression="AuctionRef" />
                                        <asp:BoundField HeaderText="Ref" SortExpression="AuctionRef" DataField="AuctionRef" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Valuation" SortExpression="Valuation" DataField="Valuation" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="Minimum Bid" SortExpression="MinBid" DataField="MinBid" HtmlEncode="false"/>
                                        <asp:BoundField HeaderText="End Date" SortExpression="EndDate" DataField="EndDate" HtmlEncode="false"/>
                                        <asp:TemplateField HeaderText="Count Down" SortExpression="">
                                            <ItemTemplate >
                                                <span id="timer_<%# Container.DataItemIndex %>"
                                                  class="timer" 
                                                  data-start='<%#Eval("EndDate", "{0:M/dd/yyyy H:mm:ss}")%>'
                                                  data-currentTime='<%# DateTime.Now.ToString("M/dd/yyyy H:mm:ss") %>'></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="My Bid" SortExpression="MyBid" DataField="MyBid" HtmlEncode="false">
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="" SortExpression="">
                                            <ItemTemplate >
                                                <asp:LinkButton id="lnkBtnDel" runat="server" CommandName="DeleteRow" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" CommandArgument='<%#Eval("AuctionID")%>'>Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a id="SetBid" data-toggle="modal" onclick="myFunction2('<%#Eval("AuctionID")%>')" data-id="<%#Eval("AuctionID")%>" href="#<%#Eval("AuctionID")%>" style="color: #ffffff" class="open-AddBookDialog btn btn-sm btn-primary">History</a> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="gridRow" />
                                    <AlternatingRowStyle CssClass="gridAltRow" />
                                    <HeaderStyle CssClass="gridHeader" />
                                </cc1:LunchboxGridView>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>

                        </div>
                        
                        <!--SETTINGS -->
                        <div class="tab-pane" id="settings">
                            <h1>Settings</h1>
                            <p>GoDaddy Account Settings: Login details are confirmed on entry</p>

                            <asp:UpdatePanel ID="UpdatePanel1" class="form-horizontal" role="form" DefaultButton="btnRegister" runat="server">
                                <ContentTemplate>
                                <div class="form-group">
                                <label class="col-sm-2 control-label">GoDaddy Login</label>
                                <div class="col-md-6">
                                    <asp:TextBox type="text" class="form-control" ID="GodaddyAccount" placeholder="Username" runat="server" required autofocus/>
                                </div>
                              </div>
                              <div class="form-group">
                                <label class="col-sm-2 control-label">Password</label>
                                <div class="col-md-5">
                                    <asp:TextBox type="password" class="form-control" placeholder="Password" id="GoDaddyPassword" TextMode="Password" runat="server" required />
                                </div>
                                <asp:LinkButton ID="LinkButton4" Class="alert alert-success" OnClick="Update_Godaddy" role="alert" runat="server">Verify</asp:LinkButton>
                                  <asp:Label ID="Msg" style="display:none" Class="alert alert-success" role="alert" ForeColor="Green" runat="server" />
                              </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            <br/>

                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                <Triggers>        
                                    <asp:AsyncPostBackTrigger ControlID="receiveEmails" EventName="CheckedChanged" />    
                                </Triggers>  
                                <ContentTemplate>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" runat="server">Receive Alert Emails:</Label>
                                        <asp:CheckBox ID="receiveEmails" ClientIDMode="Static" AutoPostBack="True" runat="server" OnCheckedChanged="Update_EmailOptions"></asp:CheckBox>
                                    </div>
                                    <Label ID="emailmessage" style="display:none" Class="alert alert-success" role="alert" ForeColor="Green" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <!--FAQ-->
                        <div class="tab-pane" id="FAQ">
                            <h1>FAQ</h1>
                            <h3>Countdown Doesnt End when the auction does?</h3>
                            <p>Of course it does! GoDaddy end times are based on the time where their servers are based, not nessescerally the same time as your current time zone.
                            If it says it ends at 9pm and thats and hour away for you - it could well be several more or less. Just keep your eye on the timers and bid history, that will keep you sane.
                            </p>
                            <h3>Why can't I bid this domain? It doesn't show up in search.</h3>
                            <p>DAS is specifically built for Auction-format listings where you can set bids. You won't be able to use the sniper function for "Offer" listings or "Buy-it-now" domains
                            </p>
                        </div>
                        <!--ADMIN-->
                        <div class="tab-pane" id="Admin">
                            <h1>Admin</h1>
                            
                            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                
                               
                              <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="headingOne">
                                  <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                      Rank
                                    </a>
                                  </h4>
                                </div>
                                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                  <div class="panel-body">
                                      
                                  </div>
                                </div>
                              </div>
                              <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="headingTwo">
                                  <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                      Collapsible Group Item #2
                                    </a>
                                  </h4>
                                </div>
                                <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                  <div class="panel-body">
                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                  </div>
                                </div>
                              </div>

                                <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="headingThree">
                                  <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                      Collapsible Group Item #3
                                    </a>
                                  </h4>
                                </div>
                                <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                  <div class="panel-body">
                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                  </div>
                                </div>
                              </div>
                            </div>

                            <div class="row-fluid">

                                <div class="span6"> <!-- FIRST COLUMN -->
                                    <div class="checkbox">
                                        <label><input type="checkbox" name="my-checkbox" value="">Option 1</label>
                                    </div>
                                    <div class="checkbox">
                                        <label><input type="checkbox" value="">Option 2</label>
                                    </div>
                                    <div class="checkbox disabled">
                                        <label><input type="checkbox" value="" disabled>Option 3</label>
                                    </div>
                                </div>
                                            
                                <div class="span6"> <!-- FIRST COLUMN -->
                                    <div class="checkbox">
                                        <label><input type="checkbox" value="">Option 1</label>
                                    </div>
                                    <div class="checkbox">
                                        <label><input type="checkbox" value="">Option 2</label>
                                    </div>
                                    <div class="checkbox disabled">
                                        <label><input type="checkbox" value="" disabled>Option 3</label>
                                    </div>
                                </div>
                                            
                            </div>
                        </div>
                    </div>
                </div>
        <% } %>
        

        <div class="modal fade" id="addBookDialog" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    
                    <form class="form-inline" role="form">
                            
                                <div class="modal-header">
                                    <h4>Place Bid <span class="glyphicon glyphicon-usd pull-right"></span></h4>
                                </div> 
                                <div class="modal-body">
                                    <div class="form-group">
                                    <label class="sr-only">Auction Ref</label>
                                    <input type="text" name="bookId" id="bookId" value="" readonly="readonly"/>
                                    </div>
                                    <div class="form-group">
                                    <label for="inputbid" class="sr-only">Max Bid</label>
                                    <input type="number" name="bidvalue" class="form-control" id="inputbid" placeholder="Bid" min="0">
                                    </div>
                                    <button type="submit" class="btn btn-default">Confirm Bid</button><br/><br/>
                                    Please note: Bids are placed towards the END of the auction. <br/>
                                    Nothing will be done with your account or auction until the final moments.
                                </div>
                                <div class="modal-footer">
                                    <a class="btn btn-default" data-dismiss="modal">Close</a>
                                </div>
                        
                </form>
                </div>
            </div>
        </div>
        
        <!-- MULTI BID -->

        
        <div class="modal fade" id="bugreport" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                        <asp:Panel ID="Panel1" runat="server" role="form"  class="form-inline" >
                                <div class="modal-header">
                                    <h4>Report a bug <span class="glyphicon glyphicon-send pull-right"></span></h4>
                                </div> 
                                <div class="modal-body">
                                    <div class="form-group">
                                    <label for="inputbid" class="sr-only">Description</label>
                                        <asp:TextBox  id="bugtxtv"  onkeyDown="checkTextAreaMaxLength(this,event,'500');" class="span12" rows="10" Columns="120" placeholder="Report your issue" TextMode="MultiLine" runat="server" type="text" width="100%" height="100%" MaxLength="500" required autofocus>
                                                </asp:TextBox>
                                    </div>
                                    <asp:LinkButton ID="LinkButton2" OnClick="btnSubmitBug" runat="server" class="btn btn-default">Submit</asp:LinkButton>
                                </div>
                                <div class="modal-footer">
                                    <a class="btn btn-default" data-dismiss="modal">Close</a>
                                </div>
                </asp:Panel>
                </div>
            </div>
        </div>

        <div class="modal fade" id="historymodal" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    
                    <form class="form-inline" role="form">
                            
                                <div class="modal-header">
                                    <h4>History<span class="glyphicon glyphicon-phone-alt pull-right"></span></h4>
                                </div> 
                                <div class="modal-body">
                                    <div class="form-group">
                                    <label class="sr-only">Auction Ref</label>
                                    <input type="text" name="historyid" id="historyid" value="" readonly="readonly"/>
                                    </div>


                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>
                                                <cc1:LunchboxGridView  OnRowCommand="MyBids_RowCommand" ID="LunchboxGridView3" runat="server" AutoGenerateColumns="False"  
                                                        onrowcreated="gvAgency_DataBound" OnRowDeleting="PendingRecordsGridview_RowDeleting"
                                                                        CellPadding="4" CssClass="gridOverall" GridLines="None" AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" >
                                                    <EmptyDataTemplate>No bids currenlty set</EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Description" SortExpression="Text" DataField="Text" HtmlEncode="false"/>
                                                        <asp:BoundField HeaderText="Created" SortExpression="CreatedDate" DataField="CreatedDate" HtmlEncode="false"/>
                                                    </Columns>
                                                    <RowStyle CssClass="gridRow" />
                                                    <AlternatingRowStyle CssClass="gridAltRow" />
                                                    <HeaderStyle CssClass="gridHeader" />
                                                </cc1:LunchboxGridView>
                                                </ContentTemplate>
                                        </asp:UpdatePanel>

                                </div>
                                <div class="modal-footer">
                                    <a class="btn btn-default" data-dismiss="modal">Close</a>
                                </div>
                        
                </form>
                </div>
            </div>
        </div>
        
        <script src="js/bootstrap-switch.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js" ></script>
    
       </body>

    <script src="js/jQAllRangeSliders-min.js"></script>
    <script src="js/JQSlierCustomConfig.js"></script>
    <script type='text/javascript'>
              
        $(document).ready(function () {
            $("[name='my-checkbox']").bootstrapSwitch();
            $("#cbAdvancedSeach").bootstrapSwitch();
            $("#receiveEmails").bootstrapSwitch();
            $('#receiveEmails').on('switchChange.bootstrapSwitch', function (event, state) {
                __doPostBack('#receiveEmails', 'settings');
            });
            ResizeSliders();
     
            //$("#toggleDemo").removeClass("collapse in").addClass("collapse");
        });
        
        
        $("#toggleAdvSearch").click(function () {
            $('#toggleDemo').toggleClass('in');
            ResizeSliders();
            return false;
        });

        function ResizeSliders() {
            $("#PRSilder").editRangeSlider('resize');
            $("#CFSilder").editRangeSlider('resize');
            $("#DomainAge").editRangeSlider('resize');
            $("#DomainPrice").editRangeSlider('resize');
            $("#MABacklinks").editRangeSlider('resize');
            $("#MajesticIPS").editRangeSlider('resize');
            $("#MOZDA").editRangeSlider('resize');
            $("#MOZPA").editRangeSlider('resize');
            $("#MATrustFlow").editRangeSlider('resize');
        }
       
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

        function SethiddenValueForsearch() {
            $("#HiddenEndsWith").val($("#endwith").is(':checked'));
            $("#HiddenContains").val($("#contains").is(':checked'));
            $("#HiddenStartsWith").val($("#startswith").is(':checked'));
        }
    </script>
        <script>
            // Keeps the selected tab on page refresh
            $('#tabs a').click(function (e) {
                e.preventDefault();
                $(this).tab('show');
            });

            // store the currently selected tab in the hash value
            $("ul.nav-tabs > li > a").on("shown.bs.tab", function (e) {
                var id = $(e.target).attr("href").substr(1);
                window.location.hash = id;
            });

            // on load of the page: switch to the currently selected tab
            var hash = window.location.hash;
            $('#tabs a[href="' + hash + '"]').tab('show');
        </script>
        <% var dtNow = DateTime.Now; %>
        <script>
            //generate countdown timers for every auction - booya
            $(function () {
                $(".timer").each(function () {
                    var dateFuture = new Date($(this).data("start"));
                    var dateNow = new Date($(this).data("currenttime"));

                    var seconds = Math.floor((dateFuture - (dateNow)) / 1000);
                    var minutes = Math.floor(seconds / 60);
                    var hours = (Math.floor(minutes / 60));
                    var days = Math.floor(hours / 24);

                    hours = hours - (days * 24);
                    minutes = minutes - (days * 24 * 60) - (hours * 60);
                    seconds = seconds - (days * 24 * 60 * 60) - (hours * 60 * 60) - (minutes * 60);
                    zxcCountDown($(this).attr("id"), 'Ended', seconds, minutes, hours, days);

                });
            });
           

        </script>
    </html>
</asp:Content>