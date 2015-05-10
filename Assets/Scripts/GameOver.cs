using UnityEngine;
using System.Collections;
using StartApp;


public class GameOver : MonoBehaviour {

	public GUISkin skin;
	public Texture2D imgGameOver;
	public Texture2D btnVoltar;

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

		#if UNITY_ANDROID && !UNITY_EDITOR
		StartAppWrapper.addBanner (
			StartAppWrapper.BannerType.STANDARD,
			StartAppWrapper.BannerPosition.TOP);
		#endif

		if (vSair) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
			#endif
			Application.LoadLevel (0);
		}

	}

}