<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addexam.aspx.cs" Inherits="GIC_IMS.lecturer.addexam" %>

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

        a.edit {
            color: #FFC107;
            padding-left: 20px;
        }
        a.delete {
            color: #E34724;
        }

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
    </style>
</head>
<body>
   <div class="d-flex" id="wrapper">
        <!-- Sidebar -->
       <div class="bg-white" id="sidebar-wrapper">
            <div class="sidebar-heading text-left py-4 primary-text fs-4 fw-bold text-uppercase border-bottom">
                <i class="fas fa-solid fa-graduation-cap me-2"></i>G I C</div>
                <div class="list-group list-group-flush my-3">
                <a href="lecturerdash.aspx" class="list-group-item list-group-item-action bg-transparent second-text active"><i
                        class="fas fa-tachometer-alt me-2"></i>Dashboard</a>
                <a href="lec-course.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-solid fa-book me-2"></i>Batch</a>
                <a href="timetable.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-solid fa-users me-2"></i>Timetables</a>
                <a href="addexam.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-duotone fa-user-secret me-2"></i>Exams</a>
                <a href="tutorial.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-duotone fa-user-secret me-2"></i>Tutorials</a>
                <a href="lec-announcement.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                        class="fas fa-solid fa-calendar me-2"></i>Announcements</a>
                <a href="index.aspx" class="list-group-item list-group-item-action bg-transparent text-danger fw-bold"><i
                        class="fas fa-power-off me-2"></i>Logout</a>
            </div>
        </div>
        <!-- /#sidebar-wrapper -->

        <!-- Page Content -->
        <div id="page-content-wrapper">
            <nav class="navbar navbar-expand-lg navbar-light bg-transparent py-4 px-4">
                <div class="d-flex align-items-center">
                    <i class="fas fa-align-left primary-text fs-4 me-3" id="menu-toggle"></i>
                    <h2 class="fs-2 m-0">Add Exam</h2>
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
                                <i class="fas fa-user me-2"></i>Lecturer
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="#">Profile</a></li>
                                <li><a class="dropdown-item" href="#">Settings</a></li>
                                <li><a class="dropdown-item" href="#">Logout</a></li>
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
                                        <div class="btnn">
                                            <asp:LinkButton ID="lbtnEdit" runat="server" class="edit" CommandArgument='<%#Eval("ExamID") %>' title="Edit" data-toggle="tooltip" ><i class="material-icons">&#xE254;</i></asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" class="delete" CommandArgument='<%#Eval("ExamID") %>' title="Delete" data-toggle="tooltip" ><i class="material-icons">&#xE872;</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <asp:RadioButton ID="RadioButton1" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer1") %>'/><br />
                                        <asp:RadioButton ID="RadioButton2" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer2") %>'/><br />
                                        <asp:RadioButton ID="RadioButton3" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer3") %>'/><br />
                                        <asp:RadioButton ID="RadioButton4" Font-Size="Medium"  GroupName="ans" runat="server" text='<%#Eval("Answer4") %>'/><br />
                                    </div>
                                </div>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>           
                   </div>
                    <div class="col-sm-6 col-md-3 form-section">
                                    <div class="login-wrapper">
                                <div class="form-group">
                                               <asp:Label ID="lblcourse" runat="server" Text="Label" Visible="false"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <textarea runat="server" name="" id="txtquestion" cols="30" rows="7" placeholder="Question" class="form-control"></textarea>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtans1" runat="server" class="form-control" placeholder="Answer1"></asp:TextBox>
                                    </div>
                                        <div class="form-group">
                                    <asp:TextBox ID="txtans2" runat="server" class="form-control" placeholder="Answer2"></asp:TextBox>
                                    </div>
                                        <div class="form-group">
                                    <asp:TextBox ID="txtans3" runat="server" class="form-control" placeholder="Answer3"></asp:TextBox>
                                    </div>
                                        <div class="form-group">
                                    <asp:TextBox ID="txtans4" runat="server" class="form-control" placeholder="Answer4"></asp:TextBox>
                                    </div>
                                        <div class="form-group">
                                    <asp:TextBox ID="txtanswer" runat="server" class="form-control" placeholder="Answer"></asp:TextBox>
                                    </div>
                                        
                                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                <div class="form-group mb-3">
                                    <asp:Button ID="btnRegister" class="btn btn-primary" runat="server" Text="Register" OnClick="btnRegister_Click"/>
                                    <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
                                    <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                                </div>
                                    <asp:Label ID="lblID" class="hide" runat="server" Text="Label"></asp:Label>                        
                                </div>
                            </div>
                      </div>
            </div>
         </form>
             <!-- /#page-content-wrapper -->

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
