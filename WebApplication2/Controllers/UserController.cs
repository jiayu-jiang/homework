using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            List<SelectListItem> ls = GetList();
            ViewBag.ddl = ls;
            return View();        
        }

        [ChildActionOnly]
        public ActionResult Table()
        {
            LoginViewModel la = new LoginViewModel();
            InitData(la);
            return View(la);
        }

        private static void InitData(LoginViewModel la)
        {
            la.Tables = new List<GetTable>(){
            new GetTable() { Sn="1",Class="支出",Date="2016-01-01",Money="300" },
            new GetTable() { Sn="2",Class="支出",Date="2016-01-02",Money="1,600" },
            new GetTable() { Sn="3",Class="支出",Date="2016-01-03",Money="800" }
            };
        }
        public List<SelectListItem> GetList()
        {
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();
            mySelectItemList.Add(new SelectListItem()
            {
                Text = "請選擇",
                Value = "0",
                Selected = true
            });
            mySelectItemList.Add(new SelectListItem()
            {
                Text = "支出",
                Value = "1",
                Selected = false
            });
            mySelectItemList.Add(new SelectListItem()
            {
                Text = "收入",
                Value = "2",
                Selected = false
            });
            return mySelectItemList;
        }
    }
}