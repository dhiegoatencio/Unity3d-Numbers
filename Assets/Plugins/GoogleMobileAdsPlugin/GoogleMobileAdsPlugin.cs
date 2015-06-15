using System;
using UnityEngine;

// The Google Mobile Ads script used to call into the native Google Mobile Ads Plugin library.
public class GoogleMobileAdsPlugin : MonoBehaviour {

	// The plugin's class name.
	private const string PluginClassName = "com.google.unity.GoogleMobileAdsPlugin";

    // Defines string values for supported ad sizes.
    public class AdSize
    {
        private string adSize;
        private AdSize(string value)
        {
            this.adSize = value;
        }

        public override string ToString()
        {
            return adSize;
        }

        public static AdSize Banner = new AdSize("BANNER");
        public static AdSize MediumRectangle = new AdSize("IAB_MRECT");
        public static AdSize IABBanner = new AdSize("IAB_BANNER");
        public static AdSize Leaderboard = new AdSize("IAB_LEADERBOARD");
        public static AdSize SmartBanner = new AdSize("SMART_BANNER");
    }

    // These are the ad callback events that can be hooked into.
    public static event Action ReceivedAd = delegate {};
    public static event Action<string> FailedToReceiveAd = delegate {};
    public static event Action ShowingOverlay = delegate {};
    public static event Action DismissedOverlay = delegate {};
    public static event Action LeavingApplication = delegate {};

	public static event Action InterstitialReceivedAd = delegate {};
	public static event Action<string> InterstitialFailedToReceiveAd = delegate {};
	public static event Action InterstitialShowingOverlay = delegate {};
	public static event Action InterstitialDismissedOverlay = delegate {};
	public static event Action InterstitialLeavingApplication = delegate {};

    void Awake()
    {
        gameObject.name = this.GetType().ToString();
        SetCallbackHandlerName(gameObject.name);
        DontDestroyOnLoad(this);
    }

	public static void CreateInterstitial( string publisherId )
	{
		AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
		pluginClass.CallStatic("createInterstitial",
		                       new object[2] { activity, publisherId });
	}
	 
    // Create a banner view and add it into the view hierarchy.
    public static void CreateBannerView(string publisherId, AdSize adSize, bool positionAtTop)
    {
        AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
        pluginClass.CallStatic("createBannerView",
            new object[4] { activity, publisherId, adSize.ToString(), positionAtTop });
    }

	// Request a new ad for the banner view without any extras.
	public static void RequestInterstitial(bool isTesting)
	{
		AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
		pluginClass.CallStatic("requestInterstitialAd", new object[1] {isTesting});
	}

    // Request a new ad for the banner view without any extras.
    public static void RequestBannerAd(bool isTesting)
    {
		AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
        pluginClass.CallStatic("requestBannerAd", new object[1] {isTesting});
    }

    // Request a new ad for the banner view with extras.
    public static void RequestBannerAd(bool isTesting, string extras)
    {
        AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
        pluginClass.CallStatic("requestBannerAd", new object[2] {isTesting, extras});
    }

    // Set the name of the callback handler so the right component gets ad callbacks.
    public static void SetCallbackHandlerName(string callbackHandlerName)
    {
        AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
        pluginClass.CallStatic("setCallbackHandlerName", new object[1] {callbackHandlerName});
    }

    // Hide the banner view from the screen.
    public static void HideBannerView()
    {
        AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
        pluginClass.CallStatic("hideBannerView"); 
    }

	// Show the banner view on the screen.
	public static void ShowInterstitial() {
		AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
		pluginClass.CallStatic("showInterstitialAd");
	}

    // Show the banner view on the screen.
    public static void ShowBannerView() {
        AndroidJavaClass pluginClass = new AndroidJavaClass(PluginClassName);
        pluginClass.CallStatic("showBannerView");
    }

	public void OnInterstitialReceiveAd(string unusedMessage)
    {
		InterstitialReceivedAd();
    }

	public void OnInterstitialFailedToReceiveAd(string message)
    {
		InterstitialFailedToReceiveAd(message);
    }

	public void OnInterstitialPresentScreen(string unusedMessage)
    {
		InterstitialShowingOverlay();
    }

	public void OnInterstitialDismissScreen(string unusedMessage)
    {
		InterstitialDismissedOverlay();
    }

	public void OnInterstitialLeaveApplication(string unusedMessage)
    {
		InterstitialLeavingApplication();
    }
}

