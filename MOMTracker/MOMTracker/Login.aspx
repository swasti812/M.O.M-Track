<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MOMTracker.WebForm1" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>LOGIN PAGE</title>
    <link rel="stylesheet" href="../files/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/login.css" type="text/css"/>

    <link rel="stylesheet" href="../files/bootstrap.min.css"/>


    <script src="../files/jquery-3.4.1.min.js"></script>
    <script src="../files/bootstrap.min.js"></script>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>

</head>

    <body>
        <form  runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6" id="back">
                    <img src="../img/LOGO2.png" style="height: 70px" />
                    <div id="" class="text-white" style="font-family:Consolas, Andale Mono, Lucida Console, Lucida Sans Typewriter, Monaco, Courier New, monospace">MOM Tracker</div>

                
                    <div class="welcome">
                        <div>Welcome Back!</div>
                        <div id="sign">Sign in to continue access</div>
                    </div>

                </div>

                <div class="col-md-6">
                    <div class="signin"><b>SIGN IN</b></div>
                   
                    <div class="text-success">
                       
                    </div>
                    <div class="form-group row" style="padding-top:175px">
                   
                        <asp:Label ID="Label2" runat="server" class="col-sm-2 col-form-label" Text="Email"></asp:Label>  
                       
                        <div class="col-sm-10">
                           <asp:TextBox ID="TextBox" runat="server" class="form-control" placeholder="Email" Textmode="Email" ></asp:TextBox>  
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email cannot be blank" ControlToValidate="TextBox" ForeColor="Red"></asp:RequiredFieldValidator>  
                        </div>
                    </div>
                    <div class="form-group row">
                       
                        <asp:Label ID="Label3" runat="server" class="col-sm-2 col-form-label" Text="Password :"></asp:Label>
                     
                        <div class="col-sm-10">
                          
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox> 
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>  
                             
                        </div>
                    </div>
                   
                    <div class="form-group row">
                        <div class="col-lg-12"> 
                            <h6>Don't have an account? </h6>  <a href="/SignUp.aspx" > SignUp </a>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-12">
                            <asp:Button ID="btn" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="btn_Click" Text="Log In" />  
                           <asp:Label ID="Label4" runat="server" Font-Size="X-Large"></asp:Label>  
                            <%--<input type="submit" value="CONTINUE" id="btn" />--%>
                        </div>
                    </div>
                   <%-- <div class="form-group row">
                            <div class="col-sm-12">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="" id="defaultCheck1">
                                    <label class="form-check-label" for="defaultCheck1">
                                        Keep me logged in
                                    </label>
                                </div>
                            </div>
                        </div>--%>
                    
                </div>
            </div>
        </div>
        </form >
    </body>

</html>
