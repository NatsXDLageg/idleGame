using System;
using UnityEngine;

public class CollectWoodButtonBehaviour : MonoBehaviour {
    
    public ItemsGrid itemGrid;
    private int counterToIncrease;
    private const int gapOfCounter = 5;
    
	void Start () {
        this.counterToIncrease = 0;
    }

    public void CollectWood()
    {
        string WoodLogName = "WoodLog";
        if (this.itemGrid.HasItem(Type.GetType("Axe")))
        {

            return;
        }
        else
        {
            this.counterToIncrease++;
        }
        if (counterToIncrease >= gapOfCounter)
        {
            bool itemExists = this.itemGrid.IncreaseItemQuantity(WoodLogName, counterToIncrease / gapOfCounter);
            counterToIncrease %= gapOfCounter;
            if (!itemExists)
            {
                Debug.Log("Could not find " + WoodLogName);
            }
        }
    }
}
