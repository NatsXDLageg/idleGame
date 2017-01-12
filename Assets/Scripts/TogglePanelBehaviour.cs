using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TogglePanelBehaviour : MonoBehaviour {

	public Toggle[] toggles;
	public GameObject[] panels;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangePanel() {
		if (this.toggles == null || this.panels == null) {
			Debug.LogWarning ("Cannot change de panel if no toggle or panel is linked");
			return;
		}
		if (this.toggles.Length != this.panels.Length) {
			Debug.LogWarning ("The number of toggles and panels must be the same");
			return;
		}
		for (int i = 0; i < toggles.Length; i++) {
			if (toggles [i].isOn == true) {
				panels [i].SetActive (true);
			}
			else {
				panels [i].SetActive (false);
			}
		}
	}
}
