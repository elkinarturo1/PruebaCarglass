using Carglass.TechnicalAssessment.Backend.Api.Controllers;
using Carglass.TechnicalAssessment.Backend.BL;
using Carglass.TechnicalAssessment.Backend.BL.Products;
using Carglass.TechnicalAssessment.Backend.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carglass.TechnicalAssessment.Backend.Dtos;

namespace Carglass.TechnicalAssessment.Backend.Test
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void GetAll_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IProductAppService>();
            var controller = new ProductsController(mockAppService.Object);

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
            var mockAppService = new Mock<IProductAppService>();
            var controller = new ProductsController(mockAppService.Object);
            var productId = 1;

            // Act
            var result = controller.GetById(productId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
       

        [TestMethod]
        public void Create_WithValidDto_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IProductAppService>();
            var controller = new ProductsController(mockAppService.Object);
            var validProductDto = new ProductDTO();

            // Act
            var result = controller.Create(validProductDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        
        [TestMethod]
        public void Update_WithValidDto_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IProductAppService>();
            var controller = new ProductsController(mockAppService.Object);
            var validProductDto = new ProductDTO();

            // Act
            var result = controller.Update(validProductDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

       
        [TestMethod]
        public void Delete_WithValidDto_OkResult()
        {
            // Arrange
            var mockAppService = new Mock<IProductAppService>();
            var controller = new ProductsController(mockAppService.Object);
            var validProductDto = new ProductDTO();

            // Act
            var result = controller.Delete(validProductDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }       

    }
}
