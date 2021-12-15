using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBlockSpawn : Spawn {
  private void Start() {
    index = 0;
  }

  void Update(){
    if (GetComponent<BlocksSlot>().IsEmpty) {
      CreateNewObject("Walk Block");
      index++;
    }
  }
}
