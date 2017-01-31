using UnityEngine;
using System.Collections;

public class Tool : ItemBase {

    protected float totalDurability;
    protected float hardnessThatHarvests;

    public Tool(int id, string name, string spritePath) : base(id, name, spritePath) { }
    
    public override bool isTool()
    {
        return true;
    }
}
