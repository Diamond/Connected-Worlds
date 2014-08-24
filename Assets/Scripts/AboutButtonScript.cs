using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AboutButtonScript: MonoBehaviour {
	public Transform titleScreen;

	void OnMouseDown()
	{
		titleScreen.GetComponent<TitleScreenScript>().aboutDelay = 0.4f;
		titleScreen.renderer.enabled = false;
	}
}
