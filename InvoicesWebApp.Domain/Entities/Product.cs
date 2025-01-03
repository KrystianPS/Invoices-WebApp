namespace InvoicesWebApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public User User { get; set; } //rel
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public VatRate VatRate { get; set; }
        public int VatRateId { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
