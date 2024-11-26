<%@ Page Title="إصدار رقم جديد" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewNumberL.aspx.cs" Inherits="WebApplication3.NewNumberL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="Style.css" rel="stylesheet" />
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <link href="font-awesome/all.min.css" rel="stylesheet" />

    <style>
        body {
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            font-family: "alfont_com_Cairo-Regular";
             
        }

        .xc {
            background-image: url('images/logo.png');
            background-repeat: no-repeat;
            background-size: 6%;
            background-position: top right;
        }

        .conten2t {
            position: relative;
            z-index: 3;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="css/sweet.js"></script>     
    <br>
    <div class="container mt-3 content" style="text-align: right;" dir="rtl" id="container"
        runat="server">
        <div class="card shadow-lg p-3 mb-5 bg-white rounded ">
            <div class="card-body ">
                <div style="background: #C0C0C0; width: 100%; border-radius: 10px" class="">
                    <h2 class=" mb-3  text-center h1 ">أستمارة صرف رقم جديد  
                       
                    </h2>
                  
                </div>
                <form class="" dir="rtl">
                    <h3 class=" mt-2 mb-3  h4" dir="rtl">بيانات المالك</h3>

                    <div class="row">
                        <div class="mb-3 col-md-4">
                            <label for="full-name" class="form-label">الاسم المالك</label>
                            <asp:TextBox ID="FullNameTB" runat="server" CssClass="form-control" placeholder="أدخل اسم المالك"
                                required></asp:TextBox>
                        </div>

                        <div class="mb-3 col-md-4">
                            <label for="Gender" class="form-label">الجنس</label>
                            <asp:TextBox ID="GenderTB" runat="server" CssClass="form-control" placeholder="الجنس"
                                required></asp:TextBox>
                        </div>

                        <div class="mb-3 col-md-4">
                            <label for="birthdate" class="form-label">تاريخ الميلاد</label>

                            <asp:TextBox ID="BirthDate" runat="server" CssClass="form-control" TextMode="Date"
                                placeholder="تاريخ الميلاد" required></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-4 col-md-6">
                            <label for="birthplace" class="form-label">مكان الميلاد</label>
                            <asp:TextBox ID="BirthPlaceTB" runat="server" CssClass="form-control" placeholder="أدخل مكان الميلاد"
                                required></asp:TextBox>
                        </div>

                        <div class="mb-4 col-md-6">
                            <label for="Nationality" class="form-label">الجنسية</label>
                            <asp:TextBox ID="NationalityTB" runat="server" CssClass="form-control" placeholder="أدخل الجنسية"
                                required></asp:TextBox>
                        </div>



                        <div class="mb-4 col-md-6">
                            <label for="occupation" class="form-label">المهنة</label>
                            <asp:TextBox ID="OccupationTB" runat="server" CssClass="form-control" placeholder="أدخل المهنة"
                                required></asp:TextBox>
                        </div>

                        <div class="mb-1 col-md-6">
                            <label for="Professional" class="form-label">جهة وعنوان العمل </label>
                            <asp:TextBox ID="ProfessionalTB" runat="server" CssClass="form-control" placeholder="أدخل جهة وعنوان العمل"
                                required></asp:TextBox>
                        </div>
                    </div>
                    <hr />
                    <h3 class="mt-4  h3 " dir="rtl">معلومات الهوية</h3>
                    <div class="row">
                        <div class="mb-3 col-md-2">
                            <h6>نوع الهوية  </h6>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiocard" runat="server" GroupName="ids" Checked></asp:RadioButton>
                                <label class="form-check-label" for="radiocard">بطاقة شخصية</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiopassport" runat="server" GroupName="ids"></asp:RadioButton>
                                <label class="form-check-label" for="radiopassport">جواز سفر</label>
                            </div>
                        </div>
                        <div class="mb-3 col-md-4">
                            <label for="id-number" class="form-label">رقم البطاقة أو الجواز</label>
                            <asp:TextBox ID="IDNumberTB" runat="server" CssClass="form-control" placeholder="أدخل رقم البطاقة أو الجواز"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-3">
                            <label for="issue-date" class="form-label">تاريخ إصدار البطاقة أو الجواز</label>
                            <asp:TextBox ID="ReleaseDate" runat="server" CssClass="form-control" TextMode="Date"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-3 col-md-3">
                            <label for="phone" class="form-label">مكان الاصدار </label>
                            <asp:TextBox ID="PlaceIssueTB" runat="server" CssClass="form-control" required placeholder="أدخل مكان الاصدار"
                                TextMode="SingleLine" />
                        </div>
                    </div>
                    <hr />
                    <h3 class="mt-2 mb-3  h4" dir="rtl">معلومات العنوان</h3>
                    <div class="row">
                        <div class="mb-2 col-xl-3 col-sm-6">
                            <label for="province" class="form-label" id="GovernorateTB">المحافظة</label>
                            <asp:TextBox ID="province" runat="server" CssClass="form-control" placeholder="أدخل المحافظة"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-2 col-xl-3 col-sm-6">
                            <label for="district" class="form-label">المديرية</label>
                            <asp:TextBox ID="DirectorateTB" runat="server" CssClass="form-control" placeholder="أدخل المديرية"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-2 col-xl-3 col-sm-6">
                            <label for="street" class="form-label">الشارع</label>
                            <asp:TextBox ID="StreetTB" runat="server" CssClass="form-control" placeholder="أدخل الشارع"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-2 col-xl-3 col-sm-6">
                            <label for="house" class="form-label">رقم المنزل/الجوال</label>
                            <asp:TextBox ID="HouseNumberTB" runat="server" CssClass="form-control" placeholder="أدخل رقم المنزل أو الجوال"
                                required></asp:TextBox>
                        </div>
                    </div>
                    <hr />
                    <h3 class="mt-4  h3 " dir="rtl">معلومات الأقارب</h3>
                    <div class="row">
                        <div class="mb-4 col-xl-6 col-sm-6">
                            <label for="cousin_1" class="form-label">أسم القريب الاول</label>
                            <asp:TextBox ID="CousinOneTB" runat="server" CssClass="form-control" placeholder="أدخل اسم القريب الأول"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-4 col-xl-6 col-sm-6">
                            <label for="cousin_2" class="form-label">أسم القريب الثاني</label>
                            <asp:TextBox ID="CousinTwoTB" runat="server" CssClass="form-control" placeholder="أدخل اسم القريب الثاني"
                                required></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-4 col-xl-6 col-sm-6">
                            <label for="Id_Number_Cousin_1" class="form-label">عنوان القريب الأول</label>
                            <asp:TextBox ID="txtaddress1" runat="server" CssClass="form-control" placeholder="أدخل عنوان القريب الأول"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-4 col-xl-6 col-sm-6">
                            <label for="Id_Number_Cousin_2" class="form-label">عنوان القريب الثاني</label>
                            <asp:TextBox ID="txtaddress2" runat="server" CssClass="form-control" placeholder="ادخل عنوان القريب الثاني"
                                required></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-3 col-xl-6 col-sm-6">
                            <h6>نوع هوية القريب الاول</h6>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiocard2" runat="server" GroupName="ids2" Checked></asp:RadioButton>
                                <label class="form-check-label" for="radiocard2">بطاقة شخصية</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiopassport2" runat="server" GroupName="ids2"></asp:RadioButton>
                                <label class="form-check-label" for="radiopassport2">جواز سفر</label>
                            </div>
                        </div>

                        <div class="mb-3 col-xl-6 col-sm-6">

                            <h6>نوع هوية القريب الثاني</h6>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiocard3" runat="server" GroupName="ids3" Checked></asp:RadioButton>
                                <label class="form-check-label" for="radiocard3">بطاقة شخصية</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" Style="border: none; background: none;" ID="radiopassport3" runat="server" GroupName="ids3"></asp:RadioButton>
                                <label class="form-check-label" for="radiopassport3">جواز سفر</label>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="mb-4 col-xl-6 col-sm-6">
                            <label for="Id_Number_Cousin_1" class="form-label">رقم البطاقة أو الجواز للقريب الأول</label>
                            <asp:TextBox ID="IDNumberCousinOneTB" runat="server" CssClass="form-control" placeholder="أدخل رقم البطاقة أو الجواز للقريب الأول"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-4 col-xl-6 col-sm-6">
                            <label for="Id_Number_Cousin_2" class="form-label">رقم البطاقة أو الجواز للقريب الثاني</label>
                            <asp:TextBox ID="IDNumberCousinTwoTB" runat="server" CssClass="form-control" placeholder="أدخل رقم البطاقة أو الجواز للقريب الثاني"
                                required></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="mb-1 col-xl-6 col-sm-6">
                            <label for="Phone_Number_Cousin_1" class="form-label">رقم الهاتف/جوال القريب الأول</label>
                            <asp:TextBox ID="PhoneNumberCousinOneTB" runat="server" CssClass="form-control" placeholder="أدخل رقم الهاتف أو الجوال للقريب الأول"
                                required></asp:TextBox>
                        </div>
                        <div class="mb-1 col-xl-6 col-sm-6">
                            <label for="Phone_Number_Cousin_2" class="form-label">رقم جوال القريب الثاني</label>
                            <asp:TextBox ID="PhoneNumberCousinTwoTB" runat="server" CssClass="form-control" placeholder="أدخل رقم الهاتف أو جوال القريب الثاني"
                                required></asp:TextBox>
                        </div>
                    </div>
                    <hr />
                    <div class="row ">
                        <div class="" align="center">
                            &nbsp;<asp:Button ID="SendBT" runat="server" class="btn btn-primary" Text="إرسال"
                                OnClick="SendBT_Click" OnClientClick="return upDate(this)" />
                            <asp:Button runat="server" class="btn btn-dark" PostBackUrl="~/Main.aspx" Text="عودة"
                                ID="BackBT" CausesValidation="False"
                                UseSubmitBehavior="False"  />
                        </div>
                    </div>
            </div>
            </form>
        </div>
    </div>

    <script src="js/bootstrap.min.js"></script>
</asp:Content>
