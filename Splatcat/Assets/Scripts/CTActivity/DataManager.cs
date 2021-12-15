using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data {
  public string levelName;
  public int tries;
  public int forgotEndRepeat;
  public List<string> finalCode;
  public string timeSpentOnLevel;

  public Data(string levelName, int tries, int forgotEndRepeat, List<string> finalCode, string timeSpentOnLevel) {
    this.levelName = levelName;
    this.tries = tries;
    this.forgotEndRepeat = forgotEndRepeat;
    this.finalCode = finalCode;
    this.timeSpentOnLevel = timeSpentOnLevel;
  }
}

public class DataManager : MonoBehaviour {
  [System.NonSerialized] public int tries = 1;
  [System.NonSerialized] public int forgotEndRepeat = 0;
  [System.NonSerialized] public string timeSpentOnLevel;
  private List<string> finalCode = new List<string>();

  public Data ReturnData() {
    return new Data(SceneManager.GetActiveScene().name, tries, forgotEndRepeat, GetFinalCode(), timeSpentOnLevel);
  }

  public List<string> GetFinalCode() {
    List<BlockUI> blocks = new List<BlockUI>(FindObjectsOfType<BlockUI>());
    List<BlockUI> connectedBlocks = new List<BlockUI>();

    // Order blocks by connection
    BlockUI newBlock = blocks.Find(block => block.CompareTag("Beginning Block"));
    while (newBlock != null) {
      connectedBlocks.Add(newBlock);
      newBlock = blocks.Find(block => block == connectedBlocks[connectedBlocks.IndexOf(newBlock)].GetIsConnectedTo());
    }

    foreach (BlockUI b in connectedBlocks) {
      if(b.TryGetComponent<BlockWithInputUI>(out BlockWithInputUI bwi)) {
        finalCode.Add(bwi.name + " | value1 = " + bwi.InputValue1 + " value2 = " + bwi.InputValue2 + " |");
      } else if (b.CompareTag("Repeat Block")){
        finalCode.Add(b.name + " | value = " + b.GetComponent<RepeatBlockUI>().InputValue);
      } else {
        finalCode.Add(b.name);
      }
    }

    return finalCode;
  }
}
