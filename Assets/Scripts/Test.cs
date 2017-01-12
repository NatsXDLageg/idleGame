using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	private WoodLog wl;
	private WoodPlank wp;

	public Test() {
		wl = new WoodLog ();
		wp = new WoodPlank ();
	}

	public void Print() {
		Debug.Log(wl.GetId() + ", " + wp.GetId());
	}
}
