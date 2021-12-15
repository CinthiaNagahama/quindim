using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashCan : MonoBehaviour, IDropHandler {
  [SerializeField] private ConnectButton connectButton;
  private bool isConnectEnabled;

  private void Update() {
    isConnectEnabled = connectButton.GetIsConnectedEnabled();
  }

  public void OnDrop(PointerEventData eventData) {
    if (!isConnectEnabled) {
      FindObjectOfType<AudioManager>().Play("Trash");
      Destroy(eventData.pointerDrag);
    }
  }
}
