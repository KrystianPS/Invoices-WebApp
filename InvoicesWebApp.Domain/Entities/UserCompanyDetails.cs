namespace InvoicesWebApp.Domain.Entities
{
    public class UserCompanyDetails
    {
        public int Id { get; set; }
        public User User { get; set; } //rel
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public string TIN { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //rel
        public List<Invoice> CompanyInvoices { get; set; } = new List<Invoice>();
    }
}
