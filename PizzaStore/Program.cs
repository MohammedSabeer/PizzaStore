using Microsoft.EntityFrameworkCore;
using PizzaStore.Database;
using PizzaStore.Services.Cart;
using PizzaStore.Services.Cart.Contract;
using PizzaStore.Services.Orders;
using PizzaStore.Services.Orders.Contract;
using PizzaStore.Services.Product;
using PizzaStore.Services.Product.Contract;
using PizzaStore.Services.Toppings;
using PizzaStore.Services.Toppings.Contract;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    opt.JsonSerializerOptions.AllowTrailingCommas = true;
    opt.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString;
    opt.JsonSerializerOptions.IncludeFields = true;
});

builder.Services.AddDbContext<PizzaStoreContext>(options =>
{
    options.UseSqlServer("Data Source=.;database=PizzaStore;Trusted_Connection=true;TrustServerCertificate=true;");
    options.UseQueryTrackingBehavior( QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICartItemService, CartItemService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IToppingService, ToppingService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
