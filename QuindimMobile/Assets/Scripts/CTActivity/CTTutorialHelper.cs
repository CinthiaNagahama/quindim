using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CTTutorialHelper : MonoBehaviour, IPointerClickHandler {
  [System.NonSerialized] public string objName = "";

  public void OnPointerClick(PointerEventData eventData) {
    objName = eventData.pointerClick.name;
  }
}
