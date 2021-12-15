using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UwU : MonoBehaviour {
  public Dialogue preCTDialogue;
  public Dialogue posCTDialogue;
  public GameObject dialogueBox;

  private GameMaster gm;
  private CTManager ctManager;

  private void Start() {
    gm = FindObjectOfType<GameMaster>();
    gm.previousLevel = "Level 02";
    ctManager = FindObjectOfType<CTManager>();
  }

  // Handle collision with the player
  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.CompareTag("Player")) {
      var ctCount = ctManager.CountCTs(name);
      dialogueBox.SetActive(true);
      if (ctCount == 0) {
        gm.SetLastCheckpointTransform(transform.position);
        TriggerDialogue(preCTDialogue);
      } else if (ctCount >= 4){
        TriggerDialogue(posCTDialogue);
      }
    }
  }

  // Handle dialogue
  private void TriggerDialogue(Dialogue dialogue) {
    FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogueBox);
  }
}
