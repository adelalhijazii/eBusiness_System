using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eBusiness.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<MasterAboutUs> MasterAboutUs { get; set; }

        public DbSet<MasterAdvancedCapabilities> MasterAdvancedCapabilities { get; set; }

        public DbSet<MasterContactUsInformation> MasterContactUsInformation { get; set; }

        public DbSet<MasterTransformingData> MasterTransformingData { get; set; }

        public DbSet<MasterFeature> MasterFeature { get; set; }

        public DbSet<MasterFeatures> MasterFeatures { get; set; }

        public DbSet<MasterFocus> MasterFocus { get; set; }

        public DbSet<MasterMenu> MasterMenu { get; set; }
        
        public DbSet<MasterOurServices> MasterOurServices { get; set; }
        
        public DbSet<MasterPartner> MasterPartner { get; set; }

        public DbSet<MasterPortfolioItemMenu> MasterPortfolioItemMenu { get; set; }

        public DbSet<MasterPortfolioCategoryMenu> MasterPortfolioCategoryMenu { get; set; }

        public DbSet<MasterPricing> MasterPricing { get; set; }

        public DbSet<MasterQuestions> MasterQuestions { get; set; }
        
        public DbSet<MasterService> MasterService { get; set; }

        public DbSet<MasterServices> MasterServices { get; set; }

        public DbSet<MasterSocialMedium> MasterSocialMedium { get; set; }

        public DbSet<MasterTeam> MasterTeam { get; set; }

        public DbSet<MasterUsefullLinks> MasterUsefullLinks { get; set; }

        public DbSet<MasterWhyUs> MasterWhyUs { get; set; }

        public DbSet<SystemSetting> SystemSetting { get; set; }

        public DbSet<TransactionContactUs> TransactionContactUs { get; set; }

        public DbSet<TransactionNewsLetter> TransactionNewsLetter { get; set; }
    }
}
