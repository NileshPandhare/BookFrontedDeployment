// ﻿using BookEcommerceNET.Configuration;
// using BookEcommerceNET.DataInitializer;
// using BookEcommerceNET.Models;
// using BookEcommerceNET.Repositories;
// using BookEcommerceNET.Services;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//     });
// });

// builder.Services.AddControllers()
//     .AddJsonOptions(options =>
//     {
//         options.JsonSerializerOptions.ReferenceHandler = null; // <- This removes $id, $values
//         options.JsonSerializerOptions.WriteIndented = true;
//     });

// var jwtSection = builder.Configuration.GetSection("JWT");
// builder.Services.Configure<JWTSettings>(jwtSection);

// var jwtSettings = jwtSection.Get<JWTSettings>();
// var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

// // Register JWT authentication
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.RequireHttpsMetadata = false;
//     options.SaveToken = true;
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidIssuer = jwtSettings.Issuer,

//         ValidateAudience = true,
//         ValidAudience = jwtSettings.Audience,

//         ValidateLifetime = true,

//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(key)
//     };

// });


// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// //  Register DbContext with Pomelo MySQL provider
// builder.Services.AddDbContext<ShopdbContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//         new MySqlServerVersion(new Version(8, 0, 42)) // Match with your MySQL version
//     ));



// // ? Register Services and Repositories
// builder.Services.AddScoped<ICartService, CartService>();
// builder.Services.AddScoped<ICategoryService, CategoryService>();
// builder.Services.AddScoped<IOrderService, OrderService>();
// builder.Services.AddScoped<IPaymentService, PaymentService>();
// builder.Services.AddScoped<IProductService, ProductService>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<ITokenService, TokenService>();



// builder.Services.AddScoped<ICartRepository, CartRepository>();
// builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
// builder.Services.AddScoped<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();


// builder.Services.AddHostedService<DataSeeder>();
// builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
// app.UseRouting();
// app.UseCors("AllowAll");
// app.UseAuthentication();
// app.UseAuthorization();

// app.MapControllers();

// app.Run();



// // //using BookEcommerceNET.Configuration;
// // //using BookEcommerceNET.DataInitializer;
// // //using BookEcommerceNET.Models;
// // //using BookEcommerceNET.Repositories;
// // //using BookEcommerceNET.Services;
// // //using Microsoft.AspNetCore.Authentication.JwtBearer;
// // //using Microsoft.AspNetCore.Identity;
// // //using Microsoft.EntityFrameworkCore;
// // //using Microsoft.IdentityModel.Tokens;
// // //using System.Text;

// // //var builder = WebApplication.CreateBuilder(args);

// // //// ✅ CORS — allow all for now (until frontend is deployed)
// // //builder.Services.AddCors(options =>
// // //{
// // //    options.AddPolicy("AllowAll", policy =>
// // //    {
// // //        policy
// // //            .AllowAnyOrigin()
// // //            .AllowAnyMethod()
// // //            .AllowAnyHeader();
// // //    });
// // //});

// // //// ✅ JSON settings
// // //builder.Services.AddControllers()
// // //    .AddJsonOptions(options =>
// // //    {
// // //        options.JsonSerializerOptions.ReferenceHandler = null;
// // //        options.JsonSerializerOptions.WriteIndented = true;
// // //    });

// // //// ✅ JWT settings from environment variables
// // //var jwtSection = builder.Configuration.GetSection("JWT");
// // //builder.Services.Configure<JWTSettings>(jwtSection);

// // //var jwtSettings = jwtSection.Get<JWTSettings>();
// // //var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

// // //builder.Services.AddAuthentication(options =>
// // //{
// // //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
// // //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// // //})
// // //.AddJwtBearer(options =>
// // //{
// // //    options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
// // //    options.SaveToken = true;
// // //    options.TokenValidationParameters = new TokenValidationParameters
// // //    {
// // //        ValidateIssuer = true,
// // //        ValidIssuer = jwtSettings.Issuer,

// // //        ValidateAudience = true,
// // //        ValidAudience = jwtSettings.Audience,

// // //        ValidateLifetime = true,

// // //        ValidateIssuerSigningKey = true,
// // //        IssuerSigningKey = new SymmetricSecurityKey(key)
// // //    };
// // //});

// // //// ✅ Swagger always enabled for testing after deployment
// // //builder.Services.AddEndpointsApiExplorer();
// // //builder.Services.AddSwaggerGen();

// // //// ✅ MySQL connection (from Render environment variables)
// // //builder.Services.AddDbContext<ShopdbContext>(options =>
// // //    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
// // //        new MySqlServerVersion(new Version(8, 0, 42))
// // //    )
// // //);

// // //// ✅ Services & Repositories
// // //builder.Services.AddScoped<ICartService, CartService>();
// // //builder.Services.AddScoped<ICategoryService, CategoryService>();
// // //builder.Services.AddScoped<IOrderService, OrderService>();
// // //builder.Services.AddScoped<IPaymentService, PaymentService>();
// // //builder.Services.AddScoped<IProductService, ProductService>();
// // //builder.Services.AddScoped<IUserService, UserService>();
// // //builder.Services.AddScoped<ITokenService, TokenService>();

// // //builder.Services.AddScoped<ICartRepository, CartRepository>();
// // //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// // //builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// // //builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
// // //builder.Services.AddScoped<IProductRepository, ProductRepository>();
// // //builder.Services.AddScoped<IUserRepository, UserRepository>();

// // //builder.Services.AddHostedService<DataSeeder>();
// // //builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// // //var app = builder.Build();

// // //// ✅ Auto-run EF migrations so DB is ready on Render
// // //using (var scope = app.Services.CreateScope())
// // //{
// // //    var db = scope.ServiceProvider.GetRequiredService<ShopdbContext>();
// // //    db.Database.Migrate();
// // //}

// // //// ✅ Swagger for testing live API
// // //app.UseSwagger();
// // //app.UseSwaggerUI();

// // //// ✅ HTTPS redirection only in production
// // //if (!app.Environment.IsDevelopment())
// // //{
// // //    app.UseHttpsRedirection();
// // //}

// // //app.UseRouting();
// // //app.UseCors("AllowAll");
// // //app.UseAuthentication();
// // //app.UseAuthorization();

// // //app.MapControllers();

// // //app.Run();








using BookEcommerceNET.Configuration;
using BookEcommerceNET.DataInitializer;
using BookEcommerceNET.Models;
using BookEcommerceNET.Repositories;
using BookEcommerceNET.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ CORS — allow all for now (until frontend is deployed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// ✅ JSON settings
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = null;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// ✅ JWT settings from environment variables
var jwtSection = builder.Configuration.GetSection("JWT");
builder.Services.Configure<JWTSettings>(jwtSection);

var jwtSettings = jwtSection.Get<JWTSettings>();
var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,

        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// ✅ Swagger always enabled for testing after deployment
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ MySQL connection (from Render environment variables)
builder.Services.AddDbContext<ShopdbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 42))
    )
);

// ✅ Services & Repositories
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddHostedService<DataSeeder>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

var app = builder.Build();

// ✅ Auto-run EF migrations so DB is ready on Render
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ShopdbContext>();
    db.Database.Migrate();
}

// ✅ Swagger for testing live API
app.UseSwagger();
app.UseSwaggerUI();

// ✅ HTTPS redirection only in production
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
