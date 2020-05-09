using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDD
{
    [TestClass]
    public class UnitTestCook
    {
        [TestMethod]
        public void TestConvertirEnCook()
        {
            int res = Recette.ConvertirEnCook(10);
            Assert.AreEqual(20, res);
        }
    }
}
