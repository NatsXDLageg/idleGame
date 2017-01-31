using UnityEngine;
using System.Collections;

public abstract class ItemBase {

	//This class is usefull to compare items
	//It uses singleton pattern

	private int id;
	private string itemName;
    private string spritePath;

	public ItemBase(int id, string name, string spritePath) {
		this.id = id;
		this.itemName = name;
        this.spritePath = spritePath;
	}

    public virtual bool isTool()
    {
        return false;
    }

	public int GetId() {
		return this.id;
	}

	public string GetName() {
		return this.itemName;
	}

    public string GetSpritePath()
    {
        return this.spritePath;
    }
}
