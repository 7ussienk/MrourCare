<%@ Page Title="اعداد الحساب" Language="C#" AutoEventWireup="true" CodeBehind="UpdateAccountManagement.aspx.cs"
    Inherits="WebApplication3.UpdateAccountManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <link href="Style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="font-awesome/all.min.css" rel="stylesheet" />
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
</head>
<body>
    <script src="css/sweet.js"></script>
    <form id="form1" runat="server">
        <div class="container mt-3" style="text-align: right;" dir="rtl">
            <div class="card shadow-lg p-3 mb-5 bg-white rounded">
                <div class="card-body">
                    <div style="background: #C0C0C0; width: 100%; border-radius: 10px">
                        <h2 class=" mb-3  text-center h1">تعديل معلومات الحساب</h2>
                    </div>

                    <div class="row d-flex justify-content-center " align="right">
                        <div class="col-lg-8 p-0" dir="rtl">
                            <h2 class=" fw-bold mb-5 text-center" style="margin-top: 100px;"></h2>



                            <div class="row">
                                <div class="col-md-12 mt-3 mb-3">
                                    <asp:DropDownList runat="server" ID="ddlOptions" CssClass="btn btn-warning " EnableTheming="True"
                                        ValidateRequestMode="Disabled" AutoPostBack="True" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                                        <asp:ListItem>انقر للتعديل</asp:ListItem>
                                        <asp:ListItem Text="تعديل كلمة المرور" Value="1"></asp:ListItem>

                                        <asp:ListItem Text=" تعديل رقم الهـاتف" Value="3"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12 mt-3 mb-5">
                                    <div class="form-outline">
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>

                                        <asp:TextBox CssClass="form-control" ID="txtpass" runat="server" required Visible="False"></asp:TextBox>
                                    </div>

                                </div>

                            </div>



                            <hr class="divider-horizontal-blurry" />






                            <!-- Submit button -->

                            <div id="alert_suc" runat="server" class="alert alert-success mt-3" role="alert"
                                visible="false">
                                <asp:Label class="mb-5" ID="Label1" runat="server" Text=""></asp:Label>
                            </div>

                            <div id="alert_dan" runat="server" class="alert alert-danger  mt-3" visible="false"
                                role="alert">
                                <asp:Label class="mb-5" ID="Label2" runat="server" Text=""></asp:Label>
                            </div>

                            <br />

                            <div class="mb-5" align="center">
                                <asp:Button ID="btnsign1" runat="server" Text="تعديل"
                                    class="btn btn-lg btn-primary px-4" OnClick="btnsign1_Click" OnClientClick="return upDate(this)" />

                                <asp:Button ID="Button2" runat="server" Text="رجوع"
                                    class="btn btn-lg btn-secondary px-4" CausesValidation="False" UseSubmitBehavior="False"
                                    PostBackUrl="~/Main.aspx" />


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="js/bootstrap.min.js"></script>
    </form>
</body>
</html>
