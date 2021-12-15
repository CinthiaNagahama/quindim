using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : ResetObject {
  public override void Reset() {
    var playerSpawner = FindObjectOfType<PlayerSpawn>();
    playerSpawner.CreateNewObject("Player");
  }
}
