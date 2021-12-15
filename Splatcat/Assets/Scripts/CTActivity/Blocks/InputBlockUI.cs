using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputBlockUI : BlockUI, IBeginDragHandler {
  private GameObject player;
  private BlocksSlot inputBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot")) inputBlockSpawner = b;
    }
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckPosition(eventData, inputBlockSpawner);
  }
}
