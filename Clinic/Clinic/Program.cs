using Clinic.DAL;
using Clinic.BL;
using Microsoft.EntityFrameworkCore;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ClinicContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

#region Repo
builder.Services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IDatabaseRepo, DatabaseRepo>();

#endregion

#region unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region Managers
builder.Services.AddScoped<IDoctorManager, DoctorManager>();
builder.Services.AddScoped<IAppointmentManager, AppointmentManager>();
builder.Services.AddScoped<IPatientManager, PatientManager>();
builder.Services.AddScoped<IAppointmentManager, AppointmentManager>();

#endregion
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
