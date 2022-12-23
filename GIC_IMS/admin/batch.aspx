<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="batch.aspx.cs" Inherits="GIC_IMS.admin.batch" %>

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
    <link rel="stylesheet" href="css/lecture.css" media="screen" />
    <title>Global International College</title>
     <style>
        table.table td a.view {
            color: #03A9F4;
        }
        table.table td a.edit {
            color: #FFC107;
        }
        table.table td a.delete {
            color: #E34724;
        }
        #lblError {
            color: red;
            font-size: 11px;
        }
        .hide{
            display:none;
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
                    <a href="admindash.aspx" class="list-group-item list-group-item-action bg-transparent second-text active"><i
                            class="fas fa-tachometer-alt me-2"></i>Dashboard</a>
                    <a href="admission.aspx" class="list-group-item list-group-item-action bg-transparent second-text active"><i
                            class="fas fa-tachometer-alt me-2"></i>Admissions</a>
                    <a href="courses.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-solid fa-book me-2"></i>Courses</a>
                    <a href="batch.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-solid fa-bookmark me-2"></i>Batches</a>
                    <a href="student.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-solid fa-users me-2"></i>Students</a>
                    <a href="lecturer.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-duotone fa-user-secret me-2"></i>Lectures</a>
                    <a href="announcement.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-comment-dots me-2"></i>Announcements</a>
                    <a href="announcement.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-comment-dots me-2"></i>Payment</a>
                     <a href="report.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-comment-dots me-2"></i>Reports</a>
                    <a href="admin-timetable.aspx" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i
                            class="fas fa-solid fa-calendar me-2"></i>TimeTable</a>
                    <a href="../index.aspx" class="list-group-item list-group-item-action bg-transparent text-danger fw-bold"><i
                            class="fas fa-power-off me-2"></i>Logout</a>
                </div>
        </div>

        <!-- /#sidebar-wrapper -->
        <div class="container">
        <!-- Page Content -->
        <div id="page-content-wrapper">
            <nav class="navbar navbar-expand-lg navbar-light bg-transparent py-4 px-4">
                <div class="d-flex align-items-center">
                    <i class="fas fa-align-left primary-text fs-4 me-3" id="menu-toggle"></i>
                    <h2 class="fs-2 m-0">Batch</h2>
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
                                <i class="fas fa-user me-2"></i>Admin
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
                <div class="row-sort d-flex">
                    <asp:Label ID="Label1" runat="server" Text="Sort By Course :"></asp:Label>
                    <asp:DropDownList ID="dplsortCourse" runat="server"  OnSelectedIndexChanged="dplsortCourse_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:LinkButton ID="lbtnRfresh" runat="server" class="view" OnClick="lbtnRfresh_Click"><i class="material-icons">&#xe5d5;</i></asp:LinkButton>
                </div>
                <div class="row">
                <div class="col-sm-6 col-md-9 form-section">
                    <div class="table-responsive">
                        <div class="table-wrapper">
                            <table >
                                <asp:DataList class="table" ID="dtlBatch" RepeatColumns="7" runat="server">
                                    <HeaderTemplate>
                                        <tr>
                                            <th scope="col">Batch No</th>
                                            <th scope="col">Course</th>
                                            <th scope="col">StartDate</th>
                                            <th scope="col">EndDate</th>
                                            <th scope="col">Coodinator</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        
                                            <tr>
                                                <td scope="row"><%#Eval("BatchNo") %></td>
                                                <td><%#Eval("Course") %></td>
                                                <td><%#Eval("StartDate") %></td>
                                                <td><%#Eval("EndDate") %></td>
                                                <td><%#Eval("Coodinator") %></td>
                                                <td>
<%--                                                    <asp:LinkButton ID="lbtnView" runat="server" class="view" CommandArgument='<%#Eval("BatchID") %>' title="View" data-toggle="tooltip" OnClick="lbtnView_Click"><i class="material-icons">&#xe8f4;</i></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lbtnEdit" runat="server" class="edit" CommandArgument='<%#Eval("BatchID") %>' title="Edit" data-toggle="tooltip" OnClick="lbtnEdit_Click"><i class="material-icons">&#xE254;</i></asp:LinkButton>
                                                    <asp:LinkButton ID="lbtnDelete" runat="server" class="delete" CommandArgument='<%#Eval("BatchID") %>' title="Delete" data-toggle="tooltip" OnClick="lbtnDelete_Click"><i class="material-icons">&#xE872;</i></asp:LinkButton>
                                                </td>
                                            </tr>       
                                     </ItemTemplate>
                                </asp:DataList>
                            </table>
                        </div>
                    </div>
                </div>
                  <div class="col-sm-6 col-md-3 form-section">
                    <div class="login-wrapper">
                        <div class="form-group">
                          <asp:TextBox ID="txtBatchNum" runat="server" class="form-control" placeholder="Batch No"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <asp:DropDownList ID="dplCourse" runat="server" class="form-control"><asp:ListItem Value="">Select Course</asp:ListItem></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtStart" runat="server" class="form-control" placeholder="Start Date" type="text" onfocus="(this.type='date')"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEnd" runat="server" class="form-control" placeholder="End Date" type="text" onfocus="(this.type='date')"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <asp:DropDownList ID="dplcoodinator" runat="server" class="form-control"><asp:ListItem>Select Coodinator</asp:ListItem></asp:DropDownList>
                        </div>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        <div class="form-group mb-3">
                            <asp:Button ID="btnRegister" class="btn btn-primary" runat="server" Text="Register" OnClick="btnRegister_Click"/>
                            <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                            <asp:Label ID="lblID" class="hide" runat="server" Text="Label"></asp:Label>                        
                    </div>
                  </div>
                </div>
              </div>
        </form>
             <!-- /#page-content-wrapper -->
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
