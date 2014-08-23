using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	public Transform presentLayer;
	public Transform pastLayer;
	public Transform player;
	private bool _present;

	void Start()
	{
		toggleEnabled(pastLayer);
		_present = true;
	}

	public void SwapWorld()
	{
		toggleEnabled(presentLayer);
		toggleEnabled(pastLayer);
		_present = !_present;
		if (_present) {
			player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
		} else {
			player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
		}

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
