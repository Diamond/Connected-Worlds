﻿using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public Transform titleScreen;
	public float aboutDelay = 0.0f;

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