using UnityEngine;
using System.Collections;

public abstract class Collectable : ItemBase {
	protected ItemBase collectableFrom;
	protected Tool usedTool;
	protected float chanceOfGetting;

	public Collectable(int id, string name) : base(id, name) {}

	public ItemBase[] GetIngredients() {
		return this.ingredients;
	}
}
