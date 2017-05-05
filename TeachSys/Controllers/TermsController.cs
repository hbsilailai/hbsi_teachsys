using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class TermsController : Controller
    {
        Models.TeachDBEntities tdb = App_Start.Helper.tdb;
        //
        // GET: /Terms/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var term = tdb.Terms.First(t => t.ID == id);
            return View(term);
        }
        public ActionResult AddTerm(Models.Terms term)
        {
            try
            {
                tdb.Terms.Add(term);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        public ActionResult EditTerm(Models.Terms term)
        {
            try
            {
                var te = tdb.Terms.First(t => t.ID == term.ID);
                te.Name = term.Name;
                te.Status = term.Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var term = tdb.Terms.First(t => t.ID == id);
                tdb.Terms.Remove(term);
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
