using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class TeachersController : Controller
    {
        Models.TeachDBEntities tdb = new Models.TeachDBEntities();
        //
        // GET: /Teachers/

        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult GetTeachers() {
        //    var teachers = from t in tdb.Teachers
        //                  join d in tdb.Departments on t.DeptID equals d.ID
        //                  select new
        //                  {
        //                      ID = t.ID,
        //                      departmentName = d.Name,
        //                      Name = t.Name,
        //                      TeacherNo=t.TeacherNo,
        //                      IsLogin = t.IsLogin
        //                  };
        //    return Json(teachers);
        //}

        /// <summary>
        /// 根据用户传来的页号（1开始），和每页的行数，来获取对应页的记录
        /// 返回给客户端的数据有一个格式：{total:num,rows:[{},{}]}
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public ActionResult GetTeachers(int page,int rows)  //2,10
        {
            var depid = -1;
            int nums = 0;
            tdb.Teachers.Count(); //总记录数量

            var teachers = (from t in tdb.Teachers
                            join d in tdb.Departments on t.DeptID equals d.ID
                            orderby t.ID
                            select new
                            {
                                ID = t.ID,
                                departmentName = d.Name,
                                Name = t.Name,
                                TeacherNo = t.TeacherNo,
                                IsLogin = t.IsLogin
                            }
                             ).Skip((page-1) * rows).Take(rows);
                          ;
            var obj = new {total=nums,rows=teachers};

            return Json(obj,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddTeacher(Models.Teachers teacher)
        {
            try
            {
                //TODO:默认密码，后续需要从配置文件中读取
                teacher.Password = "123";
                tdb.Teachers.Add(teacher);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        public ActionResult ResetPass(int id)
        {
            try
            {
                var teacher = tdb.Teachers.Single(t => t.ID == id);
                teacher.Password = "123";
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
