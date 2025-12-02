using Microsoft.EntityFrameworkCore;
using MvcSportStore.Models;

namespace MvcSportStore.ViewModels
{
    public class ProductRepository
    {
        List<Product> _products;
        public ProductRepository(IEnumerable<Product> products)
        {
            _products = products.ToList();
        }
        private IEnumerable<Product> GetProducts(int productPage, string? category)
        {
            return _products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PagingSettings.ProductPagination)
                    .Take(PagingSettings.ProductPagination);
        }
        private PagingInfo GetPagingInfo(int productPage, string? category)
        {
            var pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.PageItems = PagingSettings.ProductPagination;
            pagingInfo.Category = category;
            if (category == null) 
            {
                pagingInfo.TotalItems = _products.Count(); 
            }
            else
            {
                pagingInfo.TotalItems = _products.Where(p=>p.Category == category).Count();
            }
                
            return pagingInfo;
        }
        public ProductModel GetProductModel(int productPage, string? category)
        {
            var productModel = new ProductModel();
            productModel.Products = GetProducts(productPage, category);
            productModel.PagingInfo = GetPagingInfo(productPage, category);
            return productModel;
        }

    }
}
