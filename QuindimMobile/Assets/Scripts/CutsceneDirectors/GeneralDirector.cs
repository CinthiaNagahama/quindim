using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GeneralDirector : MonoBehaviour {
  private PlayableDirector director;

  private void Awake() {
    director = GetComponent<PlayableDirector>();
  }

  public void Play() {
    director.Play(director.playableAsset);
  }
}
