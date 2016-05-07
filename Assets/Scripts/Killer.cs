using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements; // Declare the Unity Ads namespace.s

public class Killer : MonoBehaviour {

	public AudioClip audioAoTocarPlayer;
	private Life life;
	private Gerenciador gerenciador;

	void Start () {
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
	}
		
	// o trigger, colide, porem ele passa direto pelo objeto
	void OnTriggerEnter2D(Collider2D colisor) {

		if (colisor.gameObject.tag == "Player") {

			//pegamos o componente Life dentro do objeto com a tag Lifes
			life = GameObject.FindGameObjectWithTag("Lifes").GetComponent<Life>() as Life;

			if (life.ExcluirVida()) {
				SomAoTocarNoMenino();
				gerenciador.StartGame(); // Coloca o Player na posiçao inicial novamente se cair na agua
			} else { // se nao tiver mais vida, entao da gameOver
				SomAoTocarNoMenino();
				gerenciador.showPanelVideoAds();
			}
		} else {
			Destroy(colisor.gameObject); // apaga todo o resto que cair na agua
		}
	}

	
	void SomAoTocarNoMenino() {
		GetComponent<AudioSource>().clip = audioAoTocarPlayer;
		AudioSource.PlayClipAtPoint (audioAoTocarPlayer, transform.position); // toca o clip na posiçao do transform
	}
}