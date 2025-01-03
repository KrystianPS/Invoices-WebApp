namespace InvoicesWebApp.Domain.Entities
{
    public class VatRate
    {
        public int Id { get; set; }
        public decimal VatRateThreshold { get; set; }  // unique threshold value
        public string VatRateNameReference { get; set; }

        // rel for invoice items 
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
