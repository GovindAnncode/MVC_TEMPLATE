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
            // Replace with your actual Shopify API credentials and store URL
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
            string jsonFilePath = Server.MapPath("~//jsconfig.json"); // Path to your json file

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
            string jsonFilePath = Server.MapPath("~//jsconfig.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            foreach (var newItemData in newItem)
            {
                bool itemExists = false;

                foreach (var itemData in jsonObject.menu["items"])
                {
                    if ((int)itemData["id"] == newItemData.id)
                    {
                        itemData["platform_collection_id"] = newItemData.platform_collection_id;
                        itemData["platform_product_id"] = newItemData.platform_product_id;
                        itemData["image_url"] = newItemData.image_url;
                        itemData["title"] = newItemData.title;
                        itemData["page_url"] = newItemData.page_url;
                        // Update other fields
                        itemExists = true;
                        break;
                    }
                }

                if (!itemExists)
                {
                    // Create a new item and add it to the "items" array
                    var newItemObject = new MenuItems
                    {
                        id = newItemData.id,
                        platform_collection_id = newItemData.platform_collection_id,
                        platform_product_id = newItemData.platform_product_id,
                        image_url = newItemData.image_url,
                        title = newItemData.title,
                        page_url = newItemData.page_url
                        // Add other fields
                    };

                    jsonObject.menu["items"].Add(JObject.FromObject(newItemData));
                }
            }

            // Serialize the updated JSON object and write it back to the file
            string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

            return RedirectToAction("Menu", "Home");
        }

        [HttpPost]
        public ActionResult DeleteSection(int sectionId)
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            // Find and remove the section with the specified ID
            for (int i = 0; i < jsonObject.menu["items"].Count; i++)
            {
                if ((int)jsonObject.menu["items"][i]["id"] == sectionId)
                {
                    jsonObject.menu["items"].RemoveAt(i);
                    break;
                }
            }

            // Serialize the updated JSON object and write it back to the file
            string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

            return RedirectToAction("Menu", "Home");
        }

        public ActionResult Rules()
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json"); // Path to your json file

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
            string jsonFilePath = Server.MapPath("~//jsconfig.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            // Update the "Rules" section
            jsonObject.buy_more_save_more.Rules = JArray.FromObject(newItem);

            // Serialize the updated JSON object and write it back to the file
            string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

            return RedirectToAction("Rules", "Home");
        }



        [HttpPost]
        public ActionResult DeleteRule(int sectionId)
        {
            string jsonFilePath = Server.MapPath("~//jsconfig.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            // Find and remove the section with the specified ID
            for (int i = 0; i < jsonObject.buy_more_save_more["Rules"].Count; i++)
            {
                if ((int)jsonObject.buy_more_save_more["Rules"][i]["product_min_count"] == sectionId)
                {
                    jsonObject.buy_more_save_more["Rules"].RemoveAt(i);
                    break;
                }
            }

            // Serialize the updated JSON object and write it back to the file
            string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

            return RedirectToAction("Rules", "Home");
        }

        public async Task<ActionResult> Products()
        {
            var products = await _shopifyService.GetProducts(); // Fetch Shopify products here
  
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
                        ShopId = shopId // Associate the ShopId with the selected product
                    };

                    dbContext.tbSelectedProducts.Add(selectedProduct);
                }
                dbContext.SaveChanges();
            }
            return Json(new { success = true });
        }
    }
}