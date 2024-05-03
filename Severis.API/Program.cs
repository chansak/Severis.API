using Severis.API;
using Severis.API.Hubs;
using Severis.DataAccess;
using Severis.DataAccess.Models.Context;
using Severis.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Severis.Business;
using Severis.Shared;

var builder = WebApplication.CreateBuilder(args);

#region Repositories
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITimeProvider, DateTimeProvider>();
#endregion

#region DbContext
builder.Services.AddDbContext<BS_OE_BudgetContext>(options => options.
    UseLazyLoadingProxies().
    UseSqlServer(ConfigurationExtensions.GetConnectionString(builder.Configuration, "DefaultConnection")));
#endregion

#region Business Services
builder.Services.AddTransient<IVehicleProdServices, VehicleProdServices>();
builder.Services.AddTransient<IUploadFileJobServices, UploadFileJobServices>();
#endregion

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(builder =>
   {
       builder
       .WithOrigins()
       .AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod();
   });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR(cfg => cfg.EnableDetailedErrors = true);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(120),
});

//app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapHub<NotifyHub>("/signalr/notify");
app.MapControllers();

app.Run();
