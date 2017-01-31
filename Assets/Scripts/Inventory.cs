using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System;

public class Inventory
{
    public static Inventory instance;

    public static Inventory GetInventory()
    {
        Inventory inventory = new Inventory();
        return inventory;
    }

    private string inventoryKey = "InventorySaved";

    private string itemsPathName = ".\\Assets\\Scripts\\Items\\Items";
    private Type[] itemsTypes;
    private ItemInfo[] items;

    private string toolsPathName = ".\\Assets\\Scripts\\Items\\Tools";


    private Inventory()
    {
        //Remover essa linha!!!
        PlayerPrefs.DeleteAll();

        //Items     --------------------------------------------------------------------------------------------------
        string[] itemsFilesNames = Directory.GetFiles(this.itemsPathName, "*.cs");
        if(itemsFilesNames == null)
        {
            Debug.LogWarning("No file was encontered in the given path: " + this.itemsPathName);
            return;
        }

        string[] toolsFilesNames = Directory.GetFiles(this.toolsPathName, "*.cs");
        if (toolsFilesNames == null)
        {
            Debug.LogWarning("No file was encontered in the given path: " + this.toolsPathName);
            return;
        }

        int numberOfItems = itemsFilesNames.Length;
        int numberOfTools = toolsFilesNames.Length;
        int numberOfFiles = numberOfItems + numberOfTools;

        string[] itemsNames = new string[numberOfFiles];
        int i;
        for(i = 0; i < numberOfItems; i++)
        {
            itemsNames[i] = Path.GetFileNameWithoutExtension(itemsFilesNames[i]);
        }
        for (i = 0; i < numberOfTools; i++)
        {
            itemsNames[i + numberOfItems] = Path.GetFileNameWithoutExtension(toolsFilesNames[i]);
        }

        this.items = new ItemInfo[numberOfFiles];

        try
        {
            this.itemsTypes = new Type[numberOfFiles];
            for (i = 0; i < numberOfFiles; i++)
            {
                Type t = Type.GetType(itemsNames[i]);
                this.itemsTypes[i] = t;
            }
        }
        catch (MissingMethodException)
        {
            Debug.LogWarning("Could not find class " + itemsNames[i]);
        }
    }

    public int GetNumberOfItems()
    {
        return this.items.Length;
    }

    /// <summary>
    /// Sets each of the items that are in the array
    /// It must be called only once
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    public void SetItem (ItemInfo item, int index)
    {
        this.items[index] = item;
        this.items[index].SetItemBase((ItemBase)Activator.CreateInstance(this.itemsTypes[index]));
        this.items[index].SetQuantity(0);
    }

    public ItemInfo GetItem(int index)
    {
        return this.items[index];
    }
    public ItemInfo[] GetItems()
    {
        return this.items;
    }
    
    /// <summary>
    /// Increases the quantity of a certain item
    /// if no item with the specified name is found, it returns false, otherwise, it returns true
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public bool IncreaseItemQuantity(string itemName, int quantity = 1)
    {
        for (int i = 0; i < this.items.Length; i++)
        {
            if(this.items[i].GetItemBase().GetType().Name == itemName)
            {
                this.items[i].IncQuantity(quantity);
                return true;
            }
        }
        return false;
    }

    public bool DecreaseItemQuantity(string itemName, out bool hasEnought, int quantity = 1)
    {
        for (int i = 0; i < this.items.Length; i++)
        {
            if (this.items[i].GetItemBase().GetType().Name == itemName)
            {
                if(this.items[i].GetQuantity() >= quantity)
                {
                    this.items[i].IncQuantity(-1 * quantity);
                    hasEnought = true;
                }
                else
                {
                    hasEnought = false;
                }
                return true;
            }
        }
        hasEnought = false;
        return false;
    }

    public bool HasItem(string itemName, int quantity = 1)
    {
        if(this.items == null)
        {
            Debug.Log("No items were found");
            return false;
        }
        foreach (ItemInfo item in this.items)
        {
            if(item.GetItemBase().GetName() == itemName && item.GetQuantity() >= quantity)
            {
                return true;
            }
        }
        Debug.LogWarning("Inventory doesn't have item " + itemName);
        return false;
    }

    public bool HasItem(Type type, int quantity = 1)
    {
        if (this.items == null)
        {
            Debug.Log("No items were found");
            return false;
        }
        foreach (ItemInfo item in this.items)
        {
            if (item.GetItemBase().GetType() == type && item.GetQuantity() >= quantity)
            {
                return true;
            }
            Type[] nestedTypes = item.GetItemBase().GetType().GetNestedTypes();
            foreach (Type t in nestedTypes) {
                if (t == type && item.GetQuantity() >= quantity)
                {
                    return true;
                }
            }
        }
        Debug.LogWarning("Inventory doesn't have item with type " + type);
        return false;
    }

    public void LoadInventory()
    {
        if(PlayerPrefs.HasKey(this.inventoryKey))
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                items[i].SetQuantity(PlayerPrefs.GetInt(this.inventoryKey + items[i].GetItemBase().GetName()));
            }
        }
        else
        {
            PlayerPrefs.SetInt(this.inventoryKey, 1);
            for (int i = 0; i < this.items.Length; i++)
            {
                PlayerPrefs.SetInt(this.inventoryKey + items[i].GetItemBase().GetName(), 0);
            }
        }
    }

    public void SaveInventory()
    {
        PlayerPrefs.SetInt(this.inventoryKey, 1);
        for (int i = 0; i < this.items.Length; i++)
        {
            PlayerPrefs.SetInt(this.inventoryKey + items[i].GetItemBase().GetName(), items[i].GetQuantity());
        }
    }
}
