using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayFabLevelManager : MonoBehaviour {
  private void Start() {
    SaveCurrentLevel(SceneManager.GetActiveScene().name);
  }

  public void SaveCurrentLevel(string level) {
    var request = new UpdateUserDataRequest {
      Data = new Dictionary<string, string> {
        { "Level Name", level }
      }
    };

    PlayFabClientAPI.UpdateUserData(request, OnSuccess, OnError);
  }

  private void OnSuccess(UpdateUserDataResult result) {
    Debug.Log("Current level updated!");
  }

  private void OnError(PlayFabError error) {
    Debug.Log(error.GenerateErrorReport());
  }
}
