using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // Create the mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // Create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // Create the moc context, using the resquest and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet)
        {
            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller) &&
                valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfos = propertySet.GetType().GetProperties();
                foreach(PropertyInfo propInfo in propInfos)
                {
                    if (!(routeResult.Values.ContainsKey(propInfo.Name) &&
                        valCompare(routeResult.Values[propInfo.Name], propInfo.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private void TestRouteFail(string url)
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            Assert.IsTrue(result == null || result.Route == null);
        }

        [TestMethod]
        public void TestIncomingRoutes()
        {
            TestRouteMatch("~/Admin/Index", "Admin", "Index");

            TestRouteMatch("~/One/Two", "One", "Two");

            TestRouteFail("~/Admin/Index/Segment");

            TestRouteMatch("~/Admin", "Admin", "Index");

            TestRouteMatch("~/", "Home", "Index");
        }
    }
}
