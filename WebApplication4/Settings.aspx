<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="WebApplication4.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
    <script type="text/javascript">
        function hidemessage() {
            $("#emailmessage").fadeOut();
        };
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
    Settings
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <p>Manage your preferences here.</p>
        </div>
    </div>
    <div class="row"></div>
        <br/>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <asp:UpdatePanel ID="UpdatePanel1" class="form-horizontal" role="form" DefaultButton="btnRegister" runat="server">
                <ContentTemplate>
                <div class="form-group">
                <label class="col-sm-3 control-label"><strong>GoDaddy Login</strong></label>
                <div class="col-md-6">
                    <asp:TextBox type="text" class="form-control" ID="GodaddyAccount" placeholder="Username" runat="server" required autofocus/>
                </div>
                </div>
                <div class="form-group">
                <label class="col-sm-3 control-label"><strong>Password</strong></label>
                <div class="col-md-5">
                    <asp:TextBox type="password" class="form-control" placeholder="Password" id="GodaddyPassword" TextMode="Password" runat="server" required />
                </div>
                <asp:LinkButton ID="LinkButton4" Class="btn btn-default" OnClick="Verify_click" role="alert" runat="server">Verify</asp:LinkButton>
                    <asp:Label ID="Msg" style="display:none" Class="alert alert-success" role="alert" ForeColor="Green" runat="server" />
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            <br/>

            <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" class="form-horizontal" >
                <Triggers>        
                    <asp:AsyncPostBackTrigger ControlID="receiveEmails" EventName="CheckedChanged" />    
                    <asp:AsyncPostBackTrigger ControlID="useAccountForSearch" EventName="CheckedChanged" />   
                </Triggers>  
                <ContentTemplate>
                    <div class="form-group" >
                        <label class="col-sm-3 control-label" runat="server"><strong>Receive Alert Emails:</strong></label>
                        <div class="col-sm-8">
                            <asp:CheckBox ID="receiveEmails" ClientIDMode="Static" AutoPostBack="True" runat="server" OnCheckedChanged="Update_EmailOptions"></asp:CheckBox>
                            <label style="color: grey">  Get email alerts including warnings and auctions nearing their end</label>
                        </div>
                    </div>
                    <div class="form-group" >
                        <label class="col-sm-3 control-label" runat="server"><strong>Use account for searching:</strong></label>
                        <div class="col-sm-8">
                            <asp:CheckBox ID="useAccountForSearch" ClientIDMode="Static" AutoPostBack="True" runat="server" OnCheckedChanged="Update_UseAccount"></asp:CheckBox>
                            <label style="color: grey">  Use your account for domain searchs(I.e. Enabled adult listed sites etc)</label>
                        </div>
                    </div>
                    <Label ID="emailmessage" style="display:none" Class="alert alert-success pull-right" role="alert" ForeColor="Green" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" class="form-horizontal" >
                <Triggers>        
                    <asp:AsyncPostBackTrigger ControlID="receiveEmails" EventName="CheckedChanged" />    
                </Triggers>  
                <ContentTemplate>

                    <Label ID="Label1" style="display:none" Class="alert alert-success pull-right" role="alert" ForeColor="Green" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
                
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
</asp:Content>
