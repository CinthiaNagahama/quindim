using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreenHandler : MonoBehaviour {
  public Canvas winCanvas;

  public void TurnWinScreenActive(bool boolean) {
    winCanvas.gameObject.SetActive(boolean);
    var factor = Array.Find(winCanvas.GetComponentsInChildren<TextMeshProUGUI>(), tmp => tmp.gameObject.name == "Factor");
    factor.text = $"Nível {CountCTs(SceneManager.GetActiveScene().name.Substring(3, SceneManager.GetActiveScene().name.Length - 5))}/4";
  }

  private int CountCTs(string triggerCharacterName) {
    Regex re = new Regex(triggerCharacterName);
    int count = 0;

    foreach (string key in FindObjectOfType<GameMaster>().CTS.Keys) {
      if (re.IsMatch(key)) count++;
    }

    return count;
  }
}
