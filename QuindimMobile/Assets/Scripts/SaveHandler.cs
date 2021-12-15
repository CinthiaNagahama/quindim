using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour {
  private void Awake() {
    SaveSystem.Init();
  }

  // Save in JSON file
  public void SavePosition() {
    SaveObject saveObject = new SaveObject {
      playerPosition = transform.position,
    };

    string jsonString = JsonUtility.ToJson(saveObject);
    SaveSystem.Save(jsonString);

    Debug.Log("Saved position: " + transform.position);
  }

  // Load from JSON file
  public void LoadPosition() {
    string saveString = SaveSystem.Load();

    if(saveString != null) {
      SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(saveString);

      transform.position = loadedSaveObject.playerPosition;
      Debug.Log("Loaded position: " + transform.position.ToString());
    } else {
      Debug.Log("No data available");
    }
    
  }

  private class SaveObject {
    public Vector3 playerPosition;
  }
}
