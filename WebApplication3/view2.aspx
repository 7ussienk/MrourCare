<%@ Page Title="تدقيق تجديد رخصة" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="view2.aspx.cs" Inherits="WebApplication3.view2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/StyleSheet1.css" rel="stylesheet" />
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <script>
        var obj = { status: false, ele: null };
        function upDate(btnDelete) {
            if (obj.status) {
                obj.status = false;
                return true;
            };
            Swal.fire({
                title: "هل انت متاكد من كافة المعلومات؟",
                icon: "question",
                iconHtml: "؟",
                confirmButtonText: "نعم",
                cancelButtonText: "عودة",
                denyButtonText: 'الغاء',
                showDenyButton: true,
                showCancelButton: true,
                showCloseButton: true,
                customClass: {
                    actions: 'my-actions',
                    confirmButton: 'order-3',
                    cancelButton: 'order-2 ',
                    denyButton: 'order-1',
                },

            }).then((result) => {
                if (result.isConfirmed) {
                    obj.status = true;
                    obj.ele.click();
                } else if (result.isDenied) {
                    Swal.fire('لم يتم تحديث تغييراتك', '', 'info')
                }
            });
            obj.ele = btnDelete;
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="css/sweet.js"></script>
    <link href="css/StyleSheet1.css" rel="stylesheet" />
    <script src="css/sweet.js"></script>
    <link href="Style.css" rel="stylesheet" />
    <style>
        body {
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            font-family: "alfont_com_Cairo-Regular";
        }
    </style>
    <div class="container mt-3" style="text-align: right;" dir="rtl">
        <div class="card shadow-lg p-3 mb-5 bg-white rounded" runat="server" visible="false"
            id="div">
            <div class="card-body">
                <div style="background: #C0C0C0; width: 100%; border-radius: 10px">
                    <h2 class=" mb-3  text-center h1">معاينة أستمارة تجديد رخصة قيادة</h2>
                </div>
                <form class="" dir="rtl">
                    <h3 class="mt-2 mb-3  h4" dir="rtl">بيانات مقدم الطلب</h3>

                    <div class="row">
                        <div class="mb-3 col-md-4">
                            <label for="full-name" class="form-label">الاسم الكامل</label>
                            <asp:TextBox ID="FullNameTBNew" runat="server" CssClass="form-control" placeholder="أدخل الاسم الكامل"></asp:TextBox>

                        </div>

                        <div class="mb-3 col-md-4">
                            <label for="LicNumb" class="form-label">أحمل رخصة قيادة رقم</label>
                            <asp:TextBox ID="LicNum" runat="server" CssClass="form-control" placeholder="أدخل رقم الرخصة القديمة"></asp:TextBox>
                        </div>

                        <div class="mb-3 col-md-4">
                            <label for="birthdate" class="form-label">تاريخ الميلاد</label>
                            <asp:TextBox ID="BirthDatNew" runat="server" CssClass="form-control" TextMode="Date"
                                placeholder="تاريخ الميلاد"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="mb-3 col-md-5">
                            <label for="full-name" class="form-label">تاريخ إصدار الرخصة القديمة</label>
                            <asp:TextBox ID="oldlicepr" runat="server" CssClass="form-control" TextMode="Date"
                                placeholder="  تاريخ اصدار الرخصة القديمة"></asp:TextBox>
                        </div>

                        <div class="mb-3 col-md-5">
                            <label for="LicNumb" class="form-label">تاريخ إنتهى الرخصة القديمة</label>
                            <asp:TextBox ID="oldlicexp" runat="server" CssClass="form-control" TextMode="Date"
                                placeholder="تاريخ انتهى الرخصة القديمة"></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-2">
                            <label for="LicNumb" class="form-label">مركز الاصدار</label>
                            <asp:TextBox ID="center" runat="server" CssClass="form-control" placeholder=" "></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="mb-3 col-md-4">
                            <label for="birthplace" class="form-label">مكان الميلاد</label>
                            <asp:TextBox ID="BirthPlaceTBNew" runat="server" CssClass="form-control" placeholder="أدخل مكان الميلاد"></asp:TextBox>
                        </div>

                        <div class="mb-3 col-md-4">
                            <label for="age" class="form-label">العمر</label>
                            <asp:TextBox ID="AgeTB" runat="server" CssClass="form-control" placeholder="أدخل العمر"
                                TextMode="Number"></asp:TextBox>
                        </div>

                        <div class="mb-3 col-md-4">
                            <label for="occupation" class="form-label">المهنة</label>
                            <asp:TextBox ID="OccupationTBNew" runat="server" CssClass="form-control" placeholder="أدخل المهنة"></asp:TextBox>
                        </div>
                    </div>
            </div>



            <hr />

            <h3 class="mt-2 mb-3  h4" dir="rtl">معلومات العنوان</h3>
            <div class="row">
                <div class="mb-1 col-md-3">
                    <label for="province" class="form-label">المحافظة</label>
                    <asp:TextBox ID="GovernorateTBNew" runat="server" CssClass="form-control" placeholder="أدخل المحافظة"></asp:TextBox>
                </div>
                <div class="mb-1 col-md-3">
                    <label for="district" class="form-label">المديرية</label>
                    <asp:TextBox ID="DirectorateTBNew" runat="server" CssClass="form-control" placeholder="أدخل المديرية"></asp:TextBox>
                </div>
                <div class="mb-1 col-md-3">
                    <label for="street" class="form-label">الشارع</label>
                    <asp:TextBox ID="StreetTBNew" runat="server" CssClass="form-control" placeholder="أدخل الشارع"></asp:TextBox>
                </div>
                <div class="mb-1 col-md-3">
                    <label for="house" class="form-label">رقم المنزل/الجوال</label>
                    <asp:TextBox ID="HouseNumberTBNEW" runat="server" CssClass="form-control" placeholder="أدخل رقم المنزل أو الجوال"></asp:TextBox>
                </div>
            </div>
            <hr />

            <h3 class="mt-4  h3 " dir="rtl">معلومات الهوية</h3>
            <div class="row">
                <div class="mb-3 col-md-2">
                    <h5>نوع الهوية</h5>
                    <div class="form-check">
                        <asp:RadioButton class="form-check-input" Style="border: none; background: none;"
                            ID="radiocard" runat="server" GroupName="ids"></asp:RadioButton>
                        <label class="form-check-label" for="radiocard">بطاقة شخصية</label>
                    </div>
                    <div class="form-check">
                        <asp:RadioButton class="form-check-input" Style="border: none; background: none;"
                            ID="radiopassport" runat="server" GroupName="ids"></asp:RadioButton>
                        <label class="form-check-label" for="radiopassport">جواز سفر</label>
                    </div>

                </div>
                <div class="mb-3 col-md-5">
                    <label for="id-number" class="form-label">رقم البطاقة أو الجواز</label>
                    <asp:TextBox ID="IDNumberTBNew" runat="server" CssClass="form-control" placeholder="أدخل رقم البطاقة أو الجواز"></asp:TextBox>
                </div>
                <div class="mb-3 col-md-2">
                    <label for="issue-date" class="form-label">تاريخ إصدار البطاقة أو الجواز</label>
                    <asp:TextBox ID="ReleaseDateNew" runat="server" CssClass="form-control" TextMode="Date"
                        placeholder="أدخل التاريخ"></asp:TextBox>
                </div>
                <div class="mb-3 col-md-3">
                    <label for="phone" class="form-label">مكان الاصدار </label>
                    <asp:TextBox ID="PlaceIssueTBNEW" runat="server" CssClass="form-control" TextDirection="RightToLeft"
                        placeholder="أدخل مكان الإصدار"></asp:TextBox>
                </div>


                <hr />

                <div class="row" runat="server" id="imgs" visible="false">
                    <div class="wrapper">
                        <div class="container2">
                            <input type="radio" name="slide" class="input" id="c1" checked>
                            <label id="img1" runat="server" for="c1" class="card2">
                                <div class="row">
                                    <div class="icon">1</div>
                                    <div class="description ">

                                        <p>
                                            صورة الهــويـة     
                                        </p>
                                    </div>
                                </div>
                            </label>
                            <input type="radio" name="slide" class="input" id="c2">
                            <label id="img4" runat="server" for="c2" class="card2">
                                <div class="row">
                                    <div class="icon">2</div>
                                    <div class="description">
                                        <p>
                                            الصورة الشخصية
                                        </p>
                                    </div>
                                </div>
                            </label>

                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="" align="center">
                        <div class="btn-elegant btn-group-lg" role="group" aria-label="" id="groupbtns" runat="server">
                            <asp:Button ID="confirm" runat="server" class=" btn-success " Text="موافقة" OnClick="confirm_Click" />
                            <asp:Button ID="edit" runat="server" class=" btn-secondary " Text="تعديل" OnClick="edit_Click" />
                            <asp:Button ID="cancle" runat="server" class=" btn-danger " Text="رفض" OnClick="cancle_Click" />
                        </div>

                    </div>
                </div>
                <div class="row ">
                    <div class="col-sm-12">
                        <asp:Button ID="update" runat="server" Text="تحديث" class=" btn-secondary " Visible="false"
                            OnClick="update_Click" OnClientClick="return upDate(this)" />
                        <div id="alert_dan" runat="server" class="alert alert-danger mt-3" visible="false"
                            role="alert">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="col-sm-12">
                        <section class="intro" id="notes" runat="server" visible="False">
                            <div class="container">
                                <p class="h2 mb-4 text-white">

                                    <div class="card">
                                        <div class="card-body p-4">
                                            <div class="row">
                                                <div class="col-12 mb-4">
                                                    <div class="input-group">
                                                        <div class="form-outline flex-fill">
                                                            <asp:TextBox ID="content" runat="server" CssClass="form-control" placeholder="أدخل التعديلات"
                                                                required></asp:TextBox>


                                                        </div>


                                                        <asp:Button Text="إرسال" ID="SendBTNew" runat="server" class=" btn btn-primary "
                                                            OnClick="SendBTNew_Click" />



                                                    </div>
                                                </div>
                                                قم بكتابة التعديلات التي ينبغي على المستخدم تغييرها
                                            </div>

                                        </div>
                                    </div>

                        </section>
                    </div>

                </div>
                </form>
            </div>
        </div>
    </div>
    <script src="js/bootstrap.min.js"></script>
</asp:Content>
