using UnityEngine;
using System.Collections;

public abstract class ItemBase {

	//This class is usefull to compare items
	//It uses singleton pattern

	private int id;
	private string itemName;

	public ItemBase(int id, string name) {
		this.id = id;
		this.itemName = name;
	}

	public int GetId() {
		return this.id;
	}

	public string GetName() {
		return this.itemName;
	}
}
