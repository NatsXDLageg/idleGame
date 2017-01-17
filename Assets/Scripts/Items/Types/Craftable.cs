using UnityEngine;
using System.Collections;

public abstract class Craftable : ItemBase {
	protected int numberOfDifferentIngredients;
	protected ItemBase[] ingredients;
	protected int[] numbersOfIngredients;
	protected int numberCrafted;

	public Craftable(int id, string name, string spritePath) : base(id, name, spritePath) { }

    public ItemBase[] GetIngredients() {
		return this.ingredients;
	}
}
