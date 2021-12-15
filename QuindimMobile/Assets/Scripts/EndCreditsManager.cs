using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCreditsManager : MonoBehaviour {
  public GameObject exit;

  public void Sair() {
    exit.SetActive(true);
    StartCoroutine("Delay");
  }

  IEnumerator Delay() {
    var pressed = false;
    while (!pressed) {
      if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) {
        pressed = true;
      }
      yield return null;
    }
    Application.Quit();
  }
}
