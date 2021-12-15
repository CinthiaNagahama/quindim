using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class InternetConnectionChecker : MonoBehaviour {
  // TODO

  private readonly float screenWidth_half = Screen.width / 2;
  private readonly float screenWidth_quarter = Screen.width / 4;
  private readonly float screenHeight_fivePercent = (float)(Screen.width * 0.05);

  IEnumerator CheckInternetConnection(Action<bool> action) {
    UnityWebRequest request = new UnityWebRequest("http://google.com");
    yield return request.SendWebRequest();
    if (request.error != null) {
      action(false);
    } else {
      action(true);
    }
  }

  void Start() {
    //StartCoroutine(CheckInternetConnection((isConnected) => {
    //  Debug.Log(isConnected);
    //}));
  }

  //private void OnGUI() {
  //  GUI.Box(
  //    new Rect(screenWidth_half - screenWidth_quarter, 5, screenWidth_half, screenHeight_fivePercent), 
  //    new GUIContent("Parece que algo errado aconteceu.\nTente checar sua conexão com a internet, por favor")
  //  );

  //  GUI.enabled = false;
  //}
}

