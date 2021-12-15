using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
  public Sound[] sounds;

  private static AudioManager instance;

  private void Awake() {
    if(instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
      return;
    }
    DontDestroyOnLoad(gameObject);

    foreach(Sound sound in sounds) {
      sound.audioSource = gameObject.AddComponent<AudioSource>();
      sound.SetAudioSourceSettings();
    }
  }

  private void Start() {
    if (PlayerPrefs.GetInt("playingAudio") == 1) {
      Play("MenuTheme");
    }
  }

  public void Play(string name) {
    Sound sound = Array.Find(sounds, sound => sound.name == name);
    if(sound == null) {
      Debug.LogWarning(name + " not found.");
      return;
    }
    sound.audioSource.Play();
  }

  public void UnmuteAll() {
    foreach (Sound sound in sounds) {
      sound.audioSource.mute = false;
      if (sound.name.Equals("Theme")) sound.audioSource.Play();
    }
  }

  public void Stop(string name) {
    Sound sound = Array.Find(sounds, sound => sound.name == name);
    if (sound == null) {
      Debug.LogWarning(name + " not found.");
      return;
    }
    sound.audioSource.Stop();
    sound.audioSource.mute = true;
  }

  public void StopAll() {
    foreach(Sound sound in sounds) {
      sound.audioSource.Stop();
      sound.audioSource.mute = true;
    }
  }
}
