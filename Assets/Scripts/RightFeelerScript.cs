using UnityEngine;
using System.Collections;

public class RightFeelerScript : MonoBehaviour {
	public Transform player;
	
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "WallJumpable") {
			player.GetComponent<PlayerScript>().canWallJumpRight = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "WallJumpable") {
			player.GetComponent<PlayerScript>().canWallJumpRight = false;
		}
	}
}
