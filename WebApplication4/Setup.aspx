<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="WebApplication4.Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
    Registration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
    <link href="css/Setup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentHolder" runat="server">
    <div class="form-signin">
        
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <h3>GoDaddy Account Required</h3>
                <p>Welcome! Lets get you started. All you need is a godaddy auction account - how else are we to bid! Please enter your details below.</p>
            </div>
        </div>
        <div class="row">

            <div class="col-md-8 col-md-offset-3">
                
            <asp:Panel runat="server" ID="pnlCustomer" class="form-horizontal" role="form"  DefaultButton="LinkButton3">
                <div class="form-group">
                    <label class="col-sm-2 control-label">GoDaddy Login</label>
                    <div class="col-md-6">
                        <asp:TextBox type="text" class="form-control" ID="GodaddyUsername" placeholder="Username" runat="server" required autofocus/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Password</label>
                    <div class="col-md-5">
                        <asp:TextBox type="password" class="form-control" placeholder="Password" id="GodaddyPassword" TextMode="Password" runat="server" required />
                    </div>
                    <asp:LinkButton ID="LinkButton3" Text="Save" class="btn btn-default" OnClick="btnSave_Godaddy" runat="server">Save</asp:LinkButton>
                </div>
                <asp:Label ID="Msg" ForeColor="red" runat="server" />
            </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterHolder" runat="server">
</asp:Content>
