using NUnit.Framework;
using System.Net;
using System.Text;
using System.Text.Json;
using IntegrationTest.MockedData;
using IntegrationTests;

namespace IntegrationTest
{
    [TestFixture]
    public class APITests : IntegrationFactoryFixture
    {
        const string orderURI = "/order";


        private static StringContent GetJsonStringContent<T>(T model)
                    => new(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        [Test]
        public async Task PostOrderReturnsOkTest()
        {
            var expected = "steak";
            var response = await _client.PostAsync(orderURI, GetJsonStringContent(TestSeed.GetRequestOrderDto()));
            var data = await response.Content.ReadAsStringAsync();

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(data.Split(','), Has.Length.EqualTo(3));
                Assert.That(data, Does.Contain(expected));
            });
        }

        [Test]
        public async Task PostOrderReturnsErrorTest()
        {
            var expected = "error";
            var dto = TestSeed.GetRequestOrderDto();
            dto.Dishes.Add(5);
            var response = await _client.PostAsync(orderURI, GetJsonStringContent(dto));
            var data = await response.Content.ReadAsStringAsync();

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(data, Does.Contain(expected));
            });
        }
    }
}