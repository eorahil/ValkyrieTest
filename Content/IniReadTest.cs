using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assets.Scripts.Content
{
    [TestClass]
    public class IniReadTest
    {
        static string currentPath;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Disble logger
            ValkyrieDebug.enabled = false;
            currentPath = System.IO.Path.GetFullPath(@"..\..\resources\testSample.ini");
        }

        [TestMethod]
        public void TestLoadLocalIni()
        {
            IniData result = IniRead.ReadFromIni(currentPath);
            Assert.IsNotNull(result);
        }
    }
}
