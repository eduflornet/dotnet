namespace NET5.WebApi.DAL.Entities
{
    public class PriceOffer
    {
        public const int PromotionalTextLength = 200;

        public int PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }

        [Required]
        [MaxLength(PromotionalTextLength)]
        public string PromotionalText { get; set; }

        //-----------------------------------------------
        //Relationships

        public int BookId { get; set; }
    }
}
