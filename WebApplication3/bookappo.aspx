<%@ Page Title="حجز الموعد" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="bookappo.aspx.cs" Inherits="WebApplication3.bookappo" %>


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
                title: "هل انت متاكد من اختيارك للساعة؟",
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
    <div class="container mt-3" style="text-align: right;" dir="rtl">
        <div class="card shadow-lg p-3 mb-5 bg-white rounded">
            <div class="card-body">
                <div class="hi">
                    <b>
                        <h2 class=" mb-3  text-center h1">تحديد يوم وتاريخ الحجز</h2>
                    </b>
                    <hr />
                </div>
                <form class="" dir="rtl">
                    <h3 class="mt-2 mb-3  h4" dir="rtl">التواريخ المتاحة</h3>

                    <div class="row">
                        <div class="mt-0 mb-0 col-md-12">
                            <asp:RadioButton ID="RadioButton1" GroupName="days" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged"
                                AutoPostBack="True" />
                            <asp:Label runat="server" CssClass=" " ID="txt1"></asp:Label>
                            <asp:Label runat="server" CssClass=" " ID="day1"> 2024/03/08</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server"
                                Enabled="False" Font-Bold="True" Font-Overline="True" Font-Strikeout="False"
                                Font-Underline="False" ForeColor="#006600">
                                <asp:ListItem>8:00</asp:ListItem>
                                <asp:ListItem>8:30</asp:ListItem>
                                <asp:ListItem>9:00</asp:ListItem>
                                <asp:ListItem>9:30</asp:ListItem>
                                <asp:ListItem>10:00</asp:ListItem>
                                <asp:ListItem>10:30</asp:ListItem>
                                <asp:ListItem>11:00</asp:ListItem>
                                <asp:ListItem>11:30</asp:ListItem>
                                <asp:ListItem>12:00</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="mt-0 mb-0 col-md-12">
                            <asp:RadioButton ID="RadioButton2" GroupName="days" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged"
                                AutoPostBack="True" />
                            <asp:Label runat="server" CssClass=" " ID="txt2"></asp:Label>
                            <asp:Label ID="day2" runat="server" Text="Label"></asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" Enabled="False">
                                <asp:ListItem>8:00</asp:ListItem>
                                <asp:ListItem>8:30</asp:ListItem>
                                <asp:ListItem>9:00</asp:ListItem>
                                <asp:ListItem>9:30</asp:ListItem>
                                <asp:ListItem>10:00</asp:ListItem>
                                <asp:ListItem>10:30</asp:ListItem>
                                <asp:ListItem>11:00</asp:ListItem>
                                <asp:ListItem>11:30</asp:ListItem>
                                <asp:ListItem>12:00</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="mt-0 mb-0 col-md-12">
                            <asp:RadioButton ID="RadioButton3" GroupName="days" runat="server" OnCheckedChanged="RadioButton3_CheckedChanged"
                                AutoPostBack="True" />
                            <asp:Label runat="server" CssClass=" " ID="txt3"></asp:Label>
                            <asp:Label runat="server" CssClass=" mb-2" ID="day3">yyyy/mm/dd</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" Enabled="False">
                                <asp:ListItem>8:00</asp:ListItem>
                                <asp:ListItem>8:30</asp:ListItem>
                                <asp:ListItem>9:00</asp:ListItem>
                                <asp:ListItem>9:30</asp:ListItem>
                                <asp:ListItem>10:00</asp:ListItem>
                                <asp:ListItem>10:30</asp:ListItem>
                                <asp:ListItem>11:00</asp:ListItem>
                                <asp:ListItem>11:30</asp:ListItem>
                                <asp:ListItem>12:00</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="mt-0 mb-0 col-md-12">
                            <asp:RadioButton ID="RadioButton4" GroupName="days" runat="server" OnCheckedChanged="RadioButton4_CheckedChanged"
                                AutoPostBack="True" />
                            <asp:Label runat="server" CssClass=" " ID="txt4"></asp:Label>
                            <asp:Label runat="server" ID="day4">yyyy/mm/dd</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" Enabled="False">
                                <asp:ListItem>8:00</asp:ListItem>
                                <asp:ListItem>8:30</asp:ListItem>
                                <asp:ListItem>9:00</asp:ListItem>
                                <asp:ListItem>9:30</asp:ListItem>
                                <asp:ListItem>10:00</asp:ListItem>
                                <asp:ListItem>10:30</asp:ListItem>
                                <asp:ListItem>11:00</asp:ListItem>
                                <asp:ListItem>11:30</asp:ListItem>
                                <asp:ListItem>12:00</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="mt-0 mb-0 col-md-12">
                            <asp:RadioButton ID="RadioButton5" GroupName="days" runat="server" OnCheckedChanged="RadioButton5_CheckedChanged"
                                AutoPostBack="True" />
                            <asp:Label runat="server" CssClass=" " ID="txt5"></asp:Label>
                            <asp:Label runat="server" ID="day5">yyyy/mm/dd</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList5" runat="server" Enabled="False">
                                <asp:ListItem>8:00</asp:ListItem>
                                <asp:ListItem>8:30</asp:ListItem>
                                <asp:ListItem>9:00</asp:ListItem>
                                <asp:ListItem>9:30</asp:ListItem>
                                <asp:ListItem>10:00</asp:ListItem>
                                <asp:ListItem>10:30</asp:ListItem>
                                <asp:ListItem>11:00</asp:ListItem>
                                <asp:ListItem>11:30</asp:ListItem>
                                <asp:ListItem>12:00</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <hr />
                    <hr />
                    <div class="row ">
                        <div class="" align="center">
                            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="إرسال" OnClick="Button1_Click"
                                OnClientClick="return upDate(this)" />
                            <asp:Button ID="back" runat="server" class="btn btn-dark" Text="عودة" OnClick="back_Click" />
                        </div>
                    </div>
            </div>
            </form>
        </div>
    </div>

    <script src="js/bootstrap.min.js"></script>
</asp:Content>

