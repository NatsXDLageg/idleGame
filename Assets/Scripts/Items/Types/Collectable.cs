using UnityEngine;
using System.Collections;

public abstract class Collectable : ItemBase {
	protected ItemBase collectableFrom;
	protected Tool usedTool;
	protected float chanceOfGetting;
    protected float hardness;

	public Collectable(int id, string name, string spritePath) : base(id, name, spritePath) {}
}
