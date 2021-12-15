using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
  public string userCurrentLevel;

  public void PlayGame() {
    FindObjectOfType<AudioManager>().Play("Click");
    FindObjectOfType<PlayfabManager>().UserCurrentLevel();
  }

  public void QuitGame() {
    FindObjectOfType<AudioManager>().Play("Click");

    Application.Quit();
  }
}
