using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
	public Transform player;
	private float _speed = 3.0f;

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			Respawn ();
			player.GetComponent<PlayerScript>().GetScroll();
		}
	}

	void Update()
	{
		this.transform.position -= new Vector3(3.0f * Time.deltaTime, 0.0f, 0.0f);
		if (this.transform.position.x <= -7.5f) {
			Respawn();
		}
	}

	void Respawn()
	{
		float xpos = Random.Range (10.0f, 20.0f);
		float ypos = Random.Range (0.0f, 2.5f);
		this.transform.position = new Vector3(xpos, ypos, 0.0f);
		_speed = Random.Range (2.0f, 4.0f);
	}
}
