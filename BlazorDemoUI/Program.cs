using BlazorDemo.Infrastructure;
using BlazorDemo.Application;
using BlazorDemoUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTelerikBlazor();

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userDb.json");
builder.Services
    .AddApplication()
    .AddInfrastructure(path)
    .AddUI();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

app.Run();
