using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawLine : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler { 
  private RectTransform dotRectTransform;
  private Canvas canvas;

  private bool canDraw = false;
  private LineRenderer lineRenderer;
  private Vector2 ogDotPosition;

  private Vector2 ogBlockPosition;

  private void Start() {
    dotRectTransform = GetComponentInChildren<DotUI>().DotRectTransform;
    canvas = GetComponentInParent<Canvas>();

    ogDotPosition = dotRectTransform.anchoredPosition * dotRectTransform.lossyScale;
    lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.useWorldSpace = false;
  }

  public void OnBeginDrag(PointerEventData eventData) {
    dotRectTransform.anchoredPosition = ogDotPosition;
    lineRenderer.SetPosition(1, dotRectTransform.anchoredPosition);

    BlockUI blockUI = GetComponent<BlockUI>();
    blockUI.SetIsConnected(false);
    blockUI.SetIsConnectedTo(null);
  }

  // Makes a line between mouse position and the block while dragging
  public void OnDrag(PointerEventData eventData) {
    if (canDraw) {
      dotRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

      lineRenderer.SetPosition(0, ogDotPosition);
      lineRenderer.SetPosition(1, dotRectTransform.anchoredPosition);
    }
  }

  // Makes the line turn into a dot if not connected
  public void OnEndDrag(PointerEventData eventData) {
    ogBlockPosition = GetComponent<RectTransform>().anchoredPosition;

    dotRectTransform.anchoredPosition = ogDotPosition;
    lineRenderer.SetPosition(1, dotRectTransform.anchoredPosition);
  }

  public void SetCanDraw(bool canDraw) {
    this.canDraw = canDraw;
  }
}
