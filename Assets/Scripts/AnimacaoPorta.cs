using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimacaoPorta : MonoBehaviour {
	
	private static float scroll   = 0.2f;  // scrolling velocity
	private static float duration = 1.8f;
	private float alpha  = 1.00f;
	private GUIText guiText;

	void Start() {
		guiText = GetComponent<GUIText>();
	}

	void Update () {	
		if (alpha > 0) {
			transform.position = new Vector3(transform.position.x,
			                                 transform.position.y + scroll * Time.deltaTime);
			alpha -= Time.deltaTime / duration;
			Color newColor = guiText.material.color;
			newColor.a = alpha; //can't set "a" color of material directly
			guiText.material.color = newColor;
			
		} else {
			Destroy(transform.gameObject);
		}
	}
}
