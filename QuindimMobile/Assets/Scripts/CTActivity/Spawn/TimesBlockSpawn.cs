using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesBlockSpawn : Spawn {
  private void Start() {
    index = 0;
  }

  void Update() {
    if (GetComponent<BlocksSlot>().IsEmpty) {
      CreateNewObject("Times Block");
      index++;
    }
  }
}
