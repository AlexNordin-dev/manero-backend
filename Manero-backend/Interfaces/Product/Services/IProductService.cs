﻿using Manero_backend.DTOs.Product;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Services;
using System.Linq.Expressions;

namespace Manero_backend.Interfaces.Product.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProductAsync();
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductResponse>> GetProductByTypeIdAsync(int TypeId);
        //Task<ProductResponse> CreateProductAsync(ProductRequest productRequest);
        Task<ServiceResponse<ProductResponse>> CreateProductAsync(ProductRequest productRequest);
        Task<ProductResponse> UpdateProductAsync(int id, ProductRequest productRequest);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<ProductResponse>> GetProductBySearchAsync(Expression<Func<ProductEntity, bool>> predicate);
        Task<IEnumerable<ProductResponse>> GetFeaturedProductsAsync();
        Task<IEnumerable<ProductResponse>> GetBestSellerProductsAsync();

    }
}
