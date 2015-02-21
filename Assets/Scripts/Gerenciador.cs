using UnityEngine;
using System.Collections;

public class Gerenciador : MonoBehaviour {


	public Vector2 posicaoInicialPlayer;
	public Transform player;
	public int levelAtual;
	public int proximoLevel;
	public int quantidadeAColetar = 20;

	void Awake() {
		if (player != null)
			posicaoInicialPlayer = player.position;
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
