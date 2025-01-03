﻿namespace InvoicesWebApp.Domain.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatAmount { get; set; }
        public VatRate VatRate { get; set; }
        public int VatRateThreshold { get; set; }
        public decimal TotalPrice { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
