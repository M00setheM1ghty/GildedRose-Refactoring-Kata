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
    private int _qualityLimit = 50;

    public void UpdateQuality()
    {
        foreach(var item in Items)
        {
            if (!item.Name.Contains(_agedBrie) && !item.Name.Contains(_backstagePasses))
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
                if (UnderQualityLimit(item.Quality))
                {
                    item.Quality++;

                    if (item.Name.Contains(_backstagePasses))
                    {
                        if (item.SellIn < 11)
                        {
                            if (UnderQualityLimit(item.Quality))
                            {
                                item.Quality++;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (UnderQualityLimit(item.Quality))
                            {
                                item.Quality++;
                            }
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
                    if (item.Quality < _qualityLimit)
                    {
                        item.Quality++;
                    }
                }
            }
        }
    }

    private bool UnderQualityLimit(int quality)
    {
        return quality < _qualityLimit;
    }

}