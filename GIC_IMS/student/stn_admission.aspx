<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stn_admission.aspx.cs" Inherits="GIC_IMS.student.stn_admission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link rel="stylesheet" href="../css/style.css" media="screen"/>
    <link rel="stylesheet" href="css/stn_admission.css" media="screen"/>

    <title>Global International College</title>
    <style>
        
        #lblError {
            color: red;
            font-size: 11px;
        }
        .hide{
            display:none;
        }

        #lblEmail{
            font-size: 14px;
            color: mediumvioletred;
        }
        #courseapplyforadmission{
            text-align:center;
            justify-content:space-evenly;
        }

        .profile {
	        text-align: center;
	        color: white;
	        justify-content:center;
        }
    </style>
</head>
<body>
    <div class="d-flex" id="wrapper">
        <!-- Sidebar -->
        <div class="bg-white" id="sidebar-wrapper">
            <div class="sidebar-heading text-left py-4 primary-text fs-4 fw-bold text-uppercase border-bottom">
                <i class="fas fa-solid fa-graduation-cap me-2"></i>G I C</div>
                <div class="list-group list-group-flush my-3">
                <a href="studentdash.aspx" class="list-group-item list-group-item-action bg-transparent second-text active"><i
                        class="fas fa-tachometer-alt me-2"></i>Dashboard</a>
                <a href="stn_admission.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-solid fa-book me-2"></i>Admissions</a>
                <a href="courseforpay.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-solid fa-bookmark me-2"></i>Payment</a>
                <a href="courseforexam.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-duotone fa-user-secret me-2"></i>Exams</a>
                 <a href="stn-tutorial.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-comment-dots me-2"></i>Tutorials</a>
                <a href="../contact.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-comment-dots me-2"></i>Inquiry</a>
                <a href="announcement_details.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-solid fa-calendar me-2"></i>Announcements</a>
                <a href="../index.aspx" class="list-group-item list-group-item-action bg-transparent text-danger fw-bold"><i
                        class="fas fa-power-off me-2"></i>Logout</a>
            </div>
        </div>
        <!-- /#sidebar-wrapper -->

        <!-- Page Content -->
        <div id="page-content-wrapper">
            <nav class="navbar navbar-expand-lg navbar-light bg-transparent py-4 px-4">
                <div class="d-flex align-items-center">
                    <i class="fas fa-align-left primary-text fs-4 me-3" id="menu-toggle"></i>
                    <h2 class="fs-2 m-0">Admission</h2>
                </div>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle second-text fw-bold" href="#" id="navbarDropdown"
                                role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                <i class="fas fa-user me-2"></i>Student
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="#">Profile</a></li>
                                <li><a class="dropdown-item" href="../index.aspx">Logout</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
    <form id="form1" runat="server">
          <div class="container-fluid">
                <div class="row justify-content-center">
                    <div class="col-12 col-lg-11">
                        <div class="card card0 rounded-0">
                            <div class="row">
                                <div class="col-md-5 d-md-block d-none p-0 box">
                                    <div class="card rounded-0 border-0 card1" id="bill">
                                        <h3 id="heading1"></h3>
                                        <div class="profile">
                                            <asp:Image ID="imgdp" class="popupdp" runat="server"/><br />
                                            <asp:Label ID="lblname" CssClass="h3" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblEmail" CssClass="h2" runat="server"></asp:Label>
                                            <asp:DataList ID="dtl_applyfor" runat="server" RepeatColumns="1" CellPadding="0" CellSpacing="0">
                                                <ItemTemplate>
                                                    <div class="d-flex" id="courseapplyforadmission">
                                                        <h6>Applied for :</h6>
                                                        <asp:Label ID="applyforcourse" runat="server"><%# Eval("Applyfor")%></asp:Label>
                                                    </div>
                                                 </ItemTemplate>
                                            </asp:DataList>

                                        </div>
                                    </div>
                                </div>
            
                                <div class="col-md-7 col-sm-12 p-0 box">
                                    <div class="card rounded-0 border-0 card2" id="paypage">
                                        <div class="form-card">
                                            <h2 id="heading2" class="text-danger">Fill the form</h2>
                                            <table>
                                                <tr>
                                                    <td>DOB</td>
                                                    <td><asp:TextBox type="date" ID="txtDOB" runat="server" placeholder="11/17/2000"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Phone No</td>
                                                    <td><asp:TextBox type="tel" pattern="07[1,2,5,6,7,8][0-9]{7}" maxlength="10" ID="txtPhone" runat="server" placeholder="717100072"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Gender</td>
                                                    <td>
                                                        <asp:DropDownList ID="dplGender" runat="server">
                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Femal">Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Address</td>
                                                    <td><textarea id="txtAddress" runat="server" cols="20" rows="5" placeholder="No.26/1, Peraru Kanthale."></textarea></td>
                                                </tr>
                                                <tr>
                                                    <td>City</td>
                                                    <td><asp:TextBox  ID="txtCity" runat="server" placeholder="Colombo"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Qualification</td>
                                                    <td>
                                                        <asp:DropDownList ID="dplQualification" runat="server">
                                                            <asp:ListItem>High Scool</asp:ListItem>
                                                            <asp:ListItem>Certificate</asp:ListItem>
                                                            <asp:ListItem>Diploma</asp:ListItem>
                                                            <asp:ListItem>HND</asp:ListItem>
                                                            <asp:ListItem>Bachelors</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Apply for</td>
                                                    <td><asp:DropDownList ID="dplApply" runat="server" OnSelectedIndexChanged="dplApply_SelectedIndexChanged" AutoPostBack="true"><asp:ListItem>Apply for</asp:ListItem></asp:DropDownList></td>
                                                </tr>
                                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                                        <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                                                    </td>
                                                </tr>
                                                <asp:Label ID="lblID" class="hide" runat="server" Text=""></asp:Label>
                                                <asp:Label ID="lbldpcours" class="hide" runat="server" Text=""></asp:Label>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <div>
        </div>
    </form>
 </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        var el = document.getElementById("wrapper");
        var toggleButton = document.getElementById("menu-toggle");

        toggleButton.onclick = function () {
            el.classList.toggle("toggled");
        };
    </script>
</body>
</html>