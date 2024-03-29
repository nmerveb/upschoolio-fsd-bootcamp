using Application;
using Application.Common.Interfaces;
using Domain.Settings;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using WebApi.Filters;
using WebApi.Services;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.

    builder.Services.AddControllers(opt =>  //Controller base uzerinden tureyen her classa ekler 
    {
        opt.Filters.Add<GlobalExceptionFilter>();
        // opt.Filters.Add<ValidationFilter>();
    });

    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(setupAction =>
    {
        setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Description = $"Input your Bearer token in this format - Bearer token to access this API",
        });
        setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
    });

    //Add services to the container
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructure(builder.Configuration, builder.Environment.WebRootPath);

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
                    .AddJwtBearer(o =>
                    {
                        o.RequireHttpsMetadata = false;
                        o.SaveToken = false;
                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero,
                            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                            ValidAudience = builder.Configuration["JwtSettings:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
                        };
                    });

    builder.Services.AddSignalR();
    builder.Services.AddScoped<IAccountHubService, AccountHubManager>();
    builder.Services.AddMemoryCache();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseStaticFiles();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


