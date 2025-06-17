using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class BackstagePassTests
    {
        [Test]
        public void TestBackstagePassBeforeTenDays()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(14));
            Assert.That(items[0].Quality, Is.EqualTo(21));
        }

        [Test]
        public void TestBackstagePassBetweenTenAndSixDays()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(9));
            Assert.That(items[0].Quality, Is.EqualTo(22));
        }

        [Test]
        public void TestBackstagePassBetweenFiveAndOneDays()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(4));
            Assert.That(items[0].Quality, Is.EqualTo(23));
        }

        [Test]
        public void TestBackstagePassAfterConcert()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-1));
            Assert.That(items[0].Quality, Is.EqualTo(0)); // Quality drops to 0 after the concert
        }

        [Test]
        public void TestBackstagePassNearMaxQuality()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 49 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(14));
            Assert.That(items[0].Quality, Is.EqualTo(50)); // Should not exceed 50
        }

        [Test]
        public void TestBackstagePassNearMaxQualityAfterConcert()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 49 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-1));
            Assert.That(items[0].Quality, Is.EqualTo(0)); // Quality drops to 0 after the concert
        }

        [Test]
        public void TestBackstagePassQualityDoesNotExceedMax()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(14));
            Assert.That(items[0].Quality, Is.EqualTo(50)); // Should not exceed 50
        }

        [Test]
        public void TestBackstagePassNegativeSellin()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -5, Quality = 20 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-6));
            Assert.That(items[0].Quality, Is.EqualTo(0)); // Quality drops to 0 after the concert
        }

        [Test]
        public void TestBackstagePassNotNegativeQuality()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -5, Quality = 0 } };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(-6));
            Assert.That(items[0].Quality, Is.EqualTo(0)); // Quality should stay 0
        }
    }
}
