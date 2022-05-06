using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherForecastApi.Tests;

public class WeatherForecastApiTest
{
    [Fact]
    public async Task GetWeatherForecast()
    {
        await using var application = new WeatherForecastApplication();

        var client = application.CreateClient();
        var weatherforecast = await client.GetFromJsonAsync<List<MyWeatherForecast.WeatherForecast>>("/weatherforecast");
        
        if(weatherforecast != null){
            Assert.Equal(5, weatherforecast.Count);
        }

        Assert.NotNull(weatherforecast);
    }
}
class WeatherForecastApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // var root = new InMemoryDatabaseRoot();

        // builder.ConfigureServices(services =>
        // {
        //     services.RemoveAll(typeof(DbContextOptions<TodoDbContext>));

        //     services.AddDbContext<TodoDbContext>(options =>
        //         options.UseInMemoryDatabase("Testing", root));
        // });

        return base.CreateHost(builder);
    }
}