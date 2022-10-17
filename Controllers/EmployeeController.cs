using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingKhoiLuan.DAL;
using TrainingKhoiLuan.Models;

namespace TrainingKhoiLuan.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController()
        {
            this.employeeRepository = new EmployeeRepository(new DBModel());
        }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            return Json(employeeRepository.GetEmployees(), JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new employee());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.employees.Where(x => x.employee_id == id).FirstOrDefault<employee>());
                }
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(employee emp)
        {
            
            using(DBModel db=new DBModel()){
                if (emp.employee_id==0)
                {
                    db.employees.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "save successfull" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "update successfull" }, JsonRequestBehavior.AllowGet);
                }
            }
            
        }

        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                employee emp = db.employees.Where(x => x.employee_id == id).FirstOrDefault<employee>();
                db.employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "delete successfull" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}