using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository;
using Microsoft.Extensions.DependencyInjection;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Repository.RImplementations;
using OnlineRetailShop.Services.Interface;
using OnlineRetailShop.Services.SImplementations;
using Stripe;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);


//adding the ApplicationDbContext , connection string 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopCS")));

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

#region Jwt configuration 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
#endregion



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT_Authentication", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[]{}
    }
});
});


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


//adding cache service
builder.Services.AddMemoryCache();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT_Authentication_Authorization v1"));
}


app.UseCors("AllowAnyOriginPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization(); 

app.MapControllers();

app.Run();

public partial class Program { }