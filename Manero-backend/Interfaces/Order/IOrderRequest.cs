﻿using Manero_backend.DTOs.ProductItem;
using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.Interfaces.Order
{
    public interface IOrderRequest : IOrder
    {
        public List<ProductItemOrderModel> ProductItems { get; set; }
    }
}
