using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
  public class TeacherManager
    {
        MainProjectContext db = new MainProjectContext();

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

        public string studentedit(Registration objmngr)
        {
            Registration reg_obj = db.Registrations.Find(objmngr.Rid);
            objmngr.Role = reg_obj.Role;
            objmngr.Status = reg_obj.Status;
            objmngr.EntryDate = reg_obj.EntryDate;
            objmngr.Image = reg_obj.Image;




            int result;
            //this.db.Entry(objmngr).State = EntityState.Modified;

            db.Entry(reg_obj).CurrentValues.SetValues(objmngr);

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
