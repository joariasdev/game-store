using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public double Total { get; set; } = 0;
        public double CalculatedTotal => InvoiceItems?.Sum(item => item.Total) ?? 0;
        public string Status { get; set; } = "Open";
        public Customer? Customer { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
