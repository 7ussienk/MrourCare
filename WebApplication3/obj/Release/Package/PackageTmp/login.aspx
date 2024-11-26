<%@ Page Title="تسجيل الدخول" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- font-awesome -->
    <link href="font-awesome/all.min.css" rel="stylesheet" />
    <!-- bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="Style.css" rel="stylesheet" />
    <style>
        body {
            height: 100vh;
            display: flex;
            align-items: center;
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #f5f5f5;
        }

        body {
            font-size: 20px;
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf")
        }

        .form-signin {
            width: 100%;
            max-width: 330px;
            padding: 15px;
            margin: auto;
        }

        .leb {
            margin-top: 1px;
            margin-right: 70px;
        }

        .form-signin .checkbox {
            font-weight: 400;
        }

        .form-signin .form-floating:focus-within {
            z-index: 2;
        }

        .form-signin input[type="email"] {
            margin-bottom: -1px;
            border-bottom-right-radius: 0;
            border-bottom-left-radius: 0;
        }

        .form-floating > label {
            position: absolute;
            top: -5px;
            right: 0 !important;
            left: unset;
            height: 100%;
            padding: 1rem 0;
            pointer-events: none;
            border: 1px solid transparent;
            transform-origin: 0 0;
            transition: opacity .1s ease-in-out,transform 0.1s ease-in-out;
        }
    </style>
    
</head>
<body>


    <form id="MyForm" method="post" runat="server" class="form-signin" dir="rtl">
            <h2 class="mb-5 fw-bold leb ">تسجيل الدخول</h2>

            <div class="form-floating">
                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="floatingInput" id="lblusername">الايميل</label>
            </div>

            <div class="form-floating">
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <label for="floatingPassword" id="lblpassword">كلمة المرور</label>
            </div>

            <asp:Button runat="server" Text="تسجيل الدخول" CssClass="btn btn-md btn-primary mt-4" ID="Signinbtn" OnClick="Signinbtn_Click"></asp:Button>

            <asp:Button runat="server" Text="عودة" CssClass="btn btn-md btn-dark mt-4" PostBackUrl="/Main.aspx" ID="Backbtn"></asp:Button>


            <div id="alert_dan" runat="server" class="alert alert-danger mt-3" visible="false" role="alert">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>

            <div class="mt-3">
                <a href="ForgetPass.aspx" class="text-decoration-none text-dark">نسيت كلمة المرور؟</a>
                <br />
                <a href="SignUp.aspx" class="text-decoration-none  " style="color: blue;">انشاء حساب</a>

            </div>

            <p class="mt-5 mb-3 text-muted">خريجي جامعة سيئون &copy 2024-2023</p>

            <script>
                var userInput = document.querySelector("[name = 'txtUserName']");
                userInput.focus();
            </script>

            <script src="js/script.js"></script>
            <script src="bootstrap/bootstrap.js"></script>
            <script src="font-awesome/all.min.js"></script>
            <script src="js/jquery-3.6.0.min.js"></script>
    </form>

</body>
</html>
