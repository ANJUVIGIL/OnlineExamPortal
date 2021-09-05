using DAL.Manager;
using DAL.Models;
using ExamManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamManagement.Controllers
{
    public class TeacherController : Controller
    {
         MainProjectContext db = new MainProjectContext();
        //
        // GET: /Teacher/

        public ActionResult TeacherProfileView(int id=0)
        {
            TeacherManager objregmngr = new TeacherManager();
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


        public ActionResult TeacherEditProfile(int id)
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
        public ActionResult TeacherEditProfile(int id, Ent_Register collection)
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
                return RedirectToAction("TeacherProfileView");
            }
            else
            {
                return RedirectToAction("Error");
            }


           


        }

        //
        // GET: /Student/Details/5

        public ActionResult ViewAllstudent()
        {
            RegisterManager objreg = new RegisterManager();
            Ent_Register objentreg = new Ent_Register();
            var details = objreg.details.ToList();
            List<Ent_Register> reg = new List<Ent_Register>();
            foreach (var obj in details)
            {
                reg.Add(new Ent_Register
                {
                    Rid = obj.Rid,
                    Name = obj.Name,
                    Department = obj.Name,
                    //EntryDate = obj.EntryDate,
                    Email = obj.Email,
                    Phone = obj.Phone,
                    password = obj.Password,
                    Image = obj.Image,
                    Status = obj.Status,
                    Role = obj.Role,
                    //objentreg.Image = details[0].Image;
                    //Image = "../../Uploadedimages/" + obj.Image,
                    //ViewBag.Image = Image,

                });
            }
            foreach (var obj in details)
            {

                ViewBag.img = "../../Uploadedimages/" + obj.Image;
            }
            return View(reg);
        }

        //
        // GET: /Student/Create

        public ActionResult Notification ()
        {
            return View();
        } 

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Student/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddQuestion()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult AddQuestion(Ent_Question obj, Ent_Choice objchoice)
        {
            QuestionManager qustnmngr = new QuestionManager();
            Ent_Question objentreg = obj;
            DAL.Models.Question objreg = new DAL.Models.Question();
            objreg.QCid = obj.QCid;
            objreg.QuestionType = objentreg.QuestionType;
            objreg.Question1 = objentreg.Question1;
            objreg.points = objentreg.points;
            objreg.QuestionCategory = objentreg.QuestionCategory;

            var result = qustnmngr.AddQuestions(objreg);

            //Ent_Choice objent = objchoice;
            //Choice objchoices = new Choice();
            //objchoices.ChoiceId = objent.ChoiceId;
            //objchoices.Label = objent.Label;
            // qustnmngr.AddChoices(objchoices);




            if (result == "Success")
            {
                return RedirectToAction("AddChoices");
            }

            else
            {
                return RedirectToAction("Error");
            }
        }

        


        public ActionResult AddChoices()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddChoices(Ent_Question obj, Ent_Choice objchoice)
        {
            QuestionManager qustnmngr = new QuestionManager();
            Ent_Question objentreg = obj;
            //DAL.Models.Question objreg = new DAL.Models.Question();
            //objreg.QCid = obj.QCid;
            //objreg.QuestionType = objentreg.QuestionType;
            //objreg.Question1 = objentreg.Question1;
            //objreg.points = objentreg.points;
            //objreg.QuestionCategory = objentreg.QuestionCategory;

            //var result = qustnmngr.AddQuestions(objreg);

            Ent_Choice objent = objchoice;
            Choice objchoices = new Choice();
            objchoices.ChoiceId = objent.ChoiceId;
            objchoices.Label = objent.Label;
            //objchoice.Question = objentreg.QuestionCategory;
            objchoices.QuestionId = objentreg.Qid;
            objchoices.points = objentreg.points;
            qustnmngr.AddChoices(objchoices);
            



            //if (result == "Success")
            //{
            //    return RedirectToAction("AddQuestionChoices");
            //}

            //else
            //{
            return RedirectToAction("AddChoices");
            

        }

        public ActionResult List()
        {

            //var searchValue = Request.Form["search[value]"].FirstOrDefault();
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    customerData = customerData.Where(m => m.Name == searchValue);
            //}  
            var data = db.Database.SqlQuery <StudentResult>("getdata @id=1").ToList();
            return View(data);
            //return Json(new {data=data},JsonRequestBehavior.AllowGet);
        }

        //public ActionResult viewAnswerpaper()
        //{
        //    AnswerManager objreg = new AnswerManager();
        //    Ent_Answer objentreg = new Ent_Answer();
        //    var details = objreg.details.ToList();
        //    List<Ent_Answer> reg = new List<Ent_Answer>();
        //    foreach (var obj in details)
        //    {
        //        reg.Add(new Ent_Register
        //        {
        //            Rid = obj.Rid,
        //            Name = obj.Name,
        //            Department = obj.Name,
        //            //EntryDate = obj.EntryDate,
        //            Email = obj.Email,
        //            Phone = obj.Phone,
        //            password = obj.Password,
        //            Image = obj.Image,
        //            Status = obj.Status,
        //            Role = obj.Role,
        //            //objentreg.Image = details[0].Image;
        //            //Image = "../../Uploadedimages/" + obj.Image,
        //            //ViewBag.Image = Image,

        //        });
        //    }
        //    foreach (var obj in details)
        //    {

        //        ViewBag.img = "../../Uploadedimages/" + obj.Image;
        //    }
        //    return View(reg);
        //}
        //    return viewAnswerpaper();
        //}

    }
}
