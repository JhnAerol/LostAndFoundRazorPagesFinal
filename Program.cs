using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LostAndFoundRazorPages.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/LoginPage", "");
});

builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<LostAndFoundRazorPagesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LostAndFoundRazorPagesContext") ?? throw new InvalidOperationException("Connection string 'LostAndFoundRazorPagesContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.UseSession();

app.MapRazorPages()
   .WithStaticAssets();


app.Run();
