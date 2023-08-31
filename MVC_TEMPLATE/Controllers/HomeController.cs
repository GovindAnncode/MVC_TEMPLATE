using MVC_TEMPLATE.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_TEMPLATE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopifyService _shopifyService;
        public HomeController()
        {
            string shopifyApiKey = "9873ff53960ffe9567a56d407c5193d7";
            string shopifyPassword = "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";
            string shopifyStoreUrl = "quickstart-4c72b137.myshopify.com";

            _shopifyService = new ShopifyService(shopifyApiKey, shopifyPassword, shopifyStoreUrl);
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Menu()
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json"); 

            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            List<MenuItems> itemsList = new List<MenuItems>();

            foreach (var itemData in jsonObject.menu["items"])
            {
                MenuItems item = new MenuItems()
                {
                    id = (int)itemData["id"],
                    platform_collection_id = (string)itemData["platform_collection_id"],
                    platform_product_id = (string)itemData["platform_product_id"],
                    image_url = (string)itemData["image_url"],
                    title = (string)itemData["title"],
                    page_url = (string)itemData["page_url"]
                   
                };

                itemsList.Add(item);
            }

            return View(itemsList);
        }


        public ActionResult AddMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUpdateMenu(List<MenuItems> newItem)
        {
            try
            {
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.menu.items = JArray.FromObject(newItem);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

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
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                JArray rulesArray = jsonObject.menu["items"];

                for (int i = 0; i < rulesArray.Count; i++)
                {
                    dynamic rule = rulesArray[i];

                    if ((int)rule["id"] == newData.id &&
                        (string)rule["platform_collection_id"] == newData.platform_collection_id &&
                        (string)rule["platform_product_id"] == newData.platform_product_id &&
                        (string)rule["image_url"] == newData.image_url &&
                        (string)rule["title"] == newData.title &&
                        (string)rule["page_url"] == newData.page_url)
                    {
                        rulesArray.RemoveAt(i);
                        break;
                    }
                }

                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

                return Json(new { success = true, message = "Data deleted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting data." });
            }
        }
        public ActionResult Rules()
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json"); 

            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            List<Rules> itemsList = new List<Rules>();
            foreach (var itemData in jsonObject.buy_more_save_more["Rules"])
            {
                Rules item = new Rules()
                {

                    product_min_count = (int)itemData["product_min_count"],
                    product_max_count = (int)itemData["product_max_count"],
                    free_shipping = (bool)itemData["free_shipping"],
                    discount_percentage = (int)itemData["discount_percentage"],
                    message = (string)itemData["message"],
                    applied_msg = (string)itemData["applied_msg"]
                };

                itemsList.Add(item);
            }

            return View(itemsList);
        }

        [HttpPost]
        public ActionResult AddUpdateRules(List<Rules> newItem)
        {
            try
            {
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.buy_more_save_more.Rules = JArray.FromObject(newItem);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

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
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                JArray rulesArray = jsonObject.buy_more_save_more["Rules"];

                for (int i = 0; i < rulesArray.Count; i++)
                {
                    dynamic rule = rulesArray[i];

                    if ((int)rule["product_min_count"] == newData.product_min_count &&
                        (int)rule["product_max_count"] == newData.product_max_count &&
                        (bool)rule["free_shipping"] == newData.free_shipping &&
                        (int)rule["discount_percentage"] == newData.discount_percentage &&
                        (string)rule["message"] == newData.message &&
                        (string)rule["applied_msg"] == newData.applied_msg)
                    {
                        rulesArray.RemoveAt(i);
                        break;
                    }
                }

                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

                return Json(new { success = true, message = "Data deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting data." });
            }
        }
        public ActionResult Welcome_Banner()
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json"); 

            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

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

            return View(itemsList);
        }

        [HttpPost]
        public ActionResult AddUpdateWelcomeBanner(List<Welcome_Banner> newData)
        {
            try
            {
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.WELCOME_BANNER.data = JArray.FromObject(newData);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

                return Json(new { success = true, message = "Data saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving data." });
            }
        }

        [HttpPost]
        public ActionResult DeleteWelcomeBanner(Welcome_Banner newData)
        {
            try
            {
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                JArray rulesArray = jsonObject.WELCOME_BANNER["data"];

                for (int i = 0; i < rulesArray.Count; i++)
                {
                    dynamic rule = rulesArray[i];

                    if ((int)rule["id"] == newData.id &&
                        (string)rule["banner_image_url"] == newData.banner_image_url)
                    {
                        rulesArray.RemoveAt(i);
                        break;
                    }
                }

                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

                return Json(new { success = true, message = "Data deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting data." });
            }
        }
        public ActionResult GetColors()
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json");
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

            JObject jsonObject = JObject.Parse(jsonContent);
            JObject colorsObject = jsonObject["colors"].ToObject<JObject>(); 

            Dictionary<string, string> colorData = new Dictionary<string, string>();
            foreach (var property in colorsObject.Properties())
            {
                colorData.Add(property.Name, property.Value.ToString());
            }

            return View(colorData);
        }

        [HttpPost]
        public ActionResult SaveColors(List<ColorConfigRequestDto> formData)
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);

            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            JObject singleColorObject = new JObject();
            foreach (var colorConfig in formData)
            {
                var properties = colorConfig.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var key = property.Name;
                    var value = property.GetValue(colorConfig);
                    singleColorObject[key] = JToken.FromObject(value);
                }
            }

            jsonObject["colors"] = singleColorObject; 
            string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

            return Json(new { success = true });
        }

        public ActionResult return_reasons()
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json");

            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            List<return_reasons> itemsList = new List<return_reasons>();

            foreach (var itemData in jsonObject["return_reasons"])
            {
                return_reasons item = new return_reasons()
                {
                    reason_code = (string)itemData["reason_code"],
                    reason_title = (string)itemData["reason_title"]
                   
                };

                itemsList.Add(item);
            }

            return View(itemsList);
        }

        [HttpPost]
        public ActionResult AddUpdateReturn_reasons(List<return_reasons> newData)
        {
            try
            {
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.return_reasons = JArray.FromObject(newData);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

                return Json(new { success = true, message = "Data saved successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while saving data." });
            }
        }
        [HttpPost]
        public ActionResult DeleteReturnReason(return_reasons newData)
        {
            try
            {
                string jsonFilePath = Server.MapPath("~//jsconfig.json");
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                JArray rulesArray = jsonObject.return_reasons;

                for (int i = 0; i < rulesArray.Count; i++)
                {
                    dynamic rule = rulesArray[i];

                    if ((string)rule["reason_code"] == newData.reason_code &&
                        (string)rule["reason_title"] == newData.reason_title)
                    {
                        rulesArray.RemoveAt(i);
                        break;
                    }
                }

                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

                return Json(new { success = true, message = "Data deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while deleting data." });
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


    }
}


