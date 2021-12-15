using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class PlayFabCTManager : MonoBehaviour {  
  public void SendPlayerData() {
    Data data = GetComponent<DataManager>().ReturnData();
    
    var request = new UpdateUserDataRequest {
      Data = new Dictionary<string, string> {
        {data.levelName, JsonConvert.SerializeObject(data)}
      }
    };

    PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
  }

  private void OnDataSend(UpdateUserDataResult result) {
    Debug.Log("User data sent successfully!!!");
  }

  private void OnError(PlayFabError error) {
    Debug.Log(error.GenerateErrorReport());
  }
}
