using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository;
using Microsoft.Extensions.DependencyInjection;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Repository.RImplementations;
using OnlineRetailShop.Services.Interface;
using OnlineRetailShop.Services.SImplementations;
using Stripe;



var builder = WebApplication.CreateBuilder(args);


//adding the ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopCS")));


// Add services to the container.


#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region adding services
builder.Services.AddDbContext<ApplicationDbContext>();

//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//builder.Services.AddScoped<ICustomerService, OnlineRetailShop.Services.SImplementations.CustomerService>();


// Register repositories
//builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register services
//builder.Services.AddScoped<IProductService, OnlineRetailShop.Services.SImplementations.ProductService>();



//builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//// Register services
//builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOriginPolicy");

app.UseHttpsRedirection();

app.UseAuthorization(); 

app.MapControllers();

app.Run();

public partial class Program { }