using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DotOver : MonoBehaviour, IDropHandler {
  private Canvas canvas;
  private AudioManager audioManager;

  private BlockUI[] toBeConnectedBlocks;

  private ConnectButton connectButton;
  private bool isConnectEnabled;

  private void Start() {
    audioManager = FindObjectOfType<AudioManager>();
    canvas = GetComponentInParent<Canvas>();
    connectButton = canvas.GetComponentInChildren<ConnectButton>();
  }

  private void Update() {
    isConnectEnabled = connectButton.GetIsConnectedEnabled();
  }

  // Keeps the line if dot is over a block
  public void OnDrop(PointerEventData eventData) {
    if (isConnectEnabled) {
      toBeConnectedBlocks = canvas.GetComponentsInChildren<BlockUI>();
      TestForConnection(eventData.pointerDrag.name, eventData);
    }
    eventData.pointerDrag = null;
  }

  private void TestForConnection(string name, PointerEventData eventData) {
    foreach (BlockUI b in toBeConnectedBlocks) {
      if (b.name.Equals(name) && !b.IsConnected()) {
        HandleConnection(eventData);
        break;
      }
    }
  }

  private void HandleConnection(PointerEventData eventData) {
    BlockUI block = GetComponent<BlockUI>();

    eventData.pointerDrag.GetComponent<BlockUI>().SetIsConnected(true);
    eventData.pointerDrag.GetComponent<BlockUI>().SetIsConnectedTo(block);
    
    block.SetIsConnectedBy(eventData.pointerDrag.GetComponent<BlockUI>());

    audioManager.Play("Connect");
  }
}
