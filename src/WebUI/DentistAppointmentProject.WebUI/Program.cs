using DentistAppointmentProject.Domain.Entities.Authentication;
using DentistAppointmentProject.Persistence.Context;
using DentistAppointmentProject.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(_ => _.UseSqlServer(builder.Configuration["ConnectionStrings:SqlServerConnectionString"]));
//builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddIdentity<User, Role>(_ =>
{
    _.Password.RequiredLength = 5; //En az kaç karakterli olması gerektiğini belirtiyoruz.
    _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluğunu kaldırıyoruz.
    _.Password.RequireLowercase = false; //Küçük harf zorunluluğunu kaldırıyoruz.
    _.Password.RequireUppercase = false; //Büyük harf zorunluluğunu kaldırıyoruz.
    _.Password.RequireDigit = false; //0-9 arası sayısal karakter zorunluluğunu kaldırıyoruz.
}).AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddPersistenceServices();
var app = builder.Build();

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

app.UseAuthentication(); //metodu sayesinde uygulamanın identity ile kimlik doğrulaması gerçekleştireceğini belirtmiş bulunmaktayız.
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
