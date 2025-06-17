using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class ItemBehaviorTests
    {
        [Test]
        public void TestBeforeSellDate()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(9));
            Assert.That(items[0].Quality, Is.EqualTo(19));
        }

        [Test]
        public void TestOnSellDate()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-1));
            Assert.That(items[0].Quality, Is.EqualTo(18));
        }

        [Test]
        public void TestAfterSellDate()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = -1, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-2));
            Assert.That(items[0].Quality, Is.EqualTo(18));
        }

        [Test]
        public void TestQualityZero() {
            var items = new List<Item> {new Item { Name = "Another Item", SellIn = -1, Quality = 0 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-2));
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
    }
}
