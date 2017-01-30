using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemsGrid : MonoBehaviour {
	public int nColumns;
    public GameObject itemPrefab;
    private Inventory inventory;
    
    void Start () {
		float width = this.gameObject.GetComponent<RectTransform>().rect.width;
		Vector2 newSize = new Vector2(width / nColumns, width / nColumns);
		this.gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;

		Vector3 position = this.gameObject.GetComponent<RectTransform> ().localPosition;
		position = Vector3.zero;
		this.gameObject.GetComponent<RectTransform> ().localPosition = position;

        this.inventory = Inventory.GetInventory();

        this.LoadInventory();
	}

    public void LoadInventory()
    {
        GameObject[] gridSquares;
        
        int numberOfItems = this.inventory.GetNumberOfItems();
        gridSquares = new GameObject[numberOfItems];
        
        for(int i = 0; i < gridSquares.Length; i++)
        {
            //Cria ItemInfos com pai sendo esse objeto
            gridSquares[i] = (GameObject) Instantiate(this.itemPrefab, this.transform);
            
            this.inventory.SetItem(gridSquares[i].GetComponent<ItemInfo>(), i);

            ItemInfo item = this.inventory.GetItem(i);
            
            gridSquares[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load(item.GetItemBase().GetSpritePath(), typeof(Sprite)) as Sprite;
            gridSquares[i].transform.GetChild(2).GetComponent<Text>().text = item.GetQuantity().ToString();
        }

        this.inventory.LoadInventory();
    }

    public bool IncreaseItemQuantity(string itemName, int quantity = 1)
    {
        bool returnValue = this.inventory.IncreaseItemQuantity(itemName, quantity);
        this.UpdateQuantity();
        return returnValue;
    }

    public bool DecreaseItemQuantity(string itemName, out bool hasEnought, int quantity = 1)
    {
        bool returnValue = this.inventory.DecreaseItemQuantity(itemName, out hasEnought, quantity);
        this.UpdateQuantity();
        return returnValue;
    }

    public void UpdateQuantity(int index)
    {
        ItemInfo[] items = this.inventory.GetItems();
        items[index].transform.GetChild(2).GetComponent<Text>().text = items[index].GetQuantity().ToString();
    }

    public void UpdateQuantity()
    {
        ItemInfo[] items = this.inventory.GetItems();
        for (int i = 0; i < items.Length; i++)
        {            
            items[i].transform.GetChild(2).GetComponent<Text>().text = items[i].GetQuantity().ToString();
        }
    }
}
