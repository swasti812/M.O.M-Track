﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="MOMTracker.Upload" %>

<!DOCTYPE html>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Upload</title>

    <link rel="stylesheet" href="../files/bootstrap.min.css">
    <link rel="stylesheet" href="../css/emailinput.css" type="text/css">
    <link rel="stylesheet" href="../files/fontawesome.min.css">
    <link rel="stylesheet" href="../files/bootstrap.min.css">


    <script src="../files/jquery-3.4.1.min.js"></script>
    <script src="../files/bootstrap.min.js"></script>
    <style>

.top-nav {
  width: calc(100% - 17rem);
  margin-left: 0rem;
  transition: all 0.4s;
}

/* for toggle behavior */

#sidebar.active {
  margin-left: -17rem;
}

/*#content.active {
  width: 100%;
  margin: 0;
}*/

@media (max-width: 768px) {
  #sidebar {
    margin-left: -17rem;
  }
  #sidebar.active {
    margin-left: 0;
  }
  #content {
    width: 100%;
    margin: 0;
  }
  #content.active {
    margin-left: 17rem;
    width: calc(100% - 17rem);
  }
}


body {
  background: white;
  /*background: -webkit-linear-gradient(to bottom, #6C006D, #0F092C);
  background: linear-gradient(to bottom, #6C006D, #0F092C);
  */min-height: 100vh;
  overflow-x: hidden;
}
img{
	width:500px;
	height: auto;
	margin-left: 10%;
}

.separator {
  margin: 3rem 0;
  border-bottom: 1px dashed #fff;
}

.text-uppercase {
  letter-spacing: 0.1em;
}

.text-gray {
  color: #aaa;
}
		nav{
		background: linear-gradient(to bottom, #6C006D, #0F092C);
	}


	@media screen and (max-width: 768px) {
		img{
			width: 400px;
			margin-left: 10%;
		}
		.nav-item{
			margin-top: -10px;
		}
}

	@media screen and (max-width: 1000px) {
		img{
			width: 400px;
			margin-left: 10%;
		}
		#logo{
			width: 50px;
		}
		.nav-item{
			margin-top: -5px;
		}
}
	@media screen and (max-width: 500px) {
		img{
			width: 250px;
			margin-left: 10%;
		}
		#logo{

		}
		.nav-item{
			margin-top: -5px;
		}
		.media-body{
			font-size: 20px;
			margin-left: -10px
		}
}
    </style>
    <script>
		/*$(function() {
  			// Sidebar toggle
  			$('#sidebarCollapse').on('click', function() {
    			$('#sidebar, #content').toggleClass('active');
  			});
		});*/
    </script>
</head>

<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <%--<div class="media nav-item ml-1" >
            <img src="../img/LOGO2.png" style="height: 70px;width:"20px">

        </div>--%>
        <div class="media-body nav-item ml-0">
            <b class="m-1" style="font-family:Consolas, Andale Mono, Lucida Console, Lucida Sans Typewriter, Monaco, Courier New, monospace">M.O.M TRACKER/b>
        </div>

        <div class=" collapse navbar-collapse nav-item active " id="navbarSupportedContent">
            <!--
        <a class="nav-link" href="#"	>Signout</a>-->
        </div>
       <%-- <a href="https://localhost:44378/Account/Login">
        <button id="sidebarCollapse" type="button" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active"><small class="text-uppercase font-weight-bold">Back</small></button>
        </a>--%>


    </nav>
    <div class="page-content active container" id="content">
        <div class="row pt-3">
            <div class="col-lg-6">
                <div class="row pt-3">
                    <div class="col-lg-12">
                        <img src="../img/link.png" />
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="row pt-3">
                    <div class="col-lg-12">
                       <form runat="server">
                            <div class="form-horizontal">
                                <hr />
                               
                                <div class="form-group">
                                <%--    <label class="control-label col-md-2">Email ID</label>--%>
                                    <asp:Label ID="LABEL1" runat="server" Text="Status" ></asp:Label>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Height="100px"  ></asp:TextBox>
                                   
                                </div>
                                <div class="row pt-5 ">
                                    <div class="col-lg-6 mx-auto">
                                          <asp:Button ID="btn" runat="server" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active mb-4 ml-5" OnClick="btn_Click" Text="Submit" />  
                                       <%-- <button type="submit" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active mb-4 ml-5"><em class="font-weight-bold">Change password</em></button>--%>
                                    </div>

                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
