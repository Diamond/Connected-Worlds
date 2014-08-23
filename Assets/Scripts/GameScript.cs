using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	public Transform presentLayer;
	public Transform pastLayer;
	public Transform player;

	void Start()
	{
		toggleEnabled(pastLayer);
	}

	public void SwapWorld()
	{
		toggleEnabled(presentLayer);
		toggleEnabled(pastLayer);
	}

	public void toggleEnabled(Transform obj)
	{
		if (obj.renderer) {
			obj.renderer.enabled = !obj.renderer.enabled;
			obj.collider2D.enabled = obj.renderer.enabled;
		}
		foreach (Transform child in obj) {
			if (child.renderer) {
				child.renderer.enabled = !child.renderer.enabled;
				child.collider2D.enabled = child.renderer.enabled;
			}
		}
	}

	void Update() {
		if (Input.GetMouseButtonDown(1)) {
			SwapWorld ();
	    }
	}
}
