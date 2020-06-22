using System.ComponentModel.DataAnnotations;

namespace CashbackManaging.Model.Entities
{
    public class MccCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}