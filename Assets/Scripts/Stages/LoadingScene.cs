using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {

	private float delay = 4.0f;
	private float currentTime = 0f;
	//private Gerenciador gerenciador;


	Button buttonObj;
	Text   textObj;

	private 	
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//ADS.showTop ();
		//ADS.showBottom ();

		buttonObj = GameObject.Find ("btnStart").GetComponent<Button>();
		buttonObj.interactable = false;

		textObj = GameObject.Find ("Loading").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!buttonObj.interactable) {
			currentTime += Time.deltaTime;

			if (currentTime > delay) {
				buttonObj.interactable = true;
				textObj.text = "Press Play";
				//textObj.color
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			//ADS.hideAll ();
			Application.LoadLevel("Menu");
		}
	}

	public void LoadLevel() {
		//ADS.hideAll ();
		Debug.Log (Gerenciador.levelLoading);
		Application.LoadLevel (Gerenciador.levelLoading);
	}
}
