<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GIC_IMS.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Login</title>
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <link rel="stylesheet" type="text/css" href="css/login.css" media="screen"/>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"/>
  <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
  <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script>
        function showPassword() {
            // Get the checkbox
            var checkBox = document.getElementById("myCheck");

            // If the checkbox is checked, display the output text
            if (checkBox.checked == true) {
                txtPass.type = "text";
            } else {
                txtPass.type = "password";
            }
        }
    </script>
</head>
<body>
  <div class="container">
    <div class="row px-3">
      <div class="col-lg-10 col-xl-9 card flex-row mx-auto px-0">
        <div class="img-left d-none d-md-flex"></div>

        <div class="card-body">
          <h4 class="title text-center mt-4">
            Login
          </h4>
          <form class="form-box px-3" runat="server">
            <div class="form-input">
              <span><i class="fa fa-envelope-o"></i></span>
              <asp:TextBox type="email" name="" runat="server" placeholder="Email Address" tabindex="10"  id="txtEmail"></asp:TextBox>
            </div>
              <asp:Label ID="lblError_mail" Text="Enter the Email" runat="server"/>
            <div class="form-input">
              <span><i class="fa fa-key"></i></span>
              <asp:TextBox type="password" name="" runat="server" placeholder="Password"  id="txtPass"></asp:TextBox>
            </div>
              <asp:Label ID="lblError_pass" Text="enter the password" runat="server"/>
            <div class="mb-3">
              <div class="">
                 <input id="myCheck" onclick="showPassword()" type="checkbox"/>
                <label class="check">Show Password</label>
              </div>
            </div>
             <asp:Label ID="lblError" ForeColor="Red" Text="Incorrect Password or Email" runat="server"/>
            <div class="mb-3">
                <asp:Button type="submit" ID="btnLogin" class="btn btn-block text-uppercase" runat="server" OnClick="btnLogin_Click" Text="Login" />
            </div>
            <div class="text-right">
                <asp:LinkButton class="forget-link" ID="lbtnforgotlink" runat="server" OnClick="lbtnforgotlink_Click">
                    Forget Password?
                </asp:LinkButton>
            </div>
            <div class="bck">
              <a href="index.aspx" class="backhome">
                < Back to Home
              </a>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
  <script src ="../script.js"></script>
</body>
</html>
