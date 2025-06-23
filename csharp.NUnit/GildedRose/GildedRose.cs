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
                if (UnderQualityLimit(item.Quality))
                {
                    item.Quality++;

                    if (item.Name.Contains(_backstagePasses))
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality = IncreaseQuality(item.Quality);
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality = IncreaseQuality(item.Quality);
                        }
                    }
                }
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
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    item.Quality = IncreaseQuality(item.Quality);
                }
            }
        }
    }

    private bool UnderQualityLimit(int quality)
    {
        return quality < _qualityUpperLimit;
    }

    private int IncreaseQuality(int quality)
    {
        if (UnderQualityLimit(quality))
            quality++;
        return quality;
    }
}