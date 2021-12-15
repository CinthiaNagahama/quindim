using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DivisionBlockUI : BlockWithInputUI, IBeginDragHandler {
  private BlocksSlot divisionBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot (5)")) divisionBlockSpawner = b;
    }
  }

  public double Division(double value1, double value2) {
    return value1 / value2;
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckPosition(eventData, divisionBlockSpawner);
  }
}
