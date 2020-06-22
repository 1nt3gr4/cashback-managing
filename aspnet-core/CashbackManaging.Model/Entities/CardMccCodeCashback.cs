using System.ComponentModel.DataAnnotations;

namespace CashbackManaging.Model.Entities
{
    public class CardMccCodeCashback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Card Card { get; set; }

        [Required]
        public MccCode MccCode { get; set; }

        [Required]
        public decimal CashbackPercentFrom { get; set; }

        [Required]
        public decimal CashbackPercentTo { get; set; }

        public bool IsForChoice { get; set; }

        public CardMccGroup Group { get; set; }
    }
}