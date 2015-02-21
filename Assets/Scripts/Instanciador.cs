using UnityEngine;
using System.Collections;

public class Instanciador : MonoBehaviour {

	public GameObject[] objetos;


	private bool isEsquerda  = true;
	public float velocidade = 5f;
	public float mxDelay;

	public float instanciadorTempo = 5f;
	public float instanciadorDelay = 3f;

	private float timeMovimento = 0f;
	public int valorMinimoRandom = 0;

	// Use this for initialization
	void Start () {
	
		InvokeRepeating("Spawn",
		                instanciadorTempo,
		                instanciadorDelay);

	}
	
	// Update is called once per frame
	void Update () {
		Movimentar ();
	}

	void Spawn() {

		int index = Random.Range (valorMinimoRandom, objetos.Length);

		Instantiate(objetos[index], // o objeto que foi sorteado no random
		            transform.position, //a posiçao do Instanciador
		            objetos[index].transform.rotation); //pega a mesma rotaçao do Numero (objeto) 
	}

	void Movimentar() {

		timeMovimento += Time.deltaTime;

		if (timeMovimento <= mxDelay) {

						if (isEsquerda) {
								transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
								transform.eulerAngles = new Vector2 (0, 0);
						} else {
								transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
								transform.eulerAngles = new Vector2 (0, 180);
						}

		} else {

			isEsquerda = !isEsquerda;
			timeMovimento = 0;
		}
	}
}
