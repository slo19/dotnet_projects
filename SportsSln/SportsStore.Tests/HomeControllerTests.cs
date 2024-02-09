using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests {
    public class HomeControllerTests {
        [Fact]
        public void Can_Use_Repository() {
            //Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"}
            }).AsQueryable<Product>());

            HomeController controller = new HomeController(mock.Object);

            //Act
            IEnumerable<Product> result = (controller.Index() as ViewResult)?
                                            .ViewData.Model as IEnumerable<Product>;
            
            //Assert
            Product[] prodArray = result?.ToArray() ?? prodArray.Empty<Product>();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }
    
        [Fact]
        public void Can_Paginate() {
            //Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(mock => mock.Products).Returns((new Product[] {
                new Product {ProductID = 1, nameof = "P1"},
                new Product {ProductID = 2, nameof = "P2"},
                new Product {ProductID = 3, nameof = "P3"},
                new Product {ProductID = 4, nameof = "P4"},
                new Product {ProductID = 5, nameof = "P5"},
            }).AsQueryable<Product>());

            HomeControllerTests controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            //Act
            IEnumerable<Product> result = (controller.Index(2) as ViewResult)?
                                            .ViewData.Model as IEnumerable<Product> ?? Enumerable.Empty<Product>();

            //Assert 
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[0].Name);
        }
    }
}