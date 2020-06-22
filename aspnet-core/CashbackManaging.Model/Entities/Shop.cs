using System.ComponentModel.DataAnnotations;

namespace CashbackManaging.Model.Entities
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        public string Url { get; set; }

        public MccCode MccCode { get; set; }
    }
}