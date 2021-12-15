using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBlockSpawn : Spawn {
  private void Start() {
    index = 0;
  }

  void Update() {
    if (GetComponent<BlocksSlot>().IsEmpty) {
      CreateNewObject("Turn Block");
      index++;
    }
  }
}
