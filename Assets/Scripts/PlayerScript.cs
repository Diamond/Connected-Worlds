using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float jumpHeight = 5.0f;
	public float playerSpeed = 0.0f;
	private bool _landed = false;
	private bool _grinding = false;
	public Transform exclamation;

	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;
		exclamation.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (_landed) {
				this.gameObject.rigidbody2D.velocity += new Vector2(0.0f, jumpHeight);
				_landed = false;
			}
		}
		this.transform.GetComponent<Animator>().SetBool("Jumping", !_landed);
		this.transform.GetComponent<Animator>().SetBool("Grinding", _grinding);
		this.particleSystem.enableEmission = _grinding;
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Ground" || c.gameObject.tag == "Grinder") {
			_landed = true;
		}
		if (c.gameObject.tag == "Grinder" && this.rigidbody2D.velocity.y <= 0.0f) {
			_grinding = true;
		}
		if (c.gameObject.tag == "Ground") {
			_grinding = false;
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "DangerZone") {
			exclamation.renderer.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "DangerZone") {
			exclamation.renderer.enabled = false;
		}
	}
}
