using System.ComponentModel.DataAnnotations;

namespace YouInvestMe.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public int RiskValue { get; set; }
    }
}
