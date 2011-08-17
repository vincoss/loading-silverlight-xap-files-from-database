using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;


namespace WebSite.Controllers
{
    public class UploadController : Controller
    {
        private readonly IDataService _dataService;

        public UploadController()
        {
            _dataService = new DataService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(bool command, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string contentType = file.ContentType;
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    _dataService.Save(command, fileName, contentType, file.InputStream);
                }
            }
            return RedirectToAction("Index");
        }
    }
}