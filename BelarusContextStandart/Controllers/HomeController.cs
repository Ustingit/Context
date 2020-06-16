using System.Threading.Tasks;
using System.Web.Mvc;
using BelarusContextStandart.Models.LanguageModels;
using Enum = BelarusContextStandart.Models.LanguageModels.Languages.Enum;

namespace BelarusContextStandart.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(TranslateModel.Default);
        }

        //ajax partial - https://metanit.com/sharp/mvc5/10.2.php , install "unobtrusive-ajax" from NuGet
        [HttpPost]
        public ActionResult Translations(string data, Enum fromLang, bool reverse, Enum toLang)
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