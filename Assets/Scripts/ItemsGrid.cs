using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemsGrid : MonoBehaviour {
	public int nColumns;
    public GameObject itemPrefab;
    private Inventory inventory;

	// Use this for initialization
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
        ItemBase[] items;
        int[] itemsQuantity;
        GameObject[] gridSquares;

        inventory.GetItems(out items, out itemsQuantity);
        gridSquares = new GameObject[items.Length];

        for(int i = 0; i < gridSquares.Length; i++)
        {
            gridSquares[i] = (GameObject) Instantiate(this.itemPrefab, this.transform);
            gridSquares[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load(items[i].GetSpritePath(), typeof(Sprite)) as Sprite;
            gridSquares[i].transform.GetChild(2).GetComponent<Text>().text = itemsQuantity[i].ToString();
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
