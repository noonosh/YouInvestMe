namespace YouInvestMe.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string InternalInstrumentId { get; set; } = string.Empty;
        public string InstrumentDisplayName { get; set; } = string.Empty;
        public string InstrumentName { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PriceCurrency { get; set; } = string.Empty;
        public string ClosingPrice { get; set; } = string.Empty;
        public int RiskLevelId { get; set; }
        public virtual RiskLevel? RiskLevel { get; set; }
    }
}
