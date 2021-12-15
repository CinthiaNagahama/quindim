using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlusBlockUI : BlockWithInputUI, IBeginDragHandler {
  private BlocksSlot plusBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot")) plusBlockSpawner = b;
    }
  }

  public double Plus(double value1, double value2) {
    return value1 + value2;
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckTransform(eventData, plusBlockSpawner);
  }
}
