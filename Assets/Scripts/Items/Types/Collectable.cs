using System;

public abstract class Collectable : ItemBase {
	protected Type[] collectsFromIt; //ObjectType instance = (ObjectType)Activator.CreateInstance(objectType);
    protected Type usedToolType;
	protected float chanceOfGetting;
    protected float hardness;   //Bedrock = 1.0f    Dirt = 0.1f

	public Collectable(int id, string name, string spritePath) : base(id, name, spritePath) {}

    public Type GetUsedToolType()
    {
        return this.usedToolType;
    }
}
