using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Controllers.NUnit;

public class BaseTest
{
    public HttpClient? _httpClient;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [SetUp]
    public async Task SetUp_HttpClient()
    {
        var factory = new WebApplicationFactory<Program>();
        _httpClient = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
            });
        }).CreateClient();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task Check_HttpClient()
    {
        Assert.IsNotNull(_httpClient);
    }
}