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
    private ItemInfo[] tools;


    private Inventory()
    {
        //Remover essa linha!!!
        PlayerPrefs.DeleteAll();

        //Items
        string[] filesNames = Directory.GetFiles(this.itemsPathName, "*.cs");
        if(filesNames == null)
        {
            Debug.LogWarning("No file was encontered in the given path: " + this.itemsPathName);
            return;
        }
        int numberOfFiles = filesNames.Length;
        string[] itemsNames = new string[numberOfFiles];
        int i;
        for(i = 0; i < numberOfFiles; i++)
        {
            itemsNames[i] = Path.GetFileNameWithoutExtension(filesNames[i]);
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
        
    }
}
