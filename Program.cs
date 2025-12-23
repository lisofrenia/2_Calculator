using Confluent.Kafka;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CalculatorContext>(options =>
{
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 5, 15)));
});
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddHostedService<KafkaConsumerService>();
builder.Services.AddSingleton<KafkaProducerHandler>();
builder.Services.AddSingleton<KafkaProducerService<Null, string>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Calculator}/{action=Index}/{id?}");

app.Run();