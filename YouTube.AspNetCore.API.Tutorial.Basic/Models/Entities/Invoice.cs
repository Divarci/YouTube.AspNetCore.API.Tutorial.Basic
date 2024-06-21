namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string PONumber { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
