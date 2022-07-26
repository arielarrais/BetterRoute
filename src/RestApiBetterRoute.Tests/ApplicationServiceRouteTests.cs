using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using RestApiBetterRoute.Application;
using RestApiBetterRoute.Domain.Core.Interfaces.Services;
using RestApiBetterRoute.Domain.Entities;

namespace RestApiBetterRoute.Tests
{
    public class ApplicationServiceClienteTests
    {

        private Mock<IServiceRoute> _serviceRouteMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _serviceRouteMock = new Mock<IServiceRoute>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void ApplicationServiceRoute_GetBetterRoute_ShouldReturnBetterRoute()
        {
            Assert.Pass();

            //Arrange
            const int id = 10;

            string route = "GRU-BRC-SCL-ORL-CDG ao custo 40.00";

            _serviceRouteMock.Setup(x => x.GetBetterRoute("gru", "cdg")).Returns(route);

            var applicationServiceRoute =
                new ApplicationServiceRoute(_serviceRouteMock.Object, _mapperMock.Object);

            //Act
            string result = applicationServiceRoute.GetBetterRoute("gru", "cdg");

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(route, result);
            _serviceRouteMock.VerifyAll();
            _mapperMock.VerifyAll();
        }
    }
}