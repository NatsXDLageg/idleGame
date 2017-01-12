using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemsGrid : MonoBehaviour {
	public int nColumns;

	// Use this for initialization
	void Start () {
		float width = this.gameObject.GetComponent<RectTransform>().rect.width;
		Vector2 newSize = new Vector2(width / nColumns, width / nColumns);
		this.gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;

		Vector3 position = this.gameObject.GetComponent<RectTransform> ().localPosition;
		position = Vector3.zero;
		this.gameObject.GetComponent<RectTransform> ().localPosition = position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
