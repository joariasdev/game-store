using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public double Price { get; set; } = 0;
        public double Total => Price * Quantity;
        public Invoice? Invoice { get; set; }
        public Product? Product { get; set; }
    }
}
