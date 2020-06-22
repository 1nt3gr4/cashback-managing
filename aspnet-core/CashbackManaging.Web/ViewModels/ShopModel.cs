using System.Collections.Generic;

namespace CashbackManaging.ViewModels
{
    public class ShopModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal[] Position { get; set; }

        public int MccCode { get; set; }

        public ICollection<CardMccCodeCashbackModel> CardCashbacks { get; set; }
    }
}