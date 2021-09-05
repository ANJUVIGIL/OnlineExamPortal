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
  public  class QuestionManager
    {
     
        MainProjectContext db = new MainProjectContext();
        public string AddQuestions(Question objreg)
        {
            int result;
            var objuser = db.Questions.Where(e => e.Question1 == objreg.Question1 ).SingleOrDefault();
            if (objuser == null)
            {
                try
                {
                    
                    db.Questions.Add(objreg);
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
                objuser.Question1 = objreg.Question1;
               
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


        public void AddChoices(Choice objreg)
        {
                  
                   

                    db.Choices.Add(objreg);
                    db.SaveChanges();
                

                


        }
    }
}
