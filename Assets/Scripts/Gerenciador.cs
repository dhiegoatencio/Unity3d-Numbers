using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class Gerenciador : MonoBehaviour {
	
	public Vector2 posicaoInicialPlayer;
	public Transform player;
	public int levelAtual;
	public int proximoLevel;
	public int quantidadeAColetar = 20;
	private bool adsShowed = false;

	void Start() {
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("34512", false); //set to false before commit (true is used for test mode)
		} else
			Debug.Log("ADS nao suportado.");
	}

	void Awake() {
		adsShowed = false; // one time per level
		if (player != null)
			posicaoInicialPlayer = player.position;
	}

	void Update() {
		if ((adsShowed == false) &&
		    (!Advertisement.isShowing) &&
			(Advertisement.isReady ("pictureZone")) &&
			(levelAtual != 0) // don't show ADS in menu/stages/gameover
		    ) {

			//show with default zone, pause engine and print result to debug log
			Advertisement.Show ("pictureZone", new ShowOptions{
				pause = true,  //pause game while ads are show
				resultCallback = result =>  //triggered when the ad is closed
				{
					Debug.Log(result.ToString());
				}
			});
			adsShowed = true;
		} else {

			if (!Advertisement.isShowing && Input.GetKeyDown (KeyCode.Escape)) {
			    if (Application.loadedLevelName == "Menu")
					Application.Quit();
				else
					Application.LoadLevel("Menu");
			}
		}
	}

	public bool isColetado() {  //se for verdadeiro passa de fase, senao fica na fase atual
		return quantidadeAColetar <= 0;
	}

	public void StartGame() {
		player.position = posicaoInicialPlayer;
	}

	public void GameOver(string nome) {
		Application.LoadLevel (nome); // carrega o level
	}

	public void AddPontosColetados(int pontos) {
		quantidadeAColetar -= pontos;
	}

	public void ProximoLevel(int level) {
		Application.LoadLevel (level);
	}
}
