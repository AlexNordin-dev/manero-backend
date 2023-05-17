﻿using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero_backend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public Task AddAsync(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public Task<CategoryEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductEntity>> GetBySearchAndFilterAsync(SearchFilterCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryEntity>> GetBySearchAsync(Expression<Func<ProductEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryEntity>> GetByTypeIdAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }      
    }
}
