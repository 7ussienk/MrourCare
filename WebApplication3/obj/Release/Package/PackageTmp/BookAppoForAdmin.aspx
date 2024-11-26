<%@ Page Title="إدارة المواعيد" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookAppoForAdmin.aspx.cs" Inherits="WebApplication3.BookAppoForAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="Style.css" rel="stylesheet" />
    <style>
        body {
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            font-family: "alfont_com_Cairo-Regular";
        }

        body {
         
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3" style="text-align: right;" dir="rtl">

        <div class="card shadow-lg p-3 mb-5 bg-white rounded">
            <div class="card-body">
                <div class="hi">
                    <h2 class=" mb-3  text-center h1">قائمة تعديل الاوقات </h2>
                </div>
                <form class="" dir="rtl">
                    
                 
                    <h3 class="mt-2 mb-5  h4" dir="rtl">التواريخ المتاحة</h3>
                    <div class="row mt-3 ">
                        <div class="mt-0 mb-0 col-xl-8 col-sm-6">

                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                            <asp:Label runat="server" CssClass=" " ID="Label1"></asp:Label>
                            <asp:Label runat="server" CssClass=" " ID="day1"> 2024/03/08</asp:Label>

                            <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" Enabled="True">
                            </asp:DropDownList>
                        </div>
                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button2" runat="server" Text="تعطيل الساعة" OnClick="Button1_Click" />
                        </div>


                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button7" runat="server" 
                                Text="تعطيل اليوم" OnClick="btn_day1" />
                        </div>


                    </div>

                    <hr />
                    <div class="row">
                        <div class="mt-0 mb-0 col-xl-8 col-sm-6">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                            <asp:Label runat="server" CssClass=" " ID="Label2"></asp:Label>
                            <asp:Label runat="server" for="full-name" ID="day2">2024/03/10</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" Enabled="True"></asp:DropDownList>
                        </div>
                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button3" runat="server" Text="تعطيل الساعة" OnClick="Button2_Click" />
                        </div>


                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button8" runat="server" 
                                Text="تعطيل اليوم" OnClick="btn2" />
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class=" col-xl-8 col-sm-6">
                            <asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="CheckBox3_CheckedChanged" AutoPostBack="True" />
                            <asp:Label runat="server" CssClass=" " ID="Label3"></asp:Label>
                            <asp:Label runat="server" for="full-name" CssClass="mb-2" ID="day3">yyyy/mm/dd</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" Enabled="True">
                                <asp:ListItem>8:00</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button4" runat="server" Text="تعطيل الساعة" OnClick="Button3_Click" />
                        </div>


                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button9" runat="server" 
                                Text="تعطيل اليوم" OnClick="btn3" />
                        </div>
                    </div>

                    <hr />
                    <div class="row">
                        <div class="mt-0 mb-0 col-xl-8 col-sm-6">
                            <asp:CheckBox ID="CheckBox4" runat="server" CssClass="" AutoPostBack="True" OnCheckedChanged="CheckBox4_CheckedChanged" />
                            <asp:Label runat="server" CssClass=" " ID="Label4"></asp:Label>
                            <asp:Label runat="server" for="full-name" ID="day4">yyyy/mm/dd</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" Enabled="True">
                                <asp:ListItem>8:00</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button5" runat="server" Text="تعطيل الساعة" OnClick="Button4_Click" />
                        </div>


                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control " ID="Button10" runat="server" 
                                Text="تعطيل اليوم" OnClick="btn4" />
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="mt-0 mb-0 col-xl-8 col-sm-6">
                            <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" />

                            <asp:Label runat="server" CssClass=" " ID="Label5"></asp:Label>
                            <asp:Label runat="server" for="full-name" ID="day5">yyyy/mm/dd</asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList5" runat="server" Enabled="True">
                                <asp:ListItem>8:00</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button6" runat="server" Text="تعطيل الساعة" OnClick="Button5_Click" />
                        </div>


                        <div class="mt-4 mb-4 col-xl-2 col-sm-3">
                            <asp:Button CssClass="form-control" ID="Button11" runat="server" 
                                Text="تعطيل اليوم" OnClick="btn5" />
                        </div>
                    </div>
                    <div class="row ">
                        <div class="col-sm-4">
                            <div class="p-3 mb-2 bg-success text-white">اللون الاخضر : ان الموعد غير محجوز وغيرمعطل.
                            </div>
                        </div>
                        <div class="col-sm-4 mb-3">
                            <div class="p-3 mb-2 bg-primary text-white">اللون الازرق : ان الموعد محجوز ولا يمكن
                                تعطيله.</div>
                        </div>
                        <div class="col-sm-4">
                            <div class="p-3 mb-2 bg-danger text-white">اللون الأحمر : دليل  على ان الموعد اجازة.
                            </div>
                        </div>
                    </div>
                    <div class="row ">
                        <div class="  col-xl-12 col-sm-12">
                        <center><asp:Label ID="alter" runat="server" CssClass="alert-danger" Text="" Style="width: 100%;"></asp:Label></center>
                    </div>                   </div>
                    <hr />
                    <div class="row ">
                     
                    </div>

                </form>
            </div>
        </div>
    </div>
    <script src="js/bootstrap.min.js"></script>


</asp:Content>
