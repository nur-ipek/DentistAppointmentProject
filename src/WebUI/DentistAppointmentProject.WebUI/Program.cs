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
    _.Password.RequiredLength = 5; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
    _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
    _.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
    _.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
    _.Password.RequireDigit = false; //0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz.
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

app.UseAuthentication(); //metodu sayesinde uygulaman�n identity ile kimlik do�rulamas� ger�ekle�tirece�ini belirtmi� bulunmaktay�z.
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
