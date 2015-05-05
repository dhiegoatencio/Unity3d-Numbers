using UnityEngine;
using System.Collections;
using StartApp;


public class GameOver : MonoBehaviour {

	public GUISkin skin;

	public Texture2D imgGameOver;
	public Texture2D btnVoltar;

	void start() {
		#if UNITY_ANDROID
		StartAppWrapper.addBanner (
			StartAppWrapper.BannerType.AUTOMATIC,
			StartAppWrapper.BannerPosition.TOP);
		#endif
	}

	void OnGUI () {
		GUI.skin = skin;
		if (imgGameOver != null) {

			GUI.DrawTexture (new Rect (Screen.width * 0.5f - imgGameOver.width * 0.5f, 50,
		                           imgGameOver.width, imgGameOver.height),
		                 imgGameOver);

		}
		Navegacao.GUIBotaoVoltar (btnVoltar);
	}

	void OnDestroy() {
		#if UNITY_ANDROID
		StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
		#endif
	}
}