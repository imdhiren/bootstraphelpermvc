using BootStrapHelpers.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapHelpers.Web.Controllers
{
    public class BootStrapController : Controller
    {
        // GET: BootStrap
        public ActionResult Index()
        {
            MainViewModel mainViewModel = new MainViewModel();

            var dateViewModel = new DateViewModel();
            TryUpdateModel(dateViewModel);

            mainViewModel.DateViewModel = dateViewModel;
            return View(mainViewModel);
        }
    }
}