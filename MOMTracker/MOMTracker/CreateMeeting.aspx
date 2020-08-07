<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMeeting.aspx.cs" Inherits="MOMTracker.CreateMeeting" ValidateRequest="False" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Compose</title>
     <link rel="stylesheet" href="../css/sent mails.css" type="text/css">
    <link rel="stylesheet" href="../files/bootstrap.min.css">
    <link rel="stylesheet" href="../css/compose.css" type="text/css">
    <link rel="stylesheet" href="../files/fontawesome.min.css">
    <link rel="stylesheet" href="../files/bootstrap.min.css">


    <script src="../files/jquery-3.4.1.min.js"></script>
    <script src="../files/bootstrap.min.js"></script>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $("InviteeList").mousedown(function (e) {
                e.preventDefault();

                var select = this;
                var scroll = select.scrollTop;

                e.target.selected = !e.target.selected;

                setTimeout(function () { select.scrollTop = scroll; }, 0);

                $(select).focus();
            }).mousemove(function (e) { e.preventDefault() });
        });
    </script>
 
    

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
    <form runat="server">
    <nav class="navbar navbar-expand-lg navbar-light bg-light fixed-top" id="sticky top-nav">
        <div class="media nav-item ml-1" style="width: 100px; "  >
            <img src="../img/LOGO2.png" style="height: 70px">

        </div>
        <div class="media-body nav-item ml-0">
            <b class="m-1" style="font-family:Consolas, Andale Mono, Lucida Console, Lucida Sans Typewriter, Monaco, Courier New, monospace">MOM Tracker</</b>
        </div>

        <div class=" collapse navbar-collapse nav-item active " id="navbarSupportedContent">
            <!--
        <a class="nav-link" href="#"	>Signout</a>-->
        </div>
        <button id="sidebarCollapse" type="button" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active"><small class="text-uppercase font-weight-bold">menu</small></button>
    <asp:Button id="Logout" runat="server"  class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active" Text="LOGOUT" OnClick="Logout_Click"/>
        </nav>
   
        <div class="vertical-nav bg-white shadow-none" id="sidebar">

        <p class="text-gray font-weight-bold text-uppercase px-3 py-3 pb-4 mb-0">MENU</p>
        <%--<a href="https://localhost:44378/Email/ShowTemplate"></a>--%>
           <%-- <button type="button" class="btn btn-light bg-light rounded-pill shadow-sm px-4 nav-item active mb-4 ml-5"><em class="text-uppercase font-weight-bold"></em></button>--%>
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
                    <a href="/AMail.aspx" class="nav-link text-dark opt">
                        <img src="../img/add.png" class="ml-2 mr-2 my-auto" style="width: 16px; height: 16px" />
                        <!-- <i class="fa fa-picture-o mr-3 text-primary fa-fw"></i>
    -->
                          Automated Mail Settings
                    </a>
                </li>
                <li class="nav-item">
                    <a href="/MOMDetails.aspx" class="nav-link text-dark opt">
                        <img src="../img/students.png" class="ml-2 mr-2 my-auto" style="width: 16px" />
                        <!-- <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
    -->
                       M.O.M Details
                    </a>
                </li>
                 <li class="nav-item">
                    <a href="/Invitee.aspx" class="nav-link text-dark opt">
                        <img src="../img/students.png" class="ml-2 mr-2 my-auto" style="width: 16px" />
                        <!-- <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
    -->
                     Add Invitee
                    </a>
                </li>
              
            <li class="nav-item mx-5">
               <%-- @if (User.Identity.IsAuthenticated)
                {
                    <button id="logout" type="button" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active"><small class="text-uppercase font-weight-bold text-black-50">@Html.ActionLink("Logout", "Logout", "Account")</small></button>
                }--%>


            </li>

        </ul>


    </div>
    <div class="page-content active container mt-2" id="content">
        
       
            <div class="row pt-5">

                <div class="col-lg-12">
                    

                        <%--@Html.AntiForgeryToken()--%>

                        <div class="form-horizontal">
                            <hr />
                          


                            <div class="form-group">
                       
                                <asp:Label ID="Label1" runat="server" class="control label col-md-2" Text="Meeting Date"></asp:Label>  
                                <div class="col-md-10">
                                    <asp:TextBox ID="TextBox" runat="server" class="form-control" placeholder="Date" Textmode="Date" width="150px"></asp:TextBox> 
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="TextBox" ForeColor="Red"></asp:RequiredFieldValidator>  
                                 
                                </div>
                            </div>

                            <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" class="control label col-md-2" Text="Meeting Time"></asp:Label> 
                                    <div class="col-md-10">
                                      
                                         <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Time" Textmode="Time" width="150px" ></asp:TextBox> 
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>  
                                    </div>
                                </div>
                            <div class="form-group">
                                 <asp:Label ID="Label3" runat="server" class="control label col-md-2" Text="Chairperson"  ></asp:Label> 

                                <div class="col-md-10">
                                    
                               
                                    <asp:DropDownList id="ChairpersonList" runat="server" CssClass="dropdown form-control"  Width="150px" >
                            <asp:ListItem Text="----SELECT----" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                             <div class="form-group">
                                <asp:Label ID="Label6" runat="server" class="control label col-md-2" Text="Invitees"></asp:Label>
                                 </div>
                                <div class="col-md-10">
                                    <%--<asp:checkboxlist runat="server" ID="InviteeList" class="listbox" Width="300px" SelectionMode="Multiple" ></asp:checkboxlist>--%>
                                   <asp:ListBox runat="server" ID="InviteeList"  width="300px" SelectionMode="Multiple"> </asp:ListBox>
                                    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
              rel="stylesheet" type="text/css" >
       <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
        <link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
        <script src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(function () {
                $('.listbox').multiselect({
                   includeSelectAllOption: true
               });
            });
        </script>--%>
                                    
                                 <%--  <%-- <asp:<%--DropDownListChosen--%> <%--ID="DropDownListChosen1" runat="server" 
            NoResultsText="No results match." width="350px"            
            DataPlaceHolder="Type Here..." AllowSingleDeselect="true">--%<%--></asp:DropDownListChosen--%>        
         
                                    </div>
                                </div>
                     <div class="form-group">
                                <asp:Label ID="Label7" runat="server" class="control label col-md-2" Text="Department"></asp:Label>
                                 </div>
                                <div class="col-md-10">
                                    <%--<asp:checkboxlist runat="server" ID="InviteeList" class="listbox" Width="300px" SelectionMode="Multiple" ></asp:checkboxlist>--%>
                                   <asp:ListBox runat="server" ID="ListBox1"  width="300px" SelectionMode="Multiple"> </asp:ListBox>
                                    </div>
                    

                           
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" class="control label col-md-2" Text="Agenda"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtTinyMCE" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <%--asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
<asp:Label ID="lblContent" runat="server"></asp:Label>
<script type="text/javascript" src="https://tinymce.cachefly.net/4.0/tinymce.min.js"></script>
<script type="text/javascript">
    tinymce.init({ selector: 'textarea', width: 500 });
</script>
                                
                                </div>
                            </div>
                       
                            
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" class="control label col-md-2" Text="Title"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>  
                                    </div>
                                </div>

                            <div class="row pt-5 ">
                                <div class="col-lg-3 mx-auto">
                                    <asp:Button ID="btn" runat="server" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active mb-4 ml-5" OnClick="btn_Click"  Text="Submit" />  

                                   <%-- <input type="submit" value="Send" class="btn btn-light bg-white rounded-pill shadow-sm px-4 nav-item active mb-4 ml-5" />@*<em class="font-weight-bold">Send mail</em></input>*@--%>

                                </div>

                            </div>
                        </div>


                 
                </div>



            </div>
     


    </div>
       </form>
</body>
</html>