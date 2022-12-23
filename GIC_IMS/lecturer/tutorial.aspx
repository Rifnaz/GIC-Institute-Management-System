﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tutorial.aspx.cs" Inherits="GIC_IMS.lecturer.tutorial" %>

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
    <title>Global International College</title>
    <style>
         a.edit {
            color: #FFC107;
            padding-left: 20px;
        }
        a.delete {
            color: #E34724;
        }

        .card-body{
            color: #1C2833;  
        }

        .card{
            width: 350px;
            height: 300px;
        }

        .card-header{
            justify-content: space-between;
            height: 100px
        }

        .frame{
            width: 300px;
            height : 150px;
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
        <div class="container">
        <!-- Page Content -->
        <div id="page-content-wrapper">
            <nav class="navbar navbar-expand-lg navbar-light bg-transparent py-4 px-4">
                <div class="d-flex align-items-center">
                    <i class="fas fa-align-left primary-text fs-4 me-3" id="menu-toggle"></i>
                    <h2 class="fs-2 m-0">Tutorials</h2>
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
                                <li><a class="dropdown-item" href="../index.aspx">Logout</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row d-flex">
                <div class="row">
                    <asp:Label ID="lblcourse" runat="server" Text="Label" Visible="false"></asp:Label>
                    <div class="col">
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtxLink" runat="server" class="form-control" placeholder="Link"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnRegister" class="btn btn-primary" runat="server" Text="Register" OnClick="btnRegister_Click"/>
                    </div>
                </div>
            </div>
            <br />
            <div class="row"> 
                   <asp:DataList ID="dtl_exam" runat="server" RepeatColumns="3" CellPadding="0" CellSpacing="0"> 
                        <ItemTemplate>
                            <div class="container-fluid">
                                <div class="card">
                                    <div class="card-header d-flex">
                                        <h5> <%#Eval("Title") %></h5>
                                        <div class="btnn">
                                            <asp:LinkButton ID="lbtnEdit" runat="server" class="edit" CommandArgument='<%#Eval("TutorialID") %>' title="Edit" data-toggle="tooltip" ><i class="material-icons">&#xE254;</i></asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" class="delete" CommandArgument='<%#Eval("TutorialID") %>' title="Delete" data-toggle="tooltip" ><i class="material-icons">&#xE872;</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <h6><%#Eval("Course") %></h6>
                                        <iframe class="frame" src='<%#Eval("Link") %>' title='<%#Eval("Title") %>' frameborder="0" allow="accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
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
