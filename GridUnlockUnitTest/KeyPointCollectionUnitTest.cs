using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridUnlock;

namespace GridUnlockUnitTest
{
    [TestClass]
    public class KeyPointCollectionUnitTest
    {
        [TestMethod]
        public void TestAdd()
        {
            KeyPointCollection list = new KeyPointCollection();

            KeyPoint p1 = new KeyPoint(1, 2);
            KeyPoint p2 = new KeyPoint(2, 1);

            list.Add(p1);
            list.Add(p2);

            Assert.IsTrue(list.Count == 2);
        }

        [TestMethod]
        public void TestAddFail()
        {
            KeyPointCollection list = new KeyPointCollection();

            KeyPoint p1 = new KeyPoint(1, 2);
            KeyPoint p2 = new KeyPoint(1, 2);

            list.Add(p1);
            list.Add(p2);

            Assert.IsTrue(list.Count == 1);
        }
    }
}
