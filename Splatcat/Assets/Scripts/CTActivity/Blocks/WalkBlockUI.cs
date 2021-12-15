using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WalkBlockUI : BlockUI, IBeginDragHandler {
  private GameObject player;
  private BlocksSlot walkBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot")) walkBlockSpawner = b;
    }
  }

  public void MoveForward() {
    FindObjectOfType<TriangleMovements>().MoveFoward();
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckPosition(eventData, walkBlockSpawner);
  }
}
