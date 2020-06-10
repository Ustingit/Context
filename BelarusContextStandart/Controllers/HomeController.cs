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

        [HttpPost]
        public ActionResult Translations(string data, Guid fromLang, bool reverse, Guid toLang)
        {
            var formData = new TranslateModel(fromLang, toLang, data, reverse);
            var translatedResult = Models.TemporaryLanguageData.TempDataProvider.GetTranslation(formData);

            return PartialView(translatedResult.Data);
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