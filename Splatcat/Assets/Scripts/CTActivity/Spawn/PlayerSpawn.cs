using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : Spawn {
  private void Start() {
    index = 0;
  }

  public override void CreateNewObject(string name) {
    var player = Instantiate(prefab);
    player.GetComponent<Transform>().position = transform.position;
    player.transform.localScale = new Vector3(.6f, .6f, 1);
    player.name = $"{name} {index}";

    index++;
  }
}
