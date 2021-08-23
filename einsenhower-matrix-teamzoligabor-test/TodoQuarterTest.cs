using Codecool.EinsenhowerMatrix;
using NUnit.Framework;
using System;

namespace einsenhower_matrix_teamzoligabor_test
{
    public class TodoQuarterTest
    {
        private TodoQuarter tq;

        [SetUp]
        public void Setup()
        {
            tq = new TodoQuarter();
        }

        [Test]
        public void AddOneItemAndCheckSize()
        {
            tq.AddItem("a", new DateTime(2000, 01, 01));
            Assert.AreEqual(1, tq.Items.Count);
        }

        [Test]
        public void AddOneItemAndArchiveItemsAndCheckSize()
        {
            tq.AddItem("a", new DateTime(2000, 01, 01));
            tq.ArchiveItems();
            Assert.AreEqual(0, tq.Items.Count);
        }
    }
}