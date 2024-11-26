<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="WebApplication3.Error404" %>

<!DOCTYPE html>
<link href="css/bootstrap.min.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>حدث خطاء</title>
 <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/css/bootstrap.min.css">
    <style>
        @font-face {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
        }

        body {
            background-color: #f1f1f1;
            font-family: "alfont_com_Cairo-Regular", Arial, sans-serif;
            text-align: center;
            padding: 50px;
        }

        h1 {
            font-size: 36px;
            color: #333;
        }

        p {
            font-size: 18px;
            color: #777;
        }

        .image-container {
            margin-top: 50px;
        }

        img {
            max-width: 700px;
            height: auto;
            margin: 0 auto;
            display: block;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="image-container">
                    <img src="images/404.png" alt="Error Image">
                  s
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/js/bootstrap.bundle.min.js"></script>
</body>
</html>