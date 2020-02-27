using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using modern_tech;

namespace modern_tech_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExample01() {
            var startTime = new DateTime(2000, 2, 12);
            var expectedEndDateTime = new DateTime(2001, 2, 12);
            (DateTime s, DateTime e) resp = Example.GenerateSubscription(startTime);

            Assert.AreEqual(resp.e, expectedEndDateTime);
        }

        [TestMethod]
        public void TestPointClass01() {
            var p1 = new Point(1.0, 2.0);
            var p2 = new Point(1.0, 2.0);

            Assert.IsTrue(p1 == p2);
        }

        [TestMethod]
        public void TestPointClass02() {
            var p1 = new Point(1.0, 2.0);
            var p2 = new Point(2.0, 1.0);

            Assert.IsTrue(p1 != p2);
        }

        [TestMethod]
        public void TestPointClass03() {
            var p1 = new Point(1.0, 2.0);
            var p2 = new Point(2.0, 1.0);

            p1.SwapCoords();
            Assert.IsTrue(p1 == p2);
        }
    }
}
