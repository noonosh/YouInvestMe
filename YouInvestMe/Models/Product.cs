using System.ComponentModel.DataAnnotations;

namespace YouInvestMe.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Display(Name = "Internal ID")]
        public string InternalInstrumentId { get; set; }
        
        [Display(Name = "Display Name")]
        public string InstrumentDisplayName { get; set; }
        
        [Display(Name = "Full name")]
        public string InstrumentName { get; set; }
        
        [Display(Name = "Asset Type")]
        [Required]
        public string AssetType { get; set; }
        
        public string Region { get; set; }
        
        public string Country { get; set; }
        
        [Display(Name = "Price Currency")]
        public string PriceCurrency { get; set; }
        
        [Display(Name = "Closing Price")]
        public float ClosingPrice { get; set; }
        
        [Display(Name = "Risk Level")]
        public int RiskLevelId { get; set; }
        
        public virtual RiskLevel RiskLevel { get; set; }
    }
}
