using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {
	public Transform gameController;
	public bool isForPresent = true;

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player" && renderer.enabled) {
			gameController.GetComponent<GameScript>().SwapWorld();
		}
	}

	void Update()
	{
		if (isForPresent == gameController.GetComponent<GameScript>().present) {
			renderer.enabled = true;
		} else {
			renderer.enabled = false;
		}
	}
}
