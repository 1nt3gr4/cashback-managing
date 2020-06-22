using System.ComponentModel.DataAnnotations;

namespace CashbackManaging.Model.Entities
{
    public class UserCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Card Card { get; set; }
    }
}