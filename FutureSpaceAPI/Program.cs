using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Application.Handlers;
using FutureSpaceAPI.Application.Services;
using FutureSpaceAPI.Data;
using FutureSpaceAPI.Data.Repositories;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using FutureSpaceAPI.Domain.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("DevConnection"),
            x => x.MigrationsAssembly("FutureSpaceAPI.Data")));

    services.AddHttpClient();

    services.AddTransient<ILauncherService, LauncherService>();
    services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    services.AddScoped<ILauncherRepository, LauncherRepository>();

    services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(FutureSpaceAPI.Application.Application)));
}