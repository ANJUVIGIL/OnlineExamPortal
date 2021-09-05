using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
  public  class AdminManager
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
    }
}
