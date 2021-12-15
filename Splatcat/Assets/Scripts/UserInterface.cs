using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {
  [SerializeField] private GameObject pauseMenu;
  [SerializeField] private GameObject blocksTutorialMenu;

  [SerializeField] private Image muteButton;
  [SerializeField] private Sprite muteButtonImageOn;
  [SerializeField] private Sprite muteButtonImageOff;

  private AudioManager audioManager;

  private void Awake() {
    audioManager = FindObjectOfType<AudioManager>();
    if (!PlayerPrefs.HasKey("playingAudio")) {
      PlayerPrefs.SetInt("playingAudio", 1);
      PlayerPrefs.Save();
    }
  }

  private void Start() {
    if(PlayerPrefs.GetInt("playingAudio") == 1) {
      muteButton.sprite = muteButtonImageOn;
    } else {
      muteButton.sprite = muteButtonImageOff;
    }
  }

  public void OnPause() {
    FindObjectOfType<Timer>().timerIsRunning = false;
    pauseMenu.SetActive(true);
  }

  public void OnPauseLevel() {
    pauseMenu.SetActive(true);
  }

  public void OnMute() {
    if (PlayerPrefs.GetInt("playingAudio") == 1) {
      audioManager.StopAll();
      PlayerPrefs.SetInt("playingAudio", 0);
      muteButton.sprite = muteButtonImageOff;
    } else {
      audioManager.UnmuteAll();
      PlayerPrefs.SetInt("playingAudio", 1);
      muteButton.sprite = muteButtonImageOn;
    }
    PlayerPrefs.Save();
  }

  public void OnReset() {
    pauseMenu.SetActive(false);
    FindObjectOfType<ResetManager>().OnResetButton();
    FindObjectOfType<Timer>().timerIsRunning = true;
  }

  public void OnResume() {
    pauseMenu.SetActive(false);
    FindObjectOfType<Timer>().timerIsRunning = true;
  }

  public void OnResumeLevel() {
    pauseMenu.SetActive(false);
  }

  public void GoToMenu() {
    audioManager.Stop("Theme");
    audioManager.Play("MenuTheme");
    SceneManager.LoadScene("Menu");
  }

  public void OnShowBlocks() {
    blocksTutorialMenu.SetActive(true);
  }

  public void OnHideBlocks() {
    blocksTutorialMenu.SetActive(false);
  }
}
