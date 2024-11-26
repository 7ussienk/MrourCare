<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="TrafficSigns.aspx.cs" Inherits="WebApplication3.TrafficSigns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cards Layout</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        @font-face {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
        }
        body {
            font-family: "alfont_com_Cairo-Regular";
            text-align: center;
            background-color: floralwhite;
        }

        .card img {
            width: 100%;
            height: auto;
            object-fit: cover;
            border-radius: 10px 10px 0 0;
            transition: 400ms;
        }

        .card {
            max-width: 350px;
            margin: 20px auto; /* تعديل المسافة بين الكروت */
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            font-family: "alfont_com_Cairo-Regular";
            cursor: pointer;
            transition: 400ms;
            border-radius: 10px;
            text-align: center;
        }

        .image-container {
            text-align: center;
        }

        .col-lg-2 .card:hover {
            transform: scale(1.2);
            z-index: 1; /* تحديد ترتيب الطبقات لعرض الكارت بشكل أمامي */
        }

        .title-comm {
            color: #fff;
            font-size: 18px;
            position: relative;
            margin-top: 30px;
            margin-bottom: 30px;
            font-weight: 700;
            text-align: center;
        }

        h3.title-comm:before {
            content: '';
            position: absolute;
            top: 50%;
            left: 0;
            right: 0;
            margin-top: 0;
            border-top: 2px solid #000000;
            z-index: 1;
            display: block;
        }

        .title-comm .title-holder {
            min-width: 350px;
            height: 45px;
            background-color: #000000;
            height: auto;
            line-height: 45px;
            padding: 0px 20px;
            position: relative;
            z-index: 2;
            text-align: center;
            display: inline-block;
            min-width: 280px;
        }

        .title-holder:before {
            content: "";
            position: absolute;
            right: -15px;
            border-width: 0px;
            bottom: 0px;
            border-style: solid;
            border-color: #5c9efe transparent;
            display: block;
            width: 0;
            height: 0;
            border-top: 23px solid transparent;
            border-bottom: 22px solid transparent;
            border-left: 15px solid #000000;
        }

        .title-holder:after {
            content: "";
            position: absolute;
            left: -15px;
            border-width: 0px;
            bottom: 0px;
            border-style: solid;
            border-color: #5c9efe transparent;
            display: block;
            width: 0;
            height: 0;
            border-top: 23px solid transparent;
            border-bottom: 22px solid transparent;
            border-right: 15px solid #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/bootstrap.bundle.min.js"></script>

    <div class="container-fluid " dir="rtl">
        <h3 class="title-comm"><span class="title-holder">الأرشادات الأرشادية</span></h3>
        <div class="col-lg-12 col-sm-12 mb-5">
            <div class=" row ">
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100  ">
                        <img src="trafic/1.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">الاتفاف الى اليسار أثناء السير الى الأمام</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100  ">
                        <img src="trafic/2.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">لا يمكن دخول الشاحنات</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/3.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أقصى ارتفاع 4.4</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100 ">
                        <img src="trafic/4.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع الأنعطاف الى الخلف</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/5.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع الأنعطاف الى اليمين</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/6.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع الوقوف و الأنتظار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/7.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع الوقوف</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/8.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">الطريق يضيق من الجانبين</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/9.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">الطريق يضيق من اليمين</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/10.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">الأندماج من ناحية اليسار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/11.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">طريق غير مستوي</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/12.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">دوار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/13.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">اتجاه السير الإجباري إالى الأمام أو اليمين</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/14.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">نزول</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/15.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">صعود</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/16.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أعمال طرق</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/17.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">"علامة قف</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/18.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع الوقوف</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/19.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">علامة وجود منزلقات</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/20.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">السرعة القصوى 40</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/21.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">موقف</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/22.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">طريق ذو اتجاهين</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/23.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع الأنعطاف الى اليسار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/24.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">معبر مشاة</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/25.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع التجاوز</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/26.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">ممنوع الدخول</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/28.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">تقاطع طريق</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/29.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">مطب</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/30.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">صخور متساقطة</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/31.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">نهاية طريق مزدوج</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/32.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">الطريق يتجة لنهاية حافة</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/33.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">منعطفات خطيرة من اليمين الى اليسار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/34.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">منعطف لليمين"</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/35.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">طريق ذو أتجاهين</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/37.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">مسار ذو اتجاه متداخل</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/37.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">اتجاة السير الإجباري لليمين أو اليسار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/38.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أتجاه اجباري ألزم اليسار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/39.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أتجاه اجباري لليسار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/40.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">حصى متناثر</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/41.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">نهاية طريق حر الحركة</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/42.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أشارت ضوئية</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/43.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">نفق</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/44.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">منطقة طياران منخفضة</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/45.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أتجاه السير اجباري في الدوار</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/46.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أعطاء الأفضلية</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/47.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">طريق حر الحركة</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/48.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">محطة وقود</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/49.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">منحنيات</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/50.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">أحذر</h4>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-3 mt-1">
                    <div class="card h-100">
                        <img src="trafic/51.jpg" />
                        <div class="card-body">
                            <h4 class="card-title">حواجز</h4>
                        
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
    <!--  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"
        crossorigin="ano
    nymous"></script> -->



</asp:Content>
