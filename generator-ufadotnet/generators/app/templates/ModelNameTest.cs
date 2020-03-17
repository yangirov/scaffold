using System.Linq;
using Api.Controllers;
using BusinessLogic.Services;
using Contracts.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Api.Tests
{
    [TestFixture]
    public class <%=ModelName%>ControllerTests
    {
        private int globalId = 0;
        private <%=ModelName%>Dto dto;
        private <%=ModelName%>Controller controller;

        [SetUp]
        public void Setup()
        {
            var config = Configuration.InitConfiguration();
            var logger = Configuration.InitLogger();
            var mapper = Configuration.InitMapper();
            var connection = config.GetValue<string>("ConnectionStrings:Database");
            
            var service = new <%=ModelName%>Service(connection, logger, mapper);
            controller = new <%=ModelName%>Controller(service);
            dto = new <%=ModelName%>Dto() { };
        }

        [Test]
        [Order(1)]
        public void Add()
        {
            var result = controller.Add(dto).Result;
            globalId = result.Id;
            Assert.IsTrue(result.Id > 0);
        }

        [Test]
        [Order(2)]
        public void GetAll()
        {
            var count = controller.GetAll().Result.Count();
            Assert.IsTrue(count > 0);
        }

        [Test]
        [Order(3)]
        public void Get()
        {
            var <%=ModelName%>Id = controller.GetById(globalId).Result.Id;
            Assert.IsTrue(<%=ModelName%>Id.Equals(globalId));
        }

        [Test]
        [Order(4)]
        public void Update()
        {
            dto.Id = globalId;

            var result = controller.Update(dto).Result;
            Assert.IsTrue(result.Id == dto.Id);
        }

        [Test]
        [Order(5)]
        public void Delete()
        {
            dto.Id = globalId;

            var result = controller.Delete(dto).Result;
            Assert.IsTrue(result);
        }
    }
}