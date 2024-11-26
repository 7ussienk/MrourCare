<%@ Page Title="" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs"Inherits="WebApplication3.SignUp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <link href="Style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="font-awesome/all.min.css" rel="stylesheet" />
    <style>
        @font-face {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf")
        }

        .centered-bottom {
            display: flex;
            justify-content: center;
            align-items: safe center;
            height: 10vh;
        }

        p {
            font-size: 33px;
            text-align: center
        }

        body {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            background-color: white;
        }

        .signup-image {
            order: 2;
        }

        .signup-form {
            order: 1;
        }

        @media (max-width: 767.98px) {
            .signup-image {
                order: 1;
            }

            .signup-form {
                order: 2;
            }
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container mt-3" style="text-align: right;" dir="rtl">
            <div class="card shadow-lg p-3 mb-5 bg-white rounded">
                <div class="card-body">
                    <div style="background: #C0C0C0; width: 100%; border-radius: 10px">
                        <h2 class=" mb-3  text-center h1">إنـــشـــاء حــســاب جــديــد</h2>
                    </div>

                    <div class="row">


                        <div class="row d-flex justify-content-center " align="right">
                            <div class="col-lg-8 p-0" dir="rtl">
                                <h2 class=" fw-bold mb-5 text-center" style="margin-top: 100px;"></h2>

                                <h4 class="text-end pb-2"></h4>

                                <div class="row">
                                    <div class="col-md-6-4 ">
                                        <div class="form-outline">
                                            <label class="form-label" for="form3Example2">الاسم الرباعي</label>
                                            <asp:TextBox CssClass="form-control" ID="tdd" oninput="filterCharacters1(this)" runat="server"
                                                required></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6-2">
                                        <div class="form-outline">
                                            <label class="form-label" for="form3Example2">رقم الهاتف</label>
                                            <asp:TextBox CssClass="form-control" oninput="filternumbers(this)" ID="txtphone"
                                                runat="server" onKeyPress="if(this.value.length==9) return false;"
                                                required></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <br>
                                <div class="row">
                                    <div class="col-md-6-2 ">
                                        <h5>نوع الهوية</h5>
                                        <div class="form-check">
                                            <asp:RadioButton class="form-check-input" Style="border: none; background: none;"
                                                ID="radiocard" runat="server" GroupName="ids" Checked OnCheckedChanged="radiocard_CheckedChanged"></asp:RadioButton>
                                            <label class="form-check-label" for="radiocard">بطاقة شخصية</label>
                                        </div>
                                        <div class="form-check">
                                            <asp:RadioButton class="form-check-input" Style="border: none; background: none;"
                                                ID="radiopassport" runat="server" GroupName="ids" OnCheckedChanged="radiocard_CheckedChanged"></asp:RadioButton>
                                            <label class="form-check-label" for="radiopassport">جواز سفر</label>
                                            <br>
                                            <br>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6-2  ">
                                        <div class="form-outline">
                                            <label class="form-label" for="form3Example2">رقم الهوية</label>
                                            <asp:TextBox CssClass="form-control" ID="txtidentity" runat="server" required oninput="filternumbers2(this)"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-6-2 ">
                                        <div class="form-outline">
                                            <label class="form-label" for="form3Example2">الايميل</label>
                                            <asp:TextBox ID="txtemail" CssClass="form-control" runat="server" TextMode="Email"
                                                oninput="filterCharacters3(this)"
                                                required></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6-2">
                                        <div class="form-outline">
                                            <label class="form-label" for="form3Example2">كلمـــة السر</label>
                                            <asp:TextBox CssClass="form-control" ID="txtpass" runat="server" required></asp:TextBox>
                                        </div>


                                    </div>


                                </div>


                                <hr class="divider-horizontal-blurry" />






                                <!-- Submit button -->

                                <div id="alert_suc" runat="server" class="alert alert-success mt-3" role="alert"
                                    visible="false">
                                    <asp:Label class="mb-5" ID="Label1" runat="server" Text=""></asp:Label>
                                </div>

                                <div id="alert_dan" runat="server" class="alert alert-danger mt-3" visible="false"
                                    role="alert">
                                    <asp:Label class="mb-5" ID="Label2" runat="server" Text=""></asp:Label>
                                </div>

                                <br />

                                <div class="mb-5" align="center">
                                    <asp:Button ID="btnsign" runat="server" Text="انشاء الحساب"
                                        class="btn btn-lg btn-primary px-4" OnClick="btnsign_Click" />

                                    <asp:Button ID="Button2" runat="server" Text="رجوع"
                                        class="btn btn-lg btn-secondary px-4" CausesValidation="False" UseSubmitBehavior="False"
                                        PostBackUrl="~/login.aspx" />
                                    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>

                                </div>
                                <!-- Modal -->
                                <div class="  ">
                                    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel"
                                        aria-hidden="true">
                                        <div class="modal-dialog  modal-dialog-scrollable">
                                            <div class="modal-content">
                                                <div class="modal-header" dir="ltr">
                                                    <button type="button" class="btn-close " data-bs-dismiss="modal"
                                                        aria-label="Close">
                                                    </button>
                                                    <div>
                                                        <h1 class="" id="exampleModalLabel">الشروط والاحكام</h1>
                                                    </div>


                                                </div>
                                                <div class="modal-body">
                                                    <h1 class="modal-title fs-5 " id="exampleModalLabel">
                                                        <b>اذا تم الضغط على زر موافق فانت توافق على جميع الأحكام و الشروط : </b></h1>
                                                    <br />

                                                    -يجب على المستخدمين الالتزام بقواعد الاستخدام السليم للخدمات المقدمة. 
                                                            <br />
                                                    <br />
                                                    -عدم القيام بأي أنشطة غير قانونية أو تتعارض مع قوانين حقوق الملكية الفكرية أو سياسات
                                                    الخصوصية. 
                                                               <br />
                                                    <br />
                                                    -يجب على المستخدمين عدم التلاعب بالمستندات أو المعلومات المدخلة في الموقع، سواءً
                                                    كان ذلك بتغييرها أو تعديلها بطرق غير مصرح بها.
                                                            <br />
                                                    <br />
                                                    -يجب على المستخدمين استخدام الخدمات بشكل مشروع وفقًا للأغراض التي تم تصميمها لأجلها،
                                                    وعدم استخدامها في أي أغراض غير قانونية أو غير أخلاقية.  
                                                             <br />
                                                    <br />
                                                    -يجب أن يتم توضيح أنه في حالة اكتشاف أي انتهاك لشروط استخدام المستخدمين، ستتخذ التدابير
                                                    القانونية المناسبة للتعامل مع المستخدمين الذين يخترقون تلك الشروط.  
                                                            <br />
                                                    <br />

                                                    <h3><b>جمع المعلومات:  </b></h3>
                                                    <br />
                                                    -نقوم بجمع المعلومات الشخصية عندما تُقدم لنا طوعًا من قبل المستخدمين، مثل الاسم،
                                                    وعنوان البريد الإلكتروني، ومعلومات الاتصال  و المعلومات الشخصية.
                                                           <br />
                                                    <br />

                                                    -نستخدم المعلومات الشخصية لتقديم وتحسين خدماتنا.<br />
                                                    <br />
                                                    -قد نستخدم المعلومات للتواصل معك بشأن الخدمات التي تطلبها، وإرسال رسائل إخبارية
                                                    أو تحديثات، وتحليل البيانات والإحصائيات لتحسين خدماتنا.
                                                           <br />
                                                    <br />
                                                    -سيتم حفظ جميع المعلومات الشخصية و المستندات لدى مركز المرور سيئون ونخلي مسئوليتنا
                                                    من اي فقد أو تسريب لأي معلومات .
                                                            <br />
                                                    <br />
                                                    -لمركز المرور سيئون الأحقية بحذف اي حساب مشتبه أو غير لائق.<br />

                                                </div>
                                                <div class="centered-bottom">
                                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">حسنا</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mb-5" align="center">
                                <b><a href="#exampleModal" class="text-decoration-none" data-bs-toggle="modal">تطبيق
                                    الشروط والاحكام (اضغط للقراءة )      
                                </a></b>

                            </div>
                        </div>
                    </div>
                </div>
                <script src="js/bootstrap.min.js"></script>
                <script type="text/javascript">
                    //برمجة الاسم الرباعي
                    function filterCharacters1(input) {
                        var value = input.value;
                        var arabicRegex = /[\u0600-\u06FF\s]/;
                        var englishRegex = /[a-zA-Z]/;
                        var words = value.split(" ");
                        var digitCount = value.replace(/[^\d]/g, '').length;


                        if (words.length > 6) {
                            input.value = input.value.slice(0, input.value.length - 1);
                            var warningMessage = document.getElementById("warning-message");
                            if (warningMessage) {
                                warningMessage.textContent = "لا يمكن إدخال أكثر من أربع كلمات";
                            }
                            return;
                        }


                        if (value.length > 40) {
                            input.value = input.value.substring(0, 40);
                            var warningMessage = document.getElementById("warning-message");
                            if (!warningMessage) {
                                warningMessage = document.createElement("span");
                                warningMessage.id = "warning-message";
                                warningMessage.style.color = "red";
                                warningMessage.textContent = "الرجاء إدخال اسم لا يزيد عن 40 رقم";
                                input.parentNode.insertBefore(warningMessage, input.nextSibling);
                            }
                            return;
                        }


                        if (!arabicRegex.test(value) || (englishRegex.test(value) && !isNaN(value)) || (englishRegex.test(value) && value.length > 1)) {
                            input.value = input.value.replace(/[^ \u0600-\u06FF]/g, '');
                            var warningMessage = document.getElementById("warning-message");
                            if (!warningMessage) {
                                warningMessage = document.createElement("span");
                                warningMessage.id = "warning-message";
                                warningMessage.style.color = "red";
                                warningMessage.textContent = "الرجاء إدخال أحرف عربية فقط";
                                input.parentNode.insertBefore(warningMessage, input.nextSibling);
                            }
                        } else {
                            var warningMessage = document.getElementById("warning-message");
                            if (warningMessage) {
                                warningMessage.parentNode.removeChild(warningMessage);
                            }
                        }



                    }
                    //بركجة الاسم الرباعي
                </script>

                <script type="text/javascript">
                    //كود برمجة رقم الجوال
                    function filternumbers(input) {
                        var value = input.value;
                        var numericRegex = /^[0-9]*$/;

                        if (value.length > 9 || !numericRegex.test(value)) {
                            if (value.length > 9) {
                                input.value = input.value.substring(0, 9);
                            }
                            input.value = input.value.replace(/[^0-9]/g, '');

                            var warningMessage = document.getElementById("warning-message");
                            if (!warningMessage) {
                                warningMessage = document.createElement("span");
                                warningMessage.id = "warning-message";
                                warningMessage.style.color = "red";
                                warningMessage.textContent = "";
                                input.parentNode.appendChild(warningMessage);
                            }
                        } else if (value.length >= 2 && (value[0] != '7' || (value[1] != '1' && value[1] != '3' && value[1] != '7'))) {
                            input.value = input.value.substring(0, 1);

                            var warningMessage = document.getElementById("warning-message");
                            if (!warningMessage) {
                                warningMessage = document.createElement("span");
                                warningMessage.id = "warning-message";
                                warningMessage.style.color = "red";
                                warningMessage.textContent = "يرجى إدخال رقم بداية بـ71، 73 أو 77.";
                                input.parentNode.appendChild(warningMessage);
                            }
                        } else {
                            var warningMessage = document.getElementById("warning-message");
                            if (warningMessage) {
                                warningMessage.parentNode.removeChild(warningMessage);
                            }
                        }
                    }
                    //برمجة رقم الجوال
                </script>

                <script type="text/javascript">
                    //رقم الهوية
                    function filternumbers2(input) {
                        var value = input.value;
                        var numericRegex = /^[0-9]*$/;

                        if (!numericRegex.test(value)) {
                            input.value = value.replace(/[^0-9]/g, '');

                            var warningMessage = document.getElementById("warning-message");
                            if (!warningMessage) {
                                warningMessage = document.createElement("span");
                                warningMessage.id = "warning-message";
                                warningMessage.style.color = "red";
                                warningMessage.textContent = "يرجى إدخال أرقام فقط.";
                                input.parentNode.appendChild(warningMessage);
                            }
                        } else {
                            var warningMessage = document.getElementById("warning-message");
                            if (warningMessage) {
                                warningMessage.parentNode.removeChild(warningMessage);
                            }
                        }
                    }
                </script>
                <script>
                    //برمجة الايميل
                    function filterCharacters3(input) {
                        var value = input.value;
                        var filteredValue = value.replace(/[^a-zA-Z0-9/s.@]/g, '');

                        if (value !== filteredValue) {
                            input.value = filteredValue;
                            var warningMessage = document.getElementById("warning-message");
                            if (!warningMessage) {
                                warningMessage = document.createElement("span");
                                warningMessage.id = "warning-message";
                                warningMessage.style.color = "red";
                                warningMessage.textContent = "يرجى عدم إضافة مسافات أو أحرف غير مسموح بها.";
                                input.parentNode.appendChild(warningMessage);
                            }
                        } else {
                            var warningMessage = document.getElementById("warning-message");
                            if (warningMessage) {
                                warningMessage.parentNode.removeChild(warningMessage);
                            }
                        }
                    }
                </script>
              }
          }
      }
               
    </form>
</body>
</html>
