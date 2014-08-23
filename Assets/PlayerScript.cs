using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float jumpHeight = 5.0f;

	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			this.gameObject.rigidbody2D.velocity += new Vector2(0.0f, jumpHeight);
		}
	}
}
