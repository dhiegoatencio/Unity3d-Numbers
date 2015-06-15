using UnityEngine;
//using UnityEngine.Advertisements;
using System.Collections;

public class Inimigo : MonoBehaviour {

	public GameObject objeto;

	private bool isEsquerda  = true;
	public float velocidade = 5f;
	public float mxDelay;
	private float timeMovimento = 0f;

	public Transform verticeInicial;
	public Transform verticeFinal;
	public bool isTarget;

	private float mxDelayObject = 0.2f;
	private float timeObject = 0; 

	void Start () {} // Use this for initialization

	void Update () { // Update is called once per frame
		//if (!Advertisement.isShowing) {
			Movimentar ();
			RayCasting ();
			Behaviours ();
		//}
	}

	void RayCasting() {
		Debug.DrawLine (verticeInicial.position,
		                verticeFinal.position,
		                Color.red);

		isTarget = Physics2D.Linecast (verticeInicial.position,
		                               verticeFinal.position,
     	                               1 << LayerMask.NameToLayer ("Player"));
	}

	void Behaviours() {
		timeObject += Time.deltaTime;
		if (isTarget) {
			if (timeObject >= mxDelayObject) {
				Instantiate(objeto, verticeInicial.position, objeto.transform.rotation);
				timeObject = 0;
			}
		}
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
