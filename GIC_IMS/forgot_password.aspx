<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgot_password.aspx.cs" Inherits="GIC_IMS.forgot_password" %>

<!DOCTYPE html>
<html lang="en">

  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Bootstrap 5 Forgot Password</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
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
                    <h5>Forgot Password?</h5>
                    <p class="mb-2">Enter your registered email ID to reset the password
                    </p>
                  </div>
                    <div class="mb-3">
                      <label for="email" class="form-label">Email</label>
                        <asp:TextBox type="email" id="txtMail" class="form-control" name="email" placeholder="Enter Your Email"
                         runat="server"></asp:TextBox>
                        <asp:Label ID="lblEmailError" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="mb-3 d-grid">
                        <asp:Button  type="submit" class="btn btn-primary" ID="btnSend" runat="server" Text="Send the code" OnClick="btnSend_Click" />  
                    </div>
                    <div class="mb-3">
                        <asp:TextBox type="number" id="txtCode" class="form-control" name="code" placeholder="Enter Your code"
                         runat="server"></asp:TextBox>
                        <asp:Label ID="lblCodelError" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </div>
                     <div class="mb-2 d-grid">
                         <asp:Button type="submit" class="btn btn-success" ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />
                    </div>
                    <span>Back to <asp:LinkButton ID="lbtnLogin" runat="server" OnClick="lbtnLogin_Click">Login</asp:LinkButton></span> 
                    <asp:Label ID="Label1" runat="server" Text="" visible="false"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="LabelEmail" runat="server" Text="" Visible="false"></asp:Label>
                </div>
              </div>
            </div>
          </div>
        </div>
        
    </form>
</body>
</html>
