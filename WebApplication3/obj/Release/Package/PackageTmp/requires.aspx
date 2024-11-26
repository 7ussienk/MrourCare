<%@ Page Title="الاستعلامات" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="requires.aspx.cs" Inherits="WebApplication3.requires" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />

    <link href="css/bootrap4.css" rel="stylesheet" />
    <style>


        body {
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            font-family: "alfont_com_Cairo-Regular";
            background-color: #000000;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <script src="js/bootstrap.min.js"></script>
        <div class="container-fluid mt-3" style="text-align: right;" dir="rtl">
            <div class="card shadow-lg p-3  bg-white rounded">
                <div class="card-body ">
                    <div class=" text-center h4 " style="margin-top: -20px; margin-bottom: 40px">
                        <b>صفحة الاستعلامات</b>
                    </div>
                    <div class="row">
                        <asp:ListView runat="server" ID="myListView">
                            <ItemTemplate>
                                <div class="col-xl-2 col-sm-4 mb-2">
                                    <div class="card">
                                        <div class="card-header text-center">

                                            <asp:Label ID="lblOrderType" Font-Bold="true" runat="server" CssClass="h5" Text='<%# "طلب " + Eval("order_Type") %>'></asp:Label>
                                            <asp:Label ID="order_type" Font-Bold="true" runat="server" CssClass="h5" Text='<%#Eval("order_Type") %>'
                                                Visible="false"></asp:Label>
                                        </div>
                                        <div class="card-body text-center">
                                            <h6 class="card-title" style="height: 60px">
                                                <span><b>اسم مقدم الطلب: </b></span>
                                                <br />
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("order_name") %>'></asp:Label>
                                            </h6>
                                            <hr />
                                            <h6 class="card-title mb-0">
                                                <span><b>رقم الطلب: </b></span>
                                                <br />
                                                <asp:Label ID="lblOrderNum" runat="server" Text='<%# Eval("order_id") %>'></asp:Label>
                                            </h6>
                                            <hr />
                                            <h6 class="card-title">
                                                <span><b>تاريخ التقديم :</b></span><br />
                                                <asp:Label ID="lblDateOfOrder" runat="server" Text='<%# Eval("order_date") %>'></asp:Label>
                                            </h6>
                                        </div>
                                        <div class="card-footer " style="height:75px;">
                                            <!-- <span><%# Eval("order_status") %></span>  -->
                                            <center>
                                                <asp:Button ID="Unaccepted" CssClass="btn btn-danger" runat="server" Text="مرفوض"
                                                    Enabled="false" Visible='<%# Eval("order_status").ToString() == "مرفوض" %>' />

                                                <asp:Button ID="Under_review" CssClass="btn btn-blue-grey" runat="server" Text="قيد المراجعة"
                                                    Enabled="false" Visible='<%# Eval("order_status").ToString() == "قيد المراجعة" %>' />


                                                <asp:Button ID="Accepted" CssClass="btn btn-warning text-danger" runat="server" Text='<%# Eval("order_status")%>'
                                                    Visible='<%#   Eval("order_status").ToString() == "متأخر" %>'
                                                    OnClick="Accepted_Click" />

                                                <asp:Button ID="Button2" CssClass="btn btn-primary "  runat="server" Text='<%# Eval("order_status")%>'
                                                    Visible='<%# Eval("order_status").ToString() == "مقبول"  %>'
                                                    OnClick="Accepted_Click" />

                                                 
                                                <asp:Button ID="Button3" CssClass="btn btn-dark-green" runat="server" Text="مكتمل"
                                                    Enabled="false" visible='<%# Eval("order_status").ToString() == "مكتمل" %>' />


                                                <asp:Button ID="Edit" CssClass="btn btn-brown " runat="server" Text="تعديل" Visible='<%# Eval("order_status").ToString() == "تعديل" %>'
                                                    OnClick="Updateing" />
                                                <p id="par" runat="server" cssclass="alert-danger " style="font-size: 17px; margin-bottom: -10px"
                                                    visible='<%# mesg(Eval("order_status").ToString()) %>'>
                                                    <%# Eval("order_status").ToString() %>
                                                </p>

                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>

                </div>
            </div>
        </div>
    </body>



</asp:Content>
