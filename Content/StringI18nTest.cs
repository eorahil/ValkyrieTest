using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.Content;

namespace Assets.Scripts.Content
{
    [TestClass]
    public class StringI18nTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringI18n actual = new StringI18n(null);
            String expected = "";
            StringAssert.ReferenceEquals(expected, actual.ToString());
        }
    }
}
