using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DAL;

namespace ZhaoWanJie.week4B.Controllers
{
    public class DefaultController : Controller
    {
        Fdal d = new Fdal();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Min()
        {
            return View();
        }
        public JsonResult Mins()
        {
            var tr = d.mingXis();
            return Json(tr,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Adds(int ids)
        {
            var res = d.Sele(ids);

            return View(res);
        }
        public JsonResult addmingxi(MingXi m)
        {
            var we = d.Add(m);
            return Json(we,JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Add(int ids)
        //{
        //    var res = d.Sele(ids);

        //    return View(res);
        //}
        public JsonResult Show(int pageindex, int pagesize)
        {
            var list = d.ShowKucun(pageindex,pagesize);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Sele()
        {
            var list = d.Sel();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}