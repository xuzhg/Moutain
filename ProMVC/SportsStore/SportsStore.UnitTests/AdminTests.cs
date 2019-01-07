using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1"},
                new Product{ProductID = 2, Name = "p2"},
                new Product{ProductID = 3, Name = "p3"},
            });

            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            // Action
            Product[] result = ((IEnumerable<Product>)target.Index().ViewData.Model).ToArray();

            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("p1", result[0].Name);
            Assert.AreEqual("p2", result[1].Name);
            Assert.AreEqual("p3", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1"},
                new Product{ProductID = 2, Name = "p2"},
                new Product{ProductID = 3, Name = "p3"},
            });

            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            // Action
            Product p1 = target.Edit(1).ViewData.Model as Product;
            Product p2 = target.Edit(2).ViewData.Model as Product;
            Product p3 = target.Edit(3).ViewData.Model as Product;

            // Assert
            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1"},
                new Product{ProductID = 2, Name = "p2"},
                new Product{ProductID = 3, Name = "p3"},
            });

            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            // Action
            Product result = target.Edit(4).ViewData.Model as Product;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);
            Product product = new Product { Name = "Test" };

            // Action
            ActionResult result = target.Edit(product);

            // Assert
            mock.Verify(m => m.SaveProduct(product));

            // Assert - check the method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);
            Product product = new Product { Name = "Test" };
            target.ModelState.AddModelError("error", "error");

            // Action
            ActionResult result = target.Edit(product);

            // Assert
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());

            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Changes()
        {
            // Arrange
            Product product = new Product { ProductID = 2, Name = "Test" };
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1"},
                product,
                new Product{ProductID = 3, Name = "p3"},
            });

            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            // Action
            target.Delete(product.ProductID);

            // Assert
            mock.Verify(m => m.DeleteProduct(product.ProductID));
        }
    }
}
