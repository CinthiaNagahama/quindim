using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {
  public GameObject mainMenuScreen;
  public GameObject helpScreen;
  public GameObject resetPasswordScreen;
  public GameObject loginScreen;

  public void GoToTutorial() {
    FindObjectOfType<AudioManager>().Play("Click");
    mainMenuScreen.SetActive(false);
    helpScreen.SetActive(true);
  }

  public void BackToMainMenu() {
    FindObjectOfType<AudioManager>().Play("Click");
    mainMenuScreen.SetActive(true);
    helpScreen.SetActive(false);
  }

  public void BackToLogin() {
    FindObjectOfType<AudioManager>().Play("Click");
    loginScreen.SetActive(true);
    resetPasswordScreen.SetActive(false);
  }

  public void GoToForgotMyPassword() {
    FindObjectOfType<AudioManager>().Play("Click");
    resetPasswordScreen.SetActive(true);
    loginScreen.SetActive(false);
  }
}
