<%@ Page Title="" EnableEventValidation="false" ValidateRequest="false" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="BasicSearch.aspx.cs" Inherits="WebApplication4.BasicSearch" %>
<%@ Register TagPrefix="cc1" Namespace="LunchboxWebControls" Assembly="LunchboxWebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
    <script type="text/javascript">
        
        function CorrectCorner() {
            location.reload();
            document.getElementById("maincontent").setAttribute("border-top-left-radius", "0px");
        }

        $(function () {
            $('[data-toggle="popover"]').popover();
        });

        function myFunction(val) {
            var myBookId = val;
            $("#bookId").val(myBookId);
        };
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
    Search
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    <div class="col-md-12">
        <h4>Search</h4>
        <p>Search for new domains to bid on, Set you max bid and leave it to us!</p>
                                
        <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch" >                                   
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                <div class="navbar-header">
                    <asp:TextBox ID="txtSearch" CssClass="navbar-btn" runat="server"></asp:TextBox>&nbsp;
                    <asp:LinkButton ID="btnSearch" ClientIDMode="Static" runat="server" OnClick="SearchClick" CssClass="navbar-btn" Text="Search"></asp:LinkButton>&nbsp;

                    <asp:DropDownList ID="ddlTopResults" runat="server" CssClass="navbar-btn" AutoPostBack="true" >
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="25" Value="25" />
                        <asp:ListItem Text="50" Value="50" Selected="True" />
                        <asp:ListItem Text="100" Value="100" />
                    </asp:DropDownList>
                    <span>&nbsp;Max Results to Display</span>
                    <br/>
                    </div>          
                </div>
            </nav>
                                
        </asp:Panel>
                        <div class="table-responsive" style="margin-top: -15px">
                        <asp:UpdatePanel ID="SearchUpdate" runat="server">
                                <Triggers>
                                <asp:AsyncPostBackTrigger  ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>
                                <div id="bidcontainer">
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
                                    </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
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
                            <input runat="server" ClientIDMode="Static" type="text" name="bookId" id="bookId" value="" readonly="readonly"/>
                            </div>
                            <div class="form-group">
                            <label for="inputbid" class="sr-only">Max Bid</label>
                                <input runat="server" ClientIDMode="Static" type="number" name="bidvalue" class="form-control" id="inputbid" placeholder="Bid" min="0"/>
                            </div>
                            <asp:LinkButton CssClass="btn btn-xs btn-primary" ID="submitbutton" OnClick="submitmybid" runat="server">Submit</asp:LinkButton>
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
                        </div>


    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
</asp:Content>
