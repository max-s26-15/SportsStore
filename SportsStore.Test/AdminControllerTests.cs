using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Test
{
    public class AdminControllerTests
    {
        [Fact]
        public void Index_Contains_All_Products()
        {
            // Arrange - create a simulated storage
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" }
            }).AsQueryable());
            
            // Arrange - create controller
            AdminController target = new AdminController(mock.Object);
            
            // Act
            Product[] rez = GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();
            
            // Assert
            Assert.Equal(3, rez?.Length);
            Assert.Equal("P1", rez?[0].Name);
            Assert.Equal("P2", rez?[1].Name);
            Assert.Equal("P3", rez?[2].Name);
        }

        private T GetViewModel<T>(IActionResult result) where T : class=>
            (result as ViewResult)?.ViewData.Model as T;
    }
}