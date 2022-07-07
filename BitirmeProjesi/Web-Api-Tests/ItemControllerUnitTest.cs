using BitirmeProjesi.Infrastructure;
using BitirmeProjesi.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Web_Api_Tests
{
    public class ItemControllerUnitTest
    {
        private readonly ItemController _controller;
        private readonly IITemService _service;

        public ItemControllerUnitTest()
        {
            _service = new ItemServiceFake();
            _controller = new ItemController(_service);
        }

        [Fact]
        public void GetReturnsOkResult()
        {
            var okResult = _controller.Get();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void RemoveIdPassed()
        {
            int id = 4;
            var badrequest = _controller.Delete(id);
            Assert.IsType<BadRequestResult>(badrequest);
        }
    }
}