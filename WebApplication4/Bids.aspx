<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="Bids.aspx.cs" Inherits="WebApplication4.Bids" EnableEventValidation = "false" %>
<%@ Register TagPrefix="cc1" Namespace="LunchboxWebControls" Assembly="LunchboxWebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
    <script type="text/javascript">

        function zxcCountDown(id, mess, secs, mins, hrs, days) {
            var obj = document.getElementById(id);
            var oop = obj.oop;
            if (!oop) obj.oop = new ZxcCountDownOop(obj, mess, secs, mins, hrs, days);
            else {
                clearTimeout(oop.to);
                oop.mess = mess;
                oop.mhd = [mins, hrs, days];
                oop.srt = new Date().getTime();
                oop.fin = new Date().getTime() + ((days || 0) * 86400) + ((hrs || 0) * 3600) + ((mins || 0) * 60) + ((secs || 0));
                oop.end = ((oop.fin - oop.srt));
                oop.to = null;
                oop.cng();
            }
        }

        function ZxcCountDownOop(obj, mess, secs, mins, hrs, days) {
            this.obj = obj;
            this.mess = mess;
            this.mhd = [mins, hrs, days];
            var date = new Date();
            this.fin = new Date(date.getFullYear(), date.getMonth(), date.getDate() + (days || 0), date.getHours() + (hrs || 0), date.getMinutes() + (mins || 0), date.getSeconds() + (secs || 0));
            this.to = null;
            this.cng();
        }

        ZxcCountDownOop.prototype.cng = function () {
            var now = new Date(), s = (this.fin - now) / 1000 + 1, d = Math.floor(s / 60 / 60 / 24), h = Math.floor(s / 60 / 60 - d * 24), m = Math.floor(s / 60 - h * 60 - d * 24 * 60), s = Math.floor(s - m * 60 - h * 3600 - d * 24 * 60 * 60);
            if (this.fin - now > -500) {
                this.obj.innerHTML = (this.mhd[2] ? (d > 9 ? d : '0' + d) + ' days ' : '') + (this.mhd[1] || this.mhd[2] ? (h > 9 ? h : '0' + h) + ' hours ' : '') + (this.mhd[0] || this.mhd[1] || this.mhd[2] ? (m > 9 ? m : '0' + m) + ' minutes ' : '') + (s > 9 ? s : '0' + s) + ' seconds';
                this.to = setTimeout(function (oop) { return function () { oop.cng(); } }(this), 1000);
            }
            else {
                this.obj.innerHTML = this.mess || '';
            }
        }

        /*]]>*/
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    <div id="bidwindow" class="col-md-12">
        
        <h1>Bids</h1>
        <p>My Current Bids</p>
        <ul id="tabs" class="nav nav-tabs" data-tabs="tabs">
            <li class="active pull-right"><a href="#Current" data-toggle="tab">Current</a></li>
            <li class="pull-right"><a href="#Historical" data-toggle="tab">Historical</a></li>
        </ul>
        <div class="table-responsive">
            
        <div id="my-tab-content" class="tab-content">
            <div class="tab-pane active" id="Current">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                      
            <div id="bidcontainer">
                <cc1:LunchboxGridView OnRowCommand="MyBids_RowCommand" ID="LunchboxGridView2" runat="server" AutoGenerateColumns="False"  
                    OnRowDataBound="grdViewCustomers_OnRowDataBoundCurrent"  onrowcreated="gvAgency_DataBound" 
                    DataKeyNames="AuctionID"  CellPadding="4" CssClass="gridOverall" GridLines="None" OnRowUpdating="updatestuff"
                    AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" OnRowEditing="LunchboxGridView2_OnRowEditing" >
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
                                            <h4>Historyd<span class="glyphicon glyphicon-signal pull-right"></span></h4>
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
                        <asp:BoundField HeaderText="Ref" ReadOnly="True" SortExpression="AuctionRef" DataField="AuctionRef" HtmlEncode="false"/>
                        <asp:BoundField HeaderText="Minimum Bid" ReadOnly="True" SortExpression="MinBid" DataField="MinBid" HtmlEncode="false"/>
                        <asp:BoundField HeaderText="End Date" ReadOnly="True" SortExpression="EndDate" DataField="EndDate" HtmlEncode="false"/>
                        <asp:TemplateField HeaderText="Count Down" SortExpression="EndDate">
                            <ItemTemplate >
                                <span id="timer_<%# Container.DataItemIndex %>"
                                    class="timer" 
                                    data-start='<%#Eval("EndDate", "{0:M/dd/yyyy H:mm:ss}")%>'
                                    data-currentTime='<%# DefaultView.GetPacificTime.ToString("M/dd/yyyy H:mm:ss") %>'></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField HeaderText="My Bid" SortExpression="MyBid" DataField="MyBid" HtmlEncode="false">
                            <ItemStyle CssClass="moo"></ItemStyle>
                        </asp:BoundField>
                    
                        <asp:TemplateField>
                        <EditItemTemplate>
                            <span class="pull-right">
                                <asp:LinkButton Text="Update" style="color: #ffffff; margin: 5px 0 5px 20px" CssClass="btn btn-xs btn-primary" runat="server" CommandName="Update" CommandArgument='<%#Eval("AuctionID")%>'/>
                                <asp:LinkButton Text="Cancel" style="color: #ffffff; margin: 5px 5px " CssClass="btn btn-xs btn-warning" runat="server" OnClick = "OnCancel" />
                            </span>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" SortExpression="">
                            <ItemTemplate>
                                <span class="pull-right">
                                <asp:LinkButton id="lnkBtnDel" style="color: #ffffff; margin: 5px 0 5px 20px" CssClass="btn btn-xs btn-danger" runat="server" CommandName="DeleteRow" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" CommandArgument='<%#Eval("AuctionID")%>'>Delete</asp:LinkButton>
                                <a id="SetBid" data-toggle="modal" onclick="myFunction2('<%#Eval("AuctionID")%>')" data-id="<%#Eval("AuctionID")%>" href="#<%#Eval("AuctionID")%>" style="color: #ffffff; margin: 5px 5px " class="open-AddBookDialog btn btn-xs btn-primary">History</a> 
                            </span>
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
            </div>
            <div class="tab-pane" id="Historical">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                      
            <div id="bidcontainer">
                <cc1:LunchboxGridView OnRowCommand="MyBids_RowCommand" ID="LunchboxGridView1" runat="server" AutoGenerateColumns="False"  
                    OnRowDataBound="grdViewCustomers_OnRowDataBound"  onrowcreated="gvAgency_DataBound" 
                    DataKeyNames="AuctionID"  CellPadding="4" CssClass="gridOverall" GridLines="None" OnRowUpdating="updatestuff"
                    AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" OnRowEditing="LunchboxGridView2_OnRowEditing" >
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
                        <asp:BoundField HeaderText="Ref" ReadOnly="True" SortExpression="AuctionRef" DataField="AuctionRef" HtmlEncode="false"/>
                        <asp:BoundField HeaderText="Minimum Bid" ReadOnly="True" SortExpression="MinBid" DataField="MinBid" HtmlEncode="false"/>
                        <asp:BoundField HeaderText="End Date" ReadOnly="True" SortExpression="EndDate" DataField="EndDate" HtmlEncode="false"/>
                        <asp:TemplateField HeaderText="Count Down" SortExpression="EndDate">
                            <ItemTemplate >
                                <span id="timer_<%# Container.DataItemIndex %>"
                                    class="timer" 
                                    data-start='<%#Eval("EndDate", "{0:M/dd/yyyy H:mm:ss}")%>'
                                    data-currentTime='<%# DefaultView.GetPacificTime.ToString("M/dd/yyyy H:mm:ss") %>'></span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="My Bid" SortExpression="MyBid" DataField="MyBid" HtmlEncode="false">
                        </asp:BoundField>
                    
                        <asp:TemplateField>
                        <EditItemTemplate>
                            <span class="pull-right">
                                <asp:LinkButton Text="Update" style="color: #ffffff; margin: 5px 0 5px 20px" CssClass="btn btn-xs btn-primary" runat="server" CommandName="Update" CommandArgument='<%#Eval("AuctionID")%>'/>
                                <asp:LinkButton Text="Cancel" style="color: #ffffff; margin: 5px 5px " CssClass="btn btn-xs btn-warning" runat="server" OnClick = "OnCancel" />
                            </span>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" SortExpression="">
                            <ItemTemplate>
                                <span class="pull-right">
                                <asp:LinkButton id="lnkBtnDel" style="color: #ffffff; margin: 5px 0 5px 20px" CssClass="btn btn-xs btn-danger" runat="server" CommandName="DeleteRow" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" CommandArgument='<%#Eval("AuctionID")%>'>Delete</asp:LinkButton>
                                <a id="SetBid" data-toggle="modal" onclick="myFunction2('<%#Eval("AuctionID")%>')" data-id="<%#Eval("AuctionID")%>" href="#<%#Eval("AuctionID")%>" style="color: #ffffff; margin: 5px 5px " class="open-AddBookDialog btn btn-xs btn-primary">History</a> 
                            </span>
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
            </div>
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
<script type='text/javascript'>
    //generate countdown timers for every auction - booya
    function applyTimers() {
        $(".timer").each(function() {
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
    };

    $(document).ready(function() {
        applyTimers();
    });

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        applyTimers();
    });

</script>
</asp:Content>
