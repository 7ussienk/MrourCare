<%@ Page Title="مراجعة الحجوزات" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReviewTheDaysOfWeek.aspx.cs" Inherits="WebApplication3.ReviewTheDaysOfWeek" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @font-face {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf")
        }

        body {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
        }

        .bg-elegant {
            background-color: #2E2E2E !important
        }

        .border-5 {
            border-color: #2E2E2E !important
        }


        /* form sarch*/
        .search-form {
            width: 80%;
            margin: 0 auto;
            margin-top: 1rem;
        }

            .search-form input {
                height: 100%;
                background: transparent;
                border: 0;
                display: block;
                width: 100%;
                padding: 1rem;
                height: 100%;
                font-size: 1rem;
            }

            .search-form select {
                background: transparent;
                border: 0;
                padding: 1rem;
                height: 100%;
                font-size: 1rem;
            }

                .search-form select:focus {
                    border: 0;
                }

            .search-form button {
                height: 100%;
                width: 100%;
                font-size: 1rem;
            }

                .search-form button svg {
                    width: 24px;
                    height: 24px;
                }

        .search-body {
            margin-bottom: 1.5rem;
        }

            .search-body .search-filters .filter-list {
                margin-bottom: 1.3rem;
            }

                .search-body .search-filters .filter-list .title {
                    color: #3c4142;
                    margin-bottom: 1rem;
                }

                .search-body .search-filters .filter-list .filter-text {
                    color: #727686;
                }

            .search-body .search-result .result-header {
                margin-bottom: 2rem;
            }

                .search-body .search-result .result-header .records {
                    color: #3c4142;
                }

                .search-body .search-result .result-header .result-actions {
                    text-align: right;
                    display: flex;
                    align-items: center;
                    justify-content: space-between;
                }

                    .search-body .search-result .result-header .result-actions .result-sorting {
                        display: flex;
                        align-items: center;
                    }

                        .search-body .search-result .result-header .result-actions .result-sorting span {
                            flex-shrink: 0;
                            font-size: 0.8125rem;
                        }

                        .search-body .search-result .result-header .result-actions .result-sorting select {
                            color: #68CBD7;
                        }

                            .search-body .search-result .result-header .result-actions .result-sorting select option {
                                color: #3c4142;
                            }


        /* End form sarch*/


        .card-margin {
            margin-bottom: 1.875rem;
        }

        .card {
            border: 0;
            box-shadow: 0px 0px 10px 0px rgba(82, 63, 105, 0.1);
            -webkit-box-shadow: 0px 0px 10px 0px rgba(82, 63, 105, 0.1);
            -moz-box-shadow: 0px 0px 10px 0px rgba(82, 63, 105, 0.1);
            -ms-box-shadow: 0px 0px 10px 0px rgba(82, 63, 105, 0.1);
        }

        .card {
            position: relative;
            display: flex;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-color: #ffffff;
            background-clip: border-box;
            border: 1px solid #e6e4e9;
            border-radius: 8px;
        }

        /* USER LIST TABLE */
        /* USER LIST TABLE */
        .user-list {
            text-align: right;
        }

            .user-list tbody td > img {
                position: relative;
                max-width: 50px;
                float: left;
                margin-right: 15px;
            }

            .user-list tbody td .user-link {
                display: block;
                font-size: 1.25em;
                padding-top: 3px;
                margin-left: 0px;
            }

            .user-list tbody td .user-subhead {
                font-size: 0.875em;
                font-style: italic;
            }

        /* TABLES */
        .table {
            border-collapse: separate;
        }

        .table-hover > tbody > tr:hover > td,
        .table-hover > tbody > tr:hover > th {
            background-color: #eee;
        }

        .table thead > tr > th {
            border-bottom: 1px solid #C2C2C2;
            padding-bottom: 0;
        }

        .table tbody > tr > td {
            font-size: 0.875em;
            background: #f5f5f5;
            border-top: 10px solid #fff;
            vertical-align: middle;
            padding: 12px 8px;
        }

            .table tbody > tr > td:first-child,
            .table thead > tr > th:first-child {
                padding-left: 20px;
            }

        .table thead > tr > th span {
            border-bottom: 2px solid #C2C2C2;
            display: inline-block;
            padding: 0 5px;
            padding-bottom: 5px;
            font-weight: normal;
        }

        .table thead > tr > th > a span {
            color: #344644;
        }

            .table thead > tr > th > a span:after {
                content: "\f0dc";
                font-family: FontAwesome;
                font-style: normal;
                font-weight: normal;
                text-decoration: inherit;
                margin-left: 5px;
                font-size: 0.75em;
            }

        .table thead > tr > th > a.asc span:after {
            content: "\f0dd";
        }

        .table thead > tr > th > a.desc span:after {
            content: "\f0de";
        }

        .table thead > tr > th > a:hover span {
            text-decoration: none;
            color: #2bb6a3;
            border-color: #2bb6a3;
        }

        .table.table-hover tbody > tr > td {
            -webkit-transition: background-color 0.15s ease-in-out 0s;
            transition: background-color 0.15s ease-in-out 0s;
        }

        .table tbody tr td .call-type {
            display: block;
            font-size: 0.75em;
            text-align: center;
        }

        .table tbody tr td .first-line {
            line-height: 1.5;
            font-weight: 400;
            font-size: 1.125em;
        }

            .table tbody tr td .first-line span {
                font-size: 0.875em;
                color: #969696;
                font-weight: 300;
            }

        .table tbody tr td .second-line {
            font-size: 0.875em;
            line-height: 1.2;
        }

        .table a.table-link {
            margin: 0 5px;
            font-size: 1.125em;
        }

            .table a.table-link:hover {
                text-decoration: none;
                color: #2aa493;
            }

            .table a.table-link.danger {
                color: #fe635f;
            }

                .table a.table-link.danger:hover {
                    color: #dd504c;
                }

        .table-products tbody > tr > td {
            background: none;
            border: none;
            border-bottom: 1px solid #ebebeb;
            -webkit-transition: background-color 0.15s ease-in-out 0s;
            transition: background-color 0.15s ease-in-out 0s;
            position: relative;
        }

        .table-products tbody > tr:hover > td {
            text-decoration: none;
            background-color: #f6f6f6;
        }

        .table-products .name {
            display: block;
            font-weight: 600;
            padding-bottom: 7px;
        }

        .table-products .price {
            display: block;
            text-decoration: none;
            width: 50%;
            float: left;
            font-size: 0.875em;
        }

            .table-products .price > i {
                color: #8dc859;
            }

        .table-products .warranty {
            display: block;
            text-decoration: none;
            width: 50%;
            float: left;
            font-size: 0.875em;
        }

            .table-products .warranty > i {
                color: #f1c40f;
            }

        .table tbody > tr.table-line-fb > td {
            background-color: #9daccb;
            color: #262525;
        }

        .table tbody > tr.table-line-twitter > td {
            background-color: #9fccff;
            color: #262525;
        }

        .table tbody > tr.table-line-plus > td {
            background-color: #eea59c;
            color: #262525;
        }

        .table-stats .status-social-icon {
            font-size: 1.9em;
            vertical-align: bottom;
        }

        .table-stats .table-line-fb .status-social-icon {
            color: #556484;
        }

        .table-stats .table-line-twitter .status-social-icon {
            color: #5885b8;
        }

        .table-stats .table-line-plus .status-social-icon {
            color: #a75d54;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <script src="js/bootstrap.min.js"></script>
        <div class="card mt-3 border-5">
            <div class="card-header text-center h5 bg-elegant text-white">
                <b>مراجعة الطلبات اليومية || الاسبوعية</b>
            </div>
            <div class="card-body ">
                <div class="row" dir="rtl">
                    <div class="col-lg-12 card-margin ">
                        <div class="row">
                            <div class="col-12">
                                <div class="row no-gutters">
                                    <div class=" ">
                                        <asp:DropDownList CssClass="form-control text-center" ID="dropDays" runat="server" AutoPostBack="True" Font-Bold="True" OnSelectedIndexChanged="changeDay" EnableTheming="True" ValidateRequestMode="Disabled">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="main-box clearfix">
                            <div class="table-responsive">
                                <table class="table user-list" dir="rtl">
                                    <thead>
                                        <tr>
                                            <!-- &nbsp;-->
                                            <th class="text-center"><span>رقم</span></th>
                                            <th class="text-center"><span>أسم مقدم الطلب</span></th>
                                            <th class="text-center"><span>نوع الطلب</span></th>
                                            <th class="text-center"><span>ساعة الحجز</span></th>
                                            <th class="text-center"><span>تاربخ الحجز </span></th>
                                            <th class="text-center"><span>علامات الحضور </span></th>

                                            <asp:Label ID="sql" runat="server" Text="" Visible="false"></asp:Label>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="myListView" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 1%; text-align: center;">
                                                        <span><%# Container.DataItemIndex + 1 %></span>
                                                    </td>
                                                    <td style="width: 28%;">
                                                        
                                                        <a href="#" class='<%# name_class(Eval("order_status").ToString()) %>'><%# Eval("order_name") %></a>
                                                    </td>
                                                    <td style="width: 12%" align="center">
                                                        <a href="#" class="user-link text-decoration-none"><%# Eval("order_Type") %></a>
                                                    </td>
                                                    <td class="text-center" style="width: 12%;"></span> 
                                                        <a href="#" class="user-link text-decoration-none"><%# Eval("Hour") %></a>
                                                    </td>
                                                    <td class="text-center" style="width: 12%;">
                                                        <a href="#" class="user-link text-decoration-none"><%# Eval("BookDate") %></a>
                                                    </td>
                                                    <td style="width: 10%;" align="center">
                                                        <div class=" menu ">
                                                            <div class="row">
                                                                <div class="col-sm-6">
                                                                    <!-- order id - order type - order status -->
                                                                    <asp:Label ID="order_id" runat="server" Text='<%# Eval("order_id") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="order_type" runat="server" Text='<%# Eval("order_Type") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="order_status" runat="server" Text='<%# Eval("order_status") %>' Visible="false"></asp:Label>
                                                                    <asp:LinkButton ID="accept" runat="server"   CssClass="text-decoration-none py-2 d-block" ForeColor="Black"   OnClick="accept_Click"> <i class="fa-solid fa-check"></i></asp:LinkButton>
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    
                                                                    <asp:LinkButton ID="cancel" runat="server"   CssClass="text-decoration-none py-2 d-block" ForeColor="Black"   OnClick="cancel_Click"> <i class="fa-solid fa-x"></i> </asp:LinkButton>
                                                                   
                                                                </div>
                                                            </div>


                                                        </div>
                                                    </td>
                                                </tr>
                                                
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-footer">
                <center>
                    <asp:Label ID="day" runat="server" Text="Label" Visible="false"></asp:Label>
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="myListView" PageSize="9">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" Visible="False" />
                            <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NextPageText="التالي" NumericButtonCssClass="btn btn-dark" PreviousPageText="السابق" NextPreviousButtonCssClass="btn btn-dark" />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" Visible="False" />
                        </Fields>
                    </asp:DataPager>
                </center>
            </div>
        </div>
    </div>
</asp:Content>
