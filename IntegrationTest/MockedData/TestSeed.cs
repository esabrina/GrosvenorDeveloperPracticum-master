using Application.Contracts;
using Domain;

namespace IntegrationTest.MockedData
{
    /// <summary>
    /// Seed data mocked for tests
    /// </summary>
    public static class TestSeed
    {
        public static RequestOrderDto GetRequestOrderDto()
        {
            var list = new List<int> { 1, 2, 3 };
            return new RequestOrderDto() { Menu = Menu.evening.ToString(), Dishes = list };
        }
    }
}
