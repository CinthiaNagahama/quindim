using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnBlockUI : BlockUI, IBeginDragHandler {
  private GameObject player;
  private BlocksSlot turnBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot (1)")) turnBlockSpawner = b;
    }
  }

  public void TurnRight() {
    FindObjectOfType<TriangleMovements>().TurnRight();
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckTransform(eventData, turnBlockSpawner);
  }
}
