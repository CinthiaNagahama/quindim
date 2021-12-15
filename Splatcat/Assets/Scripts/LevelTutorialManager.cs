using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTutorialManager : MonoBehaviour {
  [SerializeField] private GameObject[] popUps;
  private int popUpIndex = 0;
  private GameMaster gm;

  private void Start() {
    gm = FindObjectOfType<GameMaster>();
  }

  private void Update() {
    if (gm.showTutorial) {
      for (int i = 0; i < popUps.Length; i++) {
        if(i == popUpIndex) {
          popUps[i].SetActive(true);
        } else {
          popUps[i].SetActive(false);
        }
      }  
    
      if(popUpIndex == 0) {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
          popUpIndex++;
        }
      } else if(popUpIndex == 1) {
        if (Input.GetKeyDown(KeyCode.Space)) {
          popUps[popUpIndex].SetActive(false);
          popUpIndex++;
          gm.showTutorial = false;
        }
      }
    }
  }
}
