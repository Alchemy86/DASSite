<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data.Entity.Migrations" %>
<%@ Import Namespace="ASEntityFramework" %>
<%@ Import Namespace="LunchboxSource.api.lunchboxcode" %>
<%@ Import Namespace="WebApplication4.LunchboxAPI" %>

<script runat="server">
    void Logon_Click(object sender, EventArgs e)
    {
        var api = new DomainAuctionSniperAPI();
        if ((api.LoginWP(UserEmail.Text, UserPass.Text) == "MATCHED"))
        {
            using (var ds = new ASEntities())
            {
                var account = ds.Users.FirstOrDefault(x => x.Username == UserEmail.Text);
                if (account == null)
                {
                    ds.Users.Add(new Users { Username = UserEmail.Text, Password = UserPass.Text });
                    ds.SaveChanges();
                }

                var accessLevel = api.GetAccessLevel(UserEmail.Text, UserPass.Text);
                if (api.GetAccessLevel(UserEmail.Text, UserPass.Text) != "FAILED")
                {
                    if (accessLevel.Contains("administrator"))
                    {
                        account.AccessLevel = 10;
                    }else if (accessLevel.Contains("optimizemember_level"))
                    {
                        var index = accessLevel.IndexOf("optimizemember_level");
                        account.AccessLevel = int.Parse(accessLevel.Substring(accessLevel.IndexOf("optimizemember_level"), 1));
                    }

                    ds.Users.AddOrUpdate(account);
                    ds.SaveChanges();
                }
            }

            FormsAuthentication.RedirectFromLoginPage
                (UserEmail.Text, Persist.Checked);
        }
        else
        {
            Msg.Text = @"Invalid credentials. Please try again.";
        }
    }

</script>
<html>
<head id="Head1" runat="server">
  <title>Forms Authentication - Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel='shortcut icon' type='image/x-icon' href='favicon.ico' />
    <link href = "~/css/bootstrap.css" rel = "stylesheet" runat="server" />
	<link href = "~/css/styles.css" rel = "stylesheet" runat="server" />
    <link id="Link1" href = "~/css/Signin.css" rel = "stylesheet" runat="server" />
    
	<script src = "http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
	<script src = "js/bootstrap.js"></script>
</head>
<body id="loginhome">
    
    <div class="login-container">
        <div class="container">
            <div class="label1">
                <img src="img/domain-auction-sniper-logo.png" />
            </div>
          <form class="form-signin" role="form" runat="server">
              <h2 class="form-signin-heading">Sign in to <br/><strong>Domain Auction Sniper</strong></h2>
            <asp:TextBox type="email" class="form-control" ID="UserEmail" placeholder="Email Address" runat="server" required autofocus/>
            <asp:TextBox type="password" class="form-control" placeholder="Password" ID="UserPass" TextMode="Password" runat="server" required />
            <div class="checkbox text-center">
              <label>
                <asp:CheckBox type="checkbox" value="remember-me" ID="Persist" runat="server" />Remember me on this computer
              </label>
            </div>
              <div class="text-center">
                  <asp:Button class="btn btn-custom-lighten" ID="Button1" OnClick="Logon_Click" Text="Log On" 
               runat="server" />
              </div>
              <asp:Label ID="Msg" ForeColor="red" runat="server" />
          </form>
            <br/>
            <div class="label1">
                <span style="color: #000000">Help:</span> <a class="label1" style="color: #006400; text-decoration: underline;" href="http://domainauctionsniper.com/wp-login.php?action=lostpassword">I can't sign in or I forgot my username/password</a>
            </div>

        </div>
    </div>
    
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <p class="navbar-text pull-left">Auction Sniper WEB</p>
            <a href="http://domainauctionsniper.com" target="_blank" class="navbar-btn btn-danger btn pull-right">Sign up NOW</a>
        </div>
    </div>
</body>
</html>