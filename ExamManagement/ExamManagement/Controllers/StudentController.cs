using DAL.Manager;
using DAL.Models;
using ExamManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamManagement.Controllers
{
    public class StudentController : Controller
    {
        MainProjectContext db = new MainProjectContext();
        //
        // GET: /Student/

        public ActionResult StudentProfileView(int id=0)
        {
            StudentManager objregmngr = new StudentManager();
            Ent_Register objentreg =new Ent_Register();
            Registration objreg = new Registration();

            var studentid = Session["Id"];
            if (studentid == null)
            {
                return RedirectToAction("Login", "Home", null);

                    
            }
            if (TempData.ContainsKey("Id"))
            {
                id = Convert.ToInt32(TempData["Id"]);
            }
            id = Convert.ToInt32(studentid);
           List<Registration>details = objregmngr.profileview(id);
           objentreg.Rid = details[0].Rid;
           objentreg.Name = details[0].Name;
           objentreg.Email = details[0].Email;
           objentreg.Department = details[0].Department;
           //objentreg.EntryDate = details[0].EntryDate.ToString("yyyyMMdd");
           objentreg.Phone = details[0].Phone;
           objentreg.password = details[0].Password;
           objentreg.Image = details[0].Image;
           objentreg.Role = details[0].Role;
           //objentreg.EntryDate = details[0].EntryDate;
           objentreg.Status = details[0].Status;
           string img = "../../Uploadedimages/" + objentreg.Image;
   
           ViewBag.img = img;
           ViewBag.Id = objentreg.Rid;
           return View(objentreg);

        }


        public ActionResult StudentEditProfile(int id)
        {
            StudentManager objregmngr = new StudentManager();
            Ent_Register objentreg = new Ent_Register();
            Registration objreg = new Registration();

            
            List<Registration> details = objregmngr.profileview(id);
            objentreg.Rid = details[0].Rid;
            objentreg.Name = details[0].Name;
            objentreg.Email = details[0].Email;
            objentreg.Department = details[0].Department;
            //objentreg.EntryDate = details[0].EntryDate.ToString("yyyyMMdd");
            objentreg.Phone = details[0].Phone;
            objentreg.password = details[0].Password;
            objentreg.Image = details[0].Image;
            objentreg.Status = details[0].Status;
            objentreg.Role = details[0].Role;
            string img = "../../Uploadedimages/" + objentreg.Image;

            ViewBag.img = img;
            ViewBag.Id = objentreg.Rid;
            return View(objentreg);

        }

        [HttpPost]
        public ActionResult EditProfile(int id, Ent_Register collection)
        {
            StudentManager objregmngr = new StudentManager();
            Ent_Register objentreg = new Ent_Register();
            Registration objreg = new Registration();

            objreg.Rid = id;
            objreg.Name = collection.Name;
            objreg.Email = collection.Email;
            objreg.Department = collection.Department;
            objreg.Phone = collection.Phone;
            objreg.Password = collection.password;
            //var InputFileName = Path.GetFileName(Image.FileName);
            //var ServerSavePath = Path.Combine(Server.MapPath("~/Uploadedimages/") + InputFileName);
            ////var imgfile = objentreg.Image;
            ////Save file to server folder  
            //Image.SaveAs(ServerSavePath);


            //objreg.Image = InputFileName;


            var result = objregmngr.studentedit(objreg);
            if (result == "Success")
            {
                return RedirectToAction("ProfileView");
            }
            else
            {
                return RedirectToAction("Error");
            }


           


        }

        //
        // GET: /Student/Details/5

        public ActionResult ExamRegistration(int id)
        {
            //StudentManager objregmngr = new StudentManager();
            Ent_Test objtest=new Ent_Test();
            //Ent_student objentstudent = new Ent_student();
            
           
           
          
            ViewBag.Tests = db.Tests.Where(X => X.isactive == true).Select(x => new { x.Id, x.Name }).ToList();
            Ent_Student objentstudent = null;
            if (Session["Ent_Student"] == null)
                objentstudent = new Ent_Student();
            else
                objentstudent = (Ent_Student)Session["Ent_Student"];

            StudentManager objregmngr = new StudentManager();
            Ent_Register objentreg = new Ent_Register();
            Registration objreg = new Registration();


            List<Registration> details = objregmngr.profileview(id);
            objentstudent.Id = details[0].Rid;
            objentstudent.Name = details[0].Name;
            objentstudent.Email = details[0].Email;
            //objentstudent.Department = details[0].Department;
            //objentreg.EntryDate = details[0].EntryDate.ToString("yyyyMMdd");
            objentstudent.Phone = details[0].Phone;
            //objentstudent.password = details[0].Password;
            
         
             

            return View(objentstudent);
        }

        //
        // GET: /Student/Create

        public ActionResult Instruction(Ent_Student objentstudent)
        {
            if (objentstudent != null)
            {
                var test = db.Tests.Where(x => x.isactive == true && x.Id == objentstudent.Id).FirstOrDefault();
                if (test != null)
                {
                    ViewBag.TestName = test.Name;
                    ViewBag.TestDescription = test.Description;
                    ViewBag.QuestionCount = test.TestXQuestions.Count;
                    ViewBag.TestDuration = test.DurationInMinute;
                }
            }
            return View(objentstudent);
        } 
        public ActionResult exam(Ent_Student model)
        {
            if(model!=null)
                Session["Ent_Student"]=model;
            if(model==null)
                 return RedirectToAction("StudentProfileView");

            if(string.IsNullOrEmpty(model.Name)||model.Id<1)
            {
                TempData["message"]="Invalid Registration details. Please try again";
                return RedirectToAction("StudentProfileView");
            }
            //to register the user for the test
            Student _user=db.Students.Where(x=>x.Name.Equals(model.Name,StringComparison.InvariantCultureIgnoreCase)
                &&((string.IsNullOrEmpty(model.Email)&& string.IsNullOrEmpty(x.Email))||(x.Email==model.Email))
                &&((string.IsNullOrEmpty(model.Phone)&& string.IsNullOrEmpty(x.Phone))||(x.Phone==x.Phone))).FirstOrDefault();
            if (_user == null)
            {
                _user=new Student()
                {
               Name=model.Name,
                Email=model.Email,
                Phone=model.Phone,
                EntryDate=DateTime.UtcNow,
                AccessLevel=100
                };
            
            db.Students.Add(_user);
            db.SaveChanges();
            }
        
        ExamRegistration registration=db.ExamRegistrations.Where(x=>x.StudentId==_user.Id
            && x.TestId==model.Id
            &&x.TokenExpireTime>DateTime.UtcNow).FirstOrDefault();
        if(registration!=null)
             {
       
            this.Session["Token"]=registration.Token;
            this.Session["TokenExpire"]=registration.TokenExpireTime;


             }
       else
        {


            Test test = db.Tests.Where(x => (x.isactive==true) && (x.Id == model.Id)).FirstOrDefault();
             if(test!=null)
             {
                 ExamRegistration newregistartion=new ExamRegistration()
             {
                 StudentId=_user.Id,
             RegistrationDate=DateTime.UtcNow,
            TestId=model.Id,
             Token=Guid.NewGuid(),
             TokenExpireTime = DateTime.UtcNow.AddMinutes(test.DurationInMinute)

             };
                 //_user.ExamRegistrations.Add(newregistartion);

             db.ExamRegistrations.Add(newregistartion);
             db.SaveChanges();
             this.Session["Token"] = newregistartion.Token;
             this.Session["TokenExpire"] = newregistartion.TokenExpireTime;

}

}
        return RedirectToAction(
            "EvalPage", new { @token = Session["Token"] }); 
  
    }
        public ActionResult EvalPage(Guid token, int? qno)
        {
            if (token == null)
            {
                TempData["message"] = "you have invalid token please register and try again";
                return RedirectToAction("ExamRegistration");
            }
            var ExamRegistration = db.ExamRegistrations.Where(x => x.Token==
                (token)).FirstOrDefault();
            if (ExamRegistration.TokenExpireTime < DateTime.UtcNow)
            {
                TempData["message"] = "the exam duration has expired at" + ExamRegistration.TokenExpireTime.ToString();
                return RedirectToAction("ExamRegistration");

            }
            if (qno.GetValueOrDefault() < 1)
                qno = 1;
            var testQuestionId = db.TestXQuestions.
                Where(x => x.TestId == ExamRegistration.TestId && x.QuestionNumber == qno)
                .Select(x => x.Id).FirstOrDefault();


            if (testQuestionId > 0)
            {
                var _model = db.TestXQuestions.ToList().Where(x => x.Id == testQuestionId).Select(x => new ExamManagement.Models.QuestionModel()
           {
               QuestionType =x.Question.QuestionType,
               QuestionNumber = x.QuestionNumber,
               Question = x.Question.Question1,
               Points =x.Question.points,
               TestId = x.TestId,
               TestName = x.Test.Name,
               Options = x.Question.Choices.ToList().Where(y => y.isactive == true).Select(y => new ExamManagement.Models.QXOModel()

               {
                   ChoiceId = y.ChoiceId,
                   Label = y.Label,
               }).ToList()
           }).FirstOrDefault();
                //now if it is already answered earlier , set the choices of the user
                var savedAnswers = db.TestXPapers.Where(x => x.TestXQuestionId == testQuestionId && x.RegistrationId == ExamRegistration.StudentId && x.Choice.isactive == true).
                    Select(x => new { x.ChoiceId, x.Answer }).ToList();
                foreach (var savedAnswer in savedAnswers)
                {
                    _model.Options.Where(x => x.ChoiceId == savedAnswer.ChoiceId).FirstOrDefault().Answer = savedAnswer.Answer;
                }
                _model.TotalQuestionInset = db.TestXQuestions.Where(x => x.Question.isactive == true && x.TestId == ExamRegistration.TestId).Count();
                ViewBag.TimeExpire = ExamRegistration.TokenExpireTime;
                return View(_model);
            }
            else
            {
                return View("Error");
            }

            
        }
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult PostAnswer(AnswerModel choices)
        {
            var registration = db.ExamRegistrations.Where(x => x.Token.Equals(choices.Token)).FirstOrDefault();
            if (registration == null)
            {
                TempData["message"] = "This token is invalid";
                return RedirectToAction("Index");
            }
            if (registration.TokenExpireTime < DateTime.UtcNow)
            {
                TempData["message"] = "The exam duration has expired at" + registration.TokenExpireTime.ToString();
                return RedirectToAction("Index");
            }
            var testQuestionInfo=db.TestXQuestions.Where
                (x=>x.TestId==registration.TestId && x.QuestionNumber==choices.QuestionId).Select(x=>new{
                    TQId=x.Id,
                    QT=x.Question.QuestionType,
                    QID=x.Id,
                    POINT=(decimal)x.Question.points,
                   
        }).FirstOrDefault();
            if (testQuestionInfo != null)
            {
                if (choices.UserChoices.Count > 1)
                {
                    var allPointValueOfChoices =
                        (
                        from a in db.Choices.Where(x => x.isactive)
                        join b in choices.UserSelectId on a.ChoiceId equals b
                        select new { a.ChoiceId, points = (decimal)a.points }).AsEnumerable().Select(x => new TestXPaper()
                        {   
                          
                            
                            RegistrationId = registration.StudentId,
                            TestXQuestionId = testQuestionInfo.QID,
                            ChoiceId = x.ChoiceId,
                            Answer = "CHECKED",
                            MarkScored = Math.Floor((testQuestionInfo.POINT / 100.00M) * x.points)
                            

                        } ).ToList()
                        
               
                    .FirstOrDefault();
               

                   db.TestXPapers.Add(allPointValueOfChoices);

                }
                else
                {
                    //answer is of type text
                    db.TestXPapers.Add(new TestXPaper()
                    {
                        RegistrationId = registration.StudentId,
                        TestXQuestionId = testQuestionInfo.QID,
                        ChoiceId = choices.UserChoices.FirstOrDefault().ChoiceId,
                        MarkScored = 1,
                        Answer = choices.Answer
                    });
                }
                db.SaveChanges();
               
            }
            //get the question depending on the direction
            var nextQuestionNumber = 1;
            if (choices.Direction.Equals("forward", StringComparison.CurrentCultureIgnoreCase))
            {
                nextQuestionNumber = db.TestXQuestions.Where(x => x.TestId == choices.TestId
                    && x.QuestionNumber > choices.QuestionId).OrderBy(x => x.QuestionNumber).Take(1).Select(x => x.QuestionNumber).FirstOrDefault();
            }
            else
            {
                nextQuestionNumber = db.TestXQuestions.Where(x => x.TestId == choices.TestId
                    && x.QuestionNumber > choices.QuestionId)
                    .OrderByDescending(x => x.QuestionNumber).Take(1).Select(x => x.QuestionNumber).FirstOrDefault();
            }
            if (nextQuestionNumber < 1)
                nextQuestionNumber =1;
            return RedirectToAction("EvalPage", new
            {
                @token = Session["Token"],
                @qno = nextQuestionNumber
            });
        }

    }
}


       
 

