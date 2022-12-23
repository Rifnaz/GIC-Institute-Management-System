<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="GIC_IMS.contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <title>Global International College</title>
    <style>
        body{
            height: 100vh;
            background: #baf3d7 !important;
            align-items: center;
            justify-content: center;
        }
  
        .bg-image {
            background-image: url('img/college.jpg');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
        }

        .backhome {
        color: #009d63;
        font-weight: bold;
        }
         
        #lblError {
            color: red;
            font-size: 11px;
        }
    </style>
</head>
<body>
    <form id="contactForm" runat="server">
        
<div class="container-fluid px-5 my-5">
  <div class="row justify-content-center">
    <div class="col-xl-10">
      <div class="card border-0 rounded-3 shadow-lg overflow-hidden">
        <div class="card-body p-0">
          <div class="row g-0">
            <div class="col-sm-6 d-none d-sm-block bg-image"></div>
            <div class="col-sm-6 p-4">
              <div class="text-center">
                <div class="h3 fw-light">Contact Form</div>
                <p class="mb-4 text-muted">Split layout contact form</p>
              </div>

                <div class="form-floating mb-3">
                  <asp:TextBox ID="txtName" runat="server"  class="form-control" type="text" placeholder="Full Name"></asp:TextBox>
                  <label for="name">Name</label>
                </div>

                <div class="form-floating mb-3">
                  <asp:TextBox ID="txtMail" runat="server"  class="form-control" type="email" placeholder="Email Address"></asp:TextBox>
                  <label for="emailAddress">Email Address</label>
                </div>

                 <div class="form-floating mb-3">
                  <asp:TextBox ID="txtPhone" runat="server"  class="form-control" type="number" placeholder="Phone No"></asp:TextBox>
                  <label for="phoneNo">Phone No</label>
                </div>

                <div class="form-floating mb-3">
                  <textarea id="txtMess" runat="server" cols="65" rows="5" placeholder=""></textarea>
                  <label for="message"></label>
                </div>
                  <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                <div class="d-grid">
                    <asp:Button ID="btnSubmit" class="btn btn-primary btn-lg" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                </div>
                <br />
                <div class="bck">
                    <asp:LinkButton ID="lnkbtnBack" class="backhome" runat="server" OnClick="lnkbtnBack_Click">< Back</asp:LinkButton>
                </div>
                <div>
                </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>

<!-- CDN Link to SB Forms Scripts -->
<script src="https://cdn.startbootstrap.com/sb-forms-latest.js"></script>
    </form>
</body>
</html>
