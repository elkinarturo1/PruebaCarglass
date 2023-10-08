using Carglass.TechnicalAssessment.Backend.Api.Controllers;
using Carglass.TechnicalAssessment.Backend.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Carglass.TechnicalAssessment.Backend.Dtos;

namespace Carglass.TechnicalAssessment.Backend.Test
{
    [TestClass]
    public class ClientsControllerTests
    {

        [TestMethod]
        public void GetAll_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IClientAppService>();
            var controller = new ClientsController(mockAppService.Object);

            // Act
            var result = controller.GetAll() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }


        [TestMethod]
        public void GetById_WithValidId_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IClientAppService>();
            var controller = new ClientsController(mockAppService.Object);
            var clientId = 1;

            // Act
            var result = controller.GetById(clientId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
              

        [TestMethod]
        public void Create_WithValidDto_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IClientAppService>();
            var controller = new ClientsController(mockAppService.Object);
            var validClientDto = new ClientDto();

            // Act
            var result = controller.Create(validClientDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

       
        [TestMethod]
        public void Update_WithValidDto_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IClientAppService>();
            var controller = new ClientsController(mockAppService.Object);
            var validClientDto = new ClientDto();

            // Act
            var result = controller.Update(validClientDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
      

        [TestMethod]
        public void Delete_WithValidDto_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IClientAppService>();
            var controller = new ClientsController(mockAppService.Object);
            var validClientDto = new ClientDto();

            // Act
            var result = controller.Delete(validClientDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }


    }
}
