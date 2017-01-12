using UnityEngine;
using System.Collections;

public abstract class Craftable : ItemBase {
	protected int numberOfDifferentIngredients;
	protected ItemBase[] ingredients;
	protected int[] numbersOfIngredients;

	protected int numberCrafted;

	public Craftable(int id, string name) : base(id, name) {}

	public ItemBase[] GetIngredients() {
		return this.ingredients;
	}
}
