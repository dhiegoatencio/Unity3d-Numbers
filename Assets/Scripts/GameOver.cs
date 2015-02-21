using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GUISkin skin;

	public Texture2D imgGameOver;
	public Texture2D btnVoltar;

	void OnGUI () {
		GUI.skin = skin;
		GUI.DrawTexture (new Rect (Screen.width * 0.5f - imgGameOver.width * 0.5f, 50,
		                           imgGameOver.width, imgGameOver.height),
		                 imgGameOver);

		Navegacao.GUIBotaoVoltar (btnVoltar);
	}
}