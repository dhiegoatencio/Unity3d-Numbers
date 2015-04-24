using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public Texture2D[] VidaAtual;
	private int vidas;
	private int contador;
	
	void Start () {
		GetComponent<GUITexture>().texture = VidaAtual [0]; //seta por default a texture da posiçao 1 do array (3 lifes)
		vidas = VidaAtual.Length;          //armazena de forma privada a quantidade de vidas (3 vidas)
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool ExcluirVida() {
		if (vidas < 0) {
			return false;
		}

		if (contador < (vidas - 1)) {
			contador += 1;
			GetComponent<GUITexture>().texture = VidaAtual [contador]; //seta a textura da quantidade de vidas atual
			return true;
		} else {
			return false;
		}
	}
}
