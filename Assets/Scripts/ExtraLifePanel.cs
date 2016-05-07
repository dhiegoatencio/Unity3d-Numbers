using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements; // Declare the Unity Ads namespace.s

public class ExtraLifePanel : MonoBehaviour {

	Gerenciador gerenciador;
	AudioSource audioSourceMainCamera;
	Life life;

	public string unityZoneId = "rewardedVideoZone";

	void Start () {
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
		audioSourceMainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource>() as AudioSource;
		life = GameObject.FindGameObjectWithTag("Lifes").GetComponent<Life>() as Life;
	}

	public void GameOver() {
		gerenciador.GameOver("GameOver"); // vai carregar a cena que tenha o nome "GameOver"
	}

	public void ShowAds() {
		if (Advertisement.IsReady (unityZoneId)) {
			ShowOptions options = new ShowOptions();
			options.resultCallback = HandleUnityAdsResult;
			Time.timeScale = 0;
			audioSourceMainCamera.mute = true;
			Advertisement.Show (unityZoneId, options);
		}
	}

	void finishAds() {
		audioSourceMainCamera.mute = false;
	}

	void HandleUnityAdsResult (ShowResult result)
	{

		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("Video completed. User rewarded credits.");
			finishAds();
			gerenciador.StartGame();
			transform.gameObject.SetActive (false);
			break;
		case ShowResult.Skipped:
			finishAds();
			Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
			finishAds();
			Debug.LogError ("Video failed to show.");
			break;
		}
	}
}
