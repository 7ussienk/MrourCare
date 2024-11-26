<%@ Page Title="تدقيق العمليات" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Operations.aspx.cs" Inherits="WebApplication3.Operations" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Operations.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <script src="js/bootstrap.min.js"></script>
        <div class="card mt-3 border-5">
            <div class="card-header text-center h5 bg-elegant text-white">
                <b>تدقيق العمليات</b>
            </div>
            <div class="card-body ">
                <div class="row" dir="rtl">
                    <div class="col-lg-12 card-margin ">
                        <div class="card search-form">
                            <div class="card-body p-0 ">
                                <form id="search-form">
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="row no-gutters">
                                                <div class="col-lg-3  col-sm-4 p-0">
                                                    <asp:DropDownList ID="orders" CssClass="form-control text-center" 
                                                        runat="server" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="orders_SelectedIndexChanged">
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-dark" Value="0">عرض كل الطلبات</asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-secondary" Value="1">طلبات تقديم رخصة </asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-secondary" Value="2">طلبات تجديد رخصة</asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-secondary" Value="3">طلبات نقل ملكية آلية.</asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-secondary " Value="4">طلبات صرف رقم جديد </asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-dark" Value="5">كل طلبات تقديم رخصة</asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-dark" Value="6">كل طلبات تجديد رخصة </asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-dark" Value="7">كل طلبات نقل ملكية آلية </asp:ListItem>
                                                        <asp:ListItem style="font-size: 16px;" class="text-light bg-dark" Value="8">كل طلبات صرف رقم جديد </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-8 c col-sm-6 p-0">
                                                    <asp:TextBox ID="searchBox" placeholder="بحث عن طريق أسم .." 
                                                        class="form-control" runat="server" OnDataBinding="btnSubmit_Click"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1 col-sm-2 p-3">
                                                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-base" 
                                                        OnClick="btnSubmit_Click">
                                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search">
                                                            <circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="row"  >
                    <div class="col-lg-12">
                        <div class="main-box clearfix ">
                            
                            <div class="table-responsive">
                                <table class="table user-list" dir="rtl">
                                    <thead>
                                        <tr>
                                            <!-- &nbsp;-->
                                            <th class="text-center"><span>رقم</span></th>
                                            <th class="text-center"><span>أسم مقدم الطلب</span></th>
                                            <th class="text-center"><span>نوع الطلب</span></th>
                                            <th class="text-center"><span>حالة الطلب</span></th>
                                            <th class="text-center "><span>بواسطة المستخدم</span></th>
                                            <th class="text-center "><span>أدوات</span></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="myListView" runat="server" PageSize="4">
                                            <ItemTemplate>

                                                <tr>
                                                    <td style="width: 1%; text-align: center;">
                                                        <span><%# Container.DataItemIndex + 1 %></span>
                                                    </td>
                                                    <td style="width: 35%;">
                                                        <a href="#" class="user-link text-decoration-none h5"><%# Eval("order_name") %></a>
                                                        <span class="user-subhead"><%#"-تاريخ التقديم :"+ Eval("order_date") %></span>
                                                    </td>
                                                    <td style="width: 10%" align="center">
                                                        <a href="#" class="user-link text-decoration-none"><%# Eval("order_Type") %></a>
                                                        <span class="user-subhead"><%# " مُعرف الطلب :"+Eval("order_id") %></span>
                                                    </td>
                                                    <td class="text-center" style="width: 7%;">
                                                        <b><span class='<%# GetOrderStatusCssClass(Eval("order_status").ToString()) %>'>
                                                            <%# Eval("order_status") %>   </b>
                                                        </span>
                                                         <b><span class="text-secondary" id="span_" runat="server" visible='<%# GetAdminmail(Eval("order_status").ToString()) %>'>
                                                             <%# Eval("EmailofAdmin") %>   </b>
                                                        </span>
                                                    </td>
                                                    <td style="width: 20%;">
                                                        <span class="user-subhead h5"><%# Eval("user_name") %></span>
                                                        <a href="#"><%# Eval("Emailofuser") %></a>
                                                    </td>
                                                    <td style="width: 10%;" align="center">
                                                        <div class=" menu ">
                                                            <div class="row">
                                                                <div class="col-sm-6">
                                                                    <asp:LinkButton ID="view" runat="server" href='<%# GetViewLink(Eval("order_Type").ToString(),Eval("order_id").ToString()) %>'
                                                                        CssClass="text-decoration-none py-2 d-block" ToolTip="عرض الوثيقة" ForeColor="Black"
                                                                        Target="_blank"> <i class="fa-solid fa-eye"></i> </asp:LinkButton>

                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <asp:LinkButton ID="print" runat="server" CssClass="text-decoration-none py-2 d-block"
                                                                        ForeColor="Black" ToolTip="طباعة الوثيقة" OnClick="Print_Click"><i class="fa-solid fa-print"></i></asp:LinkButton>

                                                                    <asp:Label ID="order_id" runat="server" Visible="false" Text='<%# Eval("order_id") %>'></asp:Label>
                                                                    <asp:Label ID="order_Type" runat="server" Visible="false" Text='<%# Eval("order_Type") %>'></asp:Label>
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
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="myListView" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                                Visible="False" />
                            <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NextPageText="التالي"
                                NumericButtonCssClass="btn btn-dark" PreviousPageText="السابق" NextPreviousButtonCssClass="btn btn-dark" />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                                ShowPreviousPageButton="False" Visible="False" />
                        </Fields>
                    </asp:DataPager>
                </center>
                <asp:Label ID="sql" runat="server" Text="select Property_ip as 'order_id',Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type',Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name' from Property "
                    Visible="false"></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
