using System.ComponentModel.DataAnnotations;

namespace CashbackManaging.Model.Entities
{
    public class CardMccGroup
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Card Card { get; set; }
        
        public decimal? CashbackPercentFrom { get; set; }
        
        public decimal? CashbackPercentTo { get; set; }

        public bool IsForChoice { get; set; }
    }
}