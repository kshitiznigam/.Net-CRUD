using CRUD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your DbContext

builder.Services.AddDbContext<YourDbContext>((options)=>{
    
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});


var app = builder.Build();

// Configure CORS
app.UseCors(options => options
    .WithOrigins("http://localhost:4200") // Replace with your Angular app's URL
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "customer",
    pattern: "Customer/{controller=Customer}/{action=Create}/{id?}");
Console.WriteLine("Application is starting. Database connection is established.");
app.Run();
