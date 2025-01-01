namespace InvoicesWebApp.Domain.Entities
{
    public class Contractor
    {
        public int Id { get; set; }
        public User User { get; set; } //rel
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TIN { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //rel
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();

    }
}
