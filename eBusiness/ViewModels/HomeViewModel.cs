using eBusiness.Models;

namespace eBusiness.ViewModels
{
    public class HomeViewModel
    {
        public MasterAboutUs AboutUs { get; set; }

        public MasterContactUsInformation ContactUsInformation1 { get; set; }

        public MasterContactUsInformation ContactUsInformation2 { get; set; }

        public MasterContactUsInformation ContactUsInformation3 { get; set; }

        public IList<MasterPartner> ListPartner { get; set; }

        public MasterFocus Focus { get; set; }
        
        public MasterFeature Feature { get; set; }

        public IList<MasterFeatures> ListFeatures { get; set; }

        public IList<MasterService> ListService { get; set; }

        public IList<MasterServices> ListServices { get; set; }
        public MasterServices Services { get; set; }

        public IList<MasterAdvancedCapabilities> ListAdvancedCapabilities { get; set; }

        public IList<MasterPortfolioCategoryMenu> ListPortfolioCategoryMenu { get; set; }

        public IList<MasterPortfolioItemMenu> ListPortfolioItemMenu { get; set; }

        public MasterPortfolioItemMenu PortfolioItemMenu { get; set; }

        public IList<MasterPricing> ListPricing { get; set; }

        public IList<MasterQuestions> ListQuestions { get; set; }

        public IList<MasterTeam> ListTeam { get; set; }

        public IList<MasterMenu> ListMenu { get; set; }

        public IList<MasterOurServices> ListOurServices { get; set; }

        public IList<MasterSocialMedium> ListSocialMedium { get; set; }

        public IList<MasterUsefullLinks> ListUsefullLinks { get; set; }

        public IList<MasterWhyUs> ListWhyUs { get; set; }

        public MasterTransformingData TransformingData { get; set; }

        public SystemSetting Setting { get; set; }

        public TransactionContactUs ContactUs { get; set; }

        public TransactionNewsLetter NewsLetter { get; set; }
    }
}
