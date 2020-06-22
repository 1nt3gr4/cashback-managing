namespace CashbackManaging.ViewModels
{
    public class CardMccCodeCashbackModel
    {
        public int Id { get; set; }

        public MccCodeModel MccCode { get; set; }

        public string CardName { get; set; }

        public decimal CashbackPercentFrom { get; set; }

        public decimal CashbackPercentTo { get; set; }
    }
}