using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BarTabService;
using Domain;
using NUnit.Framework;

namespace BarTabsServiceSpecs
{
    [TestFixture]
    public class BarTabPersistenceSpecs
    {
        private string TestPath = @"C:\ddr\test.dbtest";

        private DateTime testDate = new DateTime(2014, 12, 04);
        private BarTabFileService _service;

        [SetUp]
        public void Setup()
        {
            _service = BarTabFileService.ForTesting(TestPath);
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(TestPath))
            {
                File.Delete(TestPath);
            }
        }

        [Test]
        public void We_should_be_able_to_create_a_file()
        {
            _service.Create(GetTestTab());
            _service.Create(GetTestTab());

            var tabs = _service.Read().ToList();

            Assert.AreEqual(2, tabs.Count());
            foreach (var tab in tabs)
            {
                Assert.AreEqual(tab.BarName, "Bar");
                Assert.AreEqual(tab.Date, testDate);
                Assert.AreEqual(tab.Id, 1);
                Assert.AreEqual(tab.Items.First(), "Item");
                Assert.AreEqual(tab.WhoWasThere.First(), "Erik");
                Assert.AreEqual(tab.TabAmount, 1.1);   
            }
        }

        private BarTab GetTestTab()
        {
            return new BarTab
            {
                BarName = "Bar",
                Date = testDate,
                Id = 1,
                Items = new List<string> {"Item"},
                WhoWasThere = new List<string> {"Erik"},
                TabAmount = 1.1
            };
        }
    }
}
