using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockUI : MonoBehaviour {
  private string blockTag;
  private bool isConnected;
  private BlockUI isConnectedTo;
  private BlockUI isConnectedBy;

  private void Awake() {
    blockTag = tag;
    isConnected = false;
  }

  public void SetIsConnected(bool isConnected) {
    this.isConnected = isConnected;
  }
  public bool IsConnected() {
    return isConnected;
  }

  public string GetBlockTag() {
    return blockTag;
  }

  public void SetIsConnectedTo(BlockUI isConnectedTo) {
    this.isConnectedTo = isConnectedTo;
  }

  public BlockUI GetIsConnectedTo() {
    return isConnectedTo;
  }

  public void SetIsConnectedBy(BlockUI isConnectedBy) {
    this.isConnectedBy = isConnectedBy;
  }

  public BlockUI GetIsConnectedBy() {
    return isConnectedBy;
  }

  public void CheckTransform(PointerEventData eventData, BlocksSlot spawn) {
    var rectTransform = eventData.pointerDrag.transform as RectTransform;
    var spawnerRectTransform = spawn.slotTransform;

    if (rectTransform.position.x == spawnerRectTransform.position.x && rectTransform.position.y == spawnerRectTransform.position.y) {
       spawn.IsEmpty = true;
    }
  }
}
