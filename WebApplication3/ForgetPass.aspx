<%@ Page Title="نسيان  كلمة المرور" Language="C#" AutoEventWireup="true" CodeBehind="ForgetPass.aspx.cs" Inherits="WebApplication3.ForgetPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <title>Forget Password</title>
    <style>
        lblusername {
        }

        body {
            height: 100vh;
            display: flex;
            align-items: center;
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #f5f5f5;
        }

        body {
            font-size: 18px;
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf")
        }

        .form-signin {
            width: 100%;
            max-width: 380px;
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

        h3 {
            text-align: center
        }
    </style>

</head>
<body>

    <form id="MyForm" method="post" runat="server" class="form-signin" dir="rtl">
        <h3 class="mb-5 fw-bold  ">اعادة تعيين كلمة المرور</h3>


        <div class="form-floating">
            <asp:Label runat="server" for="floatingInput" ID="lblusername">البريد الالكتروني</asp:Label>
            <asp:TextBox ID="gmailtxt" CssClass="form-control" runat="server" TextMode="Email" required></asp:TextBox>

        </div>

        <div class="form-floating">
            <asp:Label runat="server" for="floatingPassword" ID="lblpassword">رمز التحقق</asp:Label>
            <asp:TextBox ID="verficationtxt" CssClass="form-control" required runat="server" TextMode="Password"></asp:TextBox>

        </div>


        <div class="form-floating">
            <asp:Label runat="server" for="floatingPassword" ID="Labelnewpass" Visible="False" >كلمة المرور الجديدة</asp:Label>
            <asp:TextBox ID="TextBoxnewpass" CssClass="form-control" runat="server" TextMode="Password" required Visible="False"></asp:TextBox>

        </div>
        <div class="form-floating">
            <asp:Label runat="server" for="floatingPassword" ID="Labelnewpass2" Visible="False">تأكيد كلمة المرور الجديدة</asp:Label>
            <asp:TextBox ID="txtconfnewpass" CssClass="form-control" runat="server" TextMode="Password" required OnTextChanged="TextBox1_TextChanged" Visible="False"></asp:TextBox>

        </div>
        <asp:Button ID="taked" runat="server" Text="تأكيد" CssClass="btn btn-md btn-primary mt-4" OnClick="Unnamed2_Click" Visible="False"></asp:Button>

        <asp:Button runat="server" align="center" Text="تحقق" CssClass="btn btn-md btn-primary mt-4" ID="verficationbtn" OnClick="verficationbtn_Click"></asp:Button>


        <asp:Button runat="server" Text="ارسال" CssClass="btn btn-md btn-primary mt-4" ID="Sendbtn" OnClick="Sendbtn_Click"></asp:Button>
        <asp:Button runat="server" Text="تعديل البريد الأكتروني" CssClass="btn btn-md btn-secondary mt-4" ID="editgmailbtn" OnClick="editgmailbtn_Click"></asp:Button>
        <asp:Button runat="server" Text="عودة" CssClass="btn btn-md btn-secondary mt-4" 
            PostBackUrl="~/login.aspx" OnClick="Unnamed1_Click"></asp:Button>

        <div id="alert_dan" runat="server" class="alert alert-success mt-3" role="alert">
            <asp:Label ID="Label1" runat="server" Text="
            تم تغيير كلمة المرور بنجاح.
        "
                Visible="False"></asp:Label>
        </div>




        <p class="mt-5 mb-3 text-muted">
           <asp:HiddenField ID="vcodeHiddenField" runat="server" Value="0" />
      
        </script>

        <script src="js/script.js"></script>
        <script src="bootstrap/bootstrap.js"></script>
        <script src="font-awesome/all.min.js"></script>
        <script src="js/jquery-3.6.0.min.js"></script>
    </form>

</body>
</html>
