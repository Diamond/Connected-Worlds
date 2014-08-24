using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {
	void OnMouseDown()
	{
		Application.LoadLevel ("level1");
	}
}
