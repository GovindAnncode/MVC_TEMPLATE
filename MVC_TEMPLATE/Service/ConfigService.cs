using MVC_TEMPLATE.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_TEMPLATE.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Grpc.Core;
using System.Net.Http;

namespace MVC_TEMPLATE.Service
{
    public class ConfigService : IConfigService
    {
        public ConfigService()
        {
            
        }

        public List<MenuItems> Menu()
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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

                return itemsList;
            }
            catch (Exception)
            {   
                throw; 
            }
        }
        public void AddUpdateMenu(List<MenuItems> newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.menu.items = JArray.FromObject(newData);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

               
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);
            }
            catch (Exception)
            {      
                throw; 
            }
        }
        public void DeleteSection(MenuItems newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                JArray itemsArray = jsonObject.menu["items"];

                for (int i = 0; i < itemsArray.Count; i++)
                {
                    dynamic item = itemsArray[i];

                    if ((int)item["id"] == newData.id &&
                        (string)item["platform_collection_id"] == newData.platform_collection_id &&
                        (string)item["platform_product_id"] == newData.platform_product_id &&
                        (string)item["image_url"] == newData.image_url &&
                        (string)item["title"] == newData.title &&
                        (string)item["page_url"] == newData.page_url)
                    {
                        itemsArray.RemoveAt(i);
                        break;
                    }
                }

                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);
            }
            catch (Exception)
            {
                throw;
            }    
        }

        public List<Rules> Rules()
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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

                return itemsList;
            }
            catch(Exception) 
            { 
                throw;
            }
            
        }

        public void AddUpdateRules(List<Rules> newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.buy_more_save_more.Rules = JArray.FromObject(newData);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);          
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRule(Rules newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Welcome_Banner> Welcome_Banner()
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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

                return itemsList;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void AddUpdateWelcomeBanner(List<Welcome_Banner> newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.WELCOME_BANNER.data = JArray.FromObject(newData);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);
             
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteWelcomeBanner(Welcome_Banner newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> Colors()
        {
            string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

            JObject jsonObject = JObject.Parse(jsonContent);
            JObject colorsObject = jsonObject["colors"].ToObject<JObject>();

            Dictionary<string, string> colorData = new Dictionary<string, string>();
            foreach (var property in colorsObject.Properties())
            {
                colorData.Add(property.Name, property.Value.ToString());
            }

            return colorData;
        }

        public void SaveColors(List<ColorConfigRequestDto> formData)
        {
            string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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
        }

        public List<return_reasons> return_reasons()
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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

                return itemsList;
            }
            catch
            {
                throw;
            }
        }

        public void AddUpdateReturn_reasons(List<return_reasons> newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.return_reasons = JArray.FromObject(newData);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteReturnReasons(return_reasons newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SortCollection> SortCollection()
        {
            string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            List<SortCollection> itemsList = new List<SortCollection>();

            foreach (var itemData in jsonObject["SortCollection"])
            {
                SortCollection item = new SortCollection()
                {
                    id = (int)itemData["id"],
                    platform_collection_id = (string)itemData["platform_collection_id"],
                    title = (string)itemData["title"]

                };

                itemsList.Add(item);
            }

            return itemsList;
        }

        public void AddUpdateSortCollection(List<SortCollection> newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                jsonObject.SortCollection = JArray.FromObject(newData);
                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSortCollection(SortCollection newData)
        {
            try
            {
                string jsonFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~//jsconfig.json"));
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                JArray rulesArray = jsonObject.SortCollection;

                for (int i = 0; i < rulesArray.Count; i++)
                {
                    dynamic rule = rulesArray[i];

                    if ((int)rule["id"] == newData.id &&
                        (string)rule["platform_collection_id"] == newData.platform_collection_id &&
                        (string)rule["title"] == newData.title
                        )
                    {
                        rulesArray.RemoveAt(i);
                        break;
                    }
                }

                string updatedJsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonData);       
            }
            catch (Exception)
            {
                throw;
            }
        }  
    }
}