using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorUwU : MonoBehaviour {
  private static DirectorUwU instance;

  private PlayableDirector director;

  private int cutsceneCount = 0;

  private void Awake() {
    if (instance == null) {
      instance = this;
      DontDestroyOnLoad(instance);
    } else {
      Destroy(gameObject);
      return;
    }

    director = GetComponent<PlayableDirector>();

    if(cutsceneCount == 0) {
      director.Play(director.playableAsset);
      cutsceneCount++;
    }
  }
}
