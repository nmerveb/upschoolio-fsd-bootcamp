using Microsoft.EntityFrameworkCore;
using UpSchool.Persistance.EntityFramework.Contexts;
using UpSchool.WebApi.Hubs;
using UpSchool.WepApi.AutoMapper.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

//EntityFrameworkCore ile ilgili
//builder.Services.AddDbContext<UpStorageDbContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("MySQLDB")!)); //() arasina ilgili db'ye baglanti ayarlarini veririz.

//MariaDB ayarlari
var mariaDbConnectionString = builder.Configuration.GetConnectionString("MariaDB")!;

builder.Services.AddDbContext<UpStorageDbContext>(opt => opt.UseMySql(mariaDbConnectionString, ServerVersion.AutoDetect(mariaDbConnectionString)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true)
        .AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(AccountProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.MapHub<AccountsHub>("/Hubs/AccountsHub");
app.MapHub<SeleniumLogHub>("/Hubs/SeleniumLogHub");

app.Run();
