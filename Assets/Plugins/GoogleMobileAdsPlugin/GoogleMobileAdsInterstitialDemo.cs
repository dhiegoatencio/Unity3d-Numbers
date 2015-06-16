using UnityEngine;
using System.Collections;

public class GoogleMobileAdsInterstitialDemo : MonoBehaviour {

	public string PublisherId = "";
	public bool testing = true;
	void Start()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		GoogleMobileAdsPlugin.CreateInterstitial(PublisherId);
		GoogleMobileAdsPlugin.RequestInterstitial(testing);
		#endif
	}

	void OnEnable()
	{
		GoogleMobileAdsPlugin.InterstitialReceivedAd 		 += HandleReceivedAd;
		GoogleMobileAdsPlugin.InterstitialFailedToReceiveAd  += HandleFailedToReceiveAd;
	}
	
	void OnDisable()
	{
		GoogleMobileAdsPlugin.InterstitialReceivedAd 			-= HandleReceivedAd;
		GoogleMobileAdsPlugin.InterstitialFailedToReceiveAd 	-= HandleFailedToReceiveAd;
	}
	
	public void HandleReceivedAd()
	{
		print("HandleReceivedAd event received");
		GoogleMobileAdsPlugin.ShowInterstitial();
	}
	
	public void HandleFailedToReceiveAd(string message)
	{
		print("HandleFailedToReceiveAd event received with message:");
		print(message);
	}
	


}
