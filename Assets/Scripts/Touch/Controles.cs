using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {

	public GUIText ButtonFechar;

	void Update () {
		if (Input.GetKey ("escape"))
			Application.Quit();
	}
}
