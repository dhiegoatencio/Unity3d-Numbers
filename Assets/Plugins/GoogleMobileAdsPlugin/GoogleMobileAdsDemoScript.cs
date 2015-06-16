using UnityEngine;

// Example script showing how you can easily call into the GoogleMobileAdsPlugin.
public class GoogleMobileAdsDemoScript : MonoBehaviour {

	public string PublisherId = "";
	public bool testing = true;

    void Start()
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
		GoogleMobileAdsPlugin.CreateBannerView(PublisherId, GoogleMobileAdsPlugin.AdSize.SmartBanner, true);
		GoogleMobileAdsPlugin.RequestBannerAd(testing);
		#endif
    }

    void OnEnable()
    {
		GoogleMobileAdsPlugin.ReceivedAd 		 += HandleReceivedAd;
		GoogleMobileAdsPlugin.FailedToReceiveAd  += HandleFailedToReceiveAd;
    }

    void OnDisable()
    {
		GoogleMobileAdsPlugin.ReceivedAd 			-= HandleReceivedAd;
		GoogleMobileAdsPlugin.FailedToReceiveAd 	-= HandleFailedToReceiveAd;
    }

    public void HandleReceivedAd()
    {
        print("HandleReceivedAd event received");
    }

    public void HandleFailedToReceiveAd(string message)
    {
        print("HandleFailedToReceiveAd event received with message:");
        print(message);
    }


}