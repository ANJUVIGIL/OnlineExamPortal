using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class RegisterManager
    {
        MainProjectContext db = new MainProjectContext();
        public string UserRegistration(Registration objreg)
        {
            int result;
            var objuser = db.Registrations.Where(e => e.Email == objreg.Email && e.Status != "D").SingleOrDefault();
            if (objuser == null)
            {
                try
                {
                    objreg.Status = "A";
                    objreg.Role = "notdefined";
                    db.Registrations.Add(objreg);
                    result = db.SaveChanges();
                }

                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }
            else
            {
                objuser.Name = objreg.Name;
                objuser.Department = objreg.Name;
                objuser.EntryDate = DateTime.Now;
                objuser.Email = objreg.Email;
                objuser.Phone = objreg.Phone;
                objuser.Password = objreg.Password;
                objuser.Image = objreg.Image;
                objreg.Status = "A";
                objreg.Role = objreg.Role;
                db.Entry(objuser).State = EntityState.Modified;
                result = db.SaveChanges();
            }
            if (result > 0)
            {
                return "Success";

            }
            else
            {
                return "Error";
            }



        }

        //UserLogin(List<Registration> objreg)

        public object UserLogin(Registration objreg)
        {
            var obj = db.Registrations.Where(e => e.Email == objreg.Email && e.Password == objreg.Password && e.Status == "A").SingleOrDefault();

            if (obj != null)
            {
                //string role = obj.Role;
                //string result = role;

                return obj;


            }
            else
            {
                return "not exist";
            }

        }
        public List<Registration> details
        {
            get
            {
                var albums = this.db.Registrations.Where(e=>e.Role == "notdefined").ToList();
                List<Registration> details = new List<Registration>();
                foreach (var obj in albums)
                {
                    details.Add(new Registration
                    {
                        Rid=obj.Rid,
                        Name = obj.Name,
                        Department = obj.Name,
                        EntryDate = obj.EntryDate,
                        Email = obj.Email,
                        Phone = obj.Phone,
                        Password = obj.Password,
                        Image = obj.Image,
                        Status = obj.Status,
                        Role = obj.Role,
                        //objentreg.Image = details[0].Image;
           

                    });
                }
                return details;
            }
        }
           public List<Registration> profileview(int id)
            {
            List<Registration> details = new List<Registration>();

            RegisterManager regmngr = new RegisterManager();
            Registration reg_obj = db.Registrations.Find(id);
            if (reg_obj == null)
            {
                return null;
            }
            else
            {
                details.Add(new Registration

                {
                    Rid = reg_obj.Rid,
                    Name = reg_obj.Name,
                    Email = reg_obj.Email,
                    Department = reg_obj.Department,
                    EntryDate = reg_obj.EntryDate,

                    Phone = reg_obj.Phone,
                    Password = reg_obj.Password,
                    Image = reg_obj.Image,
                    Status = reg_obj.Status,
                    Role = reg_obj.Role,


                });
                return details;


            }
        }
           public string editstatus(Registration objmngr)
           {
               Registration reg_obj = db.Registrations.Find(objmngr.Rid);
                 //objmngr.Role= reg_obj.Role;
                 //objmngr.Status = reg_obj.Status;
                 //objmngr.EntryDate= reg_obj.EntryDate;
                 //objmngr.Image = reg_obj.Image;

               reg_obj.Status = "A";
               db.Entry(reg_obj).State = EntityState.Modified;
             //result = db.SaveChanges();
                
           
            int result;
            //this.db.Entry(objmngr).State = EntityState.Modified;
          
            //db.Entry(reg_obj).CurrentValues.SetValues(objmngr);
           
            result = db.SaveChanges();
          
            if (result > 0)
            {

                return "Success";
            }
            else
            {

                return "Error";
            }
        }
      }
  }

       
