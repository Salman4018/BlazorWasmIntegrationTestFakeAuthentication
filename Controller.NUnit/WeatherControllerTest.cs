using System.Net.Http.Json;
using BlazorWasmIntegrationTestFakeAuthentication.Shared;
using Controller.NUnit;
using NUnit.Framework;

namespace Controllers.NUnit
{
    [TestFixture]
    public class WeatherControllerTests : BaseTest
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Get_All_Groups()
        {
            var result = await _httpClient!.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");

            Assert.True(result != null && result.Count() > 1);
        }

    }
}