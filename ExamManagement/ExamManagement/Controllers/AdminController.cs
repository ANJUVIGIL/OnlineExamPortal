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
    public class AdminController : Controller
    {
        MainProjectContext db = new MainProjectContext();
        //
        // GET: /Admin/

        public ActionResult ProfileView(int id = 0)
        {
            AdminManager objadminmngr = new AdminManager();
            Ent_Register objentreg = new Ent_Register();
            Registration objreg = new Registration();

            var adminid = Session["Id"];
            if (adminid == null)
            {
                return RedirectToAction("Login", "Home", null);


            }
            if (TempData.ContainsKey("Id"))
            {
                id = Convert.ToInt32(TempData["Id"]);
            }
            id = Convert.ToInt32(adminid);
            List<Registration> details = objadminmngr.profileview(id);
            objentreg.Rid = details[0].Rid;
            objentreg.Name = details[0].Name;
            objentreg.Email = details[0].Email;
            objentreg.Department = details[0].Department;
            //objentreg.EntryDate = details[0].EntryDate.ToString("yyyyMMdd");
            objentreg.Phone = details[0].Phone;
            objentreg.Role = details[0].Role;
            objentreg.password = details[0].Password;
            
            objentreg.Status = details[0].Status;
            objentreg.Image = details[0].Image;
            string img = "../../Uploadedimages/" + objentreg.Image;

            ViewBag.img = img;
            ViewBag.Id = objentreg.Rid;
            return View(objentreg);
          
        }

        public ActionResult AdminEditProfile(int id)
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
        public ActionResult AdminEditProfile(int id, Ent_Register collection)
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
        // GET: /Admin/Details/5

        public ActionResult ViewAllstudent()
        {
            RegisterManager objreg = new RegisterManager();
            Ent_Register objentreg = new Ent_Register();
           var  details = objreg.details.ToList();
           List<Ent_Register> reg = new List<Ent_Register>();
           foreach (var obj in details)
           {
               reg.Add(new Ent_Register
               {
                   Rid=obj.Rid,
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

               ViewBag.img ="../../Uploadedimages/"+ obj.Image;
           }
            return View(reg);
        }

        //
        // GET: /Admin/Create

        public ActionResult AcceptVisitor(int id)
        {
            RegisterManager objregmngr = new RegisterManager();
            Ent_Register objentreg = new Ent_Register();
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

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult AcceptVisitor(int id, Ent_Register collection)
        {
            try
            {
                // TODO: Add insert logic here

                RegisterManager objregmngr = new RegisterManager();
                Ent_Register objentreg = new Ent_Register();
                Registration objreg = new Registration();

                objreg.Rid = id;
                objreg.Name = collection.Name;
                objreg.Email = collection.Email;
                objreg.Department = collection.Department;
                objreg.Phone = collection.Phone;
                objreg.Password = collection.password;



                var result = objregmngr.editstatus(objreg);
                if (result == "Success")
                {
                    return RedirectToAction("AcceptVisitor");
                }
                else
                {
                    return RedirectToAction("Error");
                }


           

            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Admin/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Edit/5

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
        public ActionResult List()
        {

            //var searchValue = Request.Form["search[value]"].FirstOrDefault();
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    customerData = customerData.Where(m => m.Name == searchValue);
            //}  
            var data = db.Database.SqlQuery<StudentResult>("getdata @id=1").ToList();
            return View(data);
            //return Json(new {data=data},JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Delete/5

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
