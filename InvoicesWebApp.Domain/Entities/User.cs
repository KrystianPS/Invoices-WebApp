namespace InvoicesWebApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public UserCompanyDetails UserCompany { get; set; } //rel
        public int UserCompanyId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public string Role { get; set; }


        //rel
        public List<Contractor> Contractors { get; set; } = new List<Contractor>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
