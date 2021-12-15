using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CTManager : MonoBehaviour {
  private CTManager instance;
  private GameMaster gm;
  private Dictionary<string, bool> gmCTS;

  private void Start() {
    gm = FindObjectOfType<GameMaster>();
    gmCTS = gm.CTS;
  }

  public void StartCT(int levelNumber, string triggerCharacter) {
    gmCTS.Add(triggerCharacter + " " + levelNumber, false);
    gm.CTS = gmCTS;

    SceneManager.LoadScene("CT " + triggerCharacter + " " + levelNumber);
  }

  public void EndCT(int levelNumber, string triggerCharacter) {
    gmCTS[triggerCharacter + " " + levelNumber] = false;
    gm.CTS = gmCTS;
  }

  public int CountCTs(string triggerCharacterName) {
    Regex re = new Regex(triggerCharacterName);
    int count = 0;

    foreach (string key in gm.CTS.Keys) {
      if (re.IsMatch(key)) count++;
    }

    return count;
  }

  private void Awake() {
    if (instance == null) {
      instance = this;
      DontDestroyOnLoad(instance);
    } else {
      Destroy(gameObject);
      return;
    }
  }
}
