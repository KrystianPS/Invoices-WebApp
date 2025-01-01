namespace InvoicesWebApp.Domain.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalPrice { get; set; }

        //rel
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

    }
}
