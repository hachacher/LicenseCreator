using LicenseCreator.Components;
using LicenseCreator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var encryptionKey = builder.Configuration["Encryption:Key"];
var encryptionIv = builder.Configuration["Encryption:IV"];

if (string.IsNullOrEmpty(encryptionKey) || string.IsNullOrEmpty(encryptionIv))
{
    throw new Exception("Encryption key and IV must be set in appsettings.json");
}

builder.Services.AddSingleton(new EncryptionService(encryptionKey, encryptionIv));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
