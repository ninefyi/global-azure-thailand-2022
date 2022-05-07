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
        var weatherforecast = await client.GetFromJsonAsync<List<MyWeatherForecastApi.WeatherForecast>>("/weatherforecast");
        
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
        return base.CreateHost(builder);
    }
}