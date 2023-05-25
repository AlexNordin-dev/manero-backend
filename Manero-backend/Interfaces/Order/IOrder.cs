﻿namespace Manero_backend.Interfaces.Order
{
    public interface IOrder
    {
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

    }
}
