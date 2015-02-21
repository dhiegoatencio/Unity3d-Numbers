using UnityEngine;
using System.Collections;

public class Numero : MonoBehaviour {


	public AudioClip clip;
	private float timeVida;
	public  float tempoMaximoVida;
	private Score score;
	public int pontuacao = 1;

	void Awake() {
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>() as Score;	
	}

	void Start () {
		timeVida = 0;
	}
	
	void Update () {
		timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida) {
			Destroy(gameObject);
			timeVida = 0;
		}
	}

	//este evento necessita que o objeto tenha RigidBody para ativar esta rotina
	void OnCollisionEnter2D(Collision2D colisor) {

		// Quando o colisor colidir com o objeto com a tag Player
		if (colisor.gameObject.tag == "Player") {
			SomColetar();
			score.AddScore(pontuacao);
			Destroy(gameObject); // destroi o objeto, ou seja, o numero
		}
	}

	void SomColetar() {
		audio.clip = clip;
		AudioSource.PlayClipAtPoint (clip, transform.position); // toca o clip na posiçao do transform
	}
}
