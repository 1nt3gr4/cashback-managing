using System.Collections.Generic;

namespace CashbackManaging.ViewModels
{
    public class CardModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public decimal MinCostPerYear { get; set; }

        public decimal? MaxCashbackPercent { get; set; }

        public decimal? CashbackLimitInRubles { get; set; }

        public string Base64Image { get; set; }

        public bool HasCurrentUser { get; set; }

        public decimal? DefaultCashbackPercent { get; set; }

        public ICollection<CardMccCodeCashbackModel> CardMccCodeCashbacks { get; set; }
    }
}