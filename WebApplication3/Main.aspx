<%@ Page Title="الصفحة الرئيسية" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Main.aspx.cs" Inherits="WebApplication3.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="font-awesome/all.min.css" rel="stylesheet" />

    <style>
        @font-face {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf")
        }

        p {
            font-size: 33px;
            font-size: 33px;
            text-align: center
        }

        body {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
        }

        body {
            background-color: #f8f9fa !important
        }

        .card {
            width: 190px;
            height: 250px;
            padding: 0.5rem;
            background: rgb(26, 87, 143);
            border-radius: 8px;
            backdrop-filter: blur(5px);
            border-bottom: 3px solid rgba(255, 255, 255, 0.440);
            border-left: 2px rgba(255, 255, 255, 0.545) outset;
            box-shadow: -40px 50px 30px rgba(0, 0, 0, 0.280);
            transform: skewX(10deg);
            transition: .4s;
            overflow: hidden;
            color: white;
            flex: 0 0 200px;
            margin-right: 100px;
        }

        .card-container {
            display: flex;
            flex-wrap: nowrap;
        }

        .card:hover {
            height: 354px;
            transform: skew(0deg);
        }

        .align {
            padding: 1rem;
            display: flex;
            flex-direction: row;
            gap: 5px;
            align-self: flex-start;
        }

        .red {
            width: 10px;
            height: 10px;
            border-radius: 50%;
            background-color: #ff605c;
            box-shadow: -5px 5px 5px rgba(0, 0, 0, 0.280);
        }

        .yellow {
            width: 10px;
            height: 10px;
            border-radius: 50%;
            background-color: #ffbd44;
            box-shadow: -5px 5px 5px rgba(0, 0, 0, 0.280);
        }

        .green {
            width: 10px;
            height: 10px;
            border-radius: 50%;
            background-color: #00ca4e;
            box-shadow: -5px 5px 5px rgba(0, 0, 0, 0.280);
        }

        .card h1 {
            text-align: center;
            margin: 1.3rem;
            color: rgb(218, 244, 237);
            text-shadow: -10px 5px 10px rgba(0, 0, 0, 0.573);
        }

        .card h2 {
            text-align: center;
            margin: 1.3rem;
            color: rgb(218, 244, 237);
            text-shadow: -10px 5px 10px rgba(0, 0, 0, 0.573);
        }

        .card h6 {
            text-align: center;
            margin: 1.3rem;
            color: rgb(218, 244, 237);
            text-shadow: -10px 5px 10px rgba(0, 0, 0, 0.573);
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/bootstrap.min.js"></script>
    <script src="font-awesome/all.min.js"></script>
    <div class="container col-md-12 px-4 p-0 " dir="rtl">
        <div class="row ">
            <div class="col-lg-4 col-md-4 col-sm-4  "  style="">
                <img src="images/Trafficlogo.png" class="img-fluid" alt="حجز المعاملات المرورية" style="width: 850px;
                    height: 650px;"
                    loading="lazy">
            </div>

            <div class="col-lg-8 col-sm-8 text-end" style="margin-top: 150px" id="project">
                <br>
                <br>


                <h1 id="header" class="display-4 fw-bold lh-1 mb-3 user-select-none " style="color: #30485e;">
                    <span class="" >مشروع حجز</span></h1>
                <h1 id="header" class="display-4 fw-bold lh-3 mb-3 user-select-none text-success">المعاملات
                    المرورية</h1>
                <p id="titlePage" class="lead p-6 user-select-none " style="text-align: right;">
                    هو نظام يهدف إلى تسهيل وتحسين عملية حجز وإدارة المعاملات المرورية
    يتيح المشروع للمستخدمين حجز مواعيد للمعاملات المرورية المختلفة، مثل تجديد رخصة القيادة، وتسجيل السيارات
                    الجديدة، وتجديد رخصة السيارة، وتحويل الملكية، وإصدار تصاريح القيادة الخاصة.
                </p>

                <button id="Button4" type="button" class="btn btn-warning" herf="#cardss">الإستفادة من المشروع</button>

            </div>

        </div>
            <div class=" row card-container" id="f" style="display: none;">
                <div class="row col-12">
                        <div class="card mt-3 " id="cardss">
                            <div class="align">
                                <span class="red"></span>
                                <span class="yellow"></span>
                                <span class="green"></span>
                            </div>

                            <h1>طلب رخصة قيادة</h1>
                            <br>
                            <br>
                           
                            <a href="Newliesen.aspx" class="btn btn-dark">تقديم</a>
                        </div>
                        <div class="card mt-3">
                            <div class="align">
                                <span class="red"></span>
                                <span class="yellow"></span>
                                <span class="green"></span>
                            </div>

                            <h1>طلب نقل ملكية  </h1>
                            <br>
                            <br>
                            <br>
                            <a href="changeowner.aspx" class="btn btn-dark">تقديم</a>
                        </div>
                        <div class="card mt-3">
                            <div class="align">
                                <span class="red"></span>
                                <span class="yellow"></span>
                                <span class="green"></span>
                            </div>

                            <h1>تجديد رخصة قيادة</h1>
                            <br>
                            <br>
                           
                            <a href="RenewLicense.aspx" class="btn btn-dark">تقديم</a>
                        </div>
                        <div class="card mt-3">
                            <div class="align">
                                <span class="red"></span>
                                <span class="yellow"></span>
                                <span class="green"></span>
                            </div>

                            <h1>صرف رقم جديد</h1>
                            <br>
                            <br>
                            <br>
                            <a href="NewNumberL.aspx" class="btn btn-dark">تقديم</a>
                        </div>
                </div>
            </div>
        <script src="js/jquery-3.7.1.min.js"></script>

        <script>
            $(document).ready(function () {
                $('#Button4').click(function () {
                    $('#f').show();
                    const cardsContainer = document.getElementById('f');
                    const cardss = document.getElementById('project');
                    cardss.scrollIntoView({ behavior: 'smooth', block: 'start' });
                });
            });
        </script>
        <hr style="margin-top: 22%" />

    </div>


</asp:Content>
