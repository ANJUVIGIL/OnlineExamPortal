using DAL.Manager;
using DAL.Models;
using ExamManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamManagement.Controllers
{
    public class HomeController : Controller
    {
         
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Register(Ent_Register obj, HttpPostedFileBase Image)
        {
           

                RegisterManager objregmngr = new RegisterManager();
                Ent_Register objentreg = obj;
                Registration objreg = new Registration();
                objreg.Name = objentreg.Name;
                objreg.Department = objentreg.Department;
                objreg.EntryDate = DateTime.Now;
                objreg.Email = objentreg.Email;
                objreg.Phone = objentreg.Phone;
                objreg.Password = objentreg.password;
                //objreg.Image = objentreg.Image;
                objreg.Status = "A";
                objreg.Role = objentreg.Role;
                //objreg.Image = ServerSavePath;


                var InputFileName = Path.GetFileName(Image.FileName);
                var ServerSavePath = Path.Combine(Server.MapPath("~/Uploadedimages/") + InputFileName);
                //var imgfile = objentreg.Image;
                //Save file to server folder  
                Image.SaveAs(ServerSavePath);


                objreg.Image = InputFileName;


                ViewBag.UploadStatus = " files uploaded successfully.";

                var result = objregmngr.UserRegistration(objreg);


                if (result == "Success")
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    return RedirectToAction("Error");
                }
            
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Ent_Register obj )
        {
            RegisterManager objregmngr = new RegisterManager();
            Ent_Register objentreg = obj;
            Registration objreg = new Registration();
            objreg.Email = objentreg.Email;
            
            objreg.Password = objentreg.password;
            objreg.Status = "A";
            objreg.Role = objentreg.Role;
            //List<Registration> details = objregmngr.UserLogin(objreg);
            //UserLogin(List < Registration > objreg);
            //List<Registration> result = objregmngr.UserLogin( Registration objreg);
            var result = objregmngr.UserLogin(objreg);
            objreg = (Registration)result;
          
            var role = objreg.Role;
            var Rid = objreg.Rid;

            
            if (role == "Admin")
            {
                Session.Add("Id", objreg.Rid);
                return RedirectToAction("ProfileView", "Admin", new { id = Rid });
            }
            else if (role == "notdefined")
            {
                Session.Add("Id", objreg.Rid);
                return RedirectToAction("StudentProfileView", "Student", new { id = Rid });
            
            }
            else if (role == "Eval")
            {
                Session.Add("Id", objreg.Rid);
                return RedirectToAction("TeacherProfileView", "Teacher", new { id =Rid });

            }
            else
            {
                return RedirectToAction("login");
            }

            return RedirectToAction("Error");
                      
        }

        

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
    }
}
    

