using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimesBlockUI : BlockWithInputUI, IBeginDragHandler {
  private BlocksSlot timesBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot (4)")) timesBlockSpawner = b;
    }
  }

  public double Times(double value1, double value2) {
    return value1 * value2;
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckPosition(eventData, timesBlockSpawner);
  }
}
