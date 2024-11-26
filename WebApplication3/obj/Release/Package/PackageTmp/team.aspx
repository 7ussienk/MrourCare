<%@ Page Title="من نحن" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="team.aspx.cs" Inherits="WebApplication3.team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="Style.css" rel="stylesheet" />
 
    <link href="font-awesome/all.min.css" rel="stylesheet" />
    <style>
        body {
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            font-family: "alfont_com_Cairo-Regular";
            background: #000000;
        }

        .title {
            margin-top: -50px;
            margin-block-end: -50px
        }

        p, a, h1, h2, h3, h4 {
            margin: 0;
            padding: 0;
        }

        .section-team {
            padding: 80px 0;
        }

            .section-team .header-section {
                margin-bottom: 50px;
            }

                .section-team .header-section .small-title {
                    margin-bottom: 25px;
                    font-size: 16px;
                    font-weight: 500;
                    color: #3e64ff;
                }

                .section-team .header-section .title {
                    font-weight: 700;
                    font-size: 45px;
                }

            .section-team .single-person {
                margin-top: 30px;
                padding: 30px;
                background-color: #f6f9ff;
                border-radius: 5px;
            }

                .section-team .single-person:hover {
                    background: linear-gradient(to right, #016cec, #00b5f7);
                }

                .section-team .single-person .person-image {
                    position: relative;
                    margin-bottom: 50px;
                    border-radius: 50%;
                    border: 4px dashed transparent;
                    transition: padding .5s;
                }

                .section-team .single-person:hover .person-image {
                    padding: 12px;
                    border: 4px dashed #fff;
                }

                .section-team .single-person .person-image img {
                    width: 100%;
                    border-radius: 50%;
                }

                .section-team .single-person .person-image .icon {
                    position: absolute;
                    bottom: 0;
                    left: 50%;
                    transform: translate(-50%,50%);
                    display: inline-block;
                    width: 60px;
                    height: 60px;
                    line-height: 60px;
                    text-align: center;
                    background: linear-gradient(to right, #016cec, #00b5f7);
                    color: #fff;
                    border-radius: 50%;
                    font-size: 24px;
                }

                .section-team .single-person:hover .person-image .icon {
                    background: none;
                    background-color: #fff;
                    color: #016cec;
                }

                .section-team .single-person .person-info .full-name {
                    margin-bottom: 10px;
                    font-size: 28px;
                    font-weight: 700;
                }

                .section-team .single-person .person-info .speciality {
                    text-transform: uppercase;
                    font-size: 14px;
                    color: #016cec;
                }

                .section-team .single-person:hover .full-name,
                .section-team .single-person:hover .speciality {
                    color: #fff;
                }

        img {
            width 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/bootstrap.min.js"></script>
    <section class="section-team">
        <div class="container ">
            <!-- Start Header Section -->
            <div class="row justify-content-center text-center">
                <div class="col-md-8 ">
                    <div class="header-section">

                        <h2 class="title" style="color:white">خريجي جامعة سيئون 2023 - 2024  </h2>
                    </div>
                </div>
            </div>
            <!-- / End Header Section -->
            <div class="row ">
                <!-- Start Single Person -->
                <div class="col-sm-6 col-lg-4 col-xl-3">
                    <div class="single-person">
                        <div class="person-image">
                            <img src="images/Khatteb.jpg" alt="" style="width: 220px; height: 310px;">
                            <span class="icon">
                                <i class="fa-solid fa-database"></i>
                            </span>
                        </div>
                        <div class="person-info" style="text-align: center">
                            <h3 class="full-name">حسين ابوبكر ابوبكر الخطيب</h3>
                            <span class="speciality" dir="rtl">مصمم قاعدة البيانات<br />
                               Write Reports</span>
                        </div>
                    </div>
                </div>
                <!-- / End Single Person -->
                <!-- Start Single Person -->
                <div class="col-sm-6 col-lg-4 col-xl-3">
                    <div class="single-person">
                        <div class="person-image">
                            <img src="images/atass.png" alt="" style="width: 220px; height: 310px;">
                            <span class="icon">
                                <i class="fab fa-bootstrap"></i>
                            </span>
                        </div>
                        <div class="person-info  " style="text-align: center" dir="rtl">
                            <h3 class="full-name">عبدالله محمد سالم العطاس</h3>
                            <span class="speciality" dir="rtl">مطور JS,BootStrap<br /> FrontEnd</span>
                        </div>
                    </div>
                </div>
                <!-- / End Single Person -->
                <!-- Start Single Person -->
                <div class="col-sm-6 col-lg-4 col-xl-3">
                    <div class="single-person">
                        <div class="person-image">
                            <img src="images/Sleeem.png" alt="" style="width: 220px; height: 310px;">
                            <span class="icon">
                                <i class="fab fa-angular"></i>
                            </span>
                        </div>
                        <div class="person-info" style="text-align: center">
                            <h3 class="full-name">عبدالله سعيد سالم سليم</h3>
                            <span class="speciality" dir="rtl">مطور CSS , C sharp <br /> FrontEnd & BackEnd</span>
                        </div>
                    </div>
                </div>
                <!-- / End Single Person -->
                <!-- Start Single Person -->
                <div class="col-sm-6 col-lg-4 col-xl-3">
                    <div class="single-person">
                        <div class="person-image">
                            <img src="images/Balfaqih.png" alt="" style="width: 220px; height: 310px;">
                            <span class="icon">
                                <i class="fab fa-html5"></i>
                            </span>
                        </div>
                        <div class="person-info" style="text-align: center">
                            <h3 class="full-name">عبدالله محفوظ  محمد بلفقية</h3>
                            <span class="speciality" dir="rtl">مدير قاعدة بيانات , JS,CSS,ASP.Net <br /> FrontEnd & BackEnd</span>
                        </div>
                    </div>
                </div>
                <!-- / End Single Person -->
            </div>
        </div>
    </section>
</asp:Content>
