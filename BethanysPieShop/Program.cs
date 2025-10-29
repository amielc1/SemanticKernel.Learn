using BethanysPieShop;
using BethanysPieShop.Components;
using BethanysPieShop.Components.Account;
using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Data;
using BethanysPieShop.Repositories;
using BethanysPieShop.Services;
using BethanysPieShop.Util;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connectionString
        ));

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.Configure<ModelSettings>(builder.Configuration.GetSection("ModelSettings"));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IPieDataService, PieDataService>();
builder.Services.AddScoped<IPieRecipeRepository, PieRecipeRepository>();
builder.Services.AddScoped<IPieRecipeDataService, PieRecipeDataService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketDataService, TicketDataService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddKernel()
    .AddOpenAIChatCompletion(builder.Configuration.GetSection("ModelSettings").GetValue<string>("TextModelName"), builder.Configuration.GetSection("ModelSettings").GetValue<string>("OPENAI_API_KEY"))
    .AddOpenAITextToImage(builder.Configuration.GetSection("ModelSettings").GetValue<string>("OPENAI_API_KEY"), modelId: builder.Configuration.GetSection("ModelSettings").GetValue<string>("ImageModelName"));

builder.Services.AddScoped<KernelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

CreateRoles(app.Services);

app.Run();

void CreateRoles(IServiceProvider serviceProvider)
{

    var scope = app.Services.CreateScope();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    Task<IdentityResult> roleResult;

    string email = "admin@snowball.be";

    Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
    hasAdminRole.Wait();

    if (!hasAdminRole.Result)
    {
        roleResult = roleManager.CreateAsync(new IdentityRole("Administrator"));
        roleResult.Wait();
    }

    Task<bool> hasUserRole = roleManager.RoleExistsAsync("User");
    hasUserRole.Wait();

    if (!hasUserRole.Result)
    {
        roleResult = roleManager.CreateAsync(new IdentityRole("User"));
        roleResult.Wait();
    }

    Task<ApplicationUser> testUser = userManager.FindByEmailAsync(email);
    testUser.Wait();

    if (testUser.Result == null)
    {
        ApplicationUser administrator = new()
        {
            Email = email,
            UserName = email, 
            EmailConfirmed = true,
            City = "Brussels"
        };

        Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "Azerty&01?");
        newUser.Wait();

        if (newUser.Result.Succeeded)
        {
            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
            newUserRole.Wait();

            newUserRole = userManager.AddToRoleAsync(administrator, "User");
            newUserRole.Wait();

        }
    }
}
