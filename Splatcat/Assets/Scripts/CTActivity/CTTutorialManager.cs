using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTTutorialManager : MonoBehaviour {
  [SerializeField] private GameObject[] popUps;
  private int popUpIndex = 0;

  public BlocksSlot spawn;
  [System.NonSerialized] public GameObject walkBlock;
  public GameObject endBlock;
  public CTTutorialHelper connectButton;
  public CTTutorialHelper runButton;
  public CTTutorialHelper pauseButton;
  public CTTutorialHelper blocksButton;

  private float timeRemaining = 15;

  private void Update() {
    if (spawn.beginTutorial) {
      for (int i = 0; i < popUps.Length; i++) {
        if (i == popUpIndex) {
          popUps[i].SetActive(true);
        } else {
          popUps[i].SetActive(false);
        }
      }

      switch(popUpIndex){
        case 0: {
          //Debug.Log(walkBlock);
          var rectTransform = walkBlock.transform as RectTransform;
          var spawnerRectTransform = spawn.slotTransform;

          if (rectTransform.position.x != spawnerRectTransform.position.x || rectTransform.position.y != spawnerRectTransform.position.y) {
            popUpIndex++;
          }
          break;
        }
        case 1: {
          //Debug.Log(connectButton);
          if (connectButton.objName.Equals("Connect Button")) {
            popUpIndex++;
          }
          break;
        }
        case 2: {
          if (walkBlock.GetComponent<BlockUI>().GetIsConnectedBy() != null || 
              endBlock.GetComponent<BlockUI>().GetIsConnectedBy() != null) { 
            popUpIndex++;
          }
          break;
        }
        case 3: {
          //Debug.Log(runButton);

          if (runButton.objName.Equals("Run Button")) {
            popUpIndex++;
          }
          break;
        }
        case 4: {
          //Debug.Log(pauseButton);

          if (pauseButton.objName.Equals("PauseButton")) {
            popUpIndex++;
          }
          break;
        }
        case 5: {
          //Debug.Log(blocksButton);

          if (blocksButton.objName.Equals("BlocksHintsButton")) {
            popUpIndex++;
          }
          break;
        }
        case 6: {
          //Debug.Log(timeRemaining);
          if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
          } else {
            timeRemaining = 0;
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            spawn.beginTutorial = false;
          }
          break;
        }
        default: {
          Debug.Log("Destroy tutorial manager");
          Destroy(this);
          break;
        }
      }
    }
  }
}
