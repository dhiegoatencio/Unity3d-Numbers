using UnityEngine;
using System.Collections;

public class Bomba : MonoBehaviour {


	public AudioClip audioAoTocarPlayer;
	public int ponto = 2;
	public float tempoMaximoVida;
	private float tempoVida;

	private Life life;
	private Gerenciador gerenciador;

	void Awake() {
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
	}
	
	void Start () {} // Use this for initialization
	
	// Update is called once per frame
	void Update () {
		tempoVida += Time.deltaTime;
		if (tempoVida >= tempoMaximoVida) {
			Destroy(gameObject);
			tempoVida = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			life = GameObject.FindGameObjectWithTag("Lifes").GetComponent<Life>() as Life;

			if (life.ExcluirVida()) {
				SomBombaTocouNoMenino();
				Destroy(gameObject);
				gerenciador.StartGame();
			} else {
			    gerenciador.GameOver("GameOver");
			}
		}
	}

	void SomBombaTocouNoMenino() {
		GetComponent<AudioSource>().clip = audioAoTocarPlayer;
		AudioSource.PlayClipAtPoint (audioAoTocarPlayer, transform.position); // toca o clip na posiçao do transform
	}
}
