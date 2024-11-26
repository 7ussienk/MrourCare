<%@ Page Title="إصدار رخصة قيادة" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Newliesen.aspx.cs" Inherits="WebApplication3.Newliesen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="Style.css" rel="stylesheet" />
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <style>
        body {
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            font-family: "alfont_com_Cairo-Regular";
        }
    </style>
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
                Swal.fire('لم يتم حفظ تغييراتك', '', 'info')
            }
        });
        obj.ele = btnDelete;
        return false;
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <script src="css/sweet.js"></script>
    <div class="container  mt-3" style="text-align: right;" dir="rtl" id="container" runat="server">
        <div class="card shadow-lg p-3 mb-5 bg-white rounded">
            <div class="card-body">
                <div class="">
                    <div class="">
                        <div style="background: #C0C0C0; width: 100%; border-radius: 10px">
                            <h2 class=" mb-3  text-center h1">تقديم طلب رخصة قيادة</h2>
                        </div>
                    </div>
                </div>

                <form class="" dir="rtl">
                    <h3 class="mt-2 mb-3  h4" dir="rtl">بيانات مقدم الطلب</h3>

                    <div class="row">
                        <div class="mb-3 col-md-4">
                            <label for="full-name" class="form-label">الاسم الكامل</label>
                            <asp:TextBox ID="FullNameTBNew" runat="server" CssClass="form-control" placeholder="أدخل الاسم الكامل" required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-4">
                            <label for="birthdate" class="form-label">تاريخ الميلاد</label>
                            <asp:TextBox ID="BirthDatNew" runat="server" CssClass="form-control" TextMode="Date" placeholder="تاريخ الميلاد" required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-4">
                            <label for="age" class="form-label">العمر</label>
                            <asp:TextBox ID="AgeTB" runat="server" CssClass="form-control" placeholder="أدخل العمر" TextMode="Number" required></asp:TextBox>
                        </div>
                    </div>

                    <div class="row ">
                        <div class="mb-1 col-md-4">
                            <label for="birthplace" class="form-label">مكان الميلاد</label>
                            <asp:TextBox ID="BirthPlaceTBNew" runat="server" CssClass="form-control" placeholder="أدخل مكان الميلاد" required></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-8">
                            <label for="occupation" class="form-label">المهنة</label>
                            <asp:TextBox ID="OccupationTBNew" runat="server" CssClass="form-control" placeholder="أدخل المهنة" required></asp:TextBox>
                        </div>
                    </div>
                    <hr />

                    <h3 class="mt-2 mb-3  h4" dir="rtl">معلومات العنوان</h3>
                    <div class="row">
                        <div class="mb-1 col-md-3">
                            <label for="province" class="form-label">المحافظة</label>
                            <asp:TextBox ID="GovernorateTBNew" runat="server" CssClass="form-control" placeholder="أدخل المحافظة" required></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="district" class="form-label">المديرية</label>
                            <asp:TextBox ID="DirectorateTBNew" runat="server" CssClass="form-control" placeholder="أدخل المديرية" required></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="street" class="form-label">الشارع</label>
                            <asp:TextBox ID="StreetTBNew" runat="server" CssClass="form-control" placeholder="أدخل الشارع" required></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">رقم المنزل/الجوال</label>
                            <asp:TextBox ID="HouseNumberTBNEW" runat="server" CssClass="form-control" placeholder="أدخل رقم المنزل أو الجوال" required></asp:TextBox>
                        </div>
                    </div>
                    <hr />

                    <h3 class="mt-4  h4 " dir="rtl">معلومات الهوية</h3>
                    <div class="row">
                        <div class="mb-3 col-md-2">
                            <h5>نوع الهوية</h5>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiocard" runat="server" GroupName="ids" Checked></asp:RadioButton>
                                <label class="form-check-label" for="radiocard">بطاقة شخصية</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiopassport" runat="server" GroupName="ids"></asp:RadioButton>
                                <label class="form-check-label" for="radiopassport">جواز سفر</label>
                            </div>

                        </div>
                        <div class="mb-3 col-md-5">
                            <label for="id-number" class="form-label">رقم البطاقة أو الجواز</label>
                            <asp:TextBox ID="IDNumberTBNew" runat="server" CssClass="form-control" placeholder="أدخل رقم البطاقة أو الجواز" required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-2">
                            <label for="issue-date" class="form-label">تاريخ إصدار البطاقة أو الجواز</label>
                            <asp:TextBox ID="ReleaseDateNew" runat="server" CssClass="form-control" TextMode="Date" placeholder="أدخل التاريخ" required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-3">
                            <label for="phone" class="form-label">مكان الاصدار </label>
                            <asp:TextBox ID="PlaceIssueTBNEW" runat="server" CssClass="form-control" TextDirection="RightToLeft" placeholder="أدخل مكان الإصدار" required></asp:TextBox>
                        </div>
                        <hr />

                        <div class="row ">
                            <div class="" align="center">
                                <asp:Button ID="SendBTNew" runat="server" class="btn btn-primary" Text="إرسال" OnClick="SendBTNew_Click"
                                    OnClientClick="return upDate(this)" />
                                <asp:Button ID="BackBTNew" runat="server" class="btn btn-dark" Text="عودة" CausesValidation="False"
                                    UseSubmitBehavior="False" PostBackUrl="~/Main.aspx"
                                    ToolTip="العودة الى الرئيسية" OnClick="BackBTNew_Click" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="js/bootstrap.min.js"></script>
</asp:Content>
