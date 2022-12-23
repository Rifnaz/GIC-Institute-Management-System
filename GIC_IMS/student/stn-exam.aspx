<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stn-exam.aspx.cs" Inherits="GIC_IMS.student.stn_exam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link rel="stylesheet" href="../css/style.css" media="screen" />
    <link rel="stylesheet" href="css/exam.css" media="screen" />
    <title>Global International College</title>
    <style>
      
        #lblError {
            color: red;
            font-size: 11px;
        }
        .hide{
            display:none;
        }

        .ss {
            background-color: cadetblue;
            width: 50%;
            height: 60px;
            border-radius: 5px;
        }

        .row {
            justify-content: space-evenly;
        }

        .card-body{
            color: #1C2833;
        }

        .card-header{
            justify-content: space-between;
        }

        #btnSubmit{
            margin-left: 50%;
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
                    <h2 class="fs-2 m-0">Exams</h2>
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
         <div class="container">
            <div class="row"> 
               <div class="col-sm-6 col-md-9 form-section">
                   <asp:DataList ID="dtl_exam" runat="server" RepeatColumns="1" CellPadding="0" CellSpacing="0"> 
                        <ItemTemplate>
                            <div class="container-fluid">
                                <div class="card">
                                    <div class="card-header d-flex">
                                        <h4>Q. <%#Eval("Question") %></h4>
                                       
                                    </div>
                                    <div class="card-body">
                                        <asp:RadioButton ID="RadioButton1" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer1") %>'/><br />
                                        <asp:RadioButton ID="RadioButton2" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer2") %>'/><br />
                                        <asp:RadioButton ID="RadioButton3" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer3") %>'/><br />
                                        <asp:RadioButton ID="RadioButton4" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer4") %>'/><br />
                                        <asp:Label ID="lblSeleted" runat="server" Text="" ></asp:Label>
                                    </div>
                                    <asp:Label ID="lblAnswer" runat="server" Text="" Visible="false"> <%#Eval("Answer") %></asp:Label>
                                    
                                </div>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                   <div>
                       <asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit" Onclick="btnSubmit_Click"/>
                   </div>
                   </div>
                    <div class="col-sm-6 col-md-3 form-section">
                        <div class="login-wrapper">
                        <div class="card">
                            <div class="card-header"><h4>The Results</h4></div>
                            <div class="card-body d-flex">
                                <asp:Label ID="Label1" Font-Size="XX-Large" Font-Bold="true" runat="server" Text="Marks :"></asp:Label><asp:Label ID="lblResult" Font-Size="XX-Large" Font-Bold="true" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
    </form>
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
