<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Qoiuz.aspx.cs" Inherits="WebApplication3.Qoiuz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
        <style>
     @font-face {
     font-family: "alfont_com_Cairo-Regular";
     src: url("fonts/alfont_com_Cairo-Regular.ttf")
     }

    body {
        font-family: "alfont_com_Cairo-Regular";
    } 

    .card {
        max-width: 500px;
        margin: 0 auto;
        background-color: #fff;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        border-radius: 10px;
        font-family: "alfont_com_Cairo-Regular";
             
    }

    .card-header {
        background-color: #f2f2f2;
        padding: 10px;
        text-align: center;
        border-bottom: 1px solid #ddd;
        
    }

    .card-body {
        padding: 20px;
        
    }

    .question {
        font-size: 18px;
        font-weight: bold;
        margin-bottom: 20px;
    }

    .answer-option {
        margin-bottom: 10px;
        display: flex;
        align-items: center;
    }

    .answer-input {
        display: none;
    }

    .answer-button {
        margin-right: 10px;
    }

    .submit-button {
        text-align: center;
        margin-top: 20px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/bootstrap.min.js"></script>
    <div class="container mt-3" style="text-align: right;" dir="rtl">
     <div class="card shadow-lg p-3 mb-5 bg-white rounded">
         <div class="card-body">  
             <h2 class=" mb-3  text-center h1">أختبـــار علامــات المــرور</h2>
                   <div class="container">
                       <div class="card">
                           <div class="card-header w-100">
                           <h5 class="card-title">ماذا تعني هذه الصورة؟</h5>
                           </div>
                           <div class="card-body">
                               <div class="question">
                                    <div class="card-img mt-2">
                                         <center>
                                            <img id="question-image"  alt="صورة السؤال" width="200" height="200">
                                         </center>
                                         <center>
                                            <h6 id='ct' class="mt-2"> السؤال <span id="question-number"></span>من 15 اسئلة</h6>
                                        </center>
                                     </div>
                               </div>
                           </div>
                           <div class="card-footer">
                                <div class="col-sm-12 mt-1">
                                    <button type="button" name="answer" id="option1" class="btn-primary answer-button w-100"></button>
                                </div>
                                <div class="col-sm-12 mt-1">
                                    <button type="button" name="answer" id="option2" class="btn-primary answer-button w-100"></button>
                                </div>
                                <div class="col-sm-12 mt-1">
                                     <button type="button" name="answer" id="option3" class="btn-primary answer-button w-100"></button>
                                </div>
                               
                           </div>
                      </div>
                   </div>
                   <script src="css/bootstrap.js" type="text/javascript"></script>
                   <script>
                       var questions = [
                           {
                               imageSrc: "trafic/1.jpg",
                               options: ["أجباري الى اليسار", "الاتفاف الى اليسار أثناء السير الى الأمام", "اتجاه السير الإجباري إالى الأمام أو اليسار "],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/2.jpg",
                               options: [" شاحنة", "لا يمكن دخول الشاحنات", "الحموله لا تزيد عن 5 طن"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/3.jpg",
                               options: ["مسافه الأمان عن شاحنات الوقود 4.4 ", "الأبتعاد من السارة المقابلة 4.4", "أقصى ارتفاع 4.4"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/4.jpg",
                               options: ["ممنوع الأنعطاف الى الخلف", "التجاه الأمام فقط", "مسار مغلقأق"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/5.jpg",
                               options: ["ممنوع الأنعطاف الى اليمين", "الأنعطاف اليمين حاد", "الأنعطاف الي اليسار"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/6.jpg",
                               options: ["ممنوع الوقوف و الأنتظار", "ممنوع الوقف", "ممنوع الدخول"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/7.jpg",
                               options: ["ممنوع الوقوف و الأنتظار", "ممنوع الوقوف", "ممنوع الخروج"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/8.jpg",
                               options: ["الطريق يضيق من الجانبين ", "مسار واحد", "مسار مزدوج"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/9.jpg",
                               options: ["الطريق يضيق من اليسار", "الطريق يضيق من اليمين", "طريق متعرج الى اليسار"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/10.jpg",
                               options: ["طريق فرعي من اليسار", "طريق فرعي من اليمين", "الأندماج من ناحية اليسار"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/11.jpg",
                               options: ["ممطب", "سلسلة مطبات", "طريق غير مستوي"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/12.jpg",
                               options: ["دوار", "أتجاه السير الإجباري في الدوار", "ممنوع الرجوع"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/13.jpg",
                               options: ["أجباري الى اليمين", "اتجاه السير الإجباري إالى الأمام أو اليمين", "الاتفاف الى اليمين أثناء السير الى الأمام"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/14.jpg",
                               options: ["نزول", "صعود", "طريق غير مستوي"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/15.jpg",
                               options: ["نزول", "صعود", "طريق غير مستوي"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/16.jpg",
                               options: ["صيانة الكهرباء", "يتواجد عمال في المنطقة", "أعمال طرق"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/17.jpg",
                               options: ["علامة قف", "علامة التف الى اليسار", "علامة التف الى اليمين"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/18.jpg",
                               options: ["ممنوع الوقوف", "موقف مدفوع", "موقف خاص "],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/19.jpg",
                               options: ["علامة وجود منحدرات", "علامة وجود منزلقات", "علامة خطر هنالك مواد سريعة الاشتعال"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/20.jpg",
                               options: ["ادنى سرعه  40", "السرعة القصوى 40", "نهاية حد السرعة 40"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/21.jpg",
                               options: ["موقف", "موقف جانبي", "الشرطة"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/22.jpg",
                               options: ["بداية طريق مزدوج", "طريق ذو اتجاهين ", "الطريق يضيق من تجاهين"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/23.jpg",
                               options: ["الطريق حاد الي اليسار", "ممنوع الأنعطاف الى اليسار", "النعطاف الي اليمين "],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/24.jpg",
                               options: ["معبر مشاة", "معبر أطفال", "منطقة سكنية"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/25.jpg",
                               options: ["الأولوية لمن في اليمين", "ممنوع التجاوز", "الأولوية لمن في اليسار "],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/26.jpg",
                               options: ["ممنوع الخروج", "ممنوع الدخول", "أعطاء الأفضلية"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/51.jpg",
                               options: ["علامة حدودية", "برميل", "حواجز"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/28.jpg",
                               options: ["الطريق مغلق", "تقاطع طريق", "صيانة الطريق"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/29.jpg",
                               options: ["توجد صخور في الطريق", "طريق وعر", "مطب"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/30.jpg",
                               options: ["صخور متساقطة", "منطقه جبلية", "منطفه وعرة"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/31.jpg",
                               options: ["مسار مغلق", "نهاية طريق مزدوج", "بداية طريق مزدوج"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/32.jpg",
                               options: ["منطقة نزول", "منطقه خطرة", "الطريق يتجة لنهاية حافة"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/33.jpg",
                               options: ["منعطفات خطيرة من اليمين الى اليسار", "منعطفات خطيرة من اليسار الى اليمين", "طريق متعرج"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/34.jpg",
                               options: ["منعطف لليمين", "منعطف لليسار", "منعطف يضيق من اليسار"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/35.jpg",
                               options: ["منعطف لليمين", "طريق ذو أتجاهين", "منعطف يضيق من اليسار"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/37.jpg",
                               options: ["اتجاة السير الإجباري الى الأمام أو اليسار", "اتجاة السير الإجباري لليمين أو اليسار", "اتجاة السير الإجباري الى الأمام أو اليمين"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/38.jpg",
                               options: ["أتجاه اجباري ألزم اليسار", "أتجاه اجباري ألزم اليمين", "أتجاه اجباري ألزم الأمام"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/39.jpg",
                               options: ["أتجاه غير اجباري لليسار", "أتجاه اجباري لليسار", "أتجاه لليسار"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/40.jpg",
                               options: ["يمنع تغير الأطارات هنا", "منطقة أنفجار أطارات", "حصى متناثر"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/41.jpg",
                               options: ["طريق غير ناقد", "نهاية طريق حر الحركة", "طريق حر الحركة"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/42.jpg",
                               options: ["منطقة تفتيش", "أتجاه اجباري ألزم اليمين", "أشارت ضوئية"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/43.jpg",
                               options: ["الطريق مغلق", "نفق", "أمامك أفضلية"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/44.jpg",
                               options: ["مطار", "منطقة طياران منخفضة", "مدرج طياران"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/45.jpg",
                               options: ["أتجاه السير اجباري في الدوار", "دوار", "أتجاه اجباري ألزم الأمام"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/46.jpg",
                               options: ["ممنوع الأنتظار", "أعطاء الأفضلية", "قف"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/47.jpg",
                               options: ["طريق حر الحركة", "طريق للمشاة و الدرجات الهوائية", "نهاية طريق حر الحركة"],
                               correctAnswer: 0
                           },
                           {
                               imageSrc: "trafic/48.jpg",
                               options: ["موقف", "دوار", "محطة وقود"],
                               correctAnswer: 2
                           },
                           {
                               imageSrc: "trafic/49.jpg",
                               options: ["اندماج الطريق", "منحنيات", "نهاية الطريق"],
                               correctAnswer: 1
                           },
                           {
                               imageSrc: "trafic/50.jpg",
                               options: ["معبر مياه", "كتف منخفض", "أخذر"],
                               correctAnswer: 2
                           },
                           
                           // إضافة الأسئلة 
                       ];
                       var totalQuestions = questions.length;
                       var numberOfQuestions = Math.min(15, totalQuestions); // عدد الأسئلة التي ترغب في طرحها (حد أقصى 15)
                       var isTestFinished = false; // متغير للتحقق من انتهاء الاختبار
                       var correctAnswersCount = 0; // عدد الإجابات الصحيحة
                       var wrongAnswersCount = 0; // عدد الإجابات الخاطئة

                       // إذا كان عدد الأسئلة أقل من 15، قم بإعادة ترتيب الأسئلة
                       if (totalQuestions > 15) {
                           questions.sort(function () {
                               return 0.5 - Math.random();
                           });
                       }

                       var currentQuestionIndex = 0;
                       var questionImageElement = document.getElementById("question-image");
                       var option1Element = document.getElementById("option1");
                       var option2Element = document.getElementById("option2");
                       var option3Element = document.getElementById("option3");

                       loadQuestion();

                       function loadQuestion() {
                           if (currentQuestionIndex < numberOfQuestions) {
                               var currentQuestion = questions[currentQuestionIndex];
                               questionImageElement.src = currentQuestion.imageSrc;
                               option1Element.textContent = currentQuestion.options[0];
                               option2Element.textContent = currentQuestion.options[1];
                               option3Element.textContent = currentQuestion.options[2];
                               document.getElementById("question-number").textContent = currentQuestionIndex + 1;
                           } else {
                               isTestFinished = true; // تعيين قيمة true إذا انتهى الاختبار
                               showResult();
                           }
                       }

                       option1Element.addEventListener("click", function () {
                           checkAnswer(0);
                       });

                       option2Element.addEventListener("click", function () {
                           checkAnswer(1);
                       });

                       option3Element.addEventListener("click", function () {
                           checkAnswer(2);
                       });

                       function checkAnswer(selectedAnswer) {
                           if (isTestFinished) {
                               return; // إذا انتهى الاختبار، لا تقم بفحص الإجابة
                           }

                           var currentQuestion = questions[currentQuestionIndex];
                           var correctAnswer = currentQuestion.correctAnswer;

                           if (selectedAnswer === correctAnswer) {
                               alert("إجابة صحيحة!");
                               correctAnswersCount++;
                           } else {
                               alert("إجابة خاطئة!");
                               wrongAnswersCount++;
                           }

                           currentQuestionIndex++;
                           if (currentQuestionIndex < numberOfQuestions) {
                               loadQuestion();
                           }
                           else
                           {
                               alert("انتهت الأسئلة!");
                               showResult();
                               isTestFinished = true; // تعيين قيمة true بمجرد انتهاء الاختبار
                               currentQuestionIndex = numberOfQuestions;
                           }
                       }

                       function showResult() {
                         

                           var resultMessage = "نتيجة الاختبار:\n";
                           resultMessage += "عدد الإجابات الصحيحة: " + correctAnswersCount + "\n";
                           resultMessage += "عدد الإجابات الخاطئة: " + wrongAnswersCount + "\n";
                           alert(resultMessage);
                       }
                   </script>
         </div>
     </div>
</div>

</asp:Content>
