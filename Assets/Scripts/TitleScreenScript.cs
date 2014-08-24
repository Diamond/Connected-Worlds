using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public Transform titleScreen;
	public float aboutDelay = 0.0f;
	public Text distanceText;

	void Start()
	{
		Input.simulateMouseWithTouches = true;
		if (PlayerPrefs.HasKey ("Distance")) {
			distanceText.text = "Top Score: " + PlayerPrefs.GetInt("Scrolls").ToString();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !titleScreen.renderer.enabled) {
			if (aboutDelay <= 0.0f) {
				titleScreen.renderer.enabled = true;
			}
		}
		aboutDelay -= 1.0f * Time.deltaTime;
	}
}
