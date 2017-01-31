using UnityEngine;
using System.Collections;
using System;

public class StonePickaxe : Pickaxe
{
    public StonePickaxe() : base(274, "stone_pickaxe", "Artwork\\Tools\\StonePickaxe")
    {
        this.totalDurability = 100;
        this.hardnessThatHarvests = 0.3f;
    }
}
