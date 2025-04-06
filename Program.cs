using new_app_dotnet.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using new_app_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services MVC et authentification
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<StatistiqueBudgetService>();
builder.Services.AddHttpClient<StatistiqueBudgetService>();
builder.Services.AddScoped<TicketLeadService>();
builder.Services.AddScoped<SeuilService>();
builder.Services.AddHttpClient<ImportCsvService>();
builder.Services.AddScoped<ImportCsvService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Page de connexion
        options.LogoutPath = "/Logout"; // Page de déconnexion
        options.AccessDeniedPath = "/Login"; // Page d'accès refusé
    });

builder.Services.AddAuthorization(); // 🔹 Ajoute l'autorisation

var app = builder.Build();

// Configure le pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
