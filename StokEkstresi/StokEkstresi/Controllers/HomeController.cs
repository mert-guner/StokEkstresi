using Newtonsoft.Json;
using StokEkstresi.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokEkstresi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        [HttpPost]
        public string Search(string code, DateTime Start, DateTime Finish)
        {
            int StartDate = Convert.ToInt32(Start.ToOADate());
            int FinishDate = Convert.ToInt32(Finish.ToOADate());  

            List<StockDTO> list = StockDTO.GetListStock(code, StartDate, FinishDate);

            return JsonConvert.SerializeObject(list);
        }


    }
}