using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WalkBlockUI : BlockUI, IBeginDragHandler {
  private TriangleMovements player;
  private BlocksSlot walkBlockSpawner;

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot")) walkBlockSpawner = b;
    }
  }

  public void MoveForward() {
    player = FindObjectOfType<TriangleMovements>();
    player.MoveFoward();
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckTransform(eventData, walkBlockSpawner);
  }
}
