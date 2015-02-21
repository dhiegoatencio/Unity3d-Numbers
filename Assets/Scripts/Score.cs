using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//public static int score; // estatica pois a cada scene a pontuaçao deve continuar
	public static Score instance;
	private Gerenciador gerenciador;
	private int vShop;
	public bool ExibeDoor = true;

	//void Awake() {instance = this;}

	void Start () {
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
		vShop = PlayerPrefs.GetInt("shop");
		AtualizaInf ();
	}
	
	void AtualizaInf () {
		if (ExibeDoor) {
			if (gerenciador.quantidadeAColetar <= 0)
				guiText.text = "$: " + vShop + "    *** The door is open! ***";
			else
				guiText.text = "$: " + vShop + "    Door: " + gerenciador.quantidadeAColetar;
		} else
			guiText.text = "$: " +vShop;
	}

	public void AddScore(int _ponto) {
		gerenciador.AddPontosColetados (_ponto);
		vShop += _ponto;
		PlayerPrefs.SetInt("shop", vShop);
		AtualizaInf ();
	}

	public static void Inicializar() {/*score = 0;*/}

	public void ShopRemove(int _points) {
		PlayerPrefs.SetInt("shop", vShop - _points);
		AtualizaInf ();
	}

	public int GetShop() {
		return vShop;
	}
}
