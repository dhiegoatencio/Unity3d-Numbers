using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GUISkin skin;
	public Texture2D imgGameOver;
	public Texture2D btnVoltar;

	void Start() {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void OnGUI () {
		GUI.skin = skin;
		if (imgGameOver != null) {

			GUI.DrawTexture (new Rect (Screen.width * 0.5f - imgGameOver.width * 0.5f, 50,
		                           imgGameOver.width, imgGameOver.height),
		                 imgGameOver);

		}

		bool vSair = GUI.Button (new Rect (Screen.width - 100, Screen.height - 100,
		                                   100, 100),
		                         btnVoltar);

		ADS.showTop ();

		if (vSair) {
			ADS.hideAll();
			Application.LoadLevel (0);
		}

	}

}