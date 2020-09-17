using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Controllers;

namespace UnitTestStringCalculator
{
    [TestClass]
    public class AddUnitTest
    {
        [TestMethod]
        public void Add()
        {
            var _controller = new HomeController().Add("//#\n1#2");

            if (_controller is JsonResult _resultJsonResult)
            {
                Assert.AreEqual(3, _resultJsonResult.Value);
            }

            if (_controller is BadRequestObjectResult _resultBadRequest)
            {
                Assert.AreEqual(200, _resultBadRequest.StatusCode);
            }
        }
    }
}
