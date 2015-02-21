using UnityEngine;
using System.Collections;

public class CameraFollow2 : MonoBehaviour {


	public Transform player;
	public float smooth = 0.05f;
	private Vector2 velocidade;

	// Use this for initialization
	void Start () {
		velocidade = new Vector2 (0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 novaPosicao2D = Vector2.zero;

		novaPosicao2D.x = Mathf.SmoothDamp (transform.position.x, //posiçao atual
		                                    player.position.x,    //posiçao alvo
		                                    ref velocidade.x,
		                                    smooth);

		novaPosicao2D.y = Mathf.SmoothDamp (transform.position.y, //posiçao atual
		                                    player.position.y,    //posiçao alvo
		                                    ref velocidade.y,
		                                    smooth);

		//a acamera trabalha com 3 posiçoes, x/y/z
		Vector3 novaPosicao = new Vector3 (novaPosicao2D.x, 
		                                   novaPosicao2D.y,
		                                   transform.position.z);

		//Onde a camera esta, onde ela vai  (existe o metodo Slep tambem)
		transform.position = Vector3.Slerp (transform.position,
		                                    novaPosicao,
		                                    Time.time);
	}
}
