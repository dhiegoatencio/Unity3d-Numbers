using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUISkin skinMenu;

	public Texture2D btnMenuPlay;
	public Texture2D btnMenuStages;
	public Texture2D titulo;
	public Texture2D btnVoltar;

	private Gerenciador gerenciador;

	void Start () {
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
		ADS.showTop ();
	}
	
	void OnGUI () {
		GUI.skin = skinMenu;
		/*GUI.DrawTexture (new Rect (Screen.width * 0.5f - titulo.width * 0.5f, 50,
		                           titulo.width, titulo.height),
		                 titulo);*/
		GUIPlay ();
		GUISair ();
		GUIStages ();
	}

	void GUIStages () {
		bool vStages = GUI.Button (new Rect (Screen.width * 0.5f  - btnMenuStages.width * 0.5f,
		                                     Screen.height * 0.3f + btnMenuStages.height,
		                                     198, 80),
		                           btnMenuStages);

		if (vStages) {
			ADS.hideAll ();
			Application.LoadLevel("Stages");
		}
	}

	void GUIPlay() {
		bool vPlay = GUI.Button (new Rect (Screen.width * 0.5f - btnMenuPlay.width * 0.5f,
		                                   Screen.height * 0.3f,
		                                   150, 80),
		                            btnMenuPlay);
		if (vPlay) {
			ADS.hideAll();
			gerenciador.ProximoLevel (gerenciador.proximoLevel);
			Score.Inicializar ();
		}
	}

	void GUISair() {
		bool vSair = GUI.Button (new Rect (Screen.width - 100, Screen.height - 100,
		                                  100, 100),
		                        btnVoltar);
		if (vSair) {
			Application.Quit (); //na emulaçao nao funciona, so na versao compilada
		}
	}
}
