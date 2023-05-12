﻿namespace OnlineStore.Domain
{
    public class PriceChange
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DateTime DatePriceChange { get; set; }
        public decimal NewPrice { get; set; }
    }
}
