using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements; // Declare the Unity Ads namespace.s

public class Gerenciador : MonoBehaviour {
	
	public Vector2 posicaoInicialPlayer;
	public Transform player;
	public int levelAtual;
	public int proximoLevel;
	public int quantidadeAColetar = 20;

	public string unityAdsGameId = "34512";

	public int rewardQty = 250;

	public static int levelLoading; // we need access on this variable on LoadingScene
	private GameObject menuExtraLife;

	
	void Start() {
		if (Advertisement.isSupported) { // If the platform is supported,
			Advertisement.Initialize(unityAdsGameId); // initialize Unity Ads. TRUE for test mode
		}
	
		menuExtraLife = GameObject.Find ("ExtraLifePanel");
		if (menuExtraLife) {
			menuExtraLife.SetActive (false);
		}
	}

	void Awake() {
		if (player != null)
			posicaoInicialPlayer = player.position;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
		    if (Application.loadedLevelName == "Menu")
				Application.Quit();
			else
				Application.LoadLevel("Menu");
		}
	}

	public bool isColetado() {  //se for verdadeiro passa de fase, senao fica na fase atual
		return quantidadeAColetar <= 0;
	}

	public void StartGame() {
		Time.timeScale = 1;
		player.position = posicaoInicialPlayer;
	}

	public void GameOver(string nome) {
		Time.timeScale = 1;
		Application.LoadLevel (nome); // carrega o level
	}

	public void AddPontosColetados(int pontos) {
		quantidadeAColetar -= pontos;
	}

	public void ProximoLevel(int level) {
		levelLoading = level;
		Application.LoadLevel ("changeLevel"); 
	}

	public void showPanelVideoAds() {
		Time.timeScale = 0;
		menuExtraLife.SetActive (true);
	}
}
