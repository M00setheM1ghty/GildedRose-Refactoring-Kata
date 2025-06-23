using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    private string _agedBrie = "Aged Brie";
    private string _backstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private string _sulfuras = "Sulfuras, Hand of Ragnaros";
    private int _qualityUpperLimit = 50;
    private int _qualityLowerLimit = 0;

    public void UpdateQuality()
    {
        foreach(var item in Items)
        {
            if (item.Name.Contains(_sulfuras))
                continue;

            item.SellIn--;

            if (item.Name.Contains(_agedBrie))
                UpdateAgedBrie(item);
            else if (item.Name.Contains(_backstagePasses))
                UpdateBackstagePass(item);
            else
                UpdateNormalItem(item);
        }
    }

    private void IncreaseQuality(Item item)
    {
        if (item.Quality < _qualityUpperLimit)
            item.Quality++;
    }

    private void DegradeQuality(Item item)
    {
        if (item.Quality > _qualityLowerLimit)
            item.Quality--;
    }

    private bool Expired(Item item)
    {
        return item.SellIn < 0;
    }

    private void UpdateNormalItem(Item item)
    {
        DegradeQuality(item);
        if (Expired(item))
            DegradeQuality(item);
    }

    private void UpdateAgedBrie(Item item)
    {
        IncreaseQuality(item);
        if (Expired(item))
            IncreaseQuality(item);
    }

    private void UpdateBackstagePass(Item item)
    {
        int firstDayLimit = 10;
        int secondDayLimit = 5;

        IncreaseQuality(item);

        if (item.SellIn <= firstDayLimit)
        {
            IncreaseQuality(item);
        }

        if (item.SellIn <= secondDayLimit)
        {
            IncreaseQuality(item);
        }

        if(Expired(item))
        {
            item.Quality = 0;
        }
    }
}