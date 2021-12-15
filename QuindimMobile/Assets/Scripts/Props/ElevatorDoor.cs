using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ElevatorDoor : MonoBehaviour {
  public bool isOpen = false;

  private GameMaster gm;

  private void Awake() {
    gm = FindObjectOfType<GameMaster>();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (isOpen) {
      gm.transform.position = Vector2.zero;
      gm.SetLastCheckpointTransform(Vector2.zero);
      SceneManager.LoadScene("Level 02");
    }
  }
}
