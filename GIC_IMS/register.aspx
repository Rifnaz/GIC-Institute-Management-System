<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="GIC_IMS.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Student Registration</title>
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <link rel="stylesheet" type="text/css" href="css/login.css"/>
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
                txtCon.type = "text";
            } else {
                txtPass.type = "password";
                txtCon.type = "password";
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
            Student Registration
          </h4>
          <form class="form-box px-6" runat="server" >
            <asp:Label ID="lblError_name" Text="" runat="server"/>
            <div class="row">
            <div class="form-input col-md-6">
                <span><i class="fa fa-user"></i></span>
                <asp:TextBox type="text" name="firstname" runat="server" placeholder="First Name" id="txtFname"></asp:TextBox>
            </div>
            <div class="form-input col-md-6">
                <asp:TextBox ID="txtLname" type="text" name="lastname" placeholder="Last Name" runat="server"></asp:TextBox>
            </div>
            </div>
            <asp:Label ID="lblError_mail" Text="" runat="server"/>
            <div class="form-input">
              <span><i class="fa fa-envelope"></i></span>
                <asp:TextBox type="email" name="" runat="server" placeholder="Email Address" tabindex="10"  id="txtEmail"></asp:TextBox>
            </div>
            <asp:Label ID="lblError_pic" Text="" runat="server"/>
            <div class="form-input">
              <span><i class="fa fa-image"></i></span>
              <asp:FileUpload ID="fileImg" runat="server" />
            </div>
            <asp:Label ID="lblError_pass" Text="" runat="server"/>
            <div class="form-input">
              <span><i class="fa fa-key"></i></span>
              <asp:TextBox ID="txtPass" runat="server" type="password" placeholder="Password"></asp:TextBox>
            </div>
             <asp:Label ID="lblError_con" Text="" runat="server"/>
            <div class="form-input">
                <span><i class="fa fa-key"></i></span>
                <asp:TextBox ID="txtCon" runat="server" type="password" placeholder="Password"></asp:TextBox>
            </div>
            <div class="mb-3">
              <div class="">
                 <input id="myCheck" onclick="showPassword()" type="checkbox"/>
                <label class="check">Show Password</label>
              </div>
            </div>
             <asp:Label ID="lblError" Text="" runat="server"/>
            <div class="mb-3">
               <asp:Button type="submit" ID="btnSignup"  class="btn btn-block text-uppercase" runat="server" Text="Sign Up" OnClick="btnSignup_Click" />
            </div>

            <hr class="my-4"/>

            <div class="bck text-center">
              <a href="index.aspx" class="backhome">
                < Back to Home
              </a>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</body>
</html>
