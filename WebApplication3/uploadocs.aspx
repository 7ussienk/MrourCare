<%@ Page Title="رفع المستندات" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="uploadocs.aspx.cs" Inherits="WebApplication3.uploadocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/sweetalert2.min.css" rel="stylesheet" />

    <style>
        @font-face {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf")
        }

       

        p {
            font-size: 33px;
            text-align: center
        }

        body {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
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
          title: "هل انت متاكد من الرجوع الى الرئيسية؟",
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
              Swal.fire('لم يتم رفع الصور', '', 'info')
          }
      });
      obj.ele = btnDelete;
      return false;
  }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="css/sweet.js"></script>
    <script src="js/bootstrap.min.js">   </script>
    <div class="container mt-3" style="text-align: right;" dir="rtl">
        <div class="card shadow-lg p-3 mb-5 bg-white rounded">
            <div class="card-body">
                <div style="background: #C0C0C0; width: 100%; border-radius: 10px">
                    <h2 class=" mb-3  text-center h1">المتطلبات الإضافية</h2>
                </div>

                <div dir="rtl" class="card-body py-5 px-md-5 rounded">
                    <div class="row">


                        <h5 class="">نوع الهوية</h5>

                        <div class="col-lg-4 col-sm-4 mb-2 ">
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input " Style="border: none; background: none;" ID="radiocard" runat="server" GroupName="ids" Checked="True" />
                                <label class="form-check-label" for="radiocard">بطاقة شخصية</label>
                            </div>

                            <div class="form-check">
                                <asp:RadioButton class="form-check-input " Style="border: none; background: none;" ID="radiopassport" runat="server" GroupName="ids" />
                                <label class="form-check-label" for="radiopassport">جواز سفر</label>

                            </div>
                        </div>
                        <div class="form-outline col-lg-8  col-sm-8 ">
                            <asp:FileUpload ID="File1" CssClass="form-control" runat="server" accept="image/jpg,image/png" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4 ">
                            <div class="form-outline">
                                <label class="form-label" for="File4">صورة شخصية</label>
                                <asp:FileUpload ID="File4" CssClass="form-control" runat="server" accept="image/jpg,image/png" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4 ">
                            <div class="form-outline" id="HIDE2" runat="server" visible="false">
                                <label class="form-label" for="File2">صورة من فحص الدم</label>
                                <asp:FileUpload ID="File2" CssClass="form-control" runat="server" accept="image/jpg,image/png" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4 ">
                            <div class="form-outline" id="HIDE1" runat="server" visible="false">
                                <label class="form-label" for="File3">صورة من فحص النظر</label>
                                <asp:FileUpload ID="File3" CssClass="form-control" runat="server" accept="image/jpg,image/png" />
                            </div>
                        </div>

                        <div class="col-md-12 mb-4 ">
                            <div class="form-outline">
                                <asp:Label ID="Label1" runat="server" Text="ايدي المعامله هو :"></asp:Label>
                                <asp:Label ID="lblID" runat="server" Text=" "></asp:Label>

                            </div>
                        </div>
                        <div class="col-md-12 mb-4 ">
                            <div class="form-outline">
                                <asp:Label ID="Label3" runat="server" Text="نوع المعامله هو :"></asp:Label>
                                <asp:Label ID="lilType" runat="server" Text=" "></asp:Label>
                                
                                <br />
                                <div id="alert_dan" runat="server" class="alert alert-danger mt-3" role="alert" visible="false">
                                    <asp:Label ID="error_1" runat="server" Text=""><br /></asp:Label>

                                    <asp:Label ID="error_2" runat="server" Text=""><br /></asp:Label>

                                    <asp:Label ID="error_3" runat="server" Text=""><br /></asp:Label>

                                    <asp:Label ID="error_4" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="rrr">
                        </div>
                        <style>
                            .rrr {
                                width: 100%; /* تعيين العرض ليكون 100% من العرض المتاح */
                                height: 12px; /* تعيين الارتفاع لـ 2 بكسل */
                                background-color: #C0C0C0; /* تعيين لون الخط إلى #C0C0C0 */
                                border: none; /* إزالة الحدود */
                                margin-bottom: 10px;
                                border-radius: 10px
                            }
                        </style>
                       

                        <div align="center">
                            <asp:Button ID="SendBTNew" runat="server" class="btn btn-primary" Text="إرسال" OnClick="SendBTNew_Click1" />
                            <asp:Button ID="Button1" runat="server" class="btn btn-dark"  
                                Text="العودة الى الرئيسية" OnClientClick="return upDate(this)" 
                                OnClick="Button1_Click" />
                         


                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
