using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System;

public class Inventory {

    public static Inventory instance;

    public static Inventory GetInventory()
    {
        Inventory inventory = new Inventory();
        inventory.LoadInventory();
        return inventory;
    }

    private string inventoryKey = "InventorySaved";

    private string itemsPathName = ".\\Assets\\Scripts\\Items\\Items";
    private ItemBase[] items;
    private int[] itemsQuantity;

    private string toolsPathName = ".\\Assets\\Scripts\\Items\\Tools";
    private ItemBase[] tools;
    private int[] toolsQuantity;

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

        int numberOfItems = itemsNames.Length;
        this.items = new ItemBase[numberOfItems];
        this.itemsQuantity = new int[numberOfItems];
        
        try
        {
            for (i = 0; i < numberOfItems; i++)
            {
                Type t = Type.GetType(itemsNames[i]);
                this.items[i] = (ItemBase)Activator.CreateInstance(t);

                this.itemsQuantity[i] = 0;
            }
        }
        catch(MissingMethodException exception)
        {
            Debug.LogWarning("Could not find class " + itemsNames[i]);
        }
    }

    public void GetItems(out ItemBase[] items, out int[] itemsQuantity)
    {
        items = this.items;
        itemsQuantity = this.itemsQuantity;
    }

    public void LoadInventory()
    {
        if(PlayerPrefs.HasKey(this.inventoryKey))
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                itemsQuantity[i] = PlayerPrefs.GetInt(this.inventoryKey + items[i].GetName());
            }
        }
        else
        {
            PlayerPrefs.SetInt(this.inventoryKey, 1);
            for (int i = 0; i < this.items.Length; i++)
            {
                PlayerPrefs.SetInt(this.inventoryKey + items[i].GetName(), 0);
            }
        }
    }

    public void SaveInventory()
    {
        
    }
}
