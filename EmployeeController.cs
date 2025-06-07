using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManagementEntities _context = new EmployeeManagementEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public List<DepartmentMaster> Deplist()
        {
            return _context.DepartmentMasters.Where(s => s.DepartmentID != 0).ToList();
        }

        public List<RankMaster> Ranklist()
        {
            return _context.RankMasters.Where(s => s.RankID != 0).ToList();
        }

        public ActionResult Add(int id = 0)
        {
            ViewBag.deparmnetdata = Deplist();
            ViewBag.rankdata = Ranklist();

            if (id == 0)
            {
                // Return empty model for new entry
                return View(new EmployeMaster());
            }

            // Fetch existing employee for edit
            var emp = _context.EmployeMasters.FirstOrDefault(e => e.EmployeeID == id);

            if (emp == null)
            {
                // Handle case where employee doesn't exist
                return HttpNotFound();
            }

            return View(emp);
        }

        [HttpPost]
        public ActionResult Add(EmployeMaster model)
        {
            if(model.EmployeeID > 0)
            {
                _context.EmployeMasters.Add(model);
                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                _context.EmployeMasters.Add(model);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var data = (from emp in _context.EmployeMasters
                        join dept in _context.DepartmentMasters
                        on emp.DepartmentID equals dept.DepartmentID
                        join rank in _context.RankMasters on emp.RankID equals rank.RankID
                        where emp.EmployeeID != 0
                        select new empmodel
                        {
                            EmployeeID = emp.EmployeeID,
                            Name = emp.Name,
                            Gender = emp.Gender,
                            Address = emp.Address,
                            MobileNo = emp.MobileNo,
                            Email = emp.Email,
                            Salary = emp.Salary,
                            Bonus = emp.Bonus,
                            Designation = emp.Designation,
                            DepartmentName = dept.DepartmentName,
                            Rank = rank.Rank
                        }).ToList();

            return View(data);
        }


        public ActionResult Delete(int id)
        {
            var emp = _context.EmployeMasters.Where(s => s.EmployeeID == id).FirstOrDefault();
            if (emp != null)
            {
                _context.EmployeMasters.Remove(emp);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}