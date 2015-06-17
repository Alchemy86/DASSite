<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="Multibid.aspx.cs" Inherits="WebApplication4.Multibid" %>
<%@ Register TagPrefix="cc1" Namespace="LunchboxWebControls" Assembly="LunchboxWebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".fullApplyvalue").keypress(function (e) {
                if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
                    $("#errmsg").html("Digits Only").show().fadeOut("slow");
                    return false;
                }
            });
            $("#bidvalue").keypress(function (e) {
                if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
                    $("#errmsg").html("Digits Only").show().fadeOut("slow");
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                    <div class="modal-header">
                        <h4>Multibid <span class="glyphicon glyphicon-barcode pull-right"></span></h4>
                        <div id="reset" runat="server" style="display: none">
                            <asp:LinkButton ID="LinkButton7" OnClick="Reset" runat="server">Reset Search</asp:LinkButton>
                        </div>
                    </div> 
                    <div class="modal-body" style="overflow: hidden;">
                        <div class="form-group" id="multipaste" runat="server">
                        <label for="inputbid" class="sr-only">Paste your URLs below</label>
                            <asp:TextBox  id="TextBox1"  onkeyDown="checkTextAreaMaxLength(this,event,'500');" class="span12" rows="10" Columns="120" placeholder="Urls here" TextMode="MultiLine" runat="server" type="text" width="100%" height="100%" MaxLength="500" required autofocus></asp:TextBox>
                        </div>
                        
                        <div id="scrollcontainer" style="overflow-y: scroll; max-height: 250px;">
                            <div class="form-group" id="hiddenmulti" style="display: none" height="400px" runat="server" width="100%">
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
                        </div>
                        <asp:LinkButton ID="LinkButton5" OnClick="GenerateMultiBids" runat="server" class="btn btn-default">Find Auctions</asp:LinkButton>

                    </div>
                </div>
                            
                <div id="masssubmit" runat="server" style="display: none">
                    <div class="container">
                        <asp:Panel ID="Panel2" runat="server">
                            
                            <div class="form-group" id="divSubmitMultibids"  runat="server" width="100%">
                                <input id="fullApplyvalue" ClientIDMode="Static" placeholder="Amount to Bid on all" min="1" type="text" runat="server" /><span id="errmsg"></span>
                                <asp:LinkButton ID="LinkButton6" OnClick="SubmitMultiBids" runat="server" class="btn btn-default">Submit Bids</asp:LinkButton>
                                This amount will be set as you maximum value for each of the above auctions that dont have their own value set.
                            </div>

                        </asp:Panel>
                    </div>
                </div>

            </ContentTemplate>
    </asp:UpdatePanel>
                           
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
</asp:Content>
