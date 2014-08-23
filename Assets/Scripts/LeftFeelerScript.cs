using UnityEngine;
using System.Collections;

public class LeftFeelerScript : MonoBehaviour {
	public Transform player;

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "WallJumpable") {
			player.GetComponent<PlayerScript>().canWallJumpLeft = true;
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "WallJumpable") {
			player.GetComponent<PlayerScript>().canWallJumpLeft = false;
		}
	}
}
