using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class SulfurasTests
    {
        [Test]
        public void TestSulfurasNoChangePositiveSellin()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(10));
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }

        [Test]
        public void TestSulfurasNoChangeNegativeSellin()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -5, Quality = 80 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-5));
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }

        [Test]
        public void TestSulfurasNoChangeSellinZero()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(0));
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }
    }
}
