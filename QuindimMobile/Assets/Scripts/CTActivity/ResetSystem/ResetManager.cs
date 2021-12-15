using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour {
  private ResetObject[] resetScripts;

  public void OnReset() {
    FindObjectOfType<DataManager>().tries += 1;

    resetScripts = FindObjectsOfType<ResetObject>();
    foreach(ResetObject r in resetScripts) {
      r.Reset();
    }
  }

  public void OnResetButton() {
    FindObjectOfType<DataManager>().tries += 1;

    resetScripts = FindObjectsOfType<ResetObject>();
    foreach (ResetObject r in resetScripts) {
      r.Reset();
    }

    BlockUI[] blocks = FindObjectsOfType<BlockUI>();

    foreach (BlockUI b in blocks) {
      if (!b.name.Equals("Beginning") && !b.name.Equals("End")) {
        Destroy(b.gameObject);
      }
    }

    BlocksSlot[] blockSlots = FindObjectsOfType<BlocksSlot>();
    foreach(BlocksSlot bs in blockSlots) {
      bs.IsEmpty = true;
    }
  }
}
