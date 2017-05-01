using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class MajorsController : Controller
    {
        Models.TeachDBEntities tdb = new Models.TeachDBEntities();
        //
        // GET: /Majars/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetMajors()
        {
            //1、LinQ的关联语句
            //2、在数据库中建视图
            var marjors = from m in tdb.Majors
                          join d in tdb.Departments on m.DepartmentID equals d.ID
                          select new { 
                            ID=m.ID,
                            departmentName=d.Name,
                            Name=m.Name
                          };
            return Json(marjors);
        }
        public ActionResult GetMajorsByDepartmentId(int deptId)
        {
            //1、LinQ的关联语句
            //2、在数据库中建视图
            var marjors = (from m in tdb.Majors
                          where m.DepartmentID == deptId
                          select new
                          {
                              ID = m.ID,
                              Name = m.Name
                          }).ToList();
            marjors.Insert(0,new { ID = -1, Name = "----全部----" });
            return Json(marjors,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddMajor(Models.Majors major)
        {
            try
            {
                tdb.Majors.Add(major);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
    }
}
