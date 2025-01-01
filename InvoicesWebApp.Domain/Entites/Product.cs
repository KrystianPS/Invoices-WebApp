namespace InvoicesWebApp.Domain.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public User User { get; set; } //rel
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal VatRate { get; set; }
        public int QuantityInStock { get; set; }
    }
}
