using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {
  public string name;

  public AudioClip audioClip;

  [Range(0f, 1f)]
  public float volume;
  
  [Range(0.1f, 3f)]
  public float pitch;

  [Range(-1f, 1f)]
  public float panStereo;

  public bool loop;

  [HideInInspector]
  public AudioSource audioSource;

  public void SetAudioSourceSettings() {
    audioSource.clip = audioClip;
    audioSource.volume = volume;
    audioSource.pitch = pitch;
    audioSource.loop = loop;
    audioSource.panStereo = panStereo;
  }
}
