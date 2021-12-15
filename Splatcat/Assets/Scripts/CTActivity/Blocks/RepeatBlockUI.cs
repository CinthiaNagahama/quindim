using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RepeatBlockUI : BlockUI, IBeginDragHandler {
  private BlocksSlot repeatBlockSpawner;
  private string inputValue = "0";

  public string InputValue { get => inputValue; set => inputValue = value; }

  private void Start() {
    var blocksSlots = GetComponentInParent<Canvas>().GetComponentsInChildren<BlocksSlot>();

    foreach (BlocksSlot b in blocksSlots) {
      if (b.name.Equals("Blocks Slot (2)")) repeatBlockSpawner = b;
    }
  }

  public void OnBeginDrag(PointerEventData eventData) {
    CheckPosition(eventData, repeatBlockSpawner);
  }
}
