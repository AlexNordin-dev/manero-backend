﻿namespace Manero_backend.Interfaces.Order
{
    public interface IOrder
    {
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}