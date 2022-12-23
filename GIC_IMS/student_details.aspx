﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_details.aspx.cs" Inherits="GIC_IMS.student_details" %>

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
    <link rel="stylesheet" href="css/style.css" media="screen" />
    <link rel="stylesheet" href="css/sadmission.css" media="screen" />
    <title>Global International College</title>
    <style>
        .row {
            justify-content: space-evenly;
        }
         #lblError {
            color: red;
            font-size: 11px;
        }
        .hide {
            display: none;
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
                    <h2 class="fs-2 m-0">Student Details</h2>
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
        <div id="popup1" class="verlay">
                <div class="opup">
                    <asp:LinkButton ID="lnkbtnBack" class="close" runat="server" OnClick="lnkbtnBack_Click">< Back</asp:LinkButton><br /><br />
                    <div class="content">
                        <div class="row">
                            <div class="col-3">
                                <asp:Image ID="imgPopupdp" class="popupdp" runat="server" /><br />
                                <asp:Label ID="lblname" CssClass="h3" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbllast" CssClass="h3" runat="server" Text=""></asp:Label>  
                            </div>
                            <div class="col">
                                <table>
                                    <tr>
                                        <td><h6>Email    :</h6></td>
                                        <td><asp:Label ID="lblmail" CssClass="p" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><h6>DOB      :</h6></td>
                                        <td><asp:Label ID="lblDob" CssClass="p" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><h6>Phone No :</h6></td>
                                        <td><asp:Label ID="lblPhone" CssClass="p" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><h6>Gender   :</h6></td>
                                        <td><asp:Label ID="lblGender" CssClass="p" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><h6>Address  :</h6></td>
                                        <td><asp:Label ID="lblAddress" CssClass="p" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><h6>City     :</h6></td>
                                        <td><asp:Label ID="lblCity" CssClass="p" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><h6>Qualification     :</h6></td>
                                        <td><asp:Label ID="lblqual" CssClass="p" runat="server" Text=""></asp:Label></td>
                                    </tr>          
                                </table>
                            </div>
                       <div class="col">
                           <table>
                              <asp:DataList ID="dtl_Course" class="table" runat="server" RepeatColumns="3">
                                 <HeaderTemplate>
                                    <tr>
                                        <th scope="col">Course</th>
                                        <th scope="col">Batch</th>                             
                                        <th scope="col">Fee</th>
                                        <th scope="col">Payment Status</th>
                                    </tr>
                                 </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="row">
                                            <tr>
                                                <td scope="row"><%#Eval("Applyfor") %></td>
                                                <td><%#Eval("Batch") %></td>
                                                <td><%#Eval("fee") %></td>
                                                <td><%#Eval("PaymentStatus") %></td>
                                            </tr>
                                    </div>
                                  </ItemTemplate>
                                </asp:DataList>
                             </table>
                            </div>                            
                             <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="DELETE" />                       
                            </div>
                        </div>
                    </div>
                </div>
            </form>
         </div> 
      </div>
</body>
</html>
