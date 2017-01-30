using UnityEngine;
using System.Collections;

public class ItemInfo : MonoBehaviour {
    private ItemBase item;
    private int quantity;

    public ItemInfo() {}

    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }
    public int GetQuantity()
    {
        return this.quantity;
    }

    public void IncQuantity(int incAmount = 1)
    {
        this.quantity += incAmount;
    }

    public void SetItemBase(ItemBase item)
    {
        this.item = item;
    }
    public ItemBase GetItemBase()
    {
        return this.item;
    }
}
