<%@ Page Title="التعليمات" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="info.aspx.cs" Inherits="WebApplication3.info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <style>
        @font-face {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
        }

        body {
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            background: white;
        }

        #telegramForm {
            direction: rtl;
        }

        #statusMessage.su {
            color: green;
        }

        #statusMessage.error {
            color: red;
        }

        *,
        *::before,
        *::after {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        .allll {
            --color: rgba(30, 30, 30);
            --bgColor: rgba(245, 245, 245);
            min-height: 100vh;
            display: grid;
            align-content: center;
            gap: 2rem;
            padding: 2rem;
            font-family: "alfont_com_Cairo-Regular";
            src: url("fonts/alfont_com_Cairo-Regular.ttf");
            color: var(--color);
            /* background: var(--bgColor);         */
        }

        h1 {
            text-align: center;
        }

        .custom-list {
            --col-gap: 2rem;
            --row-gap: 2rem;
            --line-w: 0.25rem;
            display: grid;
            grid-template-columns: var(--line-w) 1fr;
            grid-auto-columns: max-content;
            column-gap: var(--col-gap);
            list-style: none;
            width: min(70rem, 100%);
            margin-inline: auto;
        }
            /* line */
            .custom-list:before {
                content: "";
                grid-column: 1;
                grid-row: 1 / span 20;
                background: rgb(225, 225, 225);
                border-radius: calc(var(--line-w) / 2);
            }

            .custom-list li:not(:last-child) {
                margin-bottom: var(--row-gap);
            }
            /* card */
            .custom-list li {
                grid-column: 2;
                --inlineP: 1.5rem;
                margin-inline: var(--inlineP);
                grid-row: span 2;
                display: grid;
                grid-template-rows: min-content min-content min-content;
            }
                /* date colors */
                .custom-list li .date {
                    --dateH: 3rem;
                    height: var(--dateH);
                    margin-inline: calc(var(--inlineP) * -1);
                    text-align: center;
                    background-color: var(--accent-color);
                    color: white;
                    font-size: 1.25rem;
                    font-weight: 700;
                    display: grid;
                    place-content: center;
                    position: relative;
                    border-radius: calc(var(--dateH) / 2) 0 0 calc(var(--dateH) / 2);
                }
                    /* date flap */
                    .custom-list li .date::before {
                        content: "";
                        width: var(--inlineP);
                        aspect-ratio: 1;
                        background: var(--accent-color);
                        background-image: linear-gradient(rgba(0, 0, 0, 0.2) 100%, transparent);
                        position: absolute;
                        top: 100%;
                        clip-path: polygon(0 0, 100% 0, 0 100%);
                        right: 0;
                    }
                    /* circle */
                    .custom-list li .date::after {
                        content: "";
                        position: absolute;
                        width: 2rem;
                        aspect-ratio: 1;
                        background: var(--bgColor);
                        border: 0.3rem solid var(--accent-color);
                        border-radius: 50%;
                        top: 50%;
                        transform: translate(50%, -50%);
                        right: calc(100% + var(--col-gap) + var(--line-w) / 2);
                    }
                /* title descr */
                .custom-list li .title,
                .custom-list li .descr {
                    background: var(--bgColor);
                    position: relative;
                    padding-inline: 1.5rem;
                }

                .custom-list li .title {
                    overflow: hidden;
                    padding-block-start: 1.5rem;
                    padding-block-end: 1rem;
                    font-weight: 600;
                }

                .custom-list li .descr {
                    padding-block-end: 1.5rem;
                    font-weight: 300;
                }

                    /* shadows */
                    .custom-list li .title::before,
                    .custom-list li .descr::before {
                        content: "";
                        position: absolute;
                        width: 90%;
                        height: 0.5rem;
                        background: rgba(0, 0, 0, 0.5);
                        left: 50%;
                        border-radius: 50%;
                        filter: blur(4px);
                        transform: translate(-50%, 50%);
                    }

                .custom-list li .title::before {
                    bottom: calc(100% + 0.125rem);
                }

                .custom-list li .descr::before {
                    z-index: -1;
                    bottom: 0.25rem;
                }



        @media (min-width: 40rem) {
            .custom-list {
                grid-template-columns: 1fr var(--line-w) 1fr;
            }

                .custom-list::before {
                    grid-column: 2;
                }

                .custom-list li:nth-child(odd) {
                    grid-column: 1;
                }

                .custom-list li:nth-child(even) {
                    grid-column: 3;
                }

            /* start second card */
            custom-list li:nth-child(2) {
                grid-row: 2/4;
            }

            custom-list li:nth-child(odd) .date::before {
                clip-path: polygon(0 0, 100% 0, 100% 100%);
                left: 0;
            }

            custom-list li:nth-child(odd) .date::after {
                transform: translate(-50%, -50%);
                left: calc(100% + var(--col-gap) + var(--line-w) / 2);
            }

            custom-list li:nth-child(odd) .date {
                border-radius: 0 calc(var(--dateH) / 2) calc(var(--dateH) / 2) 0;
            }
        }

        @media (min-width: 40rem) {
            custom-list {
                grid-template-columns: 1fr var(--line-w) 1fr;
            }

            ul::before {
                grid-column: 2;
            }

            ul li:nth-child(odd) {
                grid-column: 1;
            }

            ul li:nth-child(even) {
                grid-column: 3;
            }

            /* start second card */
            ul li:nth-child(2) {
                grid-row: 2/4;
            }

            ul li:nth-child(odd) .date::before {
                clip-path: polygon(0 0, 100% 0, 100% 100%);
                left: 0;
            }

            ul li:nth-child(odd) .date::after {
                transform: translate(-50%, -50%);
                left: calc(100% + var(--col-gap) + var(--line-w) / 2);
            }

            ul li:nth-child(odd) .date {
                border-radius: 0 calc(var(--dateH) / 2) calc(var(--dateH) / 2) 0;
            }
        }








        .credits {
            margin-top: 1rem;
            text-align: right;
        }

            .credits a {
                color: var(--color);
            }
    </style>

    <script>
        document.getElementById("telegramForm").addEventListener("submit", function (event) {
            event.preventDefault(); // منع الإرسال الافتراضي للنموذج
            var senderName = document.getElementById("senderName").value;
            var messageInput = document.getElementById("message").value;
            var formattedMessage = "المرسل: *" + senderName + "* \n\n" + messageInput;
            var token = "6763917046:AAHReW5a-GtekRsrHxc-0_DG4s_Vgu_mqBI";
            var chatId = "-1002124319324";
            var url = "https://api.telegram.org/bot" + token + "/sendMessage";
            var formData = new FormData();
            formData.append("chat_id", chatId);
            formData.append("text", formattedMessage);
            formData.append("parse_mode", "MarkdownV2");

            var statusMessage = document.getElementById("statusMessage");
            statusMessage.classList.remove("error");
            statusMessage.classList.remove("su");
            statusMessage.textContent = "جارٍ الإرسال...";
            fetch(url, {
                method: "POST",
                body: formData
            })
                .then(function (response) {
                    if (response.ok) {
                        statusMessage.classList.add("su");
                        statusMessage.textContent = "تم التسليم";
                        statusMessage.classList.remove("error");
                    } else {
                        statusMessage.textContent = "فشل الإرسال";
                        statusMessage.classList.add("error");
                    }
                })
                .catch(function (error) {
                    statusMessage.textContent = "فشل الإرسال: " + "حاول مرة أخرى";
                    statusMessage.classList.add("error");
                });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/bootstrap.min.js"></script>
    <div class="">
        <div class=" container-xl mt-3 mb-2" style="text-align: right;" dir="ltr">
            <div class="card-block ">
                <div class="card-header text-center h3 text-white" style="background-color: #41516C !important">
                    يرجى اتباع الإرشادات التالية بعناية لضمان قبول طلبك
                </div>
                <div class="card-body" style="background-color:  white">
                    <div class="allll">
                        <ul class="custom-list">
                            <li style="--accent-color: #41516C">
                                <div class="date">اولا</div>
                                <div class="title">قم بانشاء حسابك </div>
                                <div class="descr">
                                    عندما تقوم بانشاء حسابك تأكد من ادخال المعلومات الخاصه بك بشكل صحيح
                                    وان لديك بريد الكتروني خاص بك
                                </div>
                            </li>
                            <li style="--accent-color: #FBCA3E">
                                <div class="date">ثانيا</div>
                                <div class="title">اختر المعاملة المراد ارسالها </div>
                                <div class="descr">
                                    قم بتعبئة الاستمارة التي تريد ارسالها بشكل كامل وتأكد من سلامة المعلومات
                                    حتى لايتم رفض المعاملة لاحقا
                                </div>
                            </li>
                            <li style="--accent-color: #E24A68">
                                <div class="date">ثالثا</div>
                                <div class="title">ارفق صور للوثائق المطلوبة</div>
                                <div class="descr">
                                    بعد ارسال المعاملة قم بتصوير الوثائق والمستندات الازمة الخاصه بكل
                                    معاملة
                                </div>
                            </li>
                            <li style="--accent-color: #1B5F8C">
                                <div class="date">رابعا </div>
                                <div class="title">احجز الوقت المناسب لاجراء المقابلة</div>
                                <div class="descr">
                                    بعد ان ترسل المعاملة والوثائق الازمه ويتم قبولها اضغط على زر القبول
                                    من صفحة الاستعلامات ومن ثم قم بتحديد الوقت المناسب لك
                                </div>
                            </li>
                            <li style="--accent-color: #4CADAD">
                                <div class="date">خامسا</div>
                                <div class="title">الحضور الى المقابلة</div>
                                <div class="descr">
                                    يجب عليك التواجد في الوقت الذي تم تحديده مسبقا مع احضار جميع الوثائق
                                    والاوراق الرسميه لاستكمال بقية الاجراءات أثناء وبعد المقابلة
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <br>

        <br>
        <br>
    </div>
     
</asp:Content>

