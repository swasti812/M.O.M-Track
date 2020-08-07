<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="MOMTracker.SignUp" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SIGNUP PAGE</title>
    <link rel="stylesheet" href="../files/bootstrap.min.css">
    <link rel="stylesheet" href="../css/signup.css" type="text/css">

    <link rel="stylesheet" href="../files/bootstrap.min.css">


    <script src="../files/jquery-3.4.1.min.js"></script>
    <script src="../files/bootstrap.min.js" ></script>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
  <%--  <script>
          function signup{
              alert("A verification link has been sent on your email i'd. click on it to access your account.");
          }
    </script>--%>
</head>

    <%--@Html.AntiForgeryToken()--%>
    <body>
        <form runat="server">

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6" id="back">
                    <img src="../img/LOGO2.png" style="height: 70px" />
                    <div id="" class="text-white" style="font-family:Consolas, Andale Mono, Lucida Console, Lucida Sans Typewriter, Monaco, Courier New, monospace">M.O.M Tracker</div>
                    <div class="welcome">
                        <div>Welcome!</div>
                        
                    </div>

                </div>

                <div class="col-md-6">
                    <div class="row">
                        <div class="signup" style="padding-top:3px"><b>SIGN UP</b></div>
                    </div>

                   <%-- @Html.ValidationSummary(true, "", new { @class = "text-danger" })--%>

                    
                    <div class="form-group row" style="padding-top:120px">
                         <asp:Label ID="Label1" runat="server" class="col-sm-5 col-form-label" Text="First Name"></asp:Label>  
                      
                       
                        <div class="col-sm-7">
                           <asp:TextBox ID="TextBox1" runat="server" class="form-control" ></asp:TextBox> 
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>  
                          
                        
                           
                        </div>
                    </div>
                     <div class="form-group row" >
                         <asp:Label ID="Label6" runat="server" class="col-sm-5 col-form-label" Text="Last Name"></asp:Label>  
                      
                       
                        <div class="col-sm-7">
                           <asp:TextBox ID="TextBox6" runat="server" class="form-control" ></asp:TextBox> 
                        
                           
                        </div>
                    </div>
                    <div class="form-group row">
                        
                       <asp:Label ID="Label2" runat="server" class="col-sm-5 col-form-label" Text="Email" ></asp:Label>  
                        <div class="col-sm-7">
                             <asp:TextBox ID="TextBox2" runat="server" class="form-control" Textmode="Email" ></asp:TextBox> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email cannot be blank" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>  
                          
                        </div>
                    </div>
                    <div class="form-group row">
                      <asp:Label ID="Label3" runat="server" class="col-sm-5 col-form-label" Text="Mobile No" ></asp:Label>  
                        <div class="col-sm-7">
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control"   ></asp:TextBox> 
                        </div>
                    </div>
                    <div class="form-group row">
                      <asp:Label ID="Label7" runat="server" class="col-sm-5 col-form-label" Text="Telephone" ></asp:Label>  
                        <div class="col-sm-7">
                            <asp:TextBox ID="TextBox4" runat="server" class="form-control"  ></asp:TextBox> 
                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label ID="Label4" runat="server" class="col-sm-5 col-form-label" Text="Department" ></asp:Label>  
                       <asp:dropdownlist ID="Dep" runat="server" CssClass="dropdown form control" >
                        
                        </asp:dropdownlist>  
                    </div>
                    <div class="form-group row">
                        <asp:Label ID="Label5" runat="server" class="col-sm-5 col-form-label" Text="Password"></asp:Label>
                        <div class="col-sm-7">
                             <asp:TextBox ID="TextBox5" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox> 
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>  
                          
                        </div>

                    </div>
<%--                    <div class="form-group row">
                         <label for="inputPassword" class="col-sm-5 col-form-label">Confirm Password</label>
                        @*                            @Html.PasswordFor(model => model.ConfirmPassword, new { htmlAttributes = new { @class = "form-control", @id = "inputPassword", @placeholder = "Password" } })*@
                        @*@Html.ValidationMessageFor(model => model.ConfirmPassword, "", new { @class = "text-danger" })*@
                        <div class="col-sm-7">
                            <input type="password" class="form-control" id="inputPassword" placeholder="Password">
                        </div>

                    </div>--%>
                    <div class="form-group row">
                        <h6 >Already had an Account ? Click here to <a href="Login.aspx">Login</a></h6>
                    </div>
                
                    <div class="form-group row" >
                        <div class="col-sm-12"  >
                           <asp:Button ID="btn" runat="server" style="padding-top:-3px" BorderStyle="None" Font-Size="X-Large" OnClick="btn_Click" Text="Sign Up" />  
                        </div>
                    </div>
                   

                    <!--</form>-->
                </div>
            </div>
        </div>
            </form >
    </body>

</html>