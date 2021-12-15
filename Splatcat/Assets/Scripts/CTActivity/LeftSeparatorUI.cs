using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSeparatorUI : MonoBehaviour
{
  private RectTransform leftSeparatorRectTransform;

  private void Awake() {
    leftSeparatorRectTransform = GetComponent<RectTransform>();
  }
  public RectTransform LeftSeparatorRectTransform => leftSeparatorRectTransform;
}
