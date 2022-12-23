﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="announcement_details.aspx.cs" Inherits="GIC_IMS.announcement_detais" %>

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

        h6, table, p {
          padding: 4px;
          margin: 0;
        }

        card{
            width: 200px;
            height: 60px;
        }

        .pic{
            width: 100%;
            height: 150px;
        }

        .announce-list{
            width: 400px;
            height: 200px;
            justify-content: space-evenly;
            padding: 20px;
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
                    <h2 class="fs-2 m-0">Announcements</h2>
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
                                <li><a class="dropdown-item" href="#">Settings</a></li>
                                <li><a class="dropdown-item" href="../index.aspx">Logout</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
          <form id="form1" runat="server">
                <div class="container">              
                   <asp:DataList ID="dtl_annon" runat="server" RepeatColumns="3" CellPadding="0" CellSpacing="0"> 
                        <ItemTemplate>
                            <div class="row"> 
                                <div class="col">
                                    <div class="announce-list">                                 
                                        <div class="card">
                                            <div class="card-header d-flex">
                                               <h4><%#Eval("Title") %></h4>
                                            </div>
                                            <div class="card-body">
                                                 <asp:Image ID="Image1" class="pic" ImageUrl='<%#Eval("Picture") %>' runat="server" />
                                            <h5><%#Eval("SubTitle") %></h5>
                                             <br />
                                                <div class="row">
                                                    <div class="col"><h5>Start Date</h5></div>
                                                    <div class="col"><%#Eval("StartDate") %></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col"><h5>End Date</h5></div>
                                                    <div class="col"><%#Eval("EndDate") %></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col"><h5>Venue</h5></div>
                                                    <div class="col"><%#Eval("Venue") %></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col"><h5>Time</h5></div>
                                                    <div class="col"><%#Eval("Time") %></div>
                                                </div>
                                                <hr />
                                                <div class="row">
                                                   <div><p><%#Eval("Content") %></p></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          </div>
                            <br />
                       </ItemTemplate>
                  </asp:DataList>
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

