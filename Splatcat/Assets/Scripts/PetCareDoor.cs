using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCareDoor : MonoBehaviour {
  [SerializeField] private GameObject doorGlass;
  private void Start() {
    if(FindObjectOfType<GameMaster>().gamePhase > 1) {
      GetComponent<Collider2D>().enabled = false;

      doorGlass.SetActive(true);
    }
  }
}
