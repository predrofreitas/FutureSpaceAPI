using FutureSpaceAPI.Application.Helpers;
using FutureSpaceAPI.Application.Services;
using FutureSpaceAPI.Data;
using FutureSpaceAPI.Data.Repositories;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using FutureSpaceAPI.Domain.Interfaces.Services;
using FutureSpaceAPI.Middlewares;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHangfireDashboard();

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

    services.AddHangfire(options =>
        options.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseDefaultTypeSerializer()
        .UseMemoryStorage());

    GlobalJobFilters.Filters.Add(new AutoDisableJobAttribute());

    services.AddHangfireServer();


    services.AddTransient<ILauncherService, LauncherService>();
    services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    services.AddScoped<ILauncherRepository, LauncherRepository>();
    services.AddTransient<ExceptionHandlingMiddleware>();
    services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(FutureSpaceAPI.Application.Application)));
}