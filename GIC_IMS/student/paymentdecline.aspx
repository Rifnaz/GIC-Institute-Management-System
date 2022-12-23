<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paymentdecline.aspx.cs" Inherits="GIC_IMS.student.paymentdecline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link rel="stylesheet" href="../css/style.css" media="screen" />
    <title>Global International College</title>
   
    <style type="text/css">
        table.table td a.view {
            color: #03A9F4;
        }
        table.table td a.edit {
            color: #FFC107;
        }
        table.table td a.delete {
            color: #E34724;
        }

        .payment
	    {
		    border:1px solid #B22222;
		    height:280px;
            border-radius:20px;
            background:#fff;
	    }
       .payment_header
       {
	       background:#B22222;
	       padding:20px;
           border-radius:20px 20px 0px 0px;
	   
       }
   
       .check
       {
	       margin:0px auto;
	       width:50px;
	       height:50px;
	       border-radius:100%;
	       background:#fff;
	       text-align:center;
       }
   
       .check i
       {
	       vertical-align:middle;
	       line-height:50px;
	       font-size:30px;
       }

        .content 
        {
            text-align:center;
        }

        .content  h1
        {
            font-size:25px;
            padding-top:25px;
        }

        .content a
        {
            width:250px;
            height:50px;
            color:#fff;
            border-radius:30px;
            padding:5px 10px;
            background:#B22222;
            transition:all ease-in-out 0.3s;
            text-decoration:none;
        }

        .content a:hover
        {
            text-decoration:none;
            background:#000;
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
                    <h2 class="fs-2 m-0">Payment Declined</h2>
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
              <div class="col-md-6 mx-auto mt-5">
                 <div class="payment">
                    <div class="payment_header">
                       <div class="check"><i class="fa fa-times" aria-hidden="true"></i></div>
                    </div>
                    <div class="content">
                       <h1>Payment Declined !</h1>
                       <p>Lorem ipsum, or lipsum as it is sometimes known, is dummy text used in laying out print, graphic or web designs. </p>
                       <a href="studentdash.aspx">Go Back</a>
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

