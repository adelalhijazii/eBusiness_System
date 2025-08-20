using eBusiness.Models;
using eBusiness.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(services => services.EnableEndpointRouting = false);
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(DbContext =>
{
    DbContext.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});


builder.Services.AddScoped<IRepository<MasterAboutUs>, MasterAboutUsRepository>();
builder.Services.AddScoped<IRepository<MasterAdvancedCapabilities>, MasterAdvancedCapabilitiesRepository>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
builder.Services.AddScoped<IRepository<MasterFeature>, MasterFeatureRepository>();
builder.Services.AddScoped<IRepository<MasterFeatures>, MasterFeaturesRepository>();
builder.Services.AddScoped<IRepository<MasterFocus>, MasterFocusRepository>();
builder.Services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterOurServices>, MasterOurServicesRepository>();
builder.Services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
builder.Services.AddScoped<IRepository<MasterPortfolioCategoryMenu>, MasterPortfolioCategoryMenuRepository>();
builder.Services.AddScoped<IRepository<MasterPortfolioItemMenu>, MasterPortfolioItemMenuRepository>();
builder.Services.AddScoped<IRepository<MasterPricing>, MasterPricingRepository>();
builder.Services.AddScoped<IRepository<MasterQuestions>, MasterQuestionsRepository>();
builder.Services.AddScoped<IRepository<MasterService>, MasterServiceRepository>();
builder.Services.AddScoped<IRepository<MasterServices>, MasterServicesRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedium>, MasterSocialMediumRepository>();
builder.Services.AddScoped<IRepository<MasterTeam>, MasterTeamRepository>();
builder.Services.AddScoped<IRepository<MasterUsefullLinks>, MasterUsefullLinksRepository>();
builder.Services.AddScoped<IRepository<MasterWhyUs>, MasterWhyUsRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
builder.Services.AddScoped<IRepository<MasterTransformingData>, MasterTransformingDataRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>, TransactionContactUsRepository>();
builder.Services.AddScoped<IRepository<TransactionNewsLetter>, TransactionNewsLetterRepository>();

builder.Services.Configure<IdentityOptions>(x => {
    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    //x.Password.RequiredUniqueChars = 0;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Admin/Account/Signin";
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(app =>
{
    app.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Account}/{action=Signin}/{id?}"
                        );

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
            );
});
app.Run();
