using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class ClassesController : Controller
    {
        Models.TeachDBEntities tdb = App_Start.Helper.tdb;
        //
        // GET: /Classes/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetClassesList()
        {
            var classes = from c in tdb.Classes
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name
                          };
            return Json(classes,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetClassesListByMajorId(int majorId)
        {
            var classes = from c in tdb.Classes
                          where c.MajorID == majorId
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name
                          };
            return Json(classes, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取带班主任信息的班级列表
        /// </summary>
        /// <param name="majorId">专业的id，如果为-1表示所有专业</param>
        /// <returns></returns>
        public ActionResult GetClassesListByMajorIdWithDirector(int majorId)
        {
            var classes = from c in tdb.View_TeacherClasses
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                              MajorId = c.MajorID,
                              TeacherName = c.TeacherName,
                              TeacherNo = c.TeacherNo
                          };
            if(majorId != -1)
            {
                classes = classes.Where(t => t.MajorId == majorId);
            }
            return Json(classes, JsonRequestBehavior.AllowGet);
        }
    }
}
