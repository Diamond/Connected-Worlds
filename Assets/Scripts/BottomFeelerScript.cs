using UnityEngine;
using System.Collections;

public class BottomFeelerScript : MonoBehaviour {
	public Transform player;
	
	void OnTriggerEnter2D(Collider2D c)
	{
		PlayerScript ps = player.GetComponent<PlayerScript>();
		if (c.gameObject.tag == "Ground" || c.gameObject.tag == "Grinder") {
			ps.Landed();
		}
		if (c.gameObject.tag == "Grinder") {
			ps.Grinding();
		}
		if (c.gameObject.tag == "Ground") {
			ps.StopGrinding();
		}
	}
}
