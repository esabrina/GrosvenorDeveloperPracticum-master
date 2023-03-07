using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;


namespace IntegrationTests
{
    public abstract class IntegrationFactoryFixture
    {
        protected HttpClient _client;
        protected WebApplicationFactory<Program> _sut;

        [SetUp]
        public virtual void Setup()
        {
            _sut = new WebApplicationFactory<Program>();
            _client = _sut.CreateClient();
        }

        [TearDown]
        public virtual void TearDown()
        {
            _client?.Dispose();
            _sut?.Dispose();
        }
    }
}
