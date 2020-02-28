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

            Point p3 = p1.SwapCoords();
            Assert.IsTrue(p2 == p3);
        }

        [TestMethod]
        public void TestAssignOrException01() {
            const string fn = "roberto";
            const string ln = "saban";

            var p1 = new Person(fn, ln);

            Assert.AreEqual(p1.FirstName, fn);
            Assert.AreEqual(p1.LastName, ln);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAssignOrException02() {
            var p1 = new Person("Roberto", null);
            Assert.Fail();
        }

        [TestMethod]
        public void TestAssignOrException03() {
            var p1 = new Person("Roberto", "Saban");
            var p2 = new Person("Leila", "Suckewer");
            const string expected = "Suckewer - Saban";
            Assert.AreEqual(p1.HyphenateForPartner(p2), expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAssignOrException04() {
            var p1 = new Person("Roberto", "Saban");
            p1.HyphenateForPartner(null);
            Assert.Fail();
        }

        [TestMethod]
        public void TestNewSwitch01() {
            var timeOfToll = new DateTime(2000, 01, 01, 10, 00, 00);

            decimal t1 = TollCalculator.PeakTimePremiumImperative(timeOfToll, true);
            decimal t2 = TollCalculator.PeakTimePremium(timeOfToll, true);
            
            Assert.AreEqual(t1, t2);
        }
    }
}
