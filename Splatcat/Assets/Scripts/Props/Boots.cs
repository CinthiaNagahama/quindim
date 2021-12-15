using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Boots : MonoBehaviour {
  public Dialogue preCTDialogue;
  public Dialogue posCTDialogue;
  public GameObject dialogueBox;

  private GameMaster gm;
  private CTManager ctManager;

  [SerializeField] private GameObject handScan;

  private void Start() {
    gm = FindObjectOfType<GameMaster>();
    ctManager = FindObjectOfType<CTManager>();
  }

  // Handle collision with the player
  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.CompareTag("Player")) {
      dialogueBox.SetActive(true);
      var ctCount = ctManager.CountCTs(name);
      if (ctCount == 0) {
        gm.SetLastCheckpointTransform(transform.position - new Vector3(2f, 0f, 0f));
        TriggerDialogue(preCTDialogue);
      } else if(ctCount >= 4){
        TriggerDialogue(posCTDialogue);
        handScan.GetComponent<ElevatorDoorTrigger>().openDoor = true;
      }
    }
  }

  // Handle dialogue
  private void TriggerDialogue(Dialogue dialogue) {
    FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogueBox);
  }
}
