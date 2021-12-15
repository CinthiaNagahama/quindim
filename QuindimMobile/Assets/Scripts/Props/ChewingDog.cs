using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingDog : MonoBehaviour {
  public Dialogue preCTDialogue;
  public Dialogue posCTDialogue;
  public GameObject dialogueBox;

  private GameMaster gm;
  private CTManager ctManager;

  [SerializeField] private Collider2D doorCollider;
  [SerializeField] private GameObject handScan;
  [SerializeField] private Sprite pawScan;

  [SerializeField] private GeneralDirector director;

  private void Start() {
    gm = FindObjectOfType<GameMaster>();
    ctManager = FindObjectOfType<CTManager>();
  }

  // Handle collision with the player
  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.CompareTag("Player")) {
      dialogueBox.SetActive(true);
      Debug.Log(name);
      var ctCount = ctManager.CountCTs(name);
      if (ctCount == 0) {
        gm.SetLastCheckpointTransform(transform.position + new Vector3(2f, 0f, 0f));
        TriggerDialogue(preCTDialogue);
      } else if(ctCount >= 4) {
        TriggerDialogue(posCTDialogue);
        if(gm.gamePhase == 1) {
          director.Play();
          handScan.GetComponentInChildren<SpriteRenderer>().sprite = pawScan;
          doorCollider.isTrigger = true;
          gm.gamePhase++;
        }
      }
    }
  }

  // Handle dialogue
  private void TriggerDialogue(Dialogue dialogue) {
    FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogueBox);
  }
}
