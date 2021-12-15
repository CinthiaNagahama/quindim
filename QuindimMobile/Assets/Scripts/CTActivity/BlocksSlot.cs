using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlocksSlot : MonoBehaviour, IDropHandler{
  [SerializeField] private ConnectButton connectButton;
  private bool isConnectEnabled;
  private bool isEmpty = true;
  [System.NonSerialized] public RectTransform slotTransform;
  [System.NonSerialized] public bool beginTutorial = false;

  private void Awake() {
    slotTransform = GetComponent<RectTransform>();
  }

  private void Update() {
    isConnectEnabled = connectButton.GetIsConnectedEnabled();
  }

  public void OnDrop(PointerEventData eventData) {
    if(!isConnectEnabled) {
      Destroy(eventData.pointerDrag);
    }
  }

  public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
}
