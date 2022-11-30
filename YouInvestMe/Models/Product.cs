namespace YouInvestMe.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public virtual RiskLevel? RiskLevel { get; set; }
    }
}
