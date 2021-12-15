using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
  private static GameMaster instance;
  public int gamePhase = 1;
  public bool showTutorial;

  private Vector2 lastCheckpointTransform;
  public void SetLastCheckpointTransform(Vector2 newTransform) {
    lastCheckpointTransform = newTransform;
    transform.position = newTransform;
  }
  public Vector3 GetLastCheckpointTransform() {
    return lastCheckpointTransform;
  }
  
  private Dictionary<string, bool> cts = new Dictionary<string, bool>();
  public Dictionary<string, bool> CTS { set => cts = value; get => cts; }

  public string previousLevel = "Level 01";

  private void Awake() {
    if (instance == null) {
      instance = this;
      DontDestroyOnLoad(instance);
      SetLastCheckpointTransform(transform.position);
      showTutorial = true;
    } else {
      Destroy(gameObject);
      return;
    }
  }
}
