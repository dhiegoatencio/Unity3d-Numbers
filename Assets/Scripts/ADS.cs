using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class ADS : MonoBehaviour {


	void Awake() {
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("34512", true);
		} else
			Debug.Log("ADS nao suportado.");
	}

	void Update() {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10, 10, 150, 50), Advertisement.isReady () ? "Show Ad" : "Waiting...")) {

			//show with default zone, pause engine and print result to debug log
			Advertisement.Show(null, new ShowOptions{
				pause = true,
				resultCallback = result =>
				{
					Debug.Log(result.ToString());
				}
			});
		}
	}
}