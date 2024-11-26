<%@ Page Title="إعدادات الحساب" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AccountManagement.aspx.cs" Inherits="WebApplication3.AccountManagement" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootrap4.css" rel="stylesheet" />
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

        body {
            background: #000e29;
        }
    </style>
    <style>
        .career-form {
            background-color: #4e63d7;
            border-radius: 5px;
            padding: 0 16px;
        }

            .career-form .form-control {
                background-color: rgba(255, 255, 255, 0.2);
                border: 0;
                padding: 12px 15px;
                color: #fff;
            }

                .career-form .form-control::-webkit-input-placeholder {
                    /* Chrome/Opera/Safari */
                    color: #fff;
                }

                .career-form .form-control::-moz-placeholder {
                    /* Firefox 19+ */
                    color: #fff;
                }

                .career-form .form-control:-ms-input-placeholder {
                    /* IE 10+ */
                    color: #fff;
                }

                .career-form .form-control:-moz-placeholder {
                    /* Firefox 18- */
                    color: #fff;
                }

            .career-form .custom-select {
                background-color: rgba(255, 255, 255, 0.2);
                border: 0;
                padding: 12px 15px;
                color: #fff;
                width: 100%;
                border-radius: 5px;
                text-align: left;
                height: auto;
                background-image: none;
            }

                .career-form .custom-select:focus {
                    -webkit-box-shadow: none;
                    box-shadow: none;
                }

            .career-form .select-container {
                position: relative;
            }

                .career-form .select-container:before {
                    position: absolute;
                    right: 15px;
                    top: calc(50% - 14px);
                    font-size: 18px;
                    color: #ffffff;
                    content: '\F2F9';
                    font-family: "Material-Design-Iconic-Font";
                }

        .filter-result .job-box {
            -webkit-box-shadow: 0 0 35px 0 rgba(130, 130, 130, 0.2);
            box-shadow: 0 0 35px 0 rgba(130, 130, 130, 0.2);
            border-radius: 10px;
            padding: 10px 35px;
        }

        ul {
            list-style: none;
        }

        .list-disk li {
            list-style: none;
            margin-bottom: 12px;
        }

            .list-disk li:last-child {
                margin-bottom: 0;
            }

        .job-box .img-holder {
            height: 44px;
            width: 44px;
            background-color: #2E2E2E !important;
            color: #fff;
            font-size: 22px;
            font-weight: 700;
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -webkit-box-pack: center;
            -ms-flex-pack: center;
            justify-content: center;
            -webkit-box-align: center;
            -ms-flex-align: center;
            align-items: center;
            border-radius: 65px;
        }

        .career-title {
            background-color: #4e63d7;
            color: #fff;
            padding: 15px;
            text-align: center;
            border-radius: 10px 10px 0 0;
            background-image: -webkit-gradient(linear, left top, right top, from(rgba(78, 99, 215, 0.9)), to(#5a85dd));
            background-image: linear-gradient(to right, rgba(78, 99, 215, 0.9) 0%, #5a85dd 100%);
        }

        .job-overview {
            -webkit-box-shadow: 0 0 35px 0 rgba(130, 130, 130, 0.2);
            box-shadow: 0 0 35px 0 rgba(130, 130, 130, 0.2);
            border-radius: 10px;
        }

        @media (min-width: 992px) {
            .job-overview {
                position: -webkit-sticky;
                position: sticky;
                top: 70px;
            }
        }

        .job-overview .job-detail ul {
            margin-bottom: 28px;
        }

            .job-overview .job-detail ul li {
                opacity: 0.75;
                font-weight: 600;
                margin-bottom: 15px;
            }

                .job-overview .job-detail ul li i {
                    font-size: 20px;
                    position: relative;
                    top: 1px;
                }

        .job-overview .overview-bottom,
        .job-overview .overview-top {
            padding: 35px;
        }

        .job-content ul li {
            font-weight: 600;
            opacity: 0.75;
            border-bottom: 1px solid #ccc;
            padding: 10px 5px;
        }

        @media (min-width: 768px) {
            .job-content ul li {
                border-bottom: 0;
                padding: 0;
            }
        }

        .job-content ul li i {
            font-size: 20px;
            position: relative;
            top: 1px;
        }

        .mb-30 {
            margin-bottom: 30px;
        }
    </style>
    <script>
        var obj = { status: false, ele: null };
        function upDate(btnDelete, user_name) {
            if (obj.status) {
                obj.status = false;
                return true;
            };
            Swal.fire({
                title: "هل تريد تعديل صلاحية؟",
                text: user_name,
                icon: "question",
                iconHtml: "؟",
                confirmButtonText: "نعم",
                cancelButtonText: "لا",
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
    <script src="js/bootstrap.min.js"></script>
    <div class="container-fluid mt-3" style="text-align: right;" dir="rtl">
        <div class="card mt-3 h6 text-center ">
            <div class="card-header  bg-elegant ">
                <b class="h3 text-white">تحكم بعضويات مستخدمين مرور كير </b>
            </div>
            <div class="card-body">
                <div class="row  justify-content-center">

                    <div class="card mb-4 col-sm-12 bg-elegant">
                        <divlass="card-body">
                            <div class="row">
                                <div class="col-sm-7">
                                    <asp:LinkButton ID="bnt_Show_all" CssClass="btn btn-unique col-sm" runat="server" OnClick="bnt_Show_all_Click"><i class="fa-solid fa-user-gear fa-lg"></i><i class="mr-2 ">عرض جميع المستخدمين</i></asp:LinkButton>
                                    <asp:LinkButton ID="btn_Emp" CssClass="btn btn-deep-purple col-sm" runat="server" class="btn btn-deep-purple" OnClick="btn_Emp_Click"><i class="fa-solid fa-user-gear fa-lg"></i><i class="mr-2 ">عرض جميع الموظفين</i></asp:LinkButton>
                                    <asp:LinkButton ID="btn_Mang" CssClass="btn btn-brown col-sm" runat="server" class="btn btn-brown" OnClick="btn_Mang_Click"><i class="fa-solid fa-user-gear fa-xl "></i><i class="mr-2">عرض جميع الاداريين</i></asp:LinkButton>

                                </div>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="searchBox" CssClass="form-control text-white col-sm-2" runat="server" placeholder="أدخل أسم أو ايميل العضو."></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:LinkButton ID="ByName" CssClass="btn btn-light-blue col-sm" runat="server" class="  btn-light-blue" OnClick="ByName_Click"> <i class="fa fa-angle-double-right fa-lg "></i><i class="mr-2">بالأسم</i></asp:LinkButton>
                                    <asp:LinkButton ID="ByEmail" CssClass="btn btn-light-green col-sm" runat="server" class=" btn-light-green" OnClick="ByEmail_Click"> <i class="fa fa-angle-double-right fa-lg ml-1"></i><i class="">بالايميل</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                </div>
                <div class="row">
                    <asp:ListView ID="ListView1" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-12 col-sm-12 ">
                                <div class="career-search mb-2">
                                    <div class="">


                                        <div class="filter-result ">
                                            <div class="job-box d-md-flex align-items-center justify-content-between mb-0">
                                                <div class="justify-content-end d-md-flex align-items-center flex-wrap">
                                                    <div class="img-holder mr-md-4 mb-md-0 mb-4 mx-auto mx-md-0 d-md-none d-lg-flex bg-elegant">
                                                        <i class="fa-solid fa-user"></i>

                                                    </div>

                                                    <div class="job-content ">
                                                        <b>
                                                            <h2 class="h5 m-3  text-capitalize" style="">
                                                                <%# "    "+ Eval("Name") %>
                                                            </h2>
                                                        </b>


                                                        <ul class="d-md-flex flex-wrap text-capitalize ff-open-sans">

                                                            <li class="mr-md-4">
                                                                <i class="fa-solid fa-credit-card"></i>
                                                                <i class="zmdi zmdi-pin mr-1"></i><%# Eval("Identity_type") %> <%# " : " + Eval("Identity_card") %>
                                                            </li>
                                                            <li class="mr-md-4">
                                                                <i class="fa-solid fa-mobile-screen"></i>
                                                                <i class="mr-1"></i><%# "رقم الهاتف : " + Eval("Phone") %>
                                                            </li>

                                                            <li class="mr-md-4">
                                                                <i class="fa-solid fa-envelope"></i>
                                                                <asp:Label ID="Label3" runat="server" CssClass="mr-1" Text='<%#"ايميل : " + Eval("Email") %>'></asp:Label>
                                                            </li>
                                                            <li class="mr-md-4">
                                                                <i class="fa-solid fa-user-ninja"></i>
                                                                <asp:Label ID="power" runat="server" CssClass="mr-1" Text='<%# " الصلاحيات: " + (Eval("Kind").ToString() == "0" ? "عضو" : Eval("Kind").ToString() == "1" ? "موظف" : Eval("Kind").ToString() == "2" ? "مدير" : "أدمن") %>'></asp:Label>
                                                            </li>

                                                        </ul>

                                                    </div>

                                                </div>
                                                <div class="job-right my-4 flex-shrink-0 "  >
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:DropDownList ID="DropDownList1" CssClass=" btn-elegant text-white " Style="height: 45px;
                                                                margin: -6px;"
                                                                runat="server" Visible='<%# power() %>'>
                                                                <asp:ListItem Value="-1">أختر الصلاحية</asp:ListItem>
                                                                <asp:ListItem Value="2">مدير</asp:ListItem>
                                                                <asp:ListItem Value="1">موظف</asp:ListItem>
                                                                <asp:ListItem Value="0">عضو عادي</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Button ID="Button3" CssClass="btn d-block d-sm-inline-block btn-elegant " Style="height: 45px;
                                                                margin: 3px; margin-top: -1px"
                                                                runat="server" Text="تنفيذ" OnClick="btnUp_" Visible='<%# power() %>'
                                                                OnClientClick='<%# "return upDate(this, \"" + Eval("Name") + "\");" %>'
                                                                AutoPostBack="True" />
                                                            <asp:Label ID="IP" runat="server" Visible="false" Text='<%# Eval("IP") %>'></asp:Label>
                                                            <asp:Label ID="lblKind" runat="server" Visible="false" Text='<%# Eval("Kind") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblSuss" runat="server" Visible="false" CssClass="" ForeColor="Green" Style="margin-top: 10px" Text="تمت العملية بنجاح"></asp:Label>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:ListView>
                </div>


            </div>
            <div class="card-footer bg-elegant">
                <center>
                    <asp:Label ID="sql" runat="server" Visible="false" Text="SELECT * FROM Users"></asp:Label>
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="2">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" Visible="False" />
                            <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NextPageText="التالي" NumericButtonCssClass="btn btn-dark" PreviousPageText="السابق" NextPreviousButtonCssClass="btn btn-dark" />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" Visible="False" />
                        </Fields>
                    </asp:DataPager>
                </center>



            </div>
        </div>

    <div id="djdj" visible="false" class="card shadow-lg p-3 mb-5 bg-white rounded" runat="server">


        <script src="js/bootstrap.min.js"></script>
    </div>

    <div id="alert_dan" runat="server" class="alert alert-danger" visible="false" role="alert">
        <asp:Label class="mb-5" ID="Label2" CssClass="alert alert-danger" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
