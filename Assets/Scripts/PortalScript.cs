using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {
	public Transform gameController;

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			gameController.GetComponent<GameScript>().SwapWorld();
		}
	}
}
