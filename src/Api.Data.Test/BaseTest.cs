using System;
using Xunit;
using Api.Date.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Test;

public abstract class BaseTest
{
    public BaseTest()
    {

    }
}

public class DbTeste : IDisposable
{
    private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

    public ServiceProvider ServiceProvider { get; private set; }

    public DbTeste()
    {
        var serviceCollection = new ServiceCollection();
        var connectionString = $"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Pwd=123456";
        serviceCollection.AddDbContext<MyContext>(o =>
            o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
            ServiceLifetime.Transient
        );

        ServiceProvider = serviceCollection.BuildServiceProvider();
        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context.Database.EnsureCreated();
        }
    }

    public void Dispose()
    {
        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context.Database.EnsureDeleted();
        }
    }
}
