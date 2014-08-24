using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {
	public float buildingSpeed = 5.0f;


	// Update is called once per frame
	void Update () {
		float moveY = 0.0f;
		this.transform.position -= new Vector3(buildingSpeed * Time.deltaTime, moveY, 0.0f);
		if (this.transform.position.x <= -10.0f) {
			Wrap ();
		}
	}

	void Wrap()
	{
		this.transform.position += new Vector3(90.0f, 0.0f, 0.0f);
	}
}
