<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reset-password.aspx.cs" Inherits="GIC_IMS.reset_password" %>

<!DOCTYPE html>
<html lang="en">

  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Bootstrap 5 Forgot Password</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
      <script>
        function showPassword() {
            // Get the checkbox
            var checkBox = document.getElementById("myCheck");

            // If the checkbox is checked, display the output text
            if (checkBox.checked == true) {
                txtpass.type = "text";
                txtCon.type = "text";
            } else {
                txtpass.type = "password";
                txtCon.type = "password";
            }
        }
      </script>
      <style>
        body{
            height: 100vh;
            background: #baf3d7 !important;
            justify-content: center;
          }
    </style>
  </head>
<body>
    <form id="form1" runat="server">
      <div class="container d-flex flex-column">
          <div class="row align-items-center justify-content-center
              min-vh-100 g-0">
            <div class="col-12 col-md-8 col-lg-4 border-top border-3 border-primary">
              <div class="card shadow-sm">
                <div class="card-body">
                  <div class="mb-4">
                    <h5>Reset Password</h5>
                    <p class="mb-2">Enter your new password and  confirm the password
                    </p>
                  </div>
                    <div class="mb-3">
                      <label for="password" class="form-label">New Password</label>
                        <asp:TextBox type="password" id="txtpass" class="form-control" name="password" placeholder="Enter Your New Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                       <label for="password" class="form-label">Confirm Password</label>
                        <asp:TextBox type="password" id="txtCon" class="form-control" name="password" placeholder="Confirm your Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="">
                        <input id="myCheck" onclick="showPassword()" type="checkbox"/>
                        <label class="check">Show Password</label>
                    </div>
                    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                     <div class="mb-2 d-grid">
                         <asp:Button type="submit" class="btn btn-success" ID="btnRest" runat="server" Text="Reset" OnClick="btnRest_Click" />
                    </div>
                    <div class="bck">
                      <a href="index.aspx" class="backhome">
                        Back to Home
                      </a>
                    </div>
                </div>
              </div>
            </div>
          </div>
        </div>
    </form>
</body>
</html>
