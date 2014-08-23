using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {
	public float buildingSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3(buildingSpeed * Time.deltaTime, 0.0f, 0.0f);
	}
}
