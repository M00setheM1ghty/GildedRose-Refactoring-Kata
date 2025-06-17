using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class AgedBrieTests
    {
        [Test]
        public void TestAgedBrieBeforeSellDate()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(9));
            Assert.That(items[0].Quality, Is.EqualTo(21));
        }
        [Test]
        public void TestAfterSellDate()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-2));
            Assert.That(items[0].Quality, Is.EqualTo(22));
        }
        [Test]
        public void TestNearMaxQuality()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(9));
            Assert.That(items[0].Quality, Is.EqualTo(50)); // Should not exceed 50
        }
        [Test]
        public void TestNearMaxQuality2()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-2));
            Assert.That(items[0].Quality, Is.EqualTo(50)); // Should not exceed 50
        }

        [Test]
        public void TestMaxQualityPositiveSellin()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(9));
            Assert.That(items[0].Quality, Is.EqualTo(50)); // Should remain at 50
        }

        [Test]
        public void TestMaxQualityNegativeSellin()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -3, Quality = 50 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-4));
            Assert.That(items[0].Quality, Is.EqualTo(50)); // Should remain at 50
        }
    }
}
