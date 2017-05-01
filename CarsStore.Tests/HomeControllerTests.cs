using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;

namespace CarsStore.Tests
{
    using System.Web.Mvc;

    using CarsStore.Web.Controllers;

    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexShouldPass()
        {
            var controller=new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Gosho",result.ViewBag);

        }
    }
}
