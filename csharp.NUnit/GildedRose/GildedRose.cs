using System.Collections.Generic;

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
            
            if (!item.Name.Contains(_agedBrie) && !item.Name.Contains(_backstagePasses))
            {
                if (item.Quality > _qualityLowerLimit)
                {
                    if (!item.Name.Contains(_sulfuras))
                    {
                        item.Quality--;
                    }
                }
            }
            else
            {
                if (item.Name.Contains(_agedBrie))
                    AgedBrieQualityChange(item);
                if (item.Name.Contains(_backstagePasses))
                    BackstagePassQualityChange(item);
            }

            if (!item.Name.Contains(_sulfuras))
            {
                item.SellIn--;
            }

            if (item.SellIn < 0)
            {
                if (!item.Name.Contains(_agedBrie))
                {
                    if (!item.Name.Contains(_backstagePasses))
                    {
                        if (item.Quality > 0)
                        {
                            if (!item.Name.Contains(_sulfuras))
                            {
                                item.Quality--;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    IncreaseQuality(item);
                }
            }
        }
    }

    private bool UnderQualityLimit(int quality)
    {
        return quality < _qualityUpperLimit;
    }

    private void IncreaseQuality(Item item)
    {
        if (UnderQualityLimit(item.Quality))
            item.Quality++;
    }

    private void AgedBrieQualityChange(Item item)
    {
        IncreaseQuality(item);
    }

    private void BackstagePassQualityChange(Item item)
    {

        IncreaseQuality(item);

        if (item.SellIn < 11)
        {
            IncreaseQuality(item);
        }

        if (item.SellIn < 6)
        {
            IncreaseQuality(item);
        }

    }
}