using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BelarusContextStandart.Models.LanguageModels;

namespace BelarusContextStandart.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(TranslateModel.Default);
        }

        [HttpGet]
        public ActionResult GetTranslation(TranslateModel data)
        {
            var translatedResult = Models.TemporaryLanguageData.TempDataProvider.GetTranslation(data);

            return PartialView("Translations", translatedResult);
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
    }
}