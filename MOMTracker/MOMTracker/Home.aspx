<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MOMTracker.Home" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title></title>

    <link rel="stylesheet" href="../files/bootstrap.min.css">
    <link rel="stylesheet" href="../css/sent mails.css" type="text/css">
    <link rel="stylesheet" href="../files/fontawesome.min.css">
    <link rel="stylesheet" href="../files/bootstrap.min.css">


    <script src="../files/jquery-3.4.1.min.js"></script>
    <script src="../files/bootstrap.min.js"></script>
    <style>
        @media (max-width: 486px) {
  #sidebar {
    margin-left: -17rem;
  }
  #sidebar.active {
    margin-left: 0;
  }
#content {
  width: calc(100% - 17rem);
  margin-left: 17rem;
}
 
  #content.active {
    margin-left: 0rem;
    width: 100%;
  }
}
    </style>
    <script>
        $(function () {
            // Sidebar toggle
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar, #content').toggleClass('active');
            });
        });
    </script>
</head>

<body>
    
    <nav class="navbar navbar-expand-lg navbar-light bg-light fixed-top" id="top-nav">
        <div class="media nav-item ml-1" style="width: 100px; ">
            <img src="../img/LOGO2.png" style="height: 70px">

        </div>
        <div class="media-body nav-item ml-0">
            <b class="m-1" style="font-family:Consolas, Andale Mono, Lucida Console, Lucida Sans Typewriter, Monaco, Courier New, monospace">M.O.M Tracker</b>
        </div>

        <div class=" collapse navbar-collapse nav-item active" id="navbarSupportedContent">
            <!--
        <a class="nav-link" href="#"	>Signout</a>-->
        </div>

        <button id="sidebarCollapse" type="button" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active"><small class="text-uppercase font-weight-bold">Menu</small></button>



    </nav>
    <div class="vertical-nav bg-white shadow-none" id="sidebar">

        <p class="text-gray font-weight-bold text-uppercase px-3 py-3 pb-4 mb-0">MENU</p>
     
            <ul  class="nav flex-column bg-white mb-0">
               
                <li class="nav-item">
                    <a href="/Home.aspx" class="nav-link text-dark opt">
                        <img src="../img/templates.png" class="ml-2 mr-2 my-auto" style="width: 13px; height: 16px;" />
                      
                        Home
                    </a>
                </li>
                <li class="nav-item">
                    <a href="/CreateMeeting.aspx" class="nav-link text-dark opt">
                        <img src="../img/category.png" class="mx-2" style="width: 16px; height:14px" />
                        <!-- <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
    -->
                        Create Meeting
                    </a>
                </li>
                <li class="nav-item">
                    <a href="" class="nav-link text-dark opt">
                        <img src="../img/add.png" class="ml-2 mr-2 my-auto" style="width: 16px; height: 16px" />
                        <!-- <i class="fa fa-picture-o mr-3 text-primary fa-fw"></i>
    -->
                          Automated Mail Settings
                    </a>
                </li>
                <li class="nav-item">
                    <a href="" class="nav-link text-dark opt">
                        <img src="../img/students.png" class="ml-2 mr-2 my-auto" style="width: 16px" />
                        <!-- <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
    -->
                       M.O.M Details
                    </a>
                </li>
              
                <li class="nav-item mx-5">
                    <%--@if (User.Identity.IsAuthenticated)
                    {
                        <button id="logout" type="button" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active"><small class="text-uppercase font-weight-bold text-black-50">@Html.ActionLink("Logout", "Logout", "Account")</small></button>
                    }--%>
                </li>

            </ul>


    </div>
    <div class="page-content active container-fluid" id="content">
        <div class="row pt-5">

        </div>
        <div class="row pt-5">
            <div class="col-lg-12">
                <form runat="server">

               
                <asp:GridView ID="meetlist" runat="server" class="bg-white"></asp:GridView>
                    </form>
                
              

             
            </div>
        </div>

    </div>
        
</body>
</html>