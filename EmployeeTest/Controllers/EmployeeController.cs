using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeTest.Entities;
using System.Linq.Dynamic;
using EmployeeTest.Models;

namespace EmployeeTest.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //private EmployeeEntities db = new EmployeeEntities();
        // GET: Employee
        public ActionResult Index()
        {

            List<Employee> m;
            using (var r = new EmployeeEntities())
            {
                m = r.Employees.ToList();
            }

            //var db = new EmployeeEntities();
            //List<Employee> emp;
            //using (var r = new EmployeeEntities())
            //{
            //    emp = r.Employees.Join(r.MLevels).ToList();
            //}

            //var query = EmployeeEntities...Join(db.BankTransactions,
            // acc => acc.AccountID,
            // bank => bank.AccountID,
            // (acc, bank) => new { Account = acc, BankTransaction = bank });

            //var dealerContracts = DealerContact.Join(Dealer,
            //                     contact => contact.DealerId,
            //                     dealer => dealer.DealerId,
            //                     (contact, dealer) => contact);

            //var getPhotos = (from m in db.Employees
            //                 join n in db.MLevels on m.level equals n.Id
            //                 where n.ownerName == User.Identity.Name
            //                 orderby n.id descending
            //                 select new CommentsViewModel
            //                 {
            //                     ImageCrop = m.imgcrop,
            //                     MessageId = m.id,
            //                     CommenterName = n.commenterName,
            //                     Comment = n.comment
            //                 }).Take(10).ToList();

            //using (var ctx = new EmployeeEntities())
            //{
            //    string name = "Bill";
            //    var student = ctx.Employees.Join(ctx.MLevels,)
            //                  .Where(s => s.StudentName == name)
            //                  .FirstOrDefault<Student>();
            //}

            //var query = db.Employees.Join(db.MLevels,
            //            a => a.Id,
            //            b => b.level,
            //            (a, b) => a.level)
            //       .Distinct();

            //EmployeeEntities db = new EmployeeEntities();

            //var result = from x in db.Employees
            //             join y in db.MLevels
            //             on new { X1 = x.level } equals new { X1 = y.level }
            //             select new
            //             {
            //                 x.Id,
            //                 x.name,
            //                 x.alamat,
            //                 x.email,
            //                 x.join_date,
            //                 x.status,
            //                 y.level
            //             };

            //var results = (from c in db.Employees
            //               join cn in db.MLevels on c.level equals cn.Id
            //               select new
            //               {
            //                   c.Id,
            //                   c.name,
            //                   c.alamat,
            //                   c.email,
            //                   c.join_date,
            //                   c.status,
            //                   cn.level
            //               }).ToList();

            return View(m);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            List<MLevel> mlevel;
            using (var r = new EmployeeEntities())
            {
                mlevel = r.MLevels.ToList();
            }
            ViewBag.Types = new SelectList(mlevel.ToArray(), "level", "level", "0");
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            //if (!ModelState.IsValid)
            //{
            //    List<MLevel> mlevel;
            //    using (var r = new EmployeeEntities())
            //    {
            //        mlevel = r.MLevels.ToList();
            //    }
            //    ViewBag.Types = new SelectList(mlevel.ToArray(), "level", "level", "0");
            //    return View(model);
            //}
            var employeemodel = new Employee();
            TryUpdateModel(employeemodel);

            using (var r = new EmployeeEntities())
            {
                r.Employees.Add(employeemodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Employee");
            }
            var menumodel = new Employee();
            TryUpdateModel(menumodel);

            using (var r = new EmployeeEntities())
            {
                menumodel = r.Employees.FirstOrDefault(x => x.Id == Id);
            }

            return View(menumodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit_Get(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Employee");
            }
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                List<MLevel> mlevel2;
                using (var r = new EmployeeEntities())
                {
                    mlevel2 = r.MLevels.ToList();
                }
                ViewBag.Types = new SelectList(mlevel2.ToArray(), "level", "level", "0");
                return View();
            }

            var menumodel = new Employee();
            TryUpdateModel(menumodel);

            using (var r = new EmployeeEntities())
            {
                menumodel = r.Employees.Where(x => x.Id == Id).FirstOrDefault();
            }

            List<MLevel> mlevel;
            using (var r = new EmployeeEntities())
            {
                mlevel = r.MLevels.ToList();
            }
            ViewBag.Types = new SelectList(mlevel.ToArray(), "level", "level", "0");

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int Id)
        {
            var menumodel = new Employee();
            TryUpdateModel(menumodel);

            using (var r = new EmployeeEntities())
            {
                var m = r.Employees.Where(x => x.Id == Id).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Employee");
            }
            var menumodel = new Employee();
            TryUpdateModel(menumodel);

            using (var r = new EmployeeEntities())
            {
                menumodel = r.Employees.FirstOrDefault(x => x.Id == Id);
            }

            return View(menumodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int Id)
        {
            var menumodel = new Employee();
            TryUpdateModel(menumodel);

            using (var r = new EmployeeEntities())
            {
                var m = r.Employees.Remove(r.Employees.FirstOrDefault(x => x.Id == Id));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult LoadData()
        {
            try
            {
                //Creating instance of DatabaseContext class  
                using (EmployeeEntities _context = new EmployeeEntities())
                {
                    var draw = Request.Form.GetValues("draw").FirstOrDefault();
                    var start = Request.Form.GetValues("start").FirstOrDefault();
                    var length = Request.Form.GetValues("length").FirstOrDefault();
                    var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                    var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                    var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                    //Paging Size (10,20,50,100)    
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                    int skip = start != null ? Convert.ToInt32(start) : 0;
                    int recordsTotal = 0;

                    // Getting all Customer data    
                    var employeeData = (from tempcustomer in _context.Employees
                                        select tempcustomer);

                    //Sorting    
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                    {
                        employeeData = employeeData.OrderBy(sortColumn + " " + sortColumnDir);
                    }
                    //Search    
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        employeeData = employeeData.Where(m => m.name.ToLower().Contains(searchValue.ToLower()) ||
                                                           m.alamat.ToLower().Contains(searchValue.ToLower()) ||
                                                           m.email.ToLower().Contains(searchValue.ToLower()) ||
                                                           m.level.ToLower().Contains(searchValue.ToLower()) ||
                                                           m.status.ToString().Contains(searchValue.ToLower())
                        );
                        //employeeData = employeeData.Where(x => x.name.ToLower().Contains(searchValue.ToLower())
                        //                      || x.alamat.ToLower().Contains(searchValue.ToLower())
                        //                      || x.email.ToLower().Contains(searchValue.ToLower())
                        //                      || x.level.ToString().Contains(searchValue.ToLower())
                        //                      || x.status.ToString().Contains(searchValue.ToLower())
                        //                      || x.join_date.ToString("dd'/'MM'/'yyyy").ToLower().Contains(searchValue.ToLower()));

                    }

                    //total number of rows count     
                    recordsTotal = employeeData.Count();
                    //Paging     
                    var data = employeeData.Skip(skip).Take(pageSize).ToList();
                    //Returning Json Data    
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}