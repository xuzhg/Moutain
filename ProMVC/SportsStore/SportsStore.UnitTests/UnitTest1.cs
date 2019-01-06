using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1"},
                new Product{ProductID = 2, Name = "p2"},
                new Product{ProductID = 3, Name = "p3"},
                new Product{ProductID = 4, Name = "p4"},
                new Product{ProductID = 5, Name = "p5"},
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "p4");
            Assert.AreEqual(prodArray[1].Name, "p5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;

            // Arrange - create page info data
            PageInfo pageInfo = new PageInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            MvcHtmlString result = myHelper.PageLinks(pageInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                 new Product{ProductID = 1, Name = "p1"},
                new Product{ProductID = 2, Name = "p2"},
                new Product{ProductID = 3, Name = "p3"},
                new Product{ProductID = 4, Name = "p4"},
                new Product{ProductID = 5, Name = "p5"},
            });

            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            PageInfo pageInfo = result.PageInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Product()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1", Category = "Cat1"},
                new Product{ProductID = 2, Name = "p2", Category = "Cat2"},
                new Product{ProductID = 3, Name = "p3", Category = "Cat1"},
                new Product{ProductID = 4, Name = "p4", Category = "Cat2"},
                new Product{ProductID = 5, Name = "p5", Category = "Cat3"},
            });

            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            Product[] result = ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();

            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name== "p2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name== "p4" && result[1].Category == "Cat2");
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1", Category = "Apples"},
                new Product{ProductID = 2, Name = "p2", Category = "Apples"},
                new Product{ProductID = 3, Name = "p3", Category = "Plums"},
                new Product{ProductID = 4, Name = "p4", Category = "Oranges"},
            });

            // Arrange - create the controller
            NavController target = new NavController(mock.Object);

            // Act = Get the set of categories
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");

        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1", Category = "Apples"},
                new Product{ProductID = 2, Name = "p2", Category = "Oranges"},
            });

            // Arrange
            NavController target = new NavController(mock.Object);

            // Arrange
            string categoryToSelect = "Apples";

            //  Action
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // assert
            Assert.AreEqual(categoryToSelect, result);
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "p1", Category = "Cat1"},
                new Product{ProductID = 2, Name = "p2", Category = "Cat2"},
                new Product{ProductID = 3, Name = "p3", Category = "Cat1"},
                new Product{ProductID = 4, Name = "p4", Category = "Cat2"},
                new Product{ProductID = 5, Name = "p5", Category = "Cat3"},
            });

            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            int res1 = ((ProductsListViewModel)controller.List("Cat1").Model).PageInfo.TotalItems;
            int res2 = ((ProductsListViewModel)controller.List("Cat2").Model).PageInfo.TotalItems;
            int res3= ((ProductsListViewModel)controller.List("Cat3").Model).PageInfo.TotalItems;
            int resAll = ((ProductsListViewModel)controller.List(null).Model).PageInfo.TotalItems;

            // Assert
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
