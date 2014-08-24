using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	public float buildingSpeed = 5.0f;
	public float buildingYSpeed = 0.0f;

	void Start() {
		SetYSpeed ();
	}

	// Update is called once per frame
	void Update () {
		float moveY = buildingYSpeed * Time.deltaTime;
		this.transform.position -= new Vector3(buildingSpeed * Time.deltaTime, moveY, 0.0f);
		if (this.transform.position.x <= -8.0f) {
			Wrap ();
		}
		if (this.transform.position.y >= 2.5f || this.transform.position.y <= -2.5f) {
			buildingYSpeed *= -1.0f;
		}
	}

	void Wrap()
	{
		this.transform.position += new Vector3(90.0f, 0.0f, 0.0f);
		SetYSpeed ();
	}

	void SetYSpeed()
	{
		int dir = Random.Range (0, 3);
		if (dir == 0) {
			buildingYSpeed = 1.0f;
		} else if (dir == 1) {
			buildingYSpeed = -1.0f;
		} else {
			buildingYSpeed = 0.0f;
		}
	}
}
