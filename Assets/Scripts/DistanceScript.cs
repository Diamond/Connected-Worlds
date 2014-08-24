using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceScript : MonoBehaviour {
    public Text text;
	public Transform player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Scrolls: " + player.GetComponent<PlayerScript>().scrolls.ToString ();
	}
}
