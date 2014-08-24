using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float jumpHeight = 5.0f;
	public float playerSpeed = 0.0f;
	private bool _landed = false;
	private bool _grinding = false;
	public Transform exclamation;
	public bool canWallJumpLeft = false;
	public bool canWallJumpRight = false;

	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;
		exclamation.renderer.enabled = false;
	}

	bool canJumpAgain()
	{
		return (_landed || this.canWallJumpLeft || this.canWallJumpRight);
	}
	
	// Update is called once per frame
	void Update () {
		float xvel = 0.0f;
		float yvel = 0.0f;
		if (this.canWallJumpLeft) {
			// Stick to left wall
			xvel -= 3.0f;
			yvel -= 1.0f;
		}
		if (this.canWallJumpRight) {
			// Stick to right wall
			xvel += 3.0f;
			yvel -= 1.0f;
		}
		
		if (Input.GetMouseButtonDown(0)) {
			if (canJumpAgain()) {
				if (this.canWallJumpLeft) {
					xvel = 3.0f;
					this.canWallJumpLeft = false;
				}
				if (this.canWallJumpRight) {
					xvel = -10.0f;
					this.canWallJumpRight = false;
				}
				this.gameObject.rigidbody2D.velocity += new Vector2(xvel, jumpHeight);
				_landed = false;
			}
		}// else {
			//if (Input.GetMouseButtonUp(0)) {
			//	this.gameObject.rigidbody2D.velocity -= new Vector2(0.0f, this.gameObject.rigidbody2D.velocity.y);
			//} else {
			// this.gameObject.rigidbody2D.velocity = new Vector2(xvel, yvel);
			//}
		//}
		this.transform.GetComponent<Animator>().SetBool("Jumping", !_landed);
		this.transform.GetComponent<Animator>().SetBool("Grinding", _grinding);
		this.particleSystem.enableEmission = _grinding || this.canWallJumpLeft || this.canWallJumpRight;
	}

	void OnCollisionEnter2D(Collision2D c)
	{

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

	public void Landed()
	{
		_landed = true;
	}

	public void Grinding()
	{
		_grinding = true;
	}

	public void StopGrinding()
	{
		_grinding = false;
	}

	public void OnBecameInvisible() {
		Application.LoadLevel (0);
	}
}
