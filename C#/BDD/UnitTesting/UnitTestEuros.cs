using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConvertirEnEuros()
        {
            double res = Recette.ConvertirEnEuros(10);
            Assert.AreEqual(5.0, res);
        }

    }
}
