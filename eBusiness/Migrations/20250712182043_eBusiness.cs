using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBusiness.Migrations
{
    /// <inheritdoc />
    public partial class eBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterAboutUs",
                columns: table => new
                {
                    MasterAboutUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterAboutUsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterAboutUsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterAboutUsPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterAboutUsEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAboutUs", x => x.MasterAboutUsId);
                });

            migrationBuilder.CreateTable(
                name: "MasterAdvancedCapabilities",
                columns: table => new
                {
                    MasterAdvancedCapabilitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterAdvancedCapabilitiesTitle = table.Column<int>(type: "int", nullable: false),
                    MasterAdvancedCapabilitiesBreef = table.Column<int>(type: "int", nullable: false),
                    MasterAdvancedCapabilitiesDescription = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAdvancedCapabilities", x => x.MasterAdvancedCapabilitiesId);
                });

            migrationBuilder.CreateTable(
                name: "MasterContactUsInformation",
                columns: table => new
                {
                    MasterContactUsInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterContactUsInformationIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterContactUsInformationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterContactUsInformation", x => x.MasterContactUsInformationId);
                });

            migrationBuilder.CreateTable(
                name: "MasterFeature",
                columns: table => new
                {
                    MasterFeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterFeatureTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFeatureBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFeatureDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFeatureImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFeature", x => x.MasterFeatureId);
                });

            migrationBuilder.CreateTable(
                name: "MasterFeatures",
                columns: table => new
                {
                    MasterFeaturesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterFeatureIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFeaturesTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFeaturesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFeatures", x => x.MasterFeaturesId);
                });

            migrationBuilder.CreateTable(
                name: "MasterFocus",
                columns: table => new
                {
                    MasterFocusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterFocusTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFocusBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFocusPercentageRateIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFocusPercentageRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterFocusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFocus", x => x.MasterFocusId);
                });

            migrationBuilder.CreateTable(
                name: "MasterMenu",
                columns: table => new
                {
                    MasterMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterMenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterMenuUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterMenu", x => x.MasterMenuId);
                });

            migrationBuilder.CreateTable(
                name: "MasterOurServices",
                columns: table => new
                {
                    MasterOurServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterOurServicesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOurServicesUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterOurServices", x => x.MasterOurServicesId);
                });

            migrationBuilder.CreateTable(
                name: "MasterPartner",
                columns: table => new
                {
                    MasterPartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPartnerLogoImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPartnerWebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPartner", x => x.MasterPartnerId);
                });

            migrationBuilder.CreateTable(
                name: "MasterPortfolioCategoryMenu",
                columns: table => new
                {
                    MasterPortfolioCategoryMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPortfolioCategoryMenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPortfolioCategoryMenu", x => x.MasterPortfolioCategoryMenuId);
                });

            migrationBuilder.CreateTable(
                name: "MasterPricing",
                columns: table => new
                {
                    MasterPricingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPricingTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPricingBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPricingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPricingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPricing", x => x.MasterPricingId);
                });

            migrationBuilder.CreateTable(
                name: "MasterQuestions",
                columns: table => new
                {
                    MasterQuestionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterQuestionsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterQuestionsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterQuestions", x => x.MasterQuestionsId);
                });

            migrationBuilder.CreateTable(
                name: "MasterService",
                columns: table => new
                {
                    MasterServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterServiceIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServiceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServiceImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterService", x => x.MasterServiceId);
                });

            migrationBuilder.CreateTable(
                name: "MasterServices",
                columns: table => new
                {
                    MasterServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterServicesIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServicesTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServicesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterServices", x => x.MasterServicesId);
                });

            migrationBuilder.CreateTable(
                name: "MasterSocialMedium",
                columns: table => new
                {
                    MasterSocialMediumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterSocialMediumIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSocialMediumUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSocialMedium", x => x.MasterSocialMediumId);
                });

            migrationBuilder.CreateTable(
                name: "MasterTeam",
                columns: table => new
                {
                    MasterTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterTeamTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterTeamBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterTeamDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterTeamIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterTeamIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterTeamImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTeam", x => x.MasterTeamId);
                });

            migrationBuilder.CreateTable(
                name: "MasterUsefullLinks",
                columns: table => new
                {
                    MasterUsefullLinksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterUsefullLinksName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterUsefullLinksUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterUsefullLinks", x => x.MasterUsefullLinksId);
                });

            migrationBuilder.CreateTable(
                name: "MasterWhyUs",
                columns: table => new
                {
                    MasterWhyUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterWhyUsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterWhyUsBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterWhyUsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterWhyUsImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterWhyUs", x => x.MasterWhyUsId);
                });

            migrationBuilder.CreateTable(
                name: "SystemSetting",
                columns: table => new
                {
                    SystemSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemSettingLogoImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutProfileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutProfilePosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutIconPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingAboutPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingCopyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSetting", x => x.SystemSettingId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionContactUs",
                columns: table => new
                {
                    TransactionContactUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionContactUsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionContactUs", x => x.TransactionContactUsId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionNewsLetter",
                columns: table => new
                {
                    TransactionNewsLetterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionNewsLetterEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionNewsLetter", x => x.TransactionNewsLetterId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterPortfolioItemMenu",
                columns: table => new
                {
                    MasterPortfolioItemMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPortfolioCategoryMenuId = table.Column<int>(type: "int", nullable: false),
                    MasterPortfolioItemMenuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPortfolioItemMenuBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPortfolioItemMenuImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPortfolioItemMenu", x => x.MasterPortfolioItemMenuId);
                    table.ForeignKey(
                        name: "FK_MasterPortfolioItemMenu_MasterPortfolioCategoryMenu_MasterPortfolioCategoryMenuId",
                        column: x => x.MasterPortfolioCategoryMenuId,
                        principalTable: "MasterPortfolioCategoryMenu",
                        principalColumn: "MasterPortfolioCategoryMenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPortfolioItemMenu_MasterPortfolioCategoryMenuId",
                table: "MasterPortfolioItemMenu",
                column: "MasterPortfolioCategoryMenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MasterAboutUs");

            migrationBuilder.DropTable(
                name: "MasterAdvancedCapabilities");

            migrationBuilder.DropTable(
                name: "MasterContactUsInformation");

            migrationBuilder.DropTable(
                name: "MasterFeature");

            migrationBuilder.DropTable(
                name: "MasterFeatures");

            migrationBuilder.DropTable(
                name: "MasterFocus");

            migrationBuilder.DropTable(
                name: "MasterMenu");

            migrationBuilder.DropTable(
                name: "MasterOurServices");

            migrationBuilder.DropTable(
                name: "MasterPartner");

            migrationBuilder.DropTable(
                name: "MasterPortfolioItemMenu");

            migrationBuilder.DropTable(
                name: "MasterPricing");

            migrationBuilder.DropTable(
                name: "MasterQuestions");

            migrationBuilder.DropTable(
                name: "MasterService");

            migrationBuilder.DropTable(
                name: "MasterServices");

            migrationBuilder.DropTable(
                name: "MasterSocialMedium");

            migrationBuilder.DropTable(
                name: "MasterTeam");

            migrationBuilder.DropTable(
                name: "MasterUsefullLinks");

            migrationBuilder.DropTable(
                name: "MasterWhyUs");

            migrationBuilder.DropTable(
                name: "SystemSetting");

            migrationBuilder.DropTable(
                name: "TransactionContactUs");

            migrationBuilder.DropTable(
                name: "TransactionNewsLetter");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MasterPortfolioCategoryMenu");
        }
    }
}
