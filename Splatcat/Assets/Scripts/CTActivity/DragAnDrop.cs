using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Drag and Drop System
public class DragAnDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

  private Canvas canvas;
  private RectTransform leftSeparatorRectTransform;
  private CanvasGroup canvasGroup;
  
  private bool canDrag = true;
  private RectTransform rectTransform;
  private PointerEventData lastPointerData;
  private Vector2 originalPosition;

  private void Start() {
    canvas = GetComponentInParent<Canvas>();
    leftSeparatorRectTransform = canvas.GetComponentInChildren<LeftSeparatorUI>().LeftSeparatorRectTransform;
    canvasGroup = GetComponentInChildren<CanvasGroup>();

    rectTransform = GetComponent<RectTransform>();
    originalPosition = rectTransform.anchoredPosition;
  }

  // Makes the object not interectable while dragging
  public void OnBeginDrag(PointerEventData eventData) {
    if (canDrag) {
      lastPointerData = eventData;
      canvasGroup.blocksRaycasts = false;

      BlockUI blockUI = GetComponent<BlockUI>();
      if (blockUI.GetIsConnectedBy() != null) {
        blockUI.GetIsConnectedBy().gameObject.GetComponent<LineRenderer>().SetPosition(
          1,
          Vector3.zero);
        blockUI.SetIsConnectedBy(null);
      }
    }
  }

  // Synchronizes the object moviment with the mouse moviment
  public void OnDrag(PointerEventData eventData) {
    if (canDrag) {
      if (rectTransform.position.x < leftSeparatorRectTransform.position.x) {
        FindObjectOfType<AudioManager>().Play("Trash");
        Destroy(eventData.pointerDrag);
        CancelDrag();
        OnEndDrag(lastPointerData);
      } else {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
      }
    }
  }

  // Makes the object interable after dragging
  public void OnEndDrag(PointerEventData eventData) {
    lastPointerData = null;
    canvasGroup.blocksRaycasts = true;
  }

  public void CancelDrag() {
    if(lastPointerData != null) {
      lastPointerData.pointerDrag = null;
      rectTransform.anchoredPosition = originalPosition;
    }
  }

  public bool CanDrag { get => canDrag; set => canDrag = value; }
}
