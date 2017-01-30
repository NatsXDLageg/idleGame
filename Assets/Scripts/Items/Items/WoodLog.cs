using UnityEngine;
using System.Collections;
using System;

public class WoodLog : Collectable
{
	public WoodLog () : base (17, "wood_log", "Artwork\\Items\\WoodLog")
    {
        this.usedToolType = typeof(Axe);
        this.collectsFromIt = new Type[1]
        {
            typeof(WoodLog)
        };
        this.chanceOfGetting = 1.0f;
        this.hardness = 0.2f;
    }
}
