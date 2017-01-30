using UnityEngine;
using System.Collections;
using System;

public class Cobblestone : Collectable
{
    public Cobblestone() : base(4, "cobblestone", "Artwork\\Items\\Cobblestone")
    {
        this.usedToolType = typeof(Pickaxe);
        this.collectsFromIt = new Type[1]
        {
            typeof(Cobblestone)
        };
        this.chanceOfGetting = 1.0f;
        this.hardness = 0.2f;
    }
}
