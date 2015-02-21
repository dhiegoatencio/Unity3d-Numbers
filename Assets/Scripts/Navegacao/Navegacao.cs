using UnityEngine;
using System.Collections;

public class Navegacao : MonoBehaviour {


	public static void GUIBotaoVoltar(Texture2D btnVoltar) {

		bool vSair = GUI.Button (new Rect (Screen.width - 100, Screen.height - 100,
		                                   100, 100),
		                         btnVoltar);
		if (vSair)
			Application.LoadLevel (0);
	}

}