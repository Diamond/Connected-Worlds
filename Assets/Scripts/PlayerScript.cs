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
	public AudioClip jumpSound;
	public AudioClip slideSound;
	public AudioClip scrollSound;
	public float distance = 0.0f;
	public int   scrolls = 0;

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

		if (this.transform.position.x >= 0.0f) {
			xvel = -0.1f;
		} else if (this.transform.position.x <= 0.0f) {
			xvel = 0.05f;
		}

		if (this.transform.position.x <= 0.05f && this.transform.position.x >= -0.05f) {
			xvel = 0.0f;
		}

		if (Input.GetMouseButtonDown(0)) {
			if (canJumpAgain()) {
				this.gameObject.rigidbody2D.velocity += new Vector2(xvel, jumpHeight);
				audio.PlayOneShot(jumpSound);
				_landed = false;
			} else {
				this.gameObject.rigidbody2D.velocity += new Vector2(xvel, 0.0f);
            }
		} else {
			this.gameObject.rigidbody2D.velocity += new Vector2(xvel, 0.0f);
        }
		distance += 1.0f * Time.deltaTime;
        this.transform.GetComponent<Animator>().SetBool("Jumping", !_landed);
		this.transform.GetComponent<Animator>().SetBool("Grinding", _grinding);
		this.particleSystem.enableEmission = _grinding || this.canWallJumpLeft || this.canWallJumpRight;
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
		if (PlayerPrefs.HasKey("Scrolls")) {
			if (PlayerPrefs.GetInt("Scrolls") < scrolls) {
				PlayerPrefs.SetInt("Scrolls", scrolls);
			}
		} else {
			PlayerPrefs.SetFloat("Scrolls", scrolls);
		}
		PlayerPrefs.Save();
	}

	public void GetScroll()
	{
		scrolls++;
		audio.PlayOneShot(scrollSound);
	}
}
