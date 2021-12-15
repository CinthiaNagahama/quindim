using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorTrigger : MonoBehaviour {
  public bool openDoor = false;
  
  [SerializeField] private GameObject door;
  [SerializeField] private Sprite pawScan;

  private void OnTriggerEnter2D(Collider2D collider) {
    if (openDoor) {
      GetComponentInChildren<SpriteRenderer>().sprite = pawScan;
      door.GetComponent<ElevatorDoor>().isOpen = true;
    }
  }
}
