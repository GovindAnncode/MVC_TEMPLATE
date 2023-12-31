﻿using MVC_TEMPLATE.Models;
using MVC_TEMPLATE.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_TEMPLATE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopifyService _shopifyService;
        private readonly IConfigService _configService;
        public HomeController(IConfigService configService)
        {
            string shopifyApiKey = "9873ff53960ffe9567a56d407c5193d7";
            string shopifyPassword = "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";
            string shopifyStoreUrl = "quickstart-4c72b137.myshopify.com";

            _configService = configService;
            _shopifyService = new ShopifyService(shopifyApiKey, shopifyPassword, shopifyStoreUrl);
        }
        public ActionResult Index()
        {

            return View();
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
        public async Task<ActionResult> Products()
        {
            var products = await _shopifyService.GetProducts();

            var productModels = products.Select(p => new ProductModel
            {
                ProductId = (long)p.Id,
                Title = p.Title,
                Description = p.BodyHtml,
                CreatedAt = p.CreatedAt.ToString(),
                Images = p.Images.Select(image => image.Src).ToList()
            }).ToList();

            return View("_Products", productModels);
        }

        [HttpPost]
        public async Task<ActionResult> SaveSelectedProductsAsync(List<selectProductModel> selectedProducts)
        {
            using (var dbContext = new ShopifyDataEntities())
            {
                long shopId = await _shopifyService.GetShopIdAsync();

                foreach (var product in selectedProducts)
                {
                    var selectedProduct = new tbSelectedProduct
                    {
                        ProductId = product.ProductId,
                        Product_Title = product.Product_Title,
                        CreatedOn = product.CreatedOn.ToString(),
                        ShopId = shopId
                    };

                    dbContext.tbSelectedProducts.Add(selectedProduct);
                }
                dbContext.SaveChanges();
            }
            return Json(new { success = true });
        }

        public List<Welcome_Banner> WelcomeBanner()
        {
            string shopName = Request.Cookies["ShopName"].Value;
            string content = System.IO.File.ReadAllText(Path.Combine(Server.MapPath($"~/ShopConfig/{shopName}_Config.json")));

            dynamic jsonObject = JsonConvert.DeserializeObject(content);

            List<Welcome_Banner> itemsList = new List<Welcome_Banner>();

            foreach (var itemData in jsonObject.WELCOME_BANNER["data"])
            {
                Welcome_Banner item = new Welcome_Banner()
                {
                    id = (int)itemData["id"],
                    banner_image_url = (string)itemData["banner_image_url"],

                };

                itemsList.Add(item);
            }

            return itemsList;
        }


    }
}


