using MVC_TEMPLATE.Models;
using MVC_TEMPLATE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TEMPLATE.Controllers
{
    public class ConfigSectionController : Controller
    {
        private readonly IConfigService _configService;
        public ConfigSectionController(IConfigService configService)
        {
            _configService = configService;
        }

        public ActionResult Menu()
        {
            try
            {
                List<MenuItems> itemsList = _configService.Menu();
                return View(itemsList);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddUpdateMenu(List<MenuItems> newItem)
        {
            try
            {
                _configService.AddUpdateMenu(newItem);
                return Json(new { success = true, message = "Data saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving data." });
            }
        }

        [HttpPost]
        public ActionResult DeleteSection(MenuItems newData)
        {
            try
            {
                _configService.DeleteSection(newData);
                return Json(new { success = true, message = "Data deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting data." });
            }
        }

        // Rules related methods

        public ActionResult Rules()
        {
            try
            {
                List<Rules> itemsList = _configService.Rules();
                return View(itemsList);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddUpdateRules(List<Rules> newItem)
        {
            try
            {
                _configService.AddUpdateRules(newItem);
                return Json(new { success = true, message = "Data saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving data." });
            }
        }

        [HttpPost]
        public ActionResult DeleteRule(Rules newData)
        {
            try
            {
                _configService.DeleteRule(newData);
                return Json(new { success = true, message = "Rule deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting rule." });
            }
        }

        public ActionResult Welcome_Banner()
        {
            try
            {
                List<Welcome_Banner> itemsList = _configService.Welcome_Banner();
                return View(itemsList);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddUpdateWelcomeBanner(List<Welcome_Banner> newData)
        {
            try
            {
                _configService.AddUpdateWelcomeBanner(newData);
                return Json(new { success = true, message = "Data saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving data." });
            }
        }

        [HttpPost]
        public ActionResult DeleteWelcome_Banner(Welcome_Banner newData)
        {
            try
            {
                _configService.DeleteWelcomeBanner(newData);
                return Json(new { success = true, message = "Welcome banner deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting welcome banner." });
            }
        }

        public ActionResult Colors()
        {
            try
            {
                Dictionary<string, string> colorData = _configService.Colors();
                return View(colorData);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveColors(List<ColorConfigRequestDto> formData)
        {
            try
            {
                _configService.SaveColors(formData);
                return Json(new { success = true, message = "Colors saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving colors." });
            }
        }

        public ActionResult return_reasons()
        {
            try
            {
                List<return_reasons> itemsList = _configService.return_reasons();
                return View(itemsList);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddUpdateReturn_reasons(List<return_reasons> newData)
        {
            try
            {
                _configService.AddUpdateReturn_reasons(newData);
                return Json(new { success = true, message = "Data saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving data." });
            }
        }

        [HttpPost]
        public ActionResult DeleteReturnReasons(return_reasons newData)
        {
            try
            {
                _configService.DeleteReturnReasons(newData);
                return Json(new { success = true, message = "Return reason deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting return reason." });
            }
        }
        public ActionResult SortCollection()
        {
            try
            {
                List<SortCollection> itemsList = _configService.SortCollection();
                return View(itemsList);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddUpdateSortCollection(List<SortCollection> newData)
        {
            try
            {
                _configService.AddUpdateSortCollection(newData);
                return Json(new { success = true, message = "Data saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving data." });
            }
        }

        [HttpPost]
        public ActionResult DeleteSortCollection(SortCollection newData)
        {
            try
            {
                _configService.DeleteSortCollection(newData);
                return Json(new { success = true, message = "Sort collection deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting sort collection." });
            }
        }

    }
}