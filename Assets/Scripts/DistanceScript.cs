using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceScript : MonoBehaviour {
    public float distance = 0.0f;
    public Text text;
    public AudioClip audio;

	// Use this for initialization
	void Start () {
	    distance = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    distance += 1.0f * Time.deltaTime;
        text.text = "Distance: " + distance.ToString ();
	}
}
