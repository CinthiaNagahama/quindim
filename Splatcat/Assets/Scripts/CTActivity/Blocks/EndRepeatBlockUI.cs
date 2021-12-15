using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndRepeatBlockUI : BlockUI, IBeginDragHandler {
  private BlocksSlot endRepeatBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot (3)")) endRepeatBlockSpawner = b;
    }
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckPosition(eventData, endRepeatBlockSpawner);
  }
}
