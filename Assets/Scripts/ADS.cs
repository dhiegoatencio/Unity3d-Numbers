using UnityEngine;
using System.Collections;
using StartApp;

public class ADS : MonoBehaviour {

	private static bool isTopActive = false;
	private static bool isBottomActive = false;

	private static float bottomDelay = 5f;
	private static float topDelay = 5f;

	private static float bottomTime = 0f;
	private static float topTime = 0f;

	public static void showTop() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (!isTopActive) {
			StartAppWrapper.addBanner (
				StartAppWrapper.BannerType.STANDARD,
				StartAppWrapper.BannerPosition.TOP);

			isTopActive = true;
		}
		#endif
	}

	public static void showBottom() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (!isBottomActive) {
			StartAppWrapper.addBanner (
				StartAppWrapper.BannerType.STANDARD,
				StartAppWrapper.BannerPosition.BOTTOM);

			isBottomActive = true;
		}
		#endif
	}

	public static void hideTop() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (isTopActive) {
			StartAppWrapper.removeBanner (StartAppWrapper.BannerPosition.TOP);
			isTopActive = false;
			topTime = 0;
		}
		#endif
	}

	public static void hideBottom() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (isBottomActive) {
			StartAppWrapper.removeBanner (StartAppWrapper.BannerPosition.BOTTOM);
			isBottomActive = false;
			bottomTime = 0;
		}
		#endif
	}

	public static void hideAll() {
		hideBottom ();
		hideTop ();
	}

	private static void topBehavior() {
		if (isTopActive) {
			topTime += Time.deltaTime;
			if (topTime >= topDelay) {
				hideTop();
				showTop();
			}
		}
	}

	private static void bottomBehavior() {
		if (isBottomActive) {
			bottomTime += Time.deltaTime;
			if (bottomTime >= bottomDelay) {
				hideBottom();
				showBottom();
			}
		}
	}

	void Update() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		topBehavior ();
		bottomBehavior ();
		#endif
	}
}