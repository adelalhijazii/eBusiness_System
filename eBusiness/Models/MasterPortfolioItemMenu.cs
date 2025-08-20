namespace eBusiness.Models
{
    public class MasterPortfolioItemMenu : BaseEntity
    {
        public int MasterPortfolioItemMenuId { get; set; }

        public int MasterPortfolioCategoryMenuId { get; set; }

        public string MasterPortfolioItemMenuTitle { get; set; }

        public string MasterPortfolioItemMenuBreef { get; set; }

        public string MasterPortfolioItemMenuImageUrl { get; set; }

        public MasterPortfolioCategoryMenu MasterPortfolioCategoryMenu { get; set; }

        public string MasterPortfolioItemMenuDetailsTitle { get; set; }

        public string MasterPortfolioItemMenuDetailsDescription1 { get; set; }

        public string MasterPortfolioItemMenuDetailsDescription2 { get; set; }

        public string MasterPortfolioItemMenuDetailsQuote { get; set; }

        public string MasterPortfolioItemMenuDetailsImageUrl { get; set; }

        public string MasterPortfolioItemMenuDetailsName { get; set; }

        public string MasterPortfolioItemMenuDetailsPosition { get; set; }

        public string MasterPortfolioItemMenuDetailsProjectCategory { get; set; }

        public string MasterPortfolioItemMenuDetailsProjectClient { get; set; }
        
        public string MasterPortfolioItemMenuDetailsProjectDate { get; set; }

        public string MasterPortfolioItemMenuDetailsProjectUrl { get; set; }

        public string MasterPortfolioItemMenuDetailsProjectWebsite { get; set; }
    }
}
