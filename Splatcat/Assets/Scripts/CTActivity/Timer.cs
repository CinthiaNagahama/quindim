using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
  [System.NonSerialized] public float time = 0;
  [System.NonSerialized] public bool timerIsRunning = false;

  private void Start() {
    timerIsRunning = true;
  }

  private void Update() {
    if (timerIsRunning) {
      time += Time.deltaTime;
      UpdateTimeSpentOnLevel();
    }
  }

  private void UpdateTimeSpentOnLevel() {
    float min = Mathf.FloorToInt(time / 60);
    float sec = Mathf.FloorToInt(time % 60);
    float milisec = (time % 1) * 1000;

    FindObjectOfType<DataManager>().timeSpentOnLevel = string.Format("{0:00}:{1:00}:{2:000}", min, sec, milisec);
  }
}
