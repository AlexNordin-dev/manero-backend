﻿using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface ICategoryRepository 
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategoryAsync();
    }
}
