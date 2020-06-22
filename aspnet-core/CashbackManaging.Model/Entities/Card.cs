using System.ComponentModel.DataAnnotations;

namespace CashbackManaging.Model.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        [Required]
        public string ShortName { get; set; }

        [Required]
        public decimal MinCostPerYear { get; set; }

        public decimal? MaxCashbackPercent { get; set; }

        public decimal? DefaultCashbackPercent { get; set; }

        public decimal? CashbackLimitInRubles { get; set; }

        public string Base64Image { get; set; }
    }
}