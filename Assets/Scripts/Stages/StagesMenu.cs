using UnityEngine;
using System.Collections;

public class StagesMenu : MonoBehaviour {

	public Texture2D btnVoltar;
	public GUISkin skin;
	private Score score;
	private Gerenciador gerenciador;

	void OnGUI () {
		ExibeStages ();
	}

	void Awake() {
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>() as Score;	
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
	}

	void ExibeStages() {

		int preco;
		int largura = 70;
		int altura  = 50;

		bool stageComprado;
		string textoBotao;


		GUI.BeginGroup (new Rect (10, 35, Screen.width, Screen.height));

		for (int i = 2; i <= 6; i++) {
			preco = i * i * 100;

			textoBotao = i.ToString();

			if (PlayerPrefs.GetInt("stage" + i.ToString(), 0) == 0) {
				textoBotao = textoBotao + "\n$" + preco.ToString();
				stageComprado = false;
			} else 
				stageComprado = true;

			// cria o botao com o preço do stage
			if (GUI.Button(new Rect(10 + largura * (i -2),10 ,largura,altura),
			               textoBotao)) {
				if (stageComprado)
					gerenciador.ProximoLevel (1);
				else {
					if (score.GetShop() >= preco) {
						score.ShopRemove(preco);
						PlayerPrefs.SetInt("stage" + i.ToString(), 1);
						gerenciador.ProximoLevel (1);
					}
				}
			}
					
		}
		GUI.EndGroup ();


		GUI.skin = skin;
		Navegacao.GUIBotaoVoltar (btnVoltar);
	}
}
