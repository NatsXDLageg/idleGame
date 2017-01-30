using UnityEngine;

public class CollectWoodButtonBehaviour : MonoBehaviour {
    
    public ItemsGrid itemGrid;
    
	void Start () {	}

    public void CollectWood()
    {
        string WoodLogName = "WoodLog";
        bool itemExists = this.itemGrid.IncreaseItemQuantity(WoodLogName);
        if(!itemExists)
        {
            Debug.Log("Could not find " + WoodLogName);
        }
    }
}
