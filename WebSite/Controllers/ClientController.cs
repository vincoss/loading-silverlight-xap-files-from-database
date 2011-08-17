using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebSite.Controllers
{
    public class ClientController : Controller
    {
        private readonly IDataService _dataService;

        public ClientController()
        {
            _dataService = new DataService();
        }

        public ActionResult Index(string id)
        {
            ViewBag.ModuleName = id;

            return View();
        }

        public ActionResult Find(string id)
        {
            var model = _dataService.GetStream(id);
            if (model != null)
            {
                return new FileContentResult(model.Data, model.ContentType);
            }
            return HttpNotFound();
        }
    }
}