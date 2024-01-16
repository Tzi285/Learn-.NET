using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {

        public ProductsController(JsonFileProductService productService)
        {
             this.ProductService = productService;
        }
        public JsonFileProductService ProductService { get;}
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return ProductService.GetProducts();
        } 
        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();
            //LINQ 
            var query = products.First(x => x.Id == productId);
            if(query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
                using (var ouputStream = File.OpenWrite(JsonFileName))
                { 
                
                }
            }
        }
    }
}
