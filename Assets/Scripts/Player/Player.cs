using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	public float velocidade;

	public Transform player;
	private Animator animator;
	private int direction = 0; // -1 = left / 1 = right

	public bool isGrounded;
	public float force;

	public float jumpTime = 0.4f;
	public float jumpDelay = 0.4f;
	public bool jumped = false;
	public Transform ground;

	public bool disableTouches;

	public AudioClip audioJump;

	private Gerenciador gerenciador;

	void Start () { // Use this for initialization
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador; //Procurando o objeto Gerenciador na cena
		animator = player.GetComponent<Animator> ();
		gerenciador.StartGame();
	}

	void Update () { // Update is called once per frame

		isGrounded = Physics2D.Linecast (this.transform.position,
		                                 ground.position,
		                                 1 << LayerMask.NameToLayer ("Plataforma"));
		animator.SetFloat ("run", Mathf.Abs (Input.GetAxis ("Horizontal")));

		Movimentar();

		jumpTime -= Time.deltaTime;
		if (jumpTime <= 0 && isGrounded && jumped) {
			jumped = false;
			animator.SetTrigger ("ground");
		}
	}

	void Movimentar(){

		//movimentos pelo teclado   (direcionais e barra de espaço)
		if ((Input.GetAxisRaw ("Horizontal") > 0) || direction == 1)
				MoveToRight ();
		else if (Input.GetAxisRaw ("Horizontal") < 0 || direction == -1)
				MoveToLeft ();
		if (Input.GetButtonDown ("Jump") && CanJump ())
				Jump ();
	}

	public void Jump () {
		if (CanJump ()) {
			GetComponent<Rigidbody2D>().AddForce(transform.up * force);
			jumpTime = jumpDelay;
			jumped   = true;
			GetComponent<AudioSource>().clip = audioJump;
			AudioSource.PlayClipAtPoint (audioJump, transform.position); // toca o clip na posiçao do transform
			animator.SetTrigger("jump");
		}
	}
 
	void MoveToRight () {
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
		transform.eulerAngles = new Vector2(0,0);
		animator.SetFloat("run", 0.9f);
	}

	void MoveToLeft() {
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
		transform.eulerAngles = new Vector2(0,180);
		animator.SetFloat("run", 0.9f);
	}

	bool CanJump () {return isGrounded && !jumped;}

	void OnCollisionEnter2D(Collision2D colisor) {

		if (colisor.gameObject.name == "Porta") {
			if (gerenciador.isColetado()) {
				gerenciador.ProximoLevel(gerenciador.proximoLevel);
			}
		}
	}

	public void SetTouchDirection(int dir) {
		this.direction = dir;
	}
}