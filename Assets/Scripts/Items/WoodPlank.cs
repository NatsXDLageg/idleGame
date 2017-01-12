using UnityEngine;
using System.Collections;

public class WoodPlank : Craftable {

	public WoodPlank () : base (5, "wood_plank") {
		this.numberOfDifferentIngredients = 1;
		this.ingredients = new ItemBase[this.numberOfDifferentIngredients];
		this.numbersOfIngredients = new int[this.numberOfDifferentIngredients];

		this.numberCrafted = 4;

		this.ingredients [0] = new WoodLog ();
		this.numbersOfIngredients [0] = 1;
	}
}
