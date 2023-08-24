using ShopifySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;

namespace MVC_TEMPLATE
{
    public class ShopifyService
    {
        private readonly string _shopifyStoreUrl;
        private readonly string _shopifyApiKey;
        private readonly string _shopifyPassword;

        public ShopifyService(string shopifyApiKey, string shopifyPassword, string shopifyStoreUrl)
        {
            _shopifyStoreUrl = shopifyStoreUrl;
            _shopifyApiKey = shopifyApiKey;
            _shopifyPassword = shopifyPassword;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var service = new ProductService(_shopifyStoreUrl, _shopifyPassword);
            var productList = await service.ListAsync();

            var products = productList.Items;

            return products;
        }

        public async Task<long> GetShopIdAsync()
        {
            var service = new ShopService(_shopifyStoreUrl, _shopifyPassword);

            var shop = await service.GetAsync();

            if (shop != null)
            {
                return shop.Id.Value;
            }

            return 0; // Return 0 if shop information not retrieved
        }


    }
}