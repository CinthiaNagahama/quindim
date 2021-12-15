using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotUI : MonoBehaviour {
  private RectTransform dotRectTransform;

  private void Awake() {
    dotRectTransform = GetComponent<RectTransform>();
  }
  public RectTransform DotRectTransform => dotRectTransform;
}
