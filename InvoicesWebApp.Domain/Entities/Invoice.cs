namespace InvoicesWebApp.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = null;
        public Contractor Contractor { get; set; } //rel
        public int ContractorId { get; set; }
        public User User { get; set; } //rel
        public int UserId { get; set; }
        public UserCompanyDetails UserCompany { get; set; } //rel
        public int UserCompanyId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public bool? IsEmailSent { get; set; }

        //rel
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();


    }
}
