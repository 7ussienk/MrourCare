<%@ Page Title=" تدقيق نقل الملكيات" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="view4.aspx.cs" Inherits="WebApplication3.view4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <link href="css/StyleSheet1.css" rel="stylesheet" />
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <style>
        body {
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            font-family: "alfont_com_Cairo-Regular";
        }

        <link href="css/bootstrap.min.css" rel="stylesheet"/ >
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
    <div class="container mt-3" style="text-align: right;" dir="rtl">
        <div class="card shadow-lg p-3 mb-5 bg-white rounded ">
            <div class="card-body" runat="server" id="div" visible="false">
                <div style="background: #C0C0C0; width: 100%; border-radius: 10px">
                    <h2 class=" mb-3  text-center h1">تقديم طلب نقل ملكية/مقطورة </h2>
                </div>
                <form class="" dir="rtl">
                    <h3 class="mt-2 mb-3  h4" dir="rtl">بيانات المركبة</h3>
                    <div class="row">
                        <div class="mb-3 col-md-3">
                            <label for="full-name" class="form-label">رقم اللوحة المعدنية </label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" Placeholder="ادخل رقم اللوحة"
                                ID="PlateNumberTB"></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-3">
                            <label for="birthdate" class="form-label">نوع الرقم</label>
                            <asp:DropDownList ID="TypeNumberDD" CssClass="form-control" runat="server">
                                <asp:ListItem>خاص</asp:ListItem>
                                <asp:ListItem>أجرة</asp:ListItem>
                                <asp:ListItem>نقل</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3 col-md-3">
                            <label for="age" class="form-label">نوع المركبه</label>
                            <asp:DropDownList ID="TypeVehicleDD" CssClass="form-control" runat="server">
                                <asp:ListItem>تكتك</asp:ListItem>
                                <asp:ListItem>شاحنة</asp:ListItem>
                                <asp:ListItem>سيارة</asp:ListItem>
                                <asp:ListItem>دراجة نارية</asp:ListItem>
                                <asp:ListItem>قاطرة</asp:ListItem>
                                <asp:ListItem>باص</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="birthplace" class="form-label">لون المركبة</label>

                            <asp:DropDownList ID="ColorVehicleDD" CssClass="form-control" runat="server">

                                <asp:ListItem>احمر</asp:ListItem>
                                <asp:ListItem>اخضر</asp:ListItem>
                                <asp:ListItem>اصفر</asp:ListItem>
                                <asp:ListItem>ابيض</asp:ListItem>
                                <asp:ListItem>اسود</asp:ListItem>
                                <asp:ListItem>اخرى</asp:ListItem>

                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="row ">

                        <div class="mb-1 col-md-4">
                            <label for="occupation" class="form-label">سنة الصنع </label>
                            <asp:TextBox ID="ManufacturingYearTB" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-4">
                            <label for="occupation" class="form-label">رقم المحرك </label>
                            <asp:TextBox ID="EngineNumberTB" runat="server" CssClass="form-control" TextMode="Number" />
                        </div>
                        <div class="mb-1 col-md-4" id="TypeNumberDD">
                            <label for="street" class="form-label">نوع رقم المقطورة</label>
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                <asp:ListItem>خاص</asp:ListItem>
                                <asp:ListItem>أجرة</asp:ListItem>
                                <asp:ListItem>نقل</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-1 col-md-4">
                            <label for="occupation" class="form-label">رقم القعادة  </label>
                            <asp:TextBox ID="CaNumberTB" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-4">
                            <label for="occupation" class="form-label">رقم رخصة التسيير|الكرت </label>
                            <asp:TextBox ID="LicenseNumberTB" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-4">
                            <label for="occupation" class="form-label">تاريخ إصدار رخصة التسيير</label>
                            <asp:TextBox ID="LicenseNumberTBdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-6">
                            <label for="district" class="form-label">رقم المقطورة المباعة</label>
                            <asp:TextBox ID="VehicalSoldTB" runat="server" CssClass="form-control" placeholder="أدخل رقم المقطورة المباعة"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-6">
                            <label for="house" class="form-label">رقم وثقية الملكية </label>
                            <asp:TextBox ID="OwnershipDocumentNumberTB" runat="server" CssClass="form-control"
                                placeholder="أدخل رقم وثيقة الملكية"></asp:TextBox>
                        </div>
                    </div>


                    <hr />

                    <h3 class="mt-2 mb-3  h4" dir="rtl">معلومات البائـع</h3>



                    <div class="row">
                        <div class="mb-3 col-md-3">
                            <h5>نوع الهوية</h5>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;"
                                    ID="radiocard" runat="server" GroupName="ids" Checked></asp:RadioButton>
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
                            <asp:TextBox ID="IDNumberTBNew" runat="server" CssClass="form-control" placeholder="أدخل رقم البطاقة أو الجواز"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-4">
                            <label for="issue-date" class="form-label">تاريخ إصدار البطاقة أو الجواز</label>
                            <asp:TextBox ID="ReleaseDateNew" runat="server" CssClass="form-control" TextMode="Date"
                                placeholder="أدخل التاريخ" required></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="mb-3 col-md-6">
                            <label for="phone" class="form-label">مكان الاصدار </label>
                            <asp:TextBox ID="PlaceIssueTBNEW" runat="server" CssClass="form-control" TextDirection="RightToLeft"
                                placeholder="أدخل مكان الإصدار" required></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-6">
                            <label for="house" class="form-label">اسم البائع كاملا </label>
                            <asp:TextBox ID="NewSellerNameTB" runat="server" CssClass="form-control" placeholder="أدخل اسم البائع"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-1 col-md-6">
                            <label for="house" class="form-label">العنوان</label>
                            <asp:TextBox ID="Address" runat="server" CssClass="form-control" placeholder="أدخل العنوان"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-6">
                            <label for="house" class="form-label" id="vehicalpolicepranch">
                                ادارة الشرطة المسجل لديها
                                المركبة
                            </label>
                            <asp:TextBox ID="OldDepartmentTB" runat="server" CssClass="form-control" placeholder="أدخل فرع الشرطة المسجل لديها المركبة"></asp:TextBox>
                        </div>

                    </div>
                    <hr />
                    <h3 class="mt-2 mb-3  h4" dir="rtl">معلومات المـالك الجديد</h3>

                    <div class="row">
                        <div class="mb-3 col-md-3">
                            <h5>نوع الهوية</h5>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;"
                                    ID="radiocard2" runat="server" GroupName="ids2" Checked></asp:RadioButton>
                                <label class="form-check-label" for="radiocard2">بطاقة شخصية</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;"
                                    ID="radiopassport2" runat="server" GroupName="ids2"></asp:RadioButton>
                                <label class="form-check-label" for="radiopassport2">جواز سفر</label>
                            </div>

                        </div>
                        <div class="mb-3 col-md-5">
                            <label for="id-number" class="form-label">رقم البطاقة أو الجواز</label>
                            <asp:TextBox ID="IDNumberTBNew2" runat="server" CssClass="form-control" placeholder="أدخل رقم البطاقة أو الجواز"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-4">
                            <label for="issue-date" class="form-label">تاريخ إصدار البطاقة أو الجواز</label>
                            <asp:TextBox ID="ReleaseDateNew2" runat="server" CssClass="form-control" TextMode="Date"
                                placeholder="أدخل التاريخ" required></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="mb-3 col-md-6">
                            <label for="phone" class="form-label">مكان الاصدار </label>
                            <asp:TextBox ID="PlaceIssueTBNEW2" runat="server" CssClass="form-control" TextDirection="RightToLeft"
                                placeholder="أدخل مكان الإصدار" required></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-6">
                            <label for="house" class="form-label">اسم المالك الجديد</label>
                            <asp:TextBox ID="NewOwnerNameTB" runat="server" CssClass="form-control" placeholder="أدخل اسم المالك الجديد"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-1 col-md-5">
                            <label for="house" class="form-label">العنوان</label>
                            <asp:TextBox ID="Address1" runat="server" CssClass="form-control" placeholder="أدخل العنوان"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-2">
                            <label for="house" class="form-label">المهنة</label>
                            <asp:TextBox ID="Job" runat="server" CssClass="form-control" placeholder="أدخل المهنة"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-5">
                            <label for="house" class="form-label">رقم الهاتف </label>
                            <asp:TextBox ID="PhoneNumberTB" runat="server" CssClass="form-control" placeholder="أدخل رقم الهاتف"
                                TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">الجنسية</label>
                            <asp:TextBox ID="NationalityTB" runat="server" CssClass="form-control" placeholder="أدخل الجنسية"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">محافظة الاقامة </label>
                            <asp:TextBox ID="GovernorateTB" runat="server" CssClass="form-control" placeholder="أدخل محافظة الإقامة"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">مديرية </label>
                            <asp:TextBox ID="DirectorateTB" runat="server" CssClass="form-control" placeholder="أدخل المديرية"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">مركز </label>
                            <asp:TextBox ID="CenterTB" runat="server" CssClass="form-control" placeholder="أدخل المركز"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">القرية</label>
                            <asp:TextBox ID="VillageTB" runat="server" CssClass="form-control" placeholder="أدخل القرية"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">حارة </label>
                            <asp:TextBox ID="NeighTB" runat="server" CssClass="form-control" placeholder="أدخل الحارة"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">شارع </label>
                            <asp:TextBox ID="StretTB" runat="server" CssClass="form-control" placeholder="أدخل الشارع"></asp:TextBox>
                        </div>
                        <div class="mb-1 col-md-3">
                            <label for="house" class="form-label">رقم المنزل </label>
                            <asp:TextBox ID="HouseNumberTB" runat="server" CssClass="form-control" placeholder="أدخل رقم المنزل"
                                TextMode="Number"></asp:TextBox>
                        </div>
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
                    <asp:Button ID="update" runat="server" Text="تحديث" class=" btn-secondary " Visible="false"
                        OnClick="update_Click" OnClientClick="return upDate(this)" />
                    <div id="alert_dan" runat="server" class="alert alert-danger mt-3" visible="false"
                        role="alert">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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
